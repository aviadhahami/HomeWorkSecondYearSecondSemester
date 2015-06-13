using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05.Othello.UI
{
    public class GameSettings : NotifyCloseForm
    {
        private int m_BoardSize = 0;
        private int m_MinBoardSize = 6;
        private int m_MaxBoardSize = 14;
        public Button m_BoardSizeButton = null;
        public Button m_PlayAgainstFriendButton = null;
        public Button m_PlayAgainstComputerButton = null;
        private event EventHandler<GameEventArgs> m_OnSettingsChanged = null;

        /// Initializes a new instance of the <see cref="GameSettings"/> class.
        public GameSettings()
        {
            m_BoardSize = m_MinBoardSize;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.Text = "Othello - Pre-Game Settings";
            this.Size = new Size(308, 148);

            intializeButtons();
        }

        /// Occurs when [on settings changed].
        public event EventHandler<GameEventArgs> OnSettingsChanged
        {
            add
            {
                this.m_OnSettingsChanged += value;
            }
            remove
            {
                this.m_OnSettingsChanged -= value;
            }
        }

        /// Intializes the buttons.
        private void intializeButtons()
        {
            m_BoardSizeButton = new Button();
            m_PlayAgainstFriendButton = new Button();
            m_PlayAgainstComputerButton = new Button();

            m_BoardSizeButton.Location = new Point(21, 21);
            m_BoardSizeButton.Size = new Size(262, 34);
            m_BoardSizeButton.Click += new EventHandler(m_BoardSizeButton_Click);
            setBoardSizeText();

            m_PlayAgainstFriendButton.Location = new Point(155, 73);
            m_PlayAgainstFriendButton.Size = new Size(128, 34);
            m_PlayAgainstFriendButton.Text = "Play against another user";
            m_PlayAgainstFriendButton.Click += new EventHandler(m_PlayAgainstFriendButton_Click);

            m_PlayAgainstComputerButton.Location = new Point(21, 73);
            m_PlayAgainstComputerButton.Size = new Size(128, 34);
            m_PlayAgainstComputerButton.Text = "Challenge our AI monkeys";
            m_PlayAgainstComputerButton.Click += new EventHandler(m_PlayAgainstComputerButton_Click);

            this.Controls.Add(m_BoardSizeButton);
            this.Controls.Add(m_PlayAgainstFriendButton);
            this.Controls.Add(m_PlayAgainstComputerButton);
        }

        /// Handles the Click event of the m_BoardSizeButton control.
        /// <param name="i_Sender">The source of the event.</param>
        /// <param name="i_EventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void m_BoardSizeButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            if (m_BoardSize == m_MaxBoardSize)
            {
                m_BoardSize = m_MinBoardSize;
            }
            else
            {
                m_BoardSize++;
            }

            setBoardSizeText();
        }

        /// Handles the Click event of the m_PlayAgainstComputerButton control.
        /// <param name="i_Sender">The source of the event.</param>
        /// <param name="i_EventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void m_PlayAgainstComputerButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            if (m_OnSettingsChanged != null)
            {   
                GameMode mode = GameMode.AgainstComputer;
                m_OnSettingsChanged(i_Sender, new GameEventArgs(mode, m_BoardSize));
            }
        }

        /// Handles the Click event of the m_PlayAgainstFriendButton control.
        /// <param name="i_Sender">The source of the event.</param>
        /// <param name="i_EventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void m_PlayAgainstFriendButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            if (m_OnSettingsChanged != null)
            {
                GameMode mode = GameMode.AgainstFriend;
                m_OnSettingsChanged(i_Sender, new GameEventArgs(mode, m_BoardSize));
            }
        }

        /// Sets the board size text.
        private void setBoardSizeText()
        {
            m_BoardSizeButton.Text = string.Format("Board Size {0}x{0} (Click To Increase)", m_BoardSize);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameSettings
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "GameSettings";
            this.Load += new System.EventHandler(this.GameSettings_Load);
            this.ResumeLayout(false);

        }

        private void GameSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
