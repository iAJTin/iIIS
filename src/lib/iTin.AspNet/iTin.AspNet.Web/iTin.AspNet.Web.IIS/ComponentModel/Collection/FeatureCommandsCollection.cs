
namespace iTin.AspNet.Web.IIS.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;

    using iTin.Core.ComponentModel;

    using Design;

    /// <summary>
    /// Class that defines a commands collection.
    /// </summary>
    public class FeatureCommandsCollection : Collection<ICommand>, IExecute
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _index = 0;
        #endregion

        #region public events

        #region [public] {event} (EventHandler<NotifyFeatureCommandCollectionExecuted>) NotifyFeatureCommandCollectionExecuted: Occurs when a command in the collection has been executed
        /// <summary>
        /// Occurs when a command in the collection has been executed.
        /// </summary>
        public event EventHandler<NotifyFeatureCommandCollectionExecutedEventArgs> NotifyFeatureCommandCollectionExecuted;
        #endregion

        #endregion

        #region interfaces

        #region IExecute

        #region public methods

        #region [public] (IResult) Execute(): Executes the command
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <returns>
        /// Operation result
        /// </returns>
        public IResult Execute()
        {
            var resultTable = new Dictionary<ICommand, IResult>();

            _index = 0;
            foreach (ICommand command in this)
            {
                if (!(command is FeatureCommand featureCommand))
                {
                    continue;
                }

                featureCommand.NotifyFeatureCommandExecuted += NotifyFeatureCommandExecuted;
                resultTable.Add(featureCommand, command.Execute());
            }

            bool allCorrectly = resultTable.Values.All(t => t.Success == true);

            return allCorrectly
                ? ResultBase.SuccessResult
                : ResultBase.ErrorResult;
        }
        #endregion

        #endregion

        #endregion

        #endregion

        #region protected virtual methods

        #region [protected] {virtual} (void) OnNotifyFeatureCommandCollectionExecuted(NotifyFeatureCommandCollectionExecutedEventArgs): Generates the NotifyFeatureCommandCollectionExecuted event
        /// <summary>
        /// Generates the <see cref="NotifyFeatureCommandCollectionExecuted"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NotifyFeatureCommandCollectionExecutedEventArgs"/> with the event data.</param>
        protected virtual void OnNotifyFeatureCommandCollectionExecuted(NotifyFeatureCommandCollectionExecutedEventArgs e) => NotifyFeatureCommandCollectionExecuted?.Invoke(this, e);
        #endregion

        #endregion

        #region private methods

        private void NotifyFeatureCommandExecuted(object sender, NotifyFeatureCommandExecutedEventArgs e)
        {
            _index++;
            OnNotifyFeatureCommandCollectionExecuted(new NotifyFeatureCommandCollectionExecutedEventArgs(_index, Count, e.Feature, e));
        }

        #endregion
    }
}
