using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.Othello.Logic
{
    public struct Location
    {
        private int m_Column;
        private int m_Row;

        /// Initializes a new instance of the <see cref="Location"/> struct.
        /// <param name="i_Column">The column.</param>
        /// <param name="i_Row">The row.</param>
        public Location(int i_Column, int i_Row)
        {
            m_Column = i_Column;
            m_Row = i_Row;
        }

        /// Gets the column.
        public int Column
        {
            get { return m_Column; }
        }

        /// Gets the row.
        public int Row
        {
            get { return m_Row; }
        }

        /// Gets an empty location.
        public static Location Empty
        {
            get { return new Location(0, 0); }
        }
    }
}
