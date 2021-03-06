﻿using System;
using System.Collections.Generic;

namespace Ex05.Othello.Logic
{
    public class OthelloLogicBoard
    {
        private readonly int r_Size = 0;
        private OthelloDisk[,] m_OthelloDisks = null;
        private List<OthelloDisk> m_OptionalMoves = null;
        private static readonly int sr_NoOptionalMoves = 0;
        private DiskMode m_CurrentDiskMode = DiskMode.Black;
        private event EventHandler<EndGameEventArgs> m_OnGameOver = null;
        private event EventHandler<PassTurnEventArgs> m_OnTurnPassed = null;

        public OthelloLogicBoard(int i_Size)
        {
            r_Size = i_Size;
            m_OptionalMoves = new List<OthelloDisk>();
            this.m_OthelloDisks = new OthelloDisk[i_Size, i_Size];

            for (int row = 0; row < r_Size; row++)
            {
                for (int col = 0; col < r_Size; col++)
                {
                    Location diskLocation = new Location(row, col);
                    OthelloDisk disk = new OthelloDisk(diskLocation);
                    this.m_OthelloDisks[row, col] = disk;
                }
            }
        }

        /// Gets the optional moves.
        public List<OthelloDisk> OptionalMoves
        {
            get { return m_OptionalMoves; }
        }

        public OthelloDisk this[int i_Column, int i_Row]
        {
            get { return m_OthelloDisks[i_Column, i_Row]; }
        }

        /// Occurs when [on game over].
        public event EventHandler<EndGameEventArgs> OnGameOver
        {
            add
            {
                m_OnGameOver += value;
            }
            remove
            {
                m_OnGameOver -= value;
            }
        }

        /// Occurs when [on turn passed].
        public event EventHandler<PassTurnEventArgs> OnTurnPassed
        {
            add
            {
                m_OnTurnPassed += value;
            }
            remove
            {
                m_OnTurnPassed -= value;
            }
        }

        /// Creates a new game.
        public void NewGame()
        {
            int halfSize = r_Size / 2;

            for (int i = 0; i < r_Size; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    this.m_OthelloDisks[i, j].DiskMode = DiskMode.IlegalMove;
                }
            }

            //Intialize disks according to the chosen size.
            this.m_OthelloDisks[halfSize - 1, halfSize - 1].DiskMode = DiskMode.White;
            this.m_OthelloDisks[halfSize - 1, halfSize].DiskMode = DiskMode.Black;
            this.m_OthelloDisks[halfSize, halfSize - 1].DiskMode = DiskMode.Black;
            this.m_OthelloDisks[halfSize, halfSize].DiskMode = DiskMode.White;

            m_OptionalMoves.Add(this.m_OthelloDisks[halfSize - 1, halfSize - 2]);
            m_OptionalMoves.Add(this.m_OthelloDisks[halfSize - 2, halfSize - 1]);
            m_OptionalMoves.Add(this.m_OthelloDisks[halfSize, halfSize + 1]);
            m_OptionalMoves.Add(this.m_OthelloDisks[halfSize + 1, halfSize]);

            foreach (OthelloDisk disk in m_OptionalMoves)
            {
                disk.DiskMode = DiskMode.OptionalMove;
            }
        }

        /// Makes the move.
        public void MakeMove(int i_Column, int i_Row)
        {
            int row = 0;
            int column = 0;
            DiskMode oppositeMode = getOppositeMode(m_CurrentDiskMode);
            this[i_Column, i_Row].DiskMode = m_CurrentDiskMode;

            //Iterate all direction in order to find all options the flip the disks.
            for (int rowIncrementor = -1; rowIncrementor <= 1; rowIncrementor++)
            {
                for (int columnIncrementor = -1; columnIncrementor <= 1; columnIncrementor++)
                {
                    if (!(rowIncrementor == 0 && columnIncrementor == 0) && canConvertTo(m_CurrentDiskMode, i_Row, i_Column, rowIncrementor, columnIncrementor))
                    {
                        row = i_Row + rowIncrementor;
                        column = i_Column + columnIncrementor;

                        while (this[column, row].DiskMode == oppositeMode)
                        {
                            this[column, row].DiskMode = m_CurrentDiskMode;
                            row += rowIncrementor;
                            column += columnIncrementor;
                        }
                    }
                }
            }
            m_CurrentDiskMode = oppositeMode;
            calculateValidMoves();
        }

