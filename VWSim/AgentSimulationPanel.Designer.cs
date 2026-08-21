using VWSim;

namespace VWSim
{
    partial class AgentSimulationPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxVacuumWorld = new System.Windows.Forms.PictureBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.labelAgentName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVacuumWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxVacuumWorld
            // 
            this.pictureBoxVacuumWorld.BackColor = System.Drawing.Color.Black;
            this.pictureBoxVacuumWorld.Location = new System.Drawing.Point(14, 73);
            this.pictureBoxVacuumWorld.Name = "pictureBoxVacuumWorld";
            this.pictureBoxVacuumWorld.Size = new System.Drawing.Size(350, 350);
            this.pictureBoxVacuumWorld.TabIndex = 0;
            this.pictureBoxVacuumWorld.TabStop = false;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.BackColor = System.Drawing.Color.Black;
            this.richTextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxLog.ForeColor = System.Drawing.Color.Lime;
            this.richTextBoxLog.Location = new System.Drawing.Point(14, 440);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxLog.Size = new System.Drawing.Size(398, 398);
            this.richTextBoxLog.TabIndex = 1;
            this.richTextBoxLog.Text = "";
            // 
            // labelAgentName
            // 
            this.labelAgentName.AutoSize = true;
            this.labelAgentName.Font = new System.Drawing.Font("Unispace", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAgentName.ForeColor = System.Drawing.Color.White;
            this.labelAgentName.Location = new System.Drawing.Point(9, 23);
            this.labelAgentName.Name = "labelAgentName";
            this.labelAgentName.Size = new System.Drawing.Size(163, 29);
            this.labelAgentName.TabIndex = 2;
            this.labelAgentName.Text = "Agent Name";
            this.labelAgentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AgentSimulationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.labelAgentName);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.pictureBoxVacuumWorld);
            this.Name = "AgentSimulationPanel";
            this.Size = new System.Drawing.Size(430, 861);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVacuumWorld)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxVacuumWorld;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Label labelAgentName;
    }
}
