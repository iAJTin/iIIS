
namespace IIS.FormsApp
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

    using iTin.AspNet.Web.IIS.ComponentModel;
    using iTin.AspNet.Web.IIS.ComponentModel.Design;

    using iTin.Core.Models.Design.Enums;
    
    public partial class IISFeaturesInstall : Form
    {

        public IISFeaturesInstall(Launcher launcher)
        {
            Launcher = launcher;

            InitializeComponent();
            InitializeControls();
        }


        private FeatureCommandsCollection Commands => Launcher.Commands;

        private Launcher Launcher { get; }


        private void InitializeControls()
        {
            Commands.NotifyFeatureCommandCollectionExecuted += NotifyFeatureCommandCollectionExecuted;
            
            FeaturesProgressBar.Value = 0;
            FeaturesProgressBar.Maximum = Commands.Count;

            StartTimer.Start();
        }


        private void FinishButton_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void NotifyFeatureCommandCollectionExecuted(object sender, NotifyFeatureCommandCollectionExecutedEventArgs e)
        {
            FeaturesProgressBar.Value++;
            FeatureLabel.Text = $"Feature: {e.Feature} ({e.Index}/{e.Total})";

            if (e.Index == e.Total)
            {
                YesNo autoClose = Launcher.AutoClose;
                if (autoClose == YesNo.Yes)
                {
                    Thread.Sleep(500);
                    Close();
                }

                FinishButton.Visible = true;
            }
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            StartTimer.Stop();

            Commands.Execute();
        }
    }
}
