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
        private readonly int r_Column = 0;
        private readonly int r_Row = 0;
        private static readonly int sr_Size = 32;
        private static readonly int sr_Margin = 3;
        private static readonly string sr_Text = "O";

        /// Initializes a new instance of the OthelloButton class.
        public OthelloButton(int i_Column, int i_Row)
        {
            this.r_Column = i_Column;
            this.r_Row = i_Row;
            this.Size = new Size(sr_Size, sr_Size);
            this.Margin = new Padding(sr_Margin);
            Disable();
        }

        /// Gets the size of the button.
        public static int ButtonSize
        {
            get { return sr_Size; }
        }

        /// Gets the button margin.
        public static int ButtonMargin
        {
            get { return sr_Margin; }
        }

        /// Gets the row.
        public int Row
        {
            get { return r_Row; }
        }

        /// Gets the column.
        public int Column
        {
            get { return r_Column; }
        }

        /// Converts the button to black.
        public void ConvertToBlack()
        {
            bool enabled = true;
            Color backColor = Color.Black;
            Color foreColor = Color.White;

            this.m_IsEnabled = false;
            setStyle(sr_Text, backColor, foreColor, enabled);
        }

        /// Converts the button to white.
        public void ConvertToWhite()
        {
            bool enabled = true;
            Color backColor = Color.White;
            Color foreColor = Color.Black;

            this.m_IsEnabled = false;
            setStyle(sr_Text, backColor, foreColor, enabled);
        }

        /// Converts the button to optional.
        public void ConvertToOptional()
        {
            bool enabled = true;
            Color backColor = Color.GreenYellow;
            Color foreColor = Color.GreenYellow;

            this.m_IsEnabled = true;
            setStyle(string.Empty, backColor, foreColor, enabled);
        }

        /// Disables this button.
        public void Disable()
        {
            bool enabled = false;
            Color backColor = Color.FromKnownColor(KnownColor.Control);
            Color foreColor = Color.FromKnownColor(KnownColor.Control);

            setStyle(string.Empty, backColor, foreColor, enabled);
        }

        /// Sets the style.
        private void setStyle(string i_Text, Color i_BackColor, Color i_ForeColor, bool i_Enabled)
        {
            this.Text = i_Text;
            this.Enabled = i_Enabled;
            this.BackColor = i_BackColor;
            this.ForeColor = i_ForeColor;
        }

        protected override void OnClick(EventArgs i_EventArgs)
        {   
            //Prevent clicks when the button is not in optional mode
            if (m_IsEnabled)
            {
                base.OnClick(i_EventArgs);
            }
        }

        protected override void OnMouseEnter(EventArgs i_EventArgs)
        {
            //Change the cursor to hand in order to show that the button is clickable.
            if (m_IsEnabled)
            {
                this.Cursor = Cursors.Hand;
                base.OnMouseEnter(i_EventArgs);
            }
        }

        protected override void OnMouseLeave(EventArgs i_EventArgs)
        {
            //Change the cursor back to narmal when the button lost focus.
            this.Cursor = Cursors.Default;
            base.OnMouseLeave(i_EventArgs);
        }

        public override string ToString()
        {
            return string.Format("Column :{0} Row: {1}", this.Column, this.Row); 
        }
    }
}
