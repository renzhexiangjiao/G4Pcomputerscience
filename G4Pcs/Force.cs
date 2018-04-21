using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4Pcs
{
    class Force
    {
        protected Object object1, object2;

        protected double value;

        public Force(Object object1, Object object2)
        {
            this.object1 = object1;
            this.object2 = object2;
        }
    }
}
