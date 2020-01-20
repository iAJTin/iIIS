﻿
namespace Syntec.Core.ComponentModel
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class Messages.
    /// </summary>
    public class Messages
    {
        #region private readonly members
        private readonly List<string> _msgs;
        #endregion

        #region constructor/s
        /// <summary>
        /// Initializes a new instance of the <see cref="Messages"/> class.
        /// </summary>
        public Messages() => _msgs = new List<string>();
        #endregion

        #region public methods
        /// <summary>
        /// Adds the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Add(string message) => _msgs.Add(message);
        
        /// <summary>
        /// Adds the specified messages.
        /// </summary>
        /// <param name="messages">The messages.</param>
        public void Add(Messages messages) => _msgs.AddRange(messages.GetMessages());

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Count() => _msgs.Count;

        /// <summary>
        /// Gets the messages.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public IEnumerable<string> GetMessages() => _msgs;

        /// <summary>
        /// To the HTML.
        /// </summary>
        /// <returns>System.String.</returns>
        public string ToHtml()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<ul class=\"messages\">");
            _msgs.ForEach(it => sb.Append("<li>").Append(it).Append("</li>"));
            sb.AppendLine("</ul>");
            return sb.ToString();
        }

        /// <summary>
        /// To the HTML.
        /// </summary>
        /// <param name="ccsClass">The class.</param>
        /// <returns>System.String.</returns>
        public string ToHtml(string ccsClass)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<ul class=\"" + ccsClass + "\">");
            _msgs.ForEach(it => sb.Append("<li>").Append(it).Append("</li>"));
            sb.AppendLine("</ul>");
            return sb.ToString();
        }
        #endregion
    }
}
