using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4Pcs
{
    class Bone
    {
        private double length;
        public Bone(Joint joint1, Joint joint2)
        {
            length = Math.Sqrt(Math.Pow(joint1.getPosition().X-joint2.getPosition().X, 2)+ Math.Pow(joint1.getPosition().Y - joint2.getPosition().Y, 2));
        }
    }
}
