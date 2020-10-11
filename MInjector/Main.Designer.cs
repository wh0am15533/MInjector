namespace MInjector
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.targetGroupBox = new System.Windows.Forms.GroupBox();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.processList = new System.Windows.Forms.ComboBox();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.hideAssemblyLoadCheck = new System.Windows.Forms.CheckBox();
            this.loadAsmBtn = new System.Windows.Forms.Button();
            this.asmPathTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.methodTxtBox = new System.Windows.Forms.TextBox();
            this.classTxtBox = new System.Windows.Forms.TextBox();
            this.namespaceTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.aboutLbl = new System.Windows.Forms.Label();
            this.injectBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.targetGroupBox.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // targetGroupBox
            // 
            this.targetGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.targetGroupBox.Controls.Add(this.refreshBtn);
            this.targetGroupBox.Controls.Add(this.processList);
            this.targetGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetGroupBox.ForeColor = System.Drawing.Color.Teal;
            this.targetGroupBox.Location = new System.Drawing.Point(11, 15);
            this.targetGroupBox.Name = "targetGroupBox";
            this.targetGroupBox.Size = new System.Drawing.Size(319, 79);
            this.targetGroupBox.TabIndex = 0;
            this.targetGroupBox.TabStop = false;
            this.targetGroupBox.Text = "Target";
            // 
            // refreshBtn
            // 
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.Location = new System.Drawing.Point(230, 31);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(59, 23);
            this.refreshBtn.TabIndex = 1;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // processList
            // 
            this.processList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.processList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.processList.ForeColor = System.Drawing.Color.DarkCyan;
            this.processList.FormattingEnabled = true;
            this.processList.Location = new System.Drawing.Point(29, 32);
            this.processList.Name = "processList";
            this.processList.Size = new System.Drawing.Size(195, 21);
            this.processList.TabIndex = 0;
            this.processList.SelectedIndexChanged += new System.EventHandler(this.processList_SelectedIndexChanged);
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.hideAssemblyLoadCheck);
            this.settingsGroupBox.Controls.Add(this.loadAsmBtn);
            this.settingsGroupBox.Controls.Add(this.asmPathTextBox);
            this.settingsGroupBox.Controls.Add(this.label4);
            this.settingsGroupBox.Controls.Add(this.methodTxtBox);
            this.settingsGroupBox.Controls.Add(this.classTxtBox);
            this.settingsGroupBox.Controls.Add(this.namespaceTxtBox);
            this.settingsGroupBox.Controls.Add(this.label3);
            this.settingsGroupBox.Controls.Add(this.label2);
            this.settingsGroupBox.Controls.Add(this.label1);
            this.settingsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsGroupBox.ForeColor = System.Drawing.Color.Teal;
            this.settingsGroupBox.Location = new System.Drawing.Point(11, 98);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(319, 181);
            this.settingsGroupBox.TabIndex = 1;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // hideAssemblyLoadCheck
            // 
            this.hideAssemblyLoadCheck.AutoSize = true;
            this.hideAssemblyLoadCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hideAssemblyLoadCheck.Location = new System.Drawing.Point(32, 149);
            this.hideAssemblyLoadCheck.Name = "hideAssemblyLoadCheck";
            this.hideAssemblyLoadCheck.Size = new System.Drawing.Size(255, 17);
            this.hideAssemblyLoadCheck.TabIndex = 6;
            this.hideAssemblyLoadCheck.Text = "Hide from AssemblyLoad Callback (Experimental)";
            this.hideAssemblyLoadCheck.UseVisualStyleBackColor = true;
            // 
            // loadAsmBtn
            // 
            this.loadAsmBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadAsmBtn.Location = new System.Drawing.Point(263, 24);
            this.loadAsmBtn.Name = "loadAsmBtn";
            this.loadAsmBtn.Size = new System.Drawing.Size(26, 23);
            this.loadAsmBtn.TabIndex = 2;
            this.loadAsmBtn.Text = "...";
            this.loadAsmBtn.UseVisualStyleBackColor = true;
            this.loadAsmBtn.Click += new System.EventHandler(this.loadAsmBtn_Click);
            // 
            // asmPathTextBox
            // 
            this.asmPathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.asmPathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.asmPathTextBox.ForeColor = System.Drawing.Color.Teal;
            this.asmPathTextBox.Location = new System.Drawing.Point(118, 25);
            this.asmPathTextBox.Name = "asmPathTextBox";
            this.asmPathTextBox.ReadOnly = true;
            this.asmPathTextBox.Size = new System.Drawing.Size(142, 20);
            this.asmPathTextBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(26, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Assembly:";
            // 
            // methodTxtBox
            // 
            this.methodTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.methodTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.methodTxtBox.ForeColor = System.Drawing.Color.Teal;
            this.methodTxtBox.Location = new System.Drawing.Point(118, 113);
            this.methodTxtBox.Name = "methodTxtBox";
            this.methodTxtBox.Size = new System.Drawing.Size(171, 20);
            this.methodTxtBox.TabIndex = 5;
            // 
            // classTxtBox
            // 
            this.classTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.classTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classTxtBox.ForeColor = System.Drawing.Color.Teal;
            this.classTxtBox.Location = new System.Drawing.Point(118, 85);
            this.classTxtBox.Name = "classTxtBox";
            this.classTxtBox.Size = new System.Drawing.Size(171, 20);
            this.classTxtBox.TabIndex = 4;
            // 
            // namespaceTxtBox
            // 
            this.namespaceTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.namespaceTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.namespaceTxtBox.ForeColor = System.Drawing.Color.Teal;
            this.namespaceTxtBox.Location = new System.Drawing.Point(118, 57);
            this.namespaceTxtBox.Name = "namespaceTxtBox";
            this.namespaceTxtBox.Size = new System.Drawing.Size(171, 20);
            this.namespaceTxtBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(26, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Method:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Location = new System.Drawing.Point(26, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Class:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Location = new System.Drawing.Point(26, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Namespace: ";
            // 
            // aboutLbl
            // 
            this.aboutLbl.AutoSize = true;
            this.aboutLbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLbl.ForeColor = System.Drawing.Color.DodgerBlue;
            this.aboutLbl.Location = new System.Drawing.Point(301, 4);
            this.aboutLbl.Name = "aboutLbl";
            this.aboutLbl.Size = new System.Drawing.Size(30, 12);
            this.aboutLbl.TabIndex = 9;
            this.aboutLbl.Text = "About";
            this.aboutLbl.Click += new System.EventHandler(this.aboutLbl_Click);
            // 
            // injectBtn
            // 
            this.injectBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateGray;
            this.injectBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.injectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.injectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.injectBtn.Location = new System.Drawing.Point(12, 285);
            this.injectBtn.Name = "injectBtn";
            this.injectBtn.Size = new System.Drawing.Size(319, 35);
            this.injectBtn.TabIndex = 10;
            this.injectBtn.Text = "I N J E C T !";
            this.injectBtn.UseVisualStyleBackColor = true;
            this.injectBtn.Click += new System.EventHandler(this.injectBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Magenta;
            this.label5.Location = new System.Drawing.Point(13, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Status:";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.ForeColor = System.Drawing.Color.Orchid;
            this.status.Location = new System.Drawing.Point(55, 331);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 13);
            this.status.TabIndex = 12;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(341, 356);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.injectBtn);
            this.Controls.Add(this.aboutLbl);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.targetGroupBox);
            this.ForeColor = System.Drawing.Color.Teal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MInjector -wh0am1 Mod v1.4";
            this.targetGroupBox.ResumeLayout(false);
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox targetGroupBox;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.ComboBox processList;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.TextBox methodTxtBox;
        private System.Windows.Forms.TextBox classTxtBox;
        private System.Windows.Forms.TextBox namespaceTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadAsmBtn;
        private System.Windows.Forms.TextBox asmPathTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox hideAssemblyLoadCheck;
        private System.Windows.Forms.Label aboutLbl;
        private System.Windows.Forms.Button injectBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label status;
    }
}

