using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Ex05.Othello.UI
{
    public class UIManager : ApplicationContext
    {
        private GameSettings m_GameSettings = null;
        private OthelloBoard m_OthelloBoard = null;

        public UIManager()
        {
            m_GameSettings = new GameSettings();
            m_GameSettings.OnSettingsChanged += new EventHandler<GameEventArgs>(m_GameSettings_OnSettingsChanged);
            m_GameSettings.OnClose += new EventHandler<EventArgs>(UIManager_OnClose);
            m_GameSettings.Show();
        }

        /// Handles the OnClose event of the UIManager control.
        private void UIManager_OnClose(object i_Sender, EventArgs i_EventArgs)
        {
            Application.Exit();
        }

        /// Handles the OnSettingsChanged event of the m_GameSettings control.
        private void m_GameSettings_OnSettingsChanged(object i_Sender, GameEventArgs i_GameEventArgs)
        {   
            //Because the instance didn't set the main form the application won't close when the form is closed  Removes the on close event for the program to not to exit.
            m_GameSettings.OnClose -= new EventHandler<EventArgs>(UIManager_OnClose);
            m_GameSettings.Close();
            m_OthelloBoard = new OthelloBoard(i_GameEventArgs.Size, i_GameEventArgs.Mode);
            m_OthelloBoard.OnClose += new EventHandler<EventArgs>(UIManager_OnClose);
            m_OthelloBoard.Show();
        }
    }
}
