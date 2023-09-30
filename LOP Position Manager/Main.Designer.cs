
namespace LOP_Position_Manager
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
            this.button_LoadPosition = new System.Windows.Forms.Button();
            this.button_SavePosition = new System.Windows.Forms.Button();
            this.textBox_PlayerPositionZ = new System.Windows.Forms.TextBox();
            this.textBox_PlayerPositionY = new System.Windows.Forms.TextBox();
            this.textBox_PlayerPositionX = new System.Windows.Forms.TextBox();
            this.selector = new System.Windows.Forms.Label();
            this.label_LoadedSaveName = new System.Windows.Forms.Label();
            this.button_SavePositionToFile = new System.Windows.Forms.Button();
            this.button_LoadPositionFromFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_WindowAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.backgroundWorker_CheckProcess = new System.ComponentModel.BackgroundWorker();
            this.textBox_SavePositionHotkey = new System.Windows.Forms.TextBox();
            this.textBox_LoadPositionHotkey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_Yaw = new System.Windows.Forms.TextBox();
            this.textBox_Pitch = new System.Windows.Forms.TextBox();
            this.backgroundWorker_Main = new System.ComponentModel.BackgroundWorker();
            this.checkBox_DisableSounds = new System.Windows.Forms.CheckBox();
            this.backgroundWorker_CheckUpdates = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // button_LoadPosition
            // 
            this.button_LoadPosition.Location = new System.Drawing.Point(172, 39);
            this.button_LoadPosition.Name = "button_LoadPosition";
            this.button_LoadPosition.Size = new System.Drawing.Size(152, 23);
            this.button_LoadPosition.TabIndex = 28;
            this.button_LoadPosition.Text = "load position";
            this.button_LoadPosition.UseVisualStyleBackColor = true;
            this.button_LoadPosition.Click += new System.EventHandler(this.button_LoadPosition_Click);
            // 
            // button_SavePosition
            // 
            this.button_SavePosition.Location = new System.Drawing.Point(12, 39);
            this.button_SavePosition.Name = "button_SavePosition";
            this.button_SavePosition.Size = new System.Drawing.Size(151, 23);
            this.button_SavePosition.TabIndex = 27;
            this.button_SavePosition.Text = "save position";
            this.button_SavePosition.UseVisualStyleBackColor = true;
            this.button_SavePosition.Click += new System.EventHandler(this.button_SavePosition_Click);
            // 
            // textBox_PlayerPositionZ
            // 
            this.textBox_PlayerPositionZ.Location = new System.Drawing.Point(244, 88);
            this.textBox_PlayerPositionZ.Name = "textBox_PlayerPositionZ";
            this.textBox_PlayerPositionZ.Size = new System.Drawing.Size(80, 20);
            this.textBox_PlayerPositionZ.TabIndex = 26;
            this.textBox_PlayerPositionZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_PlayerPositionY
            // 
            this.textBox_PlayerPositionY.Location = new System.Drawing.Point(138, 88);
            this.textBox_PlayerPositionY.Name = "textBox_PlayerPositionY";
            this.textBox_PlayerPositionY.Size = new System.Drawing.Size(80, 20);
            this.textBox_PlayerPositionY.TabIndex = 25;
            this.textBox_PlayerPositionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_PlayerPositionX
            // 
            this.textBox_PlayerPositionX.Location = new System.Drawing.Point(32, 88);
            this.textBox_PlayerPositionX.Name = "textBox_PlayerPositionX";
            this.textBox_PlayerPositionX.Size = new System.Drawing.Size(80, 20);
            this.textBox_PlayerPositionX.TabIndex = 24;
            this.textBox_PlayerPositionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // selector
            // 
            this.selector.AutoSize = true;
            this.selector.Location = new System.Drawing.Point(32000, 32000);
            this.selector.Name = "selector";
            this.selector.Size = new System.Drawing.Size(0, 13);
            this.selector.TabIndex = 32;
            // 
            // label_LoadedSaveName
            // 
            this.label_LoadedSaveName.AutoSize = true;
            this.label_LoadedSaveName.Location = new System.Drawing.Point(8, 188);
            this.label_LoadedSaveName.Name = "label_LoadedSaveName";
            this.label_LoadedSaveName.Size = new System.Drawing.Size(100, 13);
            this.label_LoadedSaveName.TabIndex = 34;
            this.label_LoadedSaveName.Text = "loaded save name: ";
            // 
            // button_SavePositionToFile
            // 
            this.button_SavePositionToFile.Location = new System.Drawing.Point(11, 162);
            this.button_SavePositionToFile.Name = "button_SavePositionToFile";
            this.button_SavePositionToFile.Size = new System.Drawing.Size(154, 23);
            this.button_SavePositionToFile.TabIndex = 36;
            this.button_SavePositionToFile.Text = "save position to file";
            this.button_SavePositionToFile.UseVisualStyleBackColor = true;
            this.button_SavePositionToFile.Click += new System.EventHandler(this.button_SavePositionToFile_Click);
            // 
            // button_LoadPositionFromFile
            // 
            this.button_LoadPositionFromFile.Location = new System.Drawing.Point(171, 162);
            this.button_LoadPositionFromFile.Name = "button_LoadPositionFromFile";
            this.button_LoadPositionFromFile.Size = new System.Drawing.Size(152, 23);
            this.button_LoadPositionFromFile.TabIndex = 37;
            this.button_LoadPositionFromFile.Text = "load position from file";
            this.button_LoadPositionFromFile.UseVisualStyleBackColor = true;
            this.button_LoadPositionFromFile.Click += new System.EventHandler(this.button_LoadPositionFromFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Z";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(13, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(311, 2);
            this.label5.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(12, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(311, 2);
            this.label8.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(12, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(311, 2);
            this.label9.TabIndex = 48;
            // 
            // checkBox_WindowAlwaysOnTop
            // 
            this.checkBox_WindowAlwaysOnTop.AutoSize = true;
            this.checkBox_WindowAlwaysOnTop.Location = new System.Drawing.Point(12, 225);
            this.checkBox_WindowAlwaysOnTop.Name = "checkBox_WindowAlwaysOnTop";
            this.checkBox_WindowAlwaysOnTop.Size = new System.Drawing.Size(130, 17);
            this.checkBox_WindowAlwaysOnTop.TabIndex = 49;
            this.checkBox_WindowAlwaysOnTop.Text = "window always on top";
            this.checkBox_WindowAlwaysOnTop.UseVisualStyleBackColor = true;
            this.checkBox_WindowAlwaysOnTop.CheckedChanged += new System.EventHandler(this.checkBox_WindowAlwaysOnTop_CheckedChanged);
            // 
            // backgroundWorker_CheckProcess
            // 
            this.backgroundWorker_CheckProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_CheckProcess_DoWork);
            // 
            // textBox_SavePositionHotkey
            // 
            this.textBox_SavePositionHotkey.Location = new System.Drawing.Point(12, 13);
            this.textBox_SavePositionHotkey.Name = "textBox_SavePositionHotkey";
            this.textBox_SavePositionHotkey.ReadOnly = true;
            this.textBox_SavePositionHotkey.Size = new System.Drawing.Size(151, 20);
            this.textBox_SavePositionHotkey.TabIndex = 52;
            this.textBox_SavePositionHotkey.Text = "< click here to set hotkey >";
            this.textBox_SavePositionHotkey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SavePositionHotkey.Enter += new System.EventHandler(this.textBox_SavePositionHotkey_Enter);
            this.textBox_SavePositionHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_SavePositionHotkey_KeyDown);
            this.textBox_SavePositionHotkey.Leave += new System.EventHandler(this.textBox_SavePositionHotkey_Leave);
            // 
            // textBox_LoadPositionHotkey
            // 
            this.textBox_LoadPositionHotkey.Location = new System.Drawing.Point(174, 13);
            this.textBox_LoadPositionHotkey.Name = "textBox_LoadPositionHotkey";
            this.textBox_LoadPositionHotkey.ReadOnly = true;
            this.textBox_LoadPositionHotkey.Size = new System.Drawing.Size(150, 20);
            this.textBox_LoadPositionHotkey.TabIndex = 53;
            this.textBox_LoadPositionHotkey.Text = "< click here to set hotkey >";
            this.textBox_LoadPositionHotkey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_LoadPositionHotkey.Enter += new System.EventHandler(this.textBox_LoadPositionHotkey_Enter);
            this.textBox_LoadPositionHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_LoadPositionHotkey_KeyDown);
            this.textBox_LoadPositionHotkey.Leave += new System.EventHandler(this.textBox_LoadPositionHotkey_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(169, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 58;
            this.label7.Text = "yaw";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 57;
            this.label11.Text = "pitch";
            // 
            // textBox_Yaw
            // 
            this.textBox_Yaw.Location = new System.Drawing.Point(201, 115);
            this.textBox_Yaw.Name = "textBox_Yaw";
            this.textBox_Yaw.Size = new System.Drawing.Size(123, 20);
            this.textBox_Yaw.TabIndex = 55;
            this.textBox_Yaw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Pitch
            // 
            this.textBox_Pitch.Location = new System.Drawing.Point(48, 115);
            this.textBox_Pitch.Name = "textBox_Pitch";
            this.textBox_Pitch.Size = new System.Drawing.Size(105, 20);
            this.textBox_Pitch.TabIndex = 54;
            this.textBox_Pitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // backgroundWorker_Main
            // 
            this.backgroundWorker_Main.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Main_DoWork);
            // 
            // checkBox_DisableSounds
            // 
            this.checkBox_DisableSounds.AutoSize = true;
            this.checkBox_DisableSounds.Location = new System.Drawing.Point(171, 225);
            this.checkBox_DisableSounds.Name = "checkBox_DisableSounds";
            this.checkBox_DisableSounds.Size = new System.Drawing.Size(96, 17);
            this.checkBox_DisableSounds.TabIndex = 59;
            this.checkBox_DisableSounds.Text = "disable sounds";
            this.checkBox_DisableSounds.UseVisualStyleBackColor = true;
            this.checkBox_DisableSounds.CheckedChanged += new System.EventHandler(this.checkBox_DisableSounds_CheckedChanged);
            // 
            // backgroundWorker_CheckUpdates
            // 
            this.backgroundWorker_CheckUpdates.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_CheckUpdates_DoWork);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 251);
            this.Controls.Add(this.checkBox_DisableSounds);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox_Yaw);
            this.Controls.Add(this.textBox_Pitch);
            this.Controls.Add(this.textBox_LoadPositionHotkey);
            this.Controls.Add(this.textBox_SavePositionHotkey);
            this.Controls.Add(this.checkBox_WindowAlwaysOnTop);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_LoadPositionFromFile);
            this.Controls.Add(this.button_SavePositionToFile);
            this.Controls.Add(this.label_LoadedSaveName);
            this.Controls.Add(this.selector);
            this.Controls.Add(this.button_LoadPosition);
            this.Controls.Add(this.button_SavePosition);
            this.Controls.Add(this.textBox_PlayerPositionZ);
            this.Controls.Add(this.textBox_PlayerPositionY);
            this.Controls.Add(this.textBox_PlayerPositionX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "LOP PM";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Click += new System.EventHandler(this.Main_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_LoadPosition;
        private System.Windows.Forms.Button button_SavePosition;
        private System.Windows.Forms.TextBox textBox_PlayerPositionZ;
        private System.Windows.Forms.TextBox textBox_PlayerPositionY;
        private System.Windows.Forms.TextBox textBox_PlayerPositionX;
        private System.Windows.Forms.Label selector;
        private System.Windows.Forms.Label label_LoadedSaveName;
        private System.Windows.Forms.Button button_SavePositionToFile;
        private System.Windows.Forms.Button button_LoadPositionFromFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_WindowAlwaysOnTop;
        private System.ComponentModel.BackgroundWorker backgroundWorker_CheckProcess;
        private System.Windows.Forms.TextBox textBox_SavePositionHotkey;
        private System.Windows.Forms.TextBox textBox_LoadPositionHotkey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_Yaw;
        private System.Windows.Forms.TextBox textBox_Pitch;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Main;
        private System.Windows.Forms.CheckBox checkBox_DisableSounds;
        private System.ComponentModel.BackgroundWorker backgroundWorker_CheckUpdates;
    }
}