        /// Determines whether [is valid move] [the specified i_ disk mode].
        /// true if is valid move the specified disk mode; otherwise, false.
        private bool isValidMove(DiskMode i_DiskMode, int i_Column, int i_Row)
        {
            if (this[i_Column, i_Row].DiskMode == DiskMode.IlegalMove)
            {
                for (int rowIncrementor = -1; rowIncrementor <= 1; rowIncrementor++)
                {
                    for (int columnIncrementor = -1; columnIncrementor <= 1; columnIncrementor++)
                    {
                        if (!(rowIncrementor == 0 && columnIncrementor == 0) && this.canConvertTo(i_DiskMode, i_Row, i_Column, rowIncrementor, columnIncrementor))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// Calculates the valid moves.
        private void calculateValidMoves()
        {
            bool hasOptionalMoves = false;
            DiskMode initialDiskMode = m_CurrentDiskMode;
            clearValidMoves();

            hasOptionalMoves = tryCalculateValidMoves(m_CurrentDiskMode);

            if (!hasOptionalMoves)
            {
                //Check the other player's optional moves.
                m_CurrentDiskMode = getOppositeMode(m_CurrentDiskMode);
                hasOptionalMoves = tryCalculateValidMoves(m_CurrentDiskMode);

                //Other player has optional move notify for passing the turn to the other player.
                if (hasOptionalMoves)
                {
                    if (m_OnTurnPassed != null)
                    {
                        PassTurnEventArgs eventArgs = new PassTurnEventArgs(initialDiskMode, m_CurrentDiskMode);
                        m_OnTurnPassed(this, eventArgs);
                    }
                }
            }

            //Both players don't have optional moves, hence, end the game.
            if (m_OptionalMoves.Count == sr_NoOptionalMoves)
            {
                handleGameOver();
            }
        }

        /// Tries the calculate valid moves.
        private bool tryCalculateValidMoves(DiskMode i_DiskMode)
        {
            for (int row = 0; row < r_Size; row++)
            {
                for (int column = 0; column < r_Size; column++)
                {
                    if (this.isValidMove(i_DiskMode, column, row))
                    {
                        OthelloDisk disk = this[column, row];

                        disk.DiskMode = DiskMode.OptionalMove;
                        m_OptionalMoves.Add(disk);
                    }
                }
            }

            return m_OptionalMoves.Count > 0;
        }

        /// Handles the game over.
        private void handleGameOver()
        {
            if (m_OnGameOver != null)
            {
                int winnerCount;
                int loserCount;
                DiskMode winnerDiskMode;
                EndGameEventArgs gameEndEventArgs = null;

                winnerDiskMode = countDisks(out winnerCount, out loserCount);
                gameEndEventArgs = new EndGameEventArgs(winnerDiskMode, winnerCount, loserCount);
                m_OnGameOver(this, gameEndEventArgs);
            }
        }

        /// Counts the disks.
        private DiskMode countDisks(out int io_WinnerCount, out int io_LoserCount)
        {
            int blackCount = 0;
            int whiteCount = 0;
            DiskMode winnerDiskMode;

            io_WinnerCount = 0;
            io_LoserCount = 0;

            for (int row = 0; row < r_Size; row++)
            {
                for (int column = 0; column < r_Size; column++)
                {
                    OthelloDisk disk = this[column, row];

                    if (disk.DiskMode == DiskMode.Black)
                    {
                        blackCount++;
                    }
                    else if (disk.DiskMode == DiskMode.White)
                    {
                        whiteCount++;
                    }
                }
            }

            if (blackCount > whiteCount)
            {
                winnerDiskMode = DiskMode.Black;
                io_WinnerCount = blackCount;
                io_LoserCount = whiteCount;
            }
            else
            {
                winnerDiskMode = DiskMode.White;
                io_WinnerCount = whiteCount;
                io_LoserCount = blackCount;
            }

            return winnerDiskMode;
        }

        /// Clears the valid moves.
        private void clearValidMoves()
        {
            foreach (OthelloDisk disk in m_OptionalMoves)
            {
                if (disk.DiskMode == DiskMode.OptionalMove)
                {
                    disk.DiskMode = DiskMode.IlegalMove;
                }
            }

            m_OptionalMoves.Clear();
        }

        /// Determines whether this instance [can convert to] the specified disk mode.
        /// true if this instance can convert to the specified disk mode; otherwise, false.
        private bool canConvertTo(DiskMode i_DiskMode, int i_StartRow, int i_StartColumn, int i_RowIncrementor, int i_ColumnIncrementor)
        {
            // Try to find oponenet's disk
            int row = i_StartRow + i_RowIncrementor;
            int column = i_StartColumn + i_ColumnIncrementor;

            DiskMode oppositeMode = getOppositeMode(i_DiskMode);

            while (row >= 0 && row < r_Size && column >= 0 && column < r_Size && this[column, row].DiskMode == oppositeMode)
            {
                row += i_RowIncrementor;
                column += i_ColumnIncrementor;
            }

            //An oponenet's disk has not been flipped
            if (row < 0 || row > r_Size - 1 || column < 0 || column > r_Size - 1 || (row - i_RowIncrementor == i_StartRow && column - i_ColumnIncrementor == i_StartColumn) || this[column, row].DiskMode != i_DiskMode)
                return false;

            return true;
        }

        /// Gets the opposite mode.
        private DiskMode getOppositeMode(DiskMode i_DiskMode)
        {
            return i_DiskMode == DiskMode.Black ? DiskMode.White : DiskMode.Black;
        }

        public string CurrentTurn
        {
            get
            {
                return m_CurrentDiskMode.ToString();
            }
        }
    }
}
