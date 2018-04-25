using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4Pcs
{
    class ResistiveForce : Force
    {
        public static List<ResistiveForce> resistiveForceList = new List<ResistiveForce>();

        private const double coefficient = 0.0005;

        public ResistiveForce(Object object2) : base(object2)
        {           
            this.value = Math.Min(object2.velocity.getValue() * object2.velocity.getValue() * coefficient, object2.acceleration.getValue());
            this.direction = object2.velocity.getDirection() + Math.PI;
        }
    }
}
