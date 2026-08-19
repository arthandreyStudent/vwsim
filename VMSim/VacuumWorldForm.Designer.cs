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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVacuumWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxVacuumWorld
            // 
            this.pictureBoxVacuumWorld.BackColor = System.Drawing.Color.Black;
            this.pictureBoxVacuumWorld.Location = new System.Drawing.Point(590, 207);
            this.pictureBoxVacuumWorld.Name = "pictureBoxVacuumWorld";
            this.pictureBoxVacuumWorld.Size = new System.Drawing.Size(400, 400);
            this.pictureBoxVacuumWorld.TabIndex = 1;
            this.pictureBoxVacuumWorld.TabStop = false;
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimulate.Location = new System.Drawing.Point(51, 45);
            this.buttonSimulate.Name = "buttonSimulate";
            this.buttonSimulate.Size = new System.Drawing.Size(119, 47);
            this.buttonSimulate.TabIndex = 5;
            this.buttonSimulate.Text = "SIMULATE";
            this.buttonSimulate.UseVisualStyleBackColor = true;
            this.buttonSimulate.Click += new System.EventHandler(this.buttonSimulate_Click);
            // 
            // richTextBoxEnvironmentLog
            // 
            this.richTextBoxEnvironmentLog.BackColor = System.Drawing.Color.Black;
            this.richTextBoxEnvironmentLog.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxEnvironmentLog.ForeColor = System.Drawing.Color.Lime;
            this.richTextBoxEnvironmentLog.Location = new System.Drawing.Point(51, 179);
            this.richTextBoxEnvironmentLog.Name = "richTextBoxEnvironmentLog";
            this.richTextBoxEnvironmentLog.Size = new System.Drawing.Size(478, 472);
            this.richTextBoxEnvironmentLog.TabIndex = 6;
            this.richTextBoxEnvironmentLog.Text = "";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(48, 130);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 16);
            this.labelStatus.TabIndex = 7;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Red;
            this.buttonCancel.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(201, 47);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 45);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // VacuumWorldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1029, 721);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.richTextBoxEnvironmentLog);
            this.Controls.Add(this.buttonSimulate);
            this.Controls.Add(this.pictureBoxVacuumWorld);
            this.Name = "VacuumWorldForm";
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
    }
}

