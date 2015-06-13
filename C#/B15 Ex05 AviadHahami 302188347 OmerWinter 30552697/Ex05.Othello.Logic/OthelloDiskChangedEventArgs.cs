using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.Othello.Logic
{
    public class OthelloDiskChangedEventArgs : EventArgs
    {   
        private readonly DiskMode m_Mode;
        private readonly Location m_Location;

        public OthelloDiskChangedEventArgs(DiskMode i_Mode, Location i_Location)
        {
            m_Mode = i_Mode;
            m_Location = i_Location;
        }

        /// Gets the disk mode.
        public DiskMode Mode
        {
            get { return m_Mode; }
        }

        /// Gets the location of the disk.
        public Location Location
        {
            get { return m_Location; }
        }
    }
}
