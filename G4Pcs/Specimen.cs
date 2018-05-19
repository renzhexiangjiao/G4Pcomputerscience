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

        public List<Force> forceList = new List<Force>();
        public List<Gravity> gravityList = new List<Gravity>();
        public List<ResistiveForce> resistiveForceList = new List<ResistiveForce>();

        private Point position;
        private double score;

        string log = "SPECIMEN#";

        public Specimen()
        {
            jointList.Add(new Joint(1, 150, 125, null, 0, 0, 0, 0));
            jointList.Add(new Joint(1, 150, 50, jointList[0], Math.PI * 0.5, Math.PI * 1.5, -Math.PI * 0.1, Math.PI * 0.1));
            jointList.Add(new Joint(1, 75, 200, jointList[0], Math.PI * 0.1, Math.PI, -Math.PI * 0.1, Math.PI * 0.1));
            jointList.Add(new Joint(1, 75, 250, jointList[2], Math.PI, Math.PI * 2, -Math.PI * 0.1, Math.PI * 0.1));
            jointList.Add(new Joint(1, 30, 250, jointList[3], Math.PI * 0.5, Math.PI, -Math.PI * 0.1, Math.PI * 0.1));
            jointList.Add(new Joint(1, 225, 200, jointList[0], Math.PI * 0.1, Math.PI, -Math.PI * 0.1, Math.PI * 0.1));
            jointList.Add(new Joint(1, 225, 250, jointList[5], Math.PI, Math.PI * 2, -Math.PI * 0.1, Math.PI * 0.1));
            jointList.Add(new Joint(1, 270, 250, jointList[6], Math.PI * 0.5, Math.PI, -Math.PI * 0.1, Math.PI * 0.1));
            jointList.Add(new Joint(1, 85, 70, jointList[1], 0, Math.PI * 2, -Math.PI * 0.1, Math.PI * 0.1));
            jointList.Add(new Joint(1, 20, 50, jointList[8], 0, Math.PI, -Math.PI * 0.1, Math.PI * 0.1));
            jointList.Add(new Joint(1, 215, 70, jointList[1], 0, Math.PI * 2, -Math.PI * 0.1, Math.PI * 0.1));
            jointList.Add(new Joint(1, 280, 50, jointList[10], 0, Math.PI, -Math.PI * 0.1, Math.PI * 0.1));
            foreach (Joint joint in jointList)
            {
                joint.assignChildren(this);
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

        public Specimen Mutated()
        {
            Specimen specimen = new Specimen();
            foreach(Joint joint in specimen.jointList)
            {
                joint.mutateFunction(0.1);
            }
            return specimen;
        }

        public void Update(int fps)
        {
            foreach(Joint joint in jointList)
            {
                joint.updateAcceleration(this);
                joint.updateVelocity(fps);
                joint.updateAngle();
                joint.updateAngle();

            }
            foreach(Bone bone in boneList)
            {

            }
            foreach(Gravity gravity in gravityList)
            {

            }
            foreach(ResistiveForce resistiveForce in resistiveForceList)
            {

            }
            foreach(Force force in forceList)
            {

            }
        }

        public Point getPosition() => position;
        public double getScore() => score;
    }
}
