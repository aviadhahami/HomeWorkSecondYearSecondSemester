using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.Othello.Logic
{
    public class OthelloDisk
    {
        private Location m_Location = Location.Empty;
        private DiskMode m_DiskMode = DiskMode.IlegalMove;
        private event EventHandler<OthelloDiskChangedEventArgs> m_OnDiskChanged = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="OthelloDisk"/> class.
        /// </summary>
        /// <param name="i_Location">The location of the disk.</param>
        public OthelloDisk(Location i_Location)
        {
            this.m_Location = i_Location;
        }

        /// <summary>
        /// Occurs when [on disk changed].
        /// </summary>
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

        /// <summary>
        /// Gets or sets the disk mode.
        /// </summary>
        /// <value>
        /// The disk mode.
        /// </value>
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

        /// <summary>
        /// Gets the disk location.
        /// </summary>
        public Location DiskLocation
        {
            get { return m_Location; }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Mode: {0} Row: {1} Column: {2}", this.DiskMode, this.m_Location.Row, m_Location.Column);
        }
    }
}
