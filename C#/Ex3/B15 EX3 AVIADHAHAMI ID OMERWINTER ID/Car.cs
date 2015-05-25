using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_EX3_AVIADHAHAMI_ID_OMERWINTER_ID
{
    class Car : Vehicle
    {
        int m_numberOfDors;
        Colors m_color;

        public Car(int i_numberOfDors, Colors i_color) : base()
        {
            m_color = i_color;
            m_numberOfDors = i_numberOfDors;
        }

        public Colors getColor
        {
            get { return m_color; }
            set { m_color = value; }
        }
        public int getNumberOfDors
        {
            get { return m_numberOfDors; }
            set { m_numberOfDors = value; }
        }
    }
    enum Colors
    {
        GREEN,
        RED,
        BLACK,
        WIGHT
    };
}
