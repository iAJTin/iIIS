
namespace iTin.AspNet.Web.IIS.ComponentModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;

    using iTin.Core.Min.ComponentModel;

    using Design;

    /// <summary>
    /// Class that defines a commands collection.
    /// </summary>
    public class FeatureCommandsCollection : Collection<ICommand>
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

        #region [public] {event} (EventHandler<NotifyFeatureCommandCollectionExecuting>) NotifyFeatureCommandCollectionExecuting: Occurs when the execution of a command associated with a feature starts
        /// <summary>
        /// Occurs when the execution of a command associated with a feature starts.
        /// </summary>
        public event EventHandler<NotifyFeatureCommandCollectionExecutingEventArgs> NotifyFeatureCommandCollectionExecuting;
        #endregion

        #region [public] {event} (EventHandler<NotifyFeatureCommandsCollectionFinishEventArgs>) NotifyFeatureCommandsCollectionFinish: Occurs immediately after the execution of the last command in the collection
        /// <summary>
        /// Occurs immediately after the execution of the last command in the collection.
        /// </summary>
        public event EventHandler<NotifyFeatureCommandsCollectionFinishEventArgs> NotifyFeatureCommandsCollectionFinish;
        #endregion

        #region [public] {event} (EventHandler<NotifyFeatureCommandsCollectionStartEventArgs>) NotifyFeatureCommandsCollectionStart: Occurs immediately before the execution of the first command of the collection
        /// <summary>
        /// Occurs immediately before the execution of the first command of the collection.
        /// </summary>
        public event EventHandler<NotifyFeatureCommandsCollectionStartEventArgs> NotifyFeatureCommandsCollectionStart;
        #endregion

        #endregion

        #region public methods

        #region [public] (void) Process(): Process all the commands in the collection
        /// <summary>
        /// Process all the commands in the collection.
        /// </summary>
        public void Process()
        {
            var resultTable = new Dictionary<ICommand, IResult>();

            _index = 0;

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

            OnNotifyFeatureCommandsCollectionFinish(new NotifyFeatureCommandsCollectionFinishEventArgs(resultTable.Values.All(t => t.Success == true) ? ResultBase.SuccessResult : ResultBase.ErrorResult));
        }
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

        #region [protected] {virtual} (void) OnNotifyFeatureCommandCollectionExecuting(NotifyFeatureCommandCollectionExecutingEventArgs): Generates the NotifyFeatureCommandCollectionExecuting event
        /// <summary>
        /// Generates the <see cref="NotifyFeatureCommandCollectionExecuting"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NotifyFeatureCommandCollectionExecutingEventArgs"/> with the event data.</param>
        protected virtual void OnNotifyFeatureCommandCollectionExecuting(NotifyFeatureCommandCollectionExecutingEventArgs e) => NotifyFeatureCommandCollectionExecuting?.Invoke(this, e);
        #endregion

        #region [protected] {virtual} (void) OnNotifyFeatureCommandsCollectionFinish(NotifyFeatureCommandsCollectionFinishEventArgs): Generates the NotifyFeatureCommandsCollectionFinish event
        /// <summary>
        /// Generates the <see cref="NotifyFeatureCommandsCollectionFinish"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NotifyFeatureCommandsCollectionFinishEventArgs"/> with the event data.</param>
        protected virtual void OnNotifyFeatureCommandsCollectionFinish(NotifyFeatureCommandsCollectionFinishEventArgs e) => NotifyFeatureCommandsCollectionFinish?.Invoke(this, e);
        #endregion

        #region [protected] {virtual} (void) OnNotifyFeatureCommandsCollectionStart(NotifyFeatureCommandsCollectionStartEventArgs): Generates the NotifyFeatureCommandsCollectionStart event
        /// <summary>
        /// Generates the <see cref="NotifyFeatureCommandsCollectionStart"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NotifyFeatureCommandsCollectionStartEventArgs"/> with the event data.</param>
        protected virtual void OnNotifyFeatureCommandsCollectionStart(NotifyFeatureCommandsCollectionStartEventArgs e) => NotifyFeatureCommandsCollectionStart?.Invoke(this, e);
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
