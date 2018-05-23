using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4Pcs
{
    class ResistiveForce : Force
    {
        private const double coefficient = 0.00003;

        public ResistiveForce(Object object2) : base(object2)
        {           
            this.value = Math.Abs(((Joint)object2).getParentBone().getLength() - ((Joint)object2).getParentBone().getDefLength()) * Math.Min(object2.getVelocity().getValue() * object2.getVelocity().getValue() * coefficient, object2.getAcceleration().getValue());
            this.direction = object2.getVelocity().getDirection() + Math.PI;
            if (((Joint)object2).getPosition().Y - Form1.groundLevel > -10)
                value *= 10;
        }
    }
}
