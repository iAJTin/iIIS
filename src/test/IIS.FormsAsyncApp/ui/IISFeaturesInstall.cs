
namespace IIS.FormsApp
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using iTin.AspNet.Web.IIS.ComponentModel;
    using iTin.AspNet.Web.IIS.ComponentModel.Design;

    using iTin.Core.ComponentModel;
    using iTin.Core.Models.Design.Enums;
    
    public partial class IISFeaturesInstall : Form
    {
        private delegate void SafeUpdateProgressBarDelegate();
        private delegate void SafeUpdateFinishButtonDelegate();
        private delegate void SafeUpdateFeatureLabelDelegate(string text);

        public IISFeaturesInstall(Launcher launcher)
        {
            Launcher = launcher;

            InitializeComponent();
            InitializeControls();
        }


        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FeatureCommandsCollection Commands => Launcher.Commands;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Launcher Launcher { get; }


        private void CloseForm()
        {
            Close();
        }

        private void InitializeControls()
        {
            Commands.NotifyFeatureCommandCollectionExecuting += NotifyFeatureCommandCollectionExecuting;
            Commands.NotifyFeatureCommandCollectionExecuted += NotifyFeatureCommandCollectionExecuted;
            Commands.NotifyFeatureCommandsCollectionFinish += NotifyFeatureCommandsCollectionFinish;
            Commands.NotifyFeatureCommandsCollectionStart += NotifyFeatureCommandsCollectionStart;

            FeaturesProgressBar.Value = 0;
            FeaturesProgressBar.Maximum = Commands.Count;

            StartTimer.Start();
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            CloseForm();
        }


        private void NotifyFeatureCommandCollectionExecuted(object sender, NotifyFeatureCommandCollectionExecutedEventArgs e)
        {
            if (FeaturesProgressBar.InvokeRequired)
            {
                var d = new SafeUpdateProgressBarDelegate(UpdateProgressBar);
                FeatureLabel.Invoke(d);
            }
            else
            {
                FeaturesProgressBar.Value++;
            }
        }

        private void NotifyFeatureCommandCollectionExecuting(object sender, NotifyFeatureCommandCollectionExecutingEventArgs e)
        {
            string featureDataText = $"{e.Feature} ({e.Index + 1}/{e.Total})";
            if (FeatureLabel.InvokeRequired)
            {
                var d = new SafeUpdateFeatureLabelDelegate(UpdateFeatureLabel);
                FeatureLabel.Invoke(d, featureDataText);
            }
            else
            {
                FeatureLabel.Text = $@"Feature: {featureDataText}";
                FeatureLabel.Refresh();
            }
        }

        private void NotifyFeatureCommandsCollectionFinish(object sender, NotifyFeatureCommandsCollectionFinishEventArgs e)
        {
            if (e.Result.Success)
            {
                YesNo autoClose = Launcher.AutoClose;
                if (autoClose == YesNo.Yes)
                {
                    CloseForm();
                }

                if (UserInformationFirstLineLabel.InvokeRequired)
                {
                    var d = new SafeUpdateFinishButtonDelegate(UpdateFinishButton);
                    FeatureLabel.Invoke(d);
                }
                else
                {
                    UserInformationFirstLineLabel.Visible = false;
                    UserInformationSecondLineLabel.Visible = false;
                    FinishButton.Visible = true;
                    FinishButton.Refresh();
                }
            }
            else
            {
                MessageBox.Show(e.Result.Errors.AsMessages().ToStringBuilder().ToString(), @"Error", MessageBoxButtons.OK);

                CloseForm();
            }
        }

        private void NotifyFeatureCommandsCollectionStart(object sender, NotifyFeatureCommandsCollectionStartEventArgs e)
        {
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            FeaturesProgressBar.Value = 0;
            FeaturesProgressBar.Maximum = Commands.Count;

            StartTimer.Stop();

            Task.Run(async () => await Commands.ProcessAsync());
        }


        private void UpdateFeatureLabel(string text)
        {
            FeatureLabel.Text = text;
            FeatureLabel.Refresh();
        }

        private void UpdateFinishButton()
        {
            UserInformationFirstLineLabel.Visible = false;
            UserInformationSecondLineLabel.Visible = false;
            FinishButton.Visible = true;
            FinishButton.Refresh();
        }

        private void UpdateProgressBar()
        {
            FeaturesProgressBar.Value++;
        }
    }
}
