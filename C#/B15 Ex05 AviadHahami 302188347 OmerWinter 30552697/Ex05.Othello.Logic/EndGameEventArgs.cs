using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex05.Othello.Logic
{
    public class EndGameEventArgs : EventArgs
    {
        private readonly DiskMode m_Winner;
        private readonly int m_WinnerCount;
        private readonly int m_LoserCount;
        private readonly bool m_HasWinner;

        /// <summary>
        /// Initializes a new instance of the <see cref="EndGameEventArgs"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets the winner.
        /// </summary>
        public DiskMode Winner
        {
            get { return m_Winner; }
        }

        /// <summary>
        /// Gets the winner count.
        /// </summary>
        public int WinnerCount
        {
            get { return m_WinnerCount; }
        }

        /// <summary>
        /// Gets the loser count.
        /// </summary>
        public int LoserCount
        {
            get { return m_LoserCount; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has winner.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has winner; otherwise, <c>false</c>.
        /// </value>
        public bool HasWinner
        {
            get { return m_HasWinner; }
        }
    }
}
