using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.Othello.UI
{
    public class GameEventArgs : EventArgs
    {
        private readonly int  m_Size;
        private readonly GameMode m_Mode;

        public GameEventArgs(GameMode i_Mode, int i_Size)
        {
            m_Mode = i_Mode;
            m_Size = i_Size;
        }

        /// Gets the mode.
        public GameMode Mode
        {
            get { return m_Mode; }
        }

        /// Gets the size.
        public int Size
        {
            get { return m_Size; }
        }
    }
}
