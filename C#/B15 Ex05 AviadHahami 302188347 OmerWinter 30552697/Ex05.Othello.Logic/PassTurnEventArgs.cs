using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.Othello.Logic
{
    public class PassTurnEventArgs : EventArgs
    {
        private DiskMode m_PassedTo;
        private DiskMode m_PassedFrom;

        /// <summary>
        /// Initializes a new instance of the <see cref="PassTurnEventArgs"/> class.
        /// </summary>
        /// <param name="i_PassedFrom">The from mode.</param>
        /// <param name="i_PassedTo">The to mode.</param>
        public PassTurnEventArgs(DiskMode i_PassedFrom, DiskMode i_PassedTo)
        {
            m_PassedTo = i_PassedTo;
            m_PassedFrom = i_PassedFrom;
        }

        /// <summary>
        /// Gets the passed from.
        /// </summary>
        public DiskMode PassedFrom
        {
            get { return m_PassedFrom; }
        }

        /// <summary>
        /// Gets the passed to.
        /// </summary>
        public DiskMode PassedTo
        {
            get { return m_PassedTo; }
        }
    }
}
