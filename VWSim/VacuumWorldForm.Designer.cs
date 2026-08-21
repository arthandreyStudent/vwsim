namespace VWSim
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
            this.buttonSimulate = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelVWSim = new System.Windows.Forms.Label();
            this.labelSubtitle = new System.Windows.Forms.Label();
            this.agentSimulationPanelRandom = new VWSim.AgentSimulationPanel();
            this.agentSimulationPanelSFA = new VWSim.AgentSimulationPanel();
            this.SuspendLayout();
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
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Inter", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(69, 324);
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
            // labelVWSim
            // 
            this.labelVWSim.AutoSize = true;
            this.labelVWSim.Font = new System.Drawing.Font("Unispace", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVWSim.ForeColor = System.Drawing.Color.White;
            this.labelVWSim.Location = new System.Drawing.Point(39, 61);
            this.labelVWSim.Name = "labelVWSim";
            this.labelVWSim.Size = new System.Drawing.Size(344, 115);
            this.labelVWSim.TabIndex = 9;
            this.labelVWSim.Text = "VWSim";
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
            // agentSimulationPanelRandom
            // 
            this.agentSimulationPanelRandom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.agentSimulationPanelRandom.Location = new System.Drawing.Point(453, 61);
            this.agentSimulationPanelRandom.Name = "agentSimulationPanelRandom";
            this.agentSimulationPanelRandom.Size = new System.Drawing.Size(430, 861);
            this.agentSimulationPanelRandom.TabIndex = 11;
            // 
            // agentSimulationPanelSFA
            // 
            this.agentSimulationPanelSFA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.agentSimulationPanelSFA.Location = new System.Drawing.Point(909, 61);
            this.agentSimulationPanelSFA.Name = "agentSimulationPanelSFA";
            this.agentSimulationPanelSFA.Size = new System.Drawing.Size(430, 861);
            this.agentSimulationPanelSFA.TabIndex = 12;
            // 
            // VacuumWorldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1784, 961);
            this.Controls.Add(this.agentSimulationPanelSFA);
            this.Controls.Add(this.agentSimulationPanelRandom);
            this.Controls.Add(this.labelSubtitle);
            this.Controls.Add(this.labelVWSim);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonSimulate);
            this.Name = "VacuumWorldForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VWSim | Vacuum World Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSimulate;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelVWSim;
        private System.Windows.Forms.Label labelSubtitle;
        private AgentSimulationPanel agentSimulationPanelRandom;
        private AgentSimulationPanel agentSimulationPanelSFA;
    }
}

