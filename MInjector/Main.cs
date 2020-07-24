using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;


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

        #endregion

        public Main()
        {
            InitializeComponent();

            RefreshMonoProcesses();
            Text += !Environment.Is64BitProcess ? " (x86)" : " (x64)";
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshMonoProcesses();
        }

        private void RefreshMonoProcesses()
        {
            processList.Items.Clear();
            settingsGroupBox.Enabled = false;
            injectBtn.Enabled = false;

            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    // This will check if process is protected (system process)
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
                    else { /* Possibly found Unity/Mono process */ }


                    // NOTES: If built with AnyCPU you'll only get the Managed modules, no Native modules.
                    // If built x32/x64 you'll get all the modules back that are the same architecture.
                    //ProcessModuleCollection mods = process.Modules;
                    // Is x32 or x64 Using my Undocumented Response Discovery! J.E
                    if (process.Modules != null)
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
                }
                catch { }
            }

            if (processList.Items.Count > 0)
            {
                processList.SelectedIndex = 0;
            }
        }

        private void processList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = (processList.SelectedItem != null && processList.SelectedItem is PrintableProcess);

            settingsGroupBox.Enabled = flag;
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
                MessageBox.Show("Injection was successful !");
            }
            else
            {
                MessageBox.Show("An error occured while injecting...");

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


    }
}
