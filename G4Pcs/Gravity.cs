using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4Pcs
{
    class Gravity : Force
    {
        public const double gravitationalConstant = 6.674E-11;

        private double distance;

        public Gravity(Object object1, Object object2, double distance) : base(object1, object2)
        {
            Object Earth = new Object(5.97222E+24);
            this.object1 = Earth;
            this.object2 = object2;
            this.distance = distance;

            this.value = gravitationalConstant * object1.getMass() * object2.getMass() / distance / distance;
        }
    }
}
