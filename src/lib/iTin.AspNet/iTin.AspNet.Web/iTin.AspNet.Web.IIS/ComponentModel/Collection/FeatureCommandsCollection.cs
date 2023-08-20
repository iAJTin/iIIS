
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using iTin.Core.ComponentModel;
using iTin.Core.ComponentModel.Results;

using iTin.AspNet.Web.IIS.ComponentModel.Design;

namespace iTin.AspNet.Web.IIS.ComponentModel;

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

    /// <summary>
    /// Occurs when a <see cref="ICommand"/> in the collection has been executed.
    /// </summary>
    public event EventHandler<NotifyFeatureCommandCollectionExecutedEventArgs> NotifyFeatureCommandCollectionExecuted;

    /// <summary>
    /// Occurs when the execution of a <see cref="ICommand"/> associated with a feature starts.
    /// </summary>
    public event EventHandler<NotifyFeatureCommandCollectionExecutingEventArgs> NotifyFeatureCommandCollectionExecuting;

    /// <summary>
    /// Occurs immediately after the execution of the last <see cref="ICommand"/> in the collection.
    /// </summary>
    public event EventHandler<NotifyFeatureCommandsCollectionFinishEventArgs> NotifyFeatureCommandsCollectionFinish;

    /// <summary>
    /// Occurs immediately before the execution of the first <see cref="ICommand"/> of the collection.
    /// </summary>
    public event EventHandler<NotifyFeatureCommandsCollectionStartEventArgs> NotifyFeatureCommandsCollectionStart;

    #endregion

    #region public properties

    /// <summary>
    /// Gets a value that indicates if Internet Information Services (IIS) is present in this system.
    /// </summary>
    /// <value>
    /// <b>true</b> if Internet Information Server (IIS) is present on your system; Otherwise <b>false</b>.
    /// </value>
    public bool InternetInformationServerIsPresent { get; internal set; }

    #endregion

    #region public async methods

    /// <summary>
    /// Process all the commands in the collection asynchronously.
    /// </summary>
    public async Task ProcessAsync()
    {
        var resultTable = new Dictionary<ICommand, IResult>();

        _index = -1;

        OnNotifyFeatureCommandsCollectionStart(new NotifyFeatureCommandsCollectionStartEventArgs(this));

        foreach (var command in this)
        {
            if (command is not FeatureCommand featureCommand)
            {
                continue;
            }

            featureCommand.NotifyFeatureCommandExecuted += NotifyFeatureCommandExecuted;
            featureCommand.NotifyFeatureCommandExecuting += NotifyFeatureCommandExecuting;

            resultTable.Add(featureCommand, await command.ExecuteAsync());
        }

        OnNotifyFeatureCommandsCollectionFinish(new NotifyFeatureCommandsCollectionFinishEventArgs(resultTable.Values.All(t => t.Success) ? BooleanResult.SuccessResult : BooleanResult.CreateErrorResult("")));
    }

    #endregion

    #region public methods

    /// <summary>
    /// Process all the commands in the collection synchronously.
    /// </summary>
    public void Process()
    {
        var resultTable = new Dictionary<ICommand, IResult>();

        _index = -1;

        OnNotifyFeatureCommandsCollectionStart(new NotifyFeatureCommandsCollectionStartEventArgs(this));

        foreach (var command in this)
        {
            if (command is not FeatureCommand featureCommand)
            {
                continue;
            }

            featureCommand.NotifyFeatureCommandExecuted += NotifyFeatureCommandExecuted;
            featureCommand.NotifyFeatureCommandExecuting += NotifyFeatureCommandExecuting;

            resultTable.Add(featureCommand, command.Execute());
        }

        OnNotifyFeatureCommandsCollectionFinish(new NotifyFeatureCommandsCollectionFinishEventArgs(resultTable.Values.All(t => t.Success) ? BooleanResult.SuccessResult : BooleanResult.CreateErrorResult("")));
    }

    #endregion

    #region protected virtual methods

    /// <summary>
    /// Raises the <see cref="NotifyFeatureCommandCollectionExecuted"/> event.
    /// </summary>
    /// <param name="e">A <see cref="NotifyFeatureCommandCollectionExecutedEventArgs"/> that contains the event data.</param>
    private void OnNotifyFeatureCommandCollectionExecuted(NotifyFeatureCommandCollectionExecutedEventArgs e) => NotifyFeatureCommandCollectionExecuted?.Invoke(this, e);

    /// <summary>
    /// Raises the <see cref="NotifyFeatureCommandCollectionExecuting"/> event.
    /// </summary>
    /// <param name="e">A <see cref="NotifyFeatureCommandCollectionExecutingEventArgs"/> that contains the event data.</param>
    private void OnNotifyFeatureCommandCollectionExecuting(NotifyFeatureCommandCollectionExecutingEventArgs e) => NotifyFeatureCommandCollectionExecuting?.Invoke(this, e);

    /// <summary>
    /// Raises the <see cref="NotifyFeatureCommandsCollectionFinish"/> event.
    /// </summary>
    /// <param name="e">A <see cref="NotifyFeatureCommandsCollectionFinishEventArgs"/> that contains the event data.</param>
    private void OnNotifyFeatureCommandsCollectionFinish(NotifyFeatureCommandsCollectionFinishEventArgs e) => NotifyFeatureCommandsCollectionFinish?.Invoke(this, e);

    /// <summary>
    /// Raises the <see cref="NotifyFeatureCommandsCollectionStart"/> event.
    /// </summary>
    /// <param name="e">A <see cref="NotifyFeatureCommandsCollectionStartEventArgs"/> that contains the event data.</param>
    private void OnNotifyFeatureCommandsCollectionStart(NotifyFeatureCommandsCollectionStartEventArgs e) => NotifyFeatureCommandsCollectionStart?.Invoke(this, e);

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
