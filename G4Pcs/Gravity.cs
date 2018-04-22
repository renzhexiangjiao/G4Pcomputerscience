using System;
using System.Collections.Generic;

namespace G4Pcs
{
    class Gravity : Force
    {
        public static List<Gravity> gravityList = new List<Gravity>();

        public const double gravitationalConstant = 6.674E-11;

        private double distance;

        public Gravity(Object object2, double distance) : base(object2)
        {
            Object Earth = new Object(5.97222E+26);
            this.object1 = Earth;
            this.distance = distance;

            this.direction = 1.5 * Math.PI;
            if (distance > 0)
                this.value = -gravitationalConstant * object1.getMass() * object2.getMass() / distance / distance;
            else if (distance < 0)
                this.value = gravitationalConstant * object1.getMass() * object2.getMass() / distance / distance;
            else
                this.value = 0;
        }

        public void update(double distance)
        {
            this.distance = distance;
            this.direction = 1.5 * Math.PI;
            if (distance > 0)
                this.value = -gravitationalConstant * object1.getMass() * object2.getMass() / distance / distance;
            else if (distance < 0)
                this.value = 32 * this.getPatient().velocity.getValue(); //gravitationalConstant * object1.getMass() * object2.getMass() / distance / distance;
            else
                this.value = 0;
        }
    }
}
