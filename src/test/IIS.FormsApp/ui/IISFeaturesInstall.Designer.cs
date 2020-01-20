namespace IIS.FormsApp
{
    partial class IISFeaturesInstall
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FeaturesProgressBar = new System.Windows.Forms.ProgressBar();
            this.FinishButton = new System.Windows.Forms.Button();
            this.FeatureLabel = new System.Windows.Forms.Label();
            this.StartTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // FeaturesProgressBar
            // 
            this.FeaturesProgressBar.Location = new System.Drawing.Point(12, 50);
            this.FeaturesProgressBar.Name = "FeaturesProgressBar";
            this.FeaturesProgressBar.Size = new System.Drawing.Size(662, 23);
            this.FeaturesProgressBar.TabIndex = 0;
            this.FeaturesProgressBar.Value = 50;
            // 
            // FinishButton
            // 
            this.FinishButton.Location = new System.Drawing.Point(599, 79);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(75, 23);
            this.FinishButton.TabIndex = 1;
            this.FinishButton.Text = "Finish";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Visible = false;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // FeatureLabel
            // 
            this.FeatureLabel.AutoSize = true;
            this.FeatureLabel.Location = new System.Drawing.Point(12, 34);
            this.FeatureLabel.Name = "FeatureLabel";
            this.FeatureLabel.Size = new System.Drawing.Size(0, 13);
            this.FeatureLabel.TabIndex = 2;
            // 
            // StartTimer
            // 
            this.StartTimer.Interval = 500;
            this.StartTimer.Tick += new System.EventHandler(this.StartTimer_Tick);
            // 
            // IISFeaturesInstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 116);
            this.Controls.Add(this.FeatureLabel);
            this.Controls.Add(this.FinishButton);
            this.Controls.Add(this.FeaturesProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IISFeaturesInstall";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar FeaturesProgressBar;
        private System.Windows.Forms.Button FinishButton;
        private System.Windows.Forms.Label FeatureLabel;
        private System.Windows.Forms.Timer StartTimer;
    }
}

