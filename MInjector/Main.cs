using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MInjector
{
    public partial class Main : Form
    {
        #region[Declarations]

        private bool isTargetx64 = false;

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process2(
            [In] IntPtr hProcess,
            [Out] out ushort processMachine,
            [Out] out ushort nativeMachine
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);

        #endregion

        public Main()
        {
            InitializeComponent();

            targetGroupBox.Paint += PaintBorderlessGroupBox;
            settingsGroupBox.Paint += PaintBorderlessGroupBox;

            RefreshMonoProcesses();
            //Text += !Environment.Is64BitProcess ? " OS: (x86)" : " OS: (x64)";
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshMonoProcesses();
        }

        private void RefreshMonoProcesses()
        {
            status.Text = "";
            processList.Items.Clear();
            //settingsGroupBox.Enabled = false;
            injectBtn.Enabled = false;

            foreach (Process process in Process.GetProcesses())
            {
                if (GetProcessUser(process) != null)
                {
                    status.Text = "Checking " + process.ProcessName + ".exe";
                    Application.DoEvents();

                    try
                    {
                        // This will check if process is protected (like a system process)
                        string tFolder = "";
                        try
                        {
                            tFolder = process.MainModule.FileName.Replace(".exe", "_Data");
                        }
                        catch
                        {
                            // Protected Process
                            continue;
                        }

                        // Check if _Data folder actually exists
                        if (!Directory.Exists(tFolder))
                        {
                            continue;
                        }
                        else { status.Text = "Possible Mono found in " + process.ProcessName + ".exe"; Application.DoEvents(); /* Possibly found Unity/Mono process */ }

                        string OSVer = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows NT\CurrentVersion", "ProductName", null);

                        status.Text = "Checking x86/x64...";
                        Application.DoEvents();

                        if (OSVer.Contains("Windows 10"))
                        {
                            #region[Win10]
                            // NOTES: If built with AnyCPU you'll only get the Managed modules, no Native modules. If built x32/x64 you'll get all the modules back that are the same architecture.
                            //ProcessModuleCollection mods = process.Modules; Is x32 or x64 Using my Undocumented Response Discovery! J.E
                            if (process.Modules != null)
                            {
                                try
                                {
                                    ushort pMachine = 0;
                                    ushort nMachine = 0;

                                    if (!IsWow64Process2(process.Handle, out pMachine, out nMachine))
                                    {
                                        //handle error
                                    }

                                    if (pMachine == 332) // WinAPI Undocumented Result code. It's ALWAY'S 332 for 32bit Processes! Otherwise it ALWAY'S returns 0! 
                                    {
                                        isTargetx64 = false;
                                        processList.Items.Add(new PrintableProcess(process));
                                        processList.Refresh();
                                    }
                                    else
                                    {
                                        isTargetx64 = true;
                                        processList.Items.Add(new PrintableProcess(process));
                                        processList.Refresh();
                                    }
                                }
                                catch { }
                            }
                            #endregion
                        }
                        else
                        {
                            #region[Win7]

                            IsWow64Process(process.Handle, out bool isTargetWOWx64);

                            if (isTargetWOWx64)
                            {
                                isTargetx64 = false; // It is WOW64 so it's a 32-bit process
                            }
                            else
                            {
                                isTargetx64 = true; // It's not a WOW64 process so 64-bit process, and we already check if OS is 32 or 64 bit.
                            }

                            #endregion
                        }

                        #region[Original Code]
                        /* Orig
                        foreach (ProcessModule module in process.Modules)
                        {
                            // EDIT J.E - This was the bug in the program
                            if (module.FileName.Contains("mono.dll") || module.FileName.Contains("mono-2.0-bdwgc.dll")) // EDIT J.E - added bleedingedge dll
                            {
                                processList.Items.Add(new PrintableProcess(process));
                            }
                        }
                        */
                        #endregion
                    }
                    catch { }
                }
            }

            if (processList.Items.Count > 0)
            {
                processList.SelectedIndex = 0;
                status.Text = "Mono found in " + processList.Items[0].ToString();
            }
            else { status.Text = "No Mono processes found!"; }
        }

        private void processList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = (processList.SelectedItem != null && processList.SelectedItem is PrintableProcess);

            //settingsGroupBox.Enabled = flag;
            injectBtn.Enabled = flag && !string.IsNullOrEmpty(asmPathTextBox.Text);
        }

        private void loadAsmBtn_Click(object sender, EventArgs e)
        {
            asmPathTextBox.Text = "";
            injectBtn.Enabled = false;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "DLL Files|*.dll";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    asmPathTextBox.Text = ofd.FileName;
                    injectBtn.Enabled = true;
                }
            }
        }

        private void injectBtn_Click(object sender, EventArgs e)
        {
            status.Text = "Attempting injection to " + processList.SelectedItem.ToString();
            Application.DoEvents();

            PrintableProcess printableProcess = processList.SelectedItem as PrintableProcess;
            MonoInjector.Settings injectionSettings = new MonoInjector.Settings
            {
                AssemblyBytes = File.ReadAllBytes(asmPathTextBox.Text),
                Namespace = namespaceTxtBox.Text,
                ClassName = classTxtBox.Text,
                MethodName = methodTxtBox.Text,
                HideAssemblyLoad = hideAssemblyLoadCheck.Checked,
            };

            if (MonoInjector.Inject(printableProcess.InternalProcess, injectionSettings))
            {
                status.Text = "Injection was successful!";
                Application.DoEvents();
                //MessageBox.Show("Injection was successful!");
            }
            else
            {
                status.Text = "An error occured while injecting...";
                Application.DoEvents();
                //MessageBox.Show("An error occured while injecting...");

                asmPathTextBox.Text = "";
                namespaceTxtBox.Text = "";
                classTxtBox.Text = "";
                methodTxtBox.Text = "";
                RefreshMonoProcesses();
            }
        }

        private void aboutLbl_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("This program was orignally brought to you by EquiFox!\n");
            sb.AppendLine("https://github.com/EquiFox/ \n");
            sb.AppendLine("I have modified the source to fix a few proccess detection bugs, and added support for MonoBleedingEdge. You can find the modded project at:\n");
            sb.AppendLine("https://github.com/wh0am15533/MInjector/");

            MessageBox.Show(sb.ToString(), "MInjector - About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PaintBorderlessGroupBox(object sender, PaintEventArgs p)
        {
            GroupBox box = (GroupBox)sender;

            DrawGroupBox(box, p.Graphics, Color.Teal, Color.FromArgb(37, 37, 38));

            #region[No Border at all just Text]
            /*
            p.Graphics.Clear(Color.FromArgb(37, 37, 38)); //p.Graphics.Clear(SystemColors.Control);            
            //SolidBrush Fill = new SolidBrush(Color.FromArgb(0xff, 0xff, 0x90)) // Custom Color
            p.Graphics.DrawString(box.Text, box.Font, Brushes.Teal, 0, 0);
            */
            #endregion
        }

        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                //g.Clear(this.BackColor);
                g.Clear(Color.FromArgb(37, 37, 38));

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        #region[Process Refresh Fix]

        private static string GetProcessUser(Process process)
        {
            IntPtr processHandle = IntPtr.Zero;
            try
            {
                OpenProcessToken(process.Handle, 8, out processHandle);
                using (WindowsIdentity wi = new WindowsIdentity(processHandle))
                {
                    string user = wi.Name;
                    return user.Contains(@"\") ? user.Substring(user.IndexOf(@"\") + 1) : user;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (processHandle != IntPtr.Zero)
                {
                    CloseHandle(processHandle);
                }
            }
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        #endregion
    }
}
