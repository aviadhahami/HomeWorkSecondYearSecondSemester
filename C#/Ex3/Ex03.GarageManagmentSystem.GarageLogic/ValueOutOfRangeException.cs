using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base()
        {
            this.m_MinValue = i_MinValue;
            this.m_MaxValue = i_MaxValue;
        }

        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue)
            : base(string.Format("Value out of range", i_MinValue, i_MaxValue), i_InnerException)
        {
        }

        public override string Message
        {
            get
            {
                return string.Format("Value must be in range: {0} to {1}!", this.m_MinValue, this.m_MaxValue);
            }
        }
    }
}
