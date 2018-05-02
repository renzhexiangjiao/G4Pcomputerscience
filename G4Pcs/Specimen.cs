using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4Pcs
{
    class Specimen
    {
        public List<Joint> jointList = new List<Joint>();
        public List<Bone> boneList = new List<Bone>();

        private Point position;
        private double score;

        public Specimen()
        {
            foreach(Joint joint in jointList)
            {
                position.X += joint.getPosition().X;
                position.Y += joint.getPosition().Y;
            }
            position.X /= jointList.Count;
            position.Y /= jointList.Count;

            score = position.X;
        }

        public Point getPosition() => position;
    }
}
