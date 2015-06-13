using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Ex05.Othello.UI
{
    public class OthelloButton : Button
    {
        private bool m_IsEnabled = false;
        private readonly int sr_Column = 0;
        private readonly int sr_Row = 0;
        private static readonly int sr_Size = 32;
        private static readonly int sr_Margin = 3;
        private static readonly string sr_Text = "✈";

        /// <summary>
        /// Initializes a new instance of the <see cref="OthelloButton"/> class.
        /// </summary>
        /// <param name="i_Column">The i_ column.</param>
        /// <param name="i_Row">The i_ row.</param>
        public OthelloButton(int i_Column, int i_Row)
        {
            this.sr_Column = i_Column;
            this.sr_Row = i_Row;
            this.Size = new Size(sr_Size, sr_Size);
            this.Margin = new Padding(sr_Margin);
            Disable();
        }

        /// <summary>
        /// Gets the size of the button.
        /// </summary>
        /// <value>
        /// The size of the button.
        /// </value>
        public static int ButtonSize
        {
            get { return sr_Size; }
        }

        /// <summary>
        /// Gets the button margin.
        /// </summary>
        public static int ButtonMargin
        {
            get { return sr_Margin; }
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        public int Row
        {
            get { return sr_Row; }
        }

        /// <summary>
        /// Gets the column.
        /// </summary>
        public int Column
        {
            get { return sr_Column; }
        }

        /// <summary>
        /// Converts the button to black.
        /// </summary>
        public void ConvertToBlack()
        {
            bool enabled = true;
            Color backColor = Color.Black;
            Color foreColor = Color.White;

            this.m_IsEnabled = false;
            setStyle(sr_Text, backColor, foreColor, enabled);
        }

        /// <summary>
        /// Converts the button to white.
        /// </summary>
        public void ConvertToWhite()
        {
            bool enabled = true;
            Color backColor = Color.White;
            Color foreColor = Color.Black;

            this.m_IsEnabled = false;
            setStyle(sr_Text, backColor, foreColor, enabled);
        }

        /// <summary>
        /// Converts the button to optional.
        /// </summary>
        public void ConvertToOptional()
        {
            bool enabled = true;
            Color backColor = Color.Coral;
            Color foreColor = Color.Coral;

            this.m_IsEnabled = true;
            setStyle(string.Empty, backColor, foreColor, enabled);
        }

        /// <summary>
        /// Disables this button.
        /// </summary>
        public void Disable()
        {
            bool enabled = false;
            Color backColor = Color.FromKnownColor(KnownColor.Control);
            Color foreColor = Color.FromKnownColor(KnownColor.Control);

            setStyle(string.Empty, backColor, foreColor, enabled);
        }

        /// <summary>
        /// Sets the style.
        /// </summary>
        /// <param name="i_Text">The text of the button .</param>
        /// <param name="i_BackColor">Backgound color of the button.</param>
        /// <param name="i_ForeColor">Foreground color of the i_ fore.</param>
        /// <param name="i_Enabled">if set to <c>true</c> [enabled].</param>
        private void setStyle(string i_Text, Color i_BackColor, Color i_ForeColor, bool i_Enabled)
        {
            this.Text = i_Text;
            this.Enabled = i_Enabled;
            this.BackColor = i_BackColor;
            this.ForeColor = i_ForeColor;
        }

        /// <summary>
        /// Raises the <see cref="E:Click"/> event.
        /// </summary>
        /// <param name="i_EventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnClick(EventArgs i_EventArgs)
        {   
            //Prevent clicks when the button is not in optional mode
            if (m_IsEnabled)
            {
                base.OnClick(i_EventArgs);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:MouseEnter"/> event.
        /// </summary>
        /// <param name="i_EventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseEnter(EventArgs i_EventArgs)
        {
            //Change the cursor to hand in order to show that the button is clickable.
            if (m_IsEnabled)
            {
                this.Cursor = Cursors.Hand;
                base.OnMouseEnter(i_EventArgs);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:MouseLeave"/> event.
        /// </summary>
        /// <param name="i_EventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnMouseLeave(EventArgs i_EventArgs)
        {
            //Change the cursor back to narmal when the button lost focus.
            this.Cursor = Cursors.Default;
            base.OnMouseLeave(i_EventArgs);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Column :{0} Row: {1}", this.Column, this.Row); 
        }
    }
}
