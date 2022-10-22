
using System;
using System.Diagnostics;
using System.Windows.Forms;

using iTin.AspNet.Web.IIS.ComponentModel;
using iTin.AspNet.Web.IIS.ComponentModel.Design;

using iTin.Core.ComponentModel;
using iTin.Core.Models.Design.Enums;

namespace IIS.FormsApp
{
    public partial class IISFeaturesInstall : Form
    {
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
            FeaturesProgressBar.Value++;
        }

        private void NotifyFeatureCommandCollectionExecuting(object sender, NotifyFeatureCommandCollectionExecutingEventArgs e)
        {
            string featureDataText = $"{e.Feature} ({e.Index + 1}/{e.Total})";
            FeatureLabel.Text = $@"Feature: {featureDataText}";
            FeatureLabel.Refresh();
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

                UserInformationFirstLineLabel.Visible = false;
                UserInformationSecondLineLabel.Visible = false;
                FinishButton.Visible = true;
            }
            else
            {
                MessageBox.Show(e.Result.Errors.AsMessages().ToStringBuilder().ToString(), @"Error", MessageBoxButtons.OK);

                CloseForm();
            }
        }

        private static void NotifyFeatureCommandsCollectionStart(object sender, NotifyFeatureCommandsCollectionStartEventArgs e)
        {
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            FeaturesProgressBar.Value = 0;
            FeaturesProgressBar.Maximum = Commands.Count;

            StartTimer.Stop();

            Commands.Process();
        }
    }
}
