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

        public static List<Force> forceList = new List<Force>();
        public static List<Gravity> gravityList = new List<Gravity>();
        public static List<ResistiveForce> resistiveForceList = new List<ResistiveForce>();

        private Point position;
        private double score;

        public Specimen()
        {
            jointList.Add(new Joint(1, 150, 125, null));
            jointList.Add(new Joint(1, 150, 50, jointList[0]));
            jointList.Add(new Joint(1, 75, 200, jointList[0]));
            jointList.Add(new Joint(1, 75, 250, jointList[2]));
            jointList.Add(new Joint(1, 30, 250, jointList[3]));
            jointList.Add(new Joint(1, 225, 200, jointList[0]));
            jointList.Add(new Joint(1, 225, 250, jointList[5]));
            jointList.Add(new Joint(1, 270, 250, jointList[6]));
            jointList.Add(new Joint(1, 85, 70, jointList[1]));
            jointList.Add(new Joint(1, 20, 50, jointList[8]));
            jointList.Add(new Joint(1, 215, 70, jointList[1]));
            jointList.Add(new Joint(1, 280, 50, jointList[10]));
            foreach (Joint joint in jointList)
            {
                joint.assignChildren();
                if (joint.getParent() != null)
                    boneList.Add(new Bone(1, joint, joint.getParent()));
                gravityList.Add(new Gravity(joint));
                resistiveForceList.Add(new ResistiveForce(joint));
            }
            foreach (Joint joint in jointList)
            {
                position.X += joint.getPosition().X;
                position.Y += joint.getPosition().Y;
            }
            position.X /= jointList.Count;
            position.Y /= jointList.Count;

            score = position.X;
        }
         
        public void Function(int tick)
        {

        }

        public Specimen Mutated()
        {

        }

        public void Update()
        {

        }

        public Point getPosition() => position;
        public double getScore() => score;
    }
}
