namespace VMSim
{
    partial class VacuumWorldForm
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
            this.pictureBoxVacuumWorld = new System.Windows.Forms.PictureBox();
            this.buttonSimulate = new System.Windows.Forms.Button();
            this.richTextBoxEnvironmentLog = new System.Windows.Forms.RichTextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelVMSim = new System.Windows.Forms.Label();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.labelRandomAgent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVacuumWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxVacuumWorld
            // 
            this.pictureBoxVacuumWorld.BackColor = System.Drawing.Color.Black;
            this.pictureBoxVacuumWorld.Location = new System.Drawing.Point(471, 73);
            this.pictureBoxVacuumWorld.Name = "pictureBoxVacuumWorld";
            this.pictureBoxVacuumWorld.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxVacuumWorld.TabIndex = 1;
            this.pictureBoxVacuumWorld.TabStop = false;
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.BackColor = System.Drawing.Color.White;
            this.buttonSimulate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSimulate.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimulate.Location = new System.Drawing.Point(73, 232);
            this.buttonSimulate.Name = "buttonSimulate";
            this.buttonSimulate.Size = new System.Drawing.Size(144, 45);
            this.buttonSimulate.TabIndex = 5;
            this.buttonSimulate.Text = "SIMULATE";
            this.buttonSimulate.UseVisualStyleBackColor = false;
            this.buttonSimulate.Click += new System.EventHandler(this.buttonSimulate_Click);
            // 
            // richTextBoxEnvironmentLog
            // 
            this.richTextBoxEnvironmentLog.BackColor = System.Drawing.Color.Black;
            this.richTextBoxEnvironmentLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxEnvironmentLog.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxEnvironmentLog.ForeColor = System.Drawing.Color.Lime;
            this.richTextBoxEnvironmentLog.Location = new System.Drawing.Point(471, 336);
            this.richTextBoxEnvironmentLog.Name = "richTextBoxEnvironmentLog";
            this.richTextBoxEnvironmentLog.Size = new System.Drawing.Size(399, 484);
            this.richTextBoxEnvironmentLog.TabIndex = 6;
            this.richTextBoxEnvironmentLog.Text = "";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Inter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(68, 361);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 19);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Red;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(241, 232);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(142, 45);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelVMSim
            // 
            this.labelVMSim.AutoSize = true;
            this.labelVMSim.Font = new System.Drawing.Font("Unispace", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVMSim.ForeColor = System.Drawing.Color.White;
            this.labelVMSim.Location = new System.Drawing.Point(39, 61);
            this.labelVMSim.Name = "labelVMSim";
            this.labelVMSim.Size = new System.Drawing.Size(344, 115);
            this.labelVMSim.TabIndex = 9;
            this.labelVMSim.Text = "VWSim";
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.AutoSize = true;
            this.labelSubtitle.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubtitle.ForeColor = System.Drawing.Color.White;
            this.labelSubtitle.Location = new System.Drawing.Point(69, 176);
            this.labelSubtitle.Name = "labelSubtitle";
            this.labelSubtitle.Size = new System.Drawing.Size(299, 19);
            this.labelSubtitle.TabIndex = 10;
            this.labelSubtitle.Text = "Vacuum World Pocket Simulator";
            // 
            // labelRandomAgent
            // 
            this.labelRandomAgent.AutoSize = true;
            this.labelRandomAgent.Font = new System.Drawing.Font("Unispace", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRandomAgent.ForeColor = System.Drawing.Color.White;
            this.labelRandomAgent.Location = new System.Drawing.Point(580, 858);
            this.labelRandomAgent.Name = "labelRandomAgent";
            this.labelRandomAgent.Size = new System.Drawing.Size(193, 29);
            this.labelRandomAgent.TabIndex = 11;
            this.labelRandomAgent.Text = "Random Agent";
            // 
            // VacuumWorldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1784, 961);
            this.Controls.Add(this.labelRandomAgent);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelVMSim);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.richTextBoxEnvironmentLog);
            this.Controls.Add(this.buttonSimulate);
            this.Controls.Add(this.pictureBoxVacuumWorld);
            this.Name = "VacuumWorldForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VMSim | Vacuum World Simulator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVacuumWorld)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxVacuumWorld;
        private System.Windows.Forms.Button buttonSimulate;
        private System.Windows.Forms.RichTextBox richTextBoxEnvironmentLog;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelVMSim;
        private System.Windows.Forms.Label labelSubtitle;
        private System.Windows.Forms.Label labelRandomAgent;
    }
}

