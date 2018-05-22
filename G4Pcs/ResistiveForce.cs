using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4Pcs
{
    class ResistiveForce : Force
    {
        private const double coefficient = 0.0005;

        public ResistiveForce(Object object2) : base(object2)
        {           
            this.value = Math.Abs(((Joint)object2).getParentBone().getLength() - ((Joint)object2).getParentBone().getDefLength()) * Math.Min(object2.velocity.getValue() * object2.velocity.getValue() * coefficient, object2.acceleration.getValue());
            this.direction = object2.velocity.getDirection() + Math.PI;
        }
    }
}
