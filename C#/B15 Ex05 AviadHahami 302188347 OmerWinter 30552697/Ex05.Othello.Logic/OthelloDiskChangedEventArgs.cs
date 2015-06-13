using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.Othello.Logic
{
    public class OthelloDiskChangedEventArgs : EventArgs
    {   
        private readonly DiskMode m_Mode;
        private readonly Location m_Location;

        /// <summary>
        /// Initializes a new instance of the <see cref="OthelloDiskChangedEventArgs"/> class.
        /// </summary>
        /// <param name="i_Mode">The disk mode.</param>
        /// <param name="i_Location">The location of the disk.</param>
        public OthelloDiskChangedEventArgs(DiskMode i_Mode, Location i_Location)
        {
            m_Mode = i_Mode;
            m_Location = i_Location;
        }

        /// <summary>
        /// Gets the disk mode.
        /// </summary>
        public DiskMode Mode
        {
            get { return m_Mode; }
        }

        /// <summary>
        /// Gets the location of the disk.
        /// </summary>
        public Location Location
        {
            get { return m_Location; }
        }
    }
}
