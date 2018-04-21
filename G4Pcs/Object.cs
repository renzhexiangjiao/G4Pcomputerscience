using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4Pcs
{
    class Object
    {
        protected double mass;
         
        public Object(double mass)
        {
            this.mass = mass;
        }

        public double getMass()
        {
            return mass;
        }
    }
}
