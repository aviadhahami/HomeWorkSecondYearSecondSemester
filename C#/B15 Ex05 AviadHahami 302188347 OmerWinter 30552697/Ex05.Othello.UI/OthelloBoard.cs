using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Ex05.Othello.Logic;
using System.Timers;

namespace Ex05.Othello.UI
{
    public class OthelloBoard : NotifyCloseForm
    {
        private int m_BlackWins = 0;
        private int m_WhiteWins = 0;
        private bool m_ComputersTurn = false;
        private static readonly int sr_BoardPadding = 31;
        private static readonly int sr_FirstButtonLocation = 12;
        private static readonly int sr_FormBorderStyleHeight = 22;
        private readonly int r_Size = 0;
        private readonly GameMode r_GameMode = GameMode.AgainstComputer;
        private OthelloLogicBoard m_LogicBoard = null;
        private System.Timers.Timer m_ComputerTurnTimer = null;
        private MethodInvoker m_MakeComputerMoveInvoker = null;

        /// Initializes a new instance of the <see cref="OthelloBoard"/> class.
        /// <param name="i_Size">Size of the Board (Size x Size)</param>
        /// <param name="i_GameMode">The game mode.</param>
        public OthelloBoard(int i_Size, GameMode i_GameMode)
        {
            this.Text = "Othello";
            r_Size = i_Size;
            r_GameMode = i_GameMode;
            this.Size = calculateDimensions();
            m_LogicBoard = new OthelloLogicBoard(i_Size);
            m_LogicBoard.OnGameOver += new EventHandler<EndGameEventArgs>(m_LogicBoard_OnGameOver);
            m_LogicBoard.OnTurnPassed += new EventHandler<PassTurnEventArgs>(m_LogicBoard_OnTurnPassed);
            m_ComputerTurnTimer = new System.Timers.Timer();
            m_ComputerTurnTimer.Interval = 1000;
            m_ComputerTurnTimer.Elapsed += new ElapsedEventHandler(m_ComputerTurnTimer_Elapsed);
            m_MakeComputerMoveInvoker = makeComputerMove;
            drawButttons();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            m_LogicBoard.NewGame();

            // For fun :)
            this.Icon = Othello.UI.Properties.Resources.dog;
            this.Show();
        }

        /// Handles the Elapsed event of the m_ComputerTurnTimer control.
        private void m_ComputerTurnTimer_Elapsed(object i_Sender, ElapsedEventArgs i_ElapsedEventArgs)
        {
            m_ComputerTurnTimer.Enabled = false;
            BeginInvoke(m_MakeComputerMoveInvoker);
        }

        /// Makes the computer move.
        private void makeComputerMove()
        {
            OthelloDisk computersDisk = getRandomMove();
            m_LogicBoard.MakeMove(computersDisk.DiskLocation.Column, computersDisk.DiskLocation.Row);
            m_ComputersTurn = false;
        }

        /// Handles the OnTurnPassed event of the m_LogicBoard control.
        private void m_LogicBoard_OnTurnPassed(object i_Sender, PassTurnEventArgs i_PassTurnEventArgs)
        {
            DiskMode passedFrom = i_PassTurnEventArgs.PassedFrom;
            DiskMode passedTo = i_PassTurnEventArgs.PassedTo;

            string message = string.Format("The {0} Player does not have any valid moves.\nThe current move has been passed to {1}", passedFrom, passedTo);
            MessageBox.Show(message, "Othello", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// Handles the OnGameOver event of the m_LogicBoard control.
        private void m_LogicBoard_OnGameOver(object i_Sender, EndGameEventArgs i_EndGameEventArgs)
        {
            DiskMode winner = i_EndGameEventArgs.Winner;
            int winnerCount = i_EndGameEventArgs.WinnerCount;
            int loserCount = i_EndGameEventArgs.LoserCount;
            string message = string.Empty;

            if (i_EndGameEventArgs.HasWinner)
            {
                if (winner == DiskMode.Black)
                {
                    m_BlackWins++;
                }
                else
                {
                    m_WhiteWins++;
                }

                message = string.Format("{0} Won!! ({1}/{2}) ({3}/{4})\nWould you like another round?", winner, winnerCount, loserCount, m_BlackWins, m_WhiteWins);
            }
            else
            {
                message = string.Format("Draw!! ({0}/{0}) ({1}/{2})\nWould you like another round?", winnerCount, m_BlackWins, m_WhiteWins);
            }

            DialogResult dialogResult = MessageBox.Show(message, "Othello", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.OK)
            {
                m_LogicBoard.NewGame();
            }
            else
            {
                this.Close();
            }
        }

        /// Calculates the dimensions.
        private Size calculateDimensions()
        {
            int buttonsSize = OthelloButton.ButtonSize * r_Size;
            int totalSize = buttonsSize + sr_BoardPadding;

            return new Size(totalSize, totalSize + sr_FormBorderStyleHeight);
        }

        /// Draws the butttons.
        private void drawButttons()
        {
            int top = sr_FirstButtonLocation;

            for (int row = 0; row < r_Size; row++)
            {
                int column = 0;
                int left = sr_FirstButtonLocation;

                do
                {
                    OthelloDisk othelloDisk = null;
                    OthelloButton button = new OthelloButton(column, row);

                    button.Click += new EventHandler(button_Click);
                    button.Location = new Point(left, top);
                    othelloDisk = m_LogicBoard[column, row];

                    othelloDisk.OnDiskChanged += delegate(object i_Sender, OthelloDiskChangedEventArgs i_EventArgs)
                    {
                        changeButtonDisplay(button, i_EventArgs.Mode);
                    };

                    this.Controls.Add(button);
                    left += OthelloButton.ButtonSize;
                    column++;
                }
                while (column < r_Size);

                top += OthelloButton.ButtonSize;
            }
        }

        /// Handles the Click event of the button control.
        private void button_Click(object i_Sender, EventArgs i_EventArgs)
        {
            if (!m_ComputersTurn)
            {
                OthelloButton button = i_Sender as OthelloButton;

                m_LogicBoard.MakeMove(button.Column, button.Row);

                if (r_GameMode == GameMode.AgainstComputer)
                {
                    m_ComputersTurn = true;
                    m_ComputerTurnTimer.Enabled = true;
                }
            }
        }

        /// Gets the random move.
        private OthelloDisk getRandomMove()
        {
            List<OthelloDisk> optionalMoves = m_LogicBoard.OptionalMoves;
            Random random = new Random();
            int randomIndex = random.Next(0, optionalMoves.Count - 1);

            return optionalMoves[randomIndex];
        }

        /// Changes the button display.
        private void changeButtonDisplay(OthelloButton i_OthelloButton, DiskMode i_DiskMode)
        {
            switch (i_DiskMode)
            {
                case DiskMode.IlegalMove:

                    i_OthelloButton.Disable();
                    break;

                case DiskMode.Black:

                    i_OthelloButton.ConvertToBlack();
                    break;

                case DiskMode.White:

                    i_OthelloButton.ConvertToWhite();
                    break;

                case DiskMode.OptionalMove:

                    i_OthelloButton.ConvertToOptional();
                    break;
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OthelloBoard));
            this.SuspendLayout();

            // OthelloBoard
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OthelloBoard";
            this.Load += new System.EventHandler(this.OthelloBoard_Load);
            this.ResumeLayout(false);

        }

        private void OthelloBoard_Load(object sender, EventArgs e)
        {

        }
    }
}
