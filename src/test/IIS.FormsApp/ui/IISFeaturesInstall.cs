
namespace IIS.FormsApp
{
    using System;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    using iTin.AspNet.Web.IIS.ComponentModel;
    using iTin.AspNet.Web.IIS.ComponentModel.Design;
    using iTin.Core.Min.ComponentModel;
    using iTin.Core.Min.Models.Design.Enums;
    
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
            Commands.NotifyFeatureCommandCollectionExecuting += NotifyFeatureCommandCollectionExecuting;
            Commands.NotifyFeatureCommandCollectionExecuted += NotifyFeatureCommandCollectionExecuted;
            Commands.NotifyFeatureCommandsCollectionFinish += NotifyFeatureCommandsCollectionFinish;

            FeaturesProgressBar.Value = 0;
            FeaturesProgressBar.Maximum = Commands.Count;

            StartTimer.Start();
        }


        private void FinishButton_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void NotifyFeatureCommandCollectionExecuted(object sender, NotifyFeatureCommandCollectionExecutedEventArgs e)
        {
            FeaturesProgressBar.Value++;
        }

        private void NotifyFeatureCommandCollectionExecuting(object sender, NotifyFeatureCommandCollectionExecutingEventArgs e)
        {
            FeatureLabel.Text = $"Feature: {e.Feature} ({e.Index}/{e.Total})";
        }

        private void NotifyFeatureCommandsCollectionFinish(object sender, NotifyFeatureCommandsCollectionFinishEventArgs e)
        {
            if (e.Result.Success)
            {
                YesNo autoClose = Launcher.AutoClose;
                if (autoClose == YesNo.Yes)
                {
                    Thread.Sleep(500);
                    Close();
                }

                FinishButton.Visible = true;
            }
            else
            {
                var messages = new StringBuilder();
                foreach (IResultErrorData error in e.Result.Errors)
                {
                    messages.AppendLine(error.Message);
                }

                MessageBox.Show(messages.ToString(), "Error", MessageBoxButtons.OK);
            }
        }


        private void StartTimer_Tick(object sender, EventArgs e)
        {
            StartTimer.Stop();

            Commands.Process();
        }
    }
}
