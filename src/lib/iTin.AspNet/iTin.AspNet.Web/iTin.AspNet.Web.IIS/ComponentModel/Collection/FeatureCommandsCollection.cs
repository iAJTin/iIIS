
namespace iTin.AspNet.Web.IIS.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using iTin.Core.ComponentModel;
    using iTin.Core.ComponentModel.Results;

    using Design;

    /// <summary>
    /// Class that defines a commands collection.
    /// </summary>
    public sealed class FeatureCommandsCollection : Collection<ICommand>
    {
        #region private members
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int _index;
        #endregion

        #region public events

        #region [public] {event} (EventHandler<NotifyFeatureCommandCollectionExecuted>) NotifyFeatureCommandCollectionExecuted: Occurs when a ICommand in the collection has been executed
        /// <summary>
        /// Occurs when a <see cref="ICommand"/> in the collection has been executed.
        /// </summary>
        public event EventHandler<NotifyFeatureCommandCollectionExecutedEventArgs> NotifyFeatureCommandCollectionExecuted;
        #endregion

        #region [public] {event} (EventHandler<NotifyFeatureCommandCollectionExecuting>) NotifyFeatureCommandCollectionExecuting: Occurs when the execution of a ICommand associated with a feature starts
        /// <summary>
        /// Occurs when the execution of a <see cref="ICommand"/> associated with a feature starts.
        /// </summary>
        public event EventHandler<NotifyFeatureCommandCollectionExecutingEventArgs> NotifyFeatureCommandCollectionExecuting;
        #endregion

        #region [public] {event} (EventHandler<NotifyFeatureCommandsCollectionFinishEventArgs>) NotifyFeatureCommandsCollectionFinish: Occurs immediately after the execution of the last ICommand in the collection
        /// <summary>
        /// Occurs immediately after the execution of the last <see cref="ICommand"/> in the collection.
        /// </summary>
        public event EventHandler<NotifyFeatureCommandsCollectionFinishEventArgs> NotifyFeatureCommandsCollectionFinish;
        #endregion

        #region [public] {event} (EventHandler<NotifyFeatureCommandsCollectionStartEventArgs>) NotifyFeatureCommandsCollectionStart: Occurs immediately before the execution of the first ICommand of the collection
        /// <summary>
        /// Occurs immediately before the execution of the first <see cref="ICommand"/> of the collection.
        /// </summary>
        public event EventHandler<NotifyFeatureCommandsCollectionStartEventArgs> NotifyFeatureCommandsCollectionStart;
        #endregion

        #endregion

        #region public properties

        #region [public] (bool) InternetInformationServerIsPresent(): Gets a value that indicates if Internet Information Services (IIS) is present in this system
        /// <summary>
        /// Gets a value that indicates if Internet Information Services (IIS) is present in this system.
        /// </summary>
        /// <value>
        /// <b>true</b> if Internet Information Server (IIS) is present on your system; Otherwise <b>false</b>.
        /// </value>
        public bool InternetInformationServerIsPresent { get; internal set; }
        #endregion

        #endregion

        #region public async methods

        #region [public] {async} (Task) ProcessAsync(): Process all the commands in the collection asynchronously
        /// <summary>
        /// Process all the commands in the collection asynchronously.
        /// </summary>
        public async Task ProcessAsync()
        {
            var resultTable = new Dictionary<ICommand, IResult>();

            _index = -1;

            OnNotifyFeatureCommandsCollectionStart(new NotifyFeatureCommandsCollectionStartEventArgs(this));

            foreach (ICommand command in this)
            {
                if (!(command is FeatureCommand featureCommand))
                {
                    continue;
                }

                featureCommand.NotifyFeatureCommandExecuted += NotifyFeatureCommandExecuted;
                featureCommand.NotifyFeatureCommandExecuting += NotifyFeatureCommandExecuting;

                resultTable.Add(featureCommand, await command.ExecuteAsync());
            }

            OnNotifyFeatureCommandsCollectionFinish(new NotifyFeatureCommandsCollectionFinishEventArgs(resultTable.Values.All(t => t.Success) ? BooleanResult.SuccessResult : BooleanResult.CreateErroResult("")));
        }
        #endregion

        #endregion

        #region public methods

        #region [public] (void) Process(): Process all the commands in the collection synchronously
        /// <summary>
        /// Process all the commands in the collection synchronously.
        /// </summary>
        public void Process()
        {
            var resultTable = new Dictionary<ICommand, IResult>();

            _index = -1;

            OnNotifyFeatureCommandsCollectionStart(new NotifyFeatureCommandsCollectionStartEventArgs(this));

            foreach (ICommand command in this)
            {
                if (!(command is FeatureCommand featureCommand))
                {
                    continue;
                }

                featureCommand.NotifyFeatureCommandExecuted += NotifyFeatureCommandExecuted;
                featureCommand.NotifyFeatureCommandExecuting += NotifyFeatureCommandExecuting;

                resultTable.Add(featureCommand, command.Execute());
            }

            OnNotifyFeatureCommandsCollectionFinish(new NotifyFeatureCommandsCollectionFinishEventArgs(resultTable.Values.All(t => t.Success) ? BooleanResult.SuccessResult : BooleanResult.CreateErroResult("")));
        }
        #endregion

        #endregion

        #region protected virtual methods

        #region [protected] {virtual} (void) OnNotifyFeatureCommandCollectionExecuted(NotifyFeatureCommandCollectionExecutedEventArgs): Raises the NotifyFeatureCommandCollectionExecuted event
        /// <summary>
        /// Raises the <see cref="NotifyFeatureCommandCollectionExecuted"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NotifyFeatureCommandCollectionExecutedEventArgs"/> that contains the event data.</param>
        private void OnNotifyFeatureCommandCollectionExecuted(NotifyFeatureCommandCollectionExecutedEventArgs e) => NotifyFeatureCommandCollectionExecuted?.Invoke(this, e);
        #endregion

        #region [protected] {virtual} (void) OnNotifyFeatureCommandCollectionExecuting(NotifyFeatureCommandCollectionExecutingEventArgs): Raises the NotifyFeatureCommandCollectionExecuting event
        /// <summary>
        /// Raises the <see cref="NotifyFeatureCommandCollectionExecuting"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NotifyFeatureCommandCollectionExecutingEventArgs"/> that contains the event data.</param>
        private void OnNotifyFeatureCommandCollectionExecuting(NotifyFeatureCommandCollectionExecutingEventArgs e) => NotifyFeatureCommandCollectionExecuting?.Invoke(this, e);
        #endregion

        #region [protected] {virtual} (void) OnNotifyFeatureCommandsCollectionFinish(NotifyFeatureCommandsCollectionFinishEventArgs): Raises the NotifyFeatureCommandsCollectionFinish event
        /// <summary>
        /// Raises the <see cref="NotifyFeatureCommandsCollectionFinish"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NotifyFeatureCommandsCollectionFinishEventArgs"/> that contains the event data.</param>
        private void OnNotifyFeatureCommandsCollectionFinish(NotifyFeatureCommandsCollectionFinishEventArgs e) => NotifyFeatureCommandsCollectionFinish?.Invoke(this, e);
        #endregion

        #region [protected] {virtual} (void) OnNotifyFeatureCommandsCollectionStart(NotifyFeatureCommandsCollectionStartEventArgs): Raises the NotifyFeatureCommandsCollectionStart event
        /// <summary>
        /// Raises the <see cref="NotifyFeatureCommandsCollectionStart"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NotifyFeatureCommandsCollectionStartEventArgs"/> that contains the event data.</param>
        private void OnNotifyFeatureCommandsCollectionStart(NotifyFeatureCommandsCollectionStartEventArgs e) => NotifyFeatureCommandsCollectionStart?.Invoke(this, e);
        #endregion

        #endregion

        #region private methods

        private void NotifyFeatureCommandExecuted(object sender, NotifyFeatureCommandExecutedEventArgs e)
        {
            OnNotifyFeatureCommandCollectionExecuted(new NotifyFeatureCommandCollectionExecutedEventArgs(_index, Count, e.Feature, e));
        }

        private void NotifyFeatureCommandExecuting(object sender, NotifyFeatureCommandExecutingEventArgs e)
        {
            _index++;
            OnNotifyFeatureCommandCollectionExecuting(new NotifyFeatureCommandCollectionExecutingEventArgs(_index, Count, e.Feature, e));
        }

        #endregion
    }
}
