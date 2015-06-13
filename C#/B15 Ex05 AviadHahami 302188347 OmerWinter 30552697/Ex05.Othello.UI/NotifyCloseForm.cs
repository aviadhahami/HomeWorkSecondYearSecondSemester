using System;
using System.Collections.Generic;
using System.Drawing;
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

        protected override void OnClosed(EventArgs i_EventArgs)
        {
            if (m_OnClose != null)
            {
                m_OnClose(this, EventArgs.Empty);
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyCloseForm));
            this.SuspendLayout();
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Font = new System.Drawing.Font("Ubuntu Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotifyCloseForm";
            this.Load += new System.EventHandler(this.NotifyCloseForm_Load);
            this.ResumeLayout(false);

        }

        private void NotifyCloseForm_Load(object sender, EventArgs e)
        {

        }
        
    }
}
