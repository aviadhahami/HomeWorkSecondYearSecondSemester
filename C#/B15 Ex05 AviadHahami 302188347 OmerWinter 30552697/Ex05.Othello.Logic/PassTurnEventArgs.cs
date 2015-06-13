using System;
using System.Collections.Generic;

namespace Ex05.Othello.Logic
{
    public class PassTurnEventArgs : EventArgs
    {
        private DiskMode m_PassedTo;
        private DiskMode m_PassedFrom;

        /// Initializes a new instance of the <see cref="PassTurnEventArgs"/> class.
        public PassTurnEventArgs(DiskMode i_PassedFrom, DiskMode i_PassedTo)
        {
            m_PassedTo = i_PassedTo;
            m_PassedFrom = i_PassedFrom;
        }

        /// Gets the passed from.
        public DiskMode PassedFrom
        {
            get { return m_PassedFrom; }
        }

        /// Gets the passed to.
        public DiskMode PassedTo
        {
            get { return m_PassedTo; }
        }
    }
}
