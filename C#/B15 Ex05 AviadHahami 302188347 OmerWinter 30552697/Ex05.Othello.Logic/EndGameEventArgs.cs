using System;
using System.Collections.Generic;
using System.Text;

namespace Ex05.Othello.Logic
{
    public class EndGameEventArgs : EventArgs
    {
        private readonly DiskMode m_Winner;
        private readonly int m_WinnerCount;
        private readonly int m_LoserCount;
        private readonly bool m_HasWinner;

        /// Initializes a new instance of the <see cref="EndGameEventArgs"/> class.
        /// <param name="i_Winner">The winner.</param>
        /// <param name="i_WinnerCount">The winner's point count.</param>
        /// <param name="i_LoserCount">The loser's point count.</param>
        public EndGameEventArgs(DiskMode i_Winner, int i_WinnerCount, int i_LoserCount)
        {
            m_Winner = i_Winner;
            m_WinnerCount = i_WinnerCount;
            m_LoserCount = i_LoserCount;
            m_HasWinner = i_WinnerCount != i_LoserCount;
        }

        /// Gets the winner.
        public DiskMode Winner
        {
            get { return m_Winner; }
        }

        /// Gets the winner count.
        public int WinnerCount
        {
            get { return m_WinnerCount; }
        }

        /// Gets the loser count.
        public int LoserCount
        {
            get { return m_LoserCount; }
        }

        /// Gets a value indicating whether this instance has winner.
        /// true if this instance has winner; otherwise, false.
        public bool HasWinner
        {
            get { return m_HasWinner; }
        }
    }
}
