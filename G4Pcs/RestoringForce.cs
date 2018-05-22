using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4Pcs
{
    class RestoringForce : Force
    {

        private double coefficient = 1;

        public RestoringForce(Object object1, Object object2) : base(object1, object2)
        {
            this.value = Math.Min(coefficient * (((Bone)object1).getLength() - ((Bone)object1).getDefLength()), 10);
            this.direction = Math.Atan2(((Joint)object2).getParent().getPosition().Y - 
                ((Joint)object2).getPosition().Y, ((Joint)object2).getParent().getPosition().X - 
                ((Joint)object2).getPosition().X);
        }
    }
}
