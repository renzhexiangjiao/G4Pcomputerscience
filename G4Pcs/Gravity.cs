using System;
using System.Collections.Generic;

namespace G4Pcs
{
    class Gravity : Force
    {
        public static List<Gravity> gravityList = new List<Gravity>();

        private const double gravitationalAcceleraction = 9.80665;

        public Gravity(Object object2) : base(object2)
        {
            this.value = - object2.getMass() * gravitationalAcceleraction;
            this.direction = 1.5 * Math.PI;
        }
    }
}
