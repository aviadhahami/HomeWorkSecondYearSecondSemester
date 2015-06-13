using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.Othello.Logic
{
    public class OthelloDisk
    {
        private Location m_Location = Location.Empty;
        private DiskMode m_DiskMode = DiskMode.IlegalMove;
        private event EventHandler<OthelloDiskChangedEventArgs> m_OnDiskChanged = null;

        public OthelloDisk(Location i_Location)
        {
            this.m_Location = i_Location;
        }

        /// Occurs when [on disk changed].
        public event EventHandler<OthelloDiskChangedEventArgs> OnDiskChanged
        {
            add
            {
                this.m_OnDiskChanged += value;
            }
            remove
            {
                this.m_OnDiskChanged -= value;
            }
        }

        /// Gets or sets the disk mode.
        public DiskMode DiskMode
        {
            get { return m_DiskMode; }
            set
            {
                if (m_DiskMode != value)
                {
                    m_DiskMode = value;

                    if (m_OnDiskChanged != null)
                    {
                        m_OnDiskChanged(this, new OthelloDiskChangedEventArgs(m_DiskMode, m_Location));
                    }
                }
            }
        }

        /// Gets the disk location.
        public Location DiskLocation
        {
            get { return m_Location; }
        }

        public override string ToString()
        {
            return string.Format("Mode: {0} Row: {1} Column: {2}", this.DiskMode, this.m_Location.Row, m_Location.Column);
        }
    }
}
