using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ex05.Othello.UI
{
    public class NotifyCloseForm : Form
    {
        private event EventHandler<EventArgs> m_OnClose = null;

        /// Occurs when [on close].
        public event EventHandler<EventArgs> OnClose
        {
            add
            {
                this.m_OnClose += value;
            }
            remove
            {
                this.m_OnClose -= value;
            }
        }

        /// Raises the <see cref="E:Closed"/> event.
        /// <param name="i_EventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnClosed(EventArgs i_EventArgs)
        {
            if (m_OnClose != null)
            {
                m_OnClose(this, EventArgs.Empty);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // NotifyCloseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "NotifyCloseForm";
            this.Load += new System.EventHandler(this.NotifyCloseForm_Load);
            this.ResumeLayout(false);

        }

        private void NotifyCloseForm_Load(object sender, EventArgs e)
        {

        }
    }
}
