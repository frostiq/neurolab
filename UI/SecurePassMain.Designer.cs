namespace UI
{
    partial class SecurePassMain
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
            this.txtserverIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPortNumber = new System.Windows.Forms.TextBox();
            this.lblPortNumber = new System.Windows.Forms.Label();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartListener = new System.Windows.Forms.Button();
            this.lstAlarmData = new System.Windows.Forms.ListBox();
            this.cmdClearUI = new System.Windows.Forms.Button();
            this.lstDataHandleUpdate = new System.Windows.Forms.ListBox();
            this.cmdSendCommand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtserverIPAddress
            // 
            this.txtserverIPAddress.Enabled = false;
            this.txtserverIPAddress.Location = new System.Drawing.Point(486, 3);
            this.txtserverIPAddress.Name = "txtserverIPAddress";
            this.txtserverIPAddress.Size = new System.Drawing.Size(121, 20);
            this.txtserverIPAddress.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Server IP Address";
            // 
            // txtPortNumber
            // 
            this.txtPortNumber.Enabled = false;
            this.txtPortNumber.Location = new System.Drawing.Point(81, 3);
            this.txtPortNumber.Name = "txtPortNumber";
            this.txtPortNumber.Size = new System.Drawing.Size(61, 20);
            this.txtPortNumber.TabIndex = 14;
            this.txtPortNumber.Text = "52200";
            // 
            // lblPortNumber
            // 
            this.lblPortNumber.AutoSize = true;
            this.lblPortNumber.Location = new System.Drawing.Point(11, 8);
            this.lblPortNumber.Name = "lblPortNumber";
            this.lblPortNumber.Size = new System.Drawing.Size(66, 13);
            this.lblPortNumber.TabIndex = 13;
            this.lblPortNumber.Text = "Port Number";
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(275, 3);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(107, 23);
            this.btnStopServer.TabIndex = 12;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartListener
            // 
            this.btnStartListener.Location = new System.Drawing.Point(162, 3);
            this.btnStartListener.Name = "btnStartListener";
            this.btnStartListener.Size = new System.Drawing.Size(107, 23);
            this.btnStartListener.TabIndex = 11;
            this.btnStartListener.Text = "Start Server";
            this.btnStartListener.UseVisualStyleBackColor = true;
            this.btnStartListener.Click += new System.EventHandler(this.btnStartListener_Click);
            // 
            // lstAlarmData
            // 
            this.lstAlarmData.FormattingEnabled = true;
            this.lstAlarmData.Location = new System.Drawing.Point(12, 49);
            this.lstAlarmData.Name = "lstAlarmData";
            this.lstAlarmData.Size = new System.Drawing.Size(945, 199);
            this.lstAlarmData.TabIndex = 17;
            // 
            // cmdClearUI
            // 
            this.cmdClearUI.Location = new System.Drawing.Point(613, 3);
            this.cmdClearUI.Name = "cmdClearUI";
            this.cmdClearUI.Size = new System.Drawing.Size(107, 23);
            this.cmdClearUI.TabIndex = 18;
            this.cmdClearUI.Text = "Clear UI";
            this.cmdClearUI.UseVisualStyleBackColor = true;
            this.cmdClearUI.Click += new System.EventHandler(this.cmdClearUI_Click);
            // 
            // lstDataHandleUpdate
            // 
            this.lstDataHandleUpdate.FormattingEnabled = true;
            this.lstDataHandleUpdate.Location = new System.Drawing.Point(12, 255);
            this.lstDataHandleUpdate.Name = "lstDataHandleUpdate";
            this.lstDataHandleUpdate.Size = new System.Drawing.Size(945, 199);
            this.lstDataHandleUpdate.TabIndex = 19;
            // 
            // cmdSendCommand
            // 
            this.cmdSendCommand.Location = new System.Drawing.Point(735, 3);
            this.cmdSendCommand.Name = "cmdSendCommand";
            this.cmdSendCommand.Size = new System.Drawing.Size(107, 23);
            this.cmdSendCommand.TabIndex = 20;
            this.cmdSendCommand.Text = "Send Information";
            this.cmdSendCommand.UseVisualStyleBackColor = true;
            this.cmdSendCommand.Click += new System.EventHandler(this.cmdSendCommand_Click);
            // 
            // SecurePassMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 466);
            this.Controls.Add(this.cmdSendCommand);
            this.Controls.Add(this.lstDataHandleUpdate);
            this.Controls.Add(this.cmdClearUI);
            this.Controls.Add(this.lstAlarmData);
            this.Controls.Add(this.txtserverIPAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPortNumber);
            this.Controls.Add(this.lblPortNumber);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.btnStartListener);
            this.Name = "SecurePassMain";
            this.Text = "Secure Pass";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SecurePassMain_FormClosed);
            this.Load += new System.EventHandler(this.SecurePassMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtserverIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPortNumber;
        private System.Windows.Forms.Label lblPortNumber;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnStartListener;
        private System.Windows.Forms.ListBox lstAlarmData;
        private System.Windows.Forms.Button cmdClearUI;
        private System.Windows.Forms.ListBox lstDataHandleUpdate;
        private System.Windows.Forms.Button cmdSendCommand;
    }
}

