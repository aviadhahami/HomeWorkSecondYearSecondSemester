using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagmentSystem.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {

        private const string K_VALUE_OUT_OF_RANGE = "Value out of range";
        private const string K_VALUE_IN_RANGE_MIN_MAX = "Value must be in range:";
        
        private float m_MaxValue;
        private float m_MinValue;
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base()
        {
            this.m_MinValue = i_MinValue;
            this.m_MaxValue = i_MaxValue;
        }

        public ValueOutOfRangeException(Exception i_InnerException, float i_MinValue, float i_MaxValue)
            : base(string.Format(K_VALUE_OUT_OF_RANGE, i_MinValue, i_MaxValue), i_InnerException)
        {
        }

        public override string Message
        {
            get
            {
                return string.Format("{0} {1} to {2}!",K_VALUE_IN_RANGE_MIN_MAX, this.m_MinValue, this.m_MaxValue);
            }
        }
    }
}
