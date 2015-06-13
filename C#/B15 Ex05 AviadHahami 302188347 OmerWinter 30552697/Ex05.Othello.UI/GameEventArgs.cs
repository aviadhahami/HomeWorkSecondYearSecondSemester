using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.Othello.UI
{
    public class GameEventArgs : EventArgs
    {
        private readonly int  m_Size;
        private readonly GameMode m_Mode;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEventArgs"/> class.
        /// </summary>
        /// <param name="i_Mode">The game mode.</param>
        /// <param name="i_Size">Size of the board (Size x Size).</param>
        public GameEventArgs(GameMode i_Mode, int i_Size)
        {
            m_Mode = i_Mode;
            m_Size = i_Size;
        }

        /// <summary>
        /// Gets the mode.
        /// </summary>
        public GameMode Mode
        {
            get { return m_Mode; }
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        public int Size
        {
            get { return m_Size; }
        }
    }
}
