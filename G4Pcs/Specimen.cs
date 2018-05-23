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

        public List<RestoringForce> restoringForceList = new List<RestoringForce>();
        public List<Gravity> gravityList = new List<Gravity>();
        public List<ResistiveForce> resistiveForceList = new List<ResistiveForce>();

        private Point position;
        private double score;

        string log = "SPECIMEN#";

        public Specimen()
        {
            jointList.Add(new Joint(1, 150, 125, null));
            jointList.Add(new Joint(1, 160, 50, jointList[0]));
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
            jointList[0].setParent(jointList[1]);
            foreach (Joint joint in jointList)
            {
                joint.assignChildren(this);
                if (joint.getParent() != null)
                {
                    boneList.Add(new Bone(1, joint, joint.getParent()));
                    joint.setParentBone(boneList[boneList.Count - 1]);
                    restoringForceList.Add(new RestoringForce(boneList[boneList.Count - 1], joint));
                }     
                gravityList.Add(new Gravity(joint));
                resistiveForceList.Add(new ResistiveForce(joint));
                joint.randomizeFunction(new Random());
            }           
        }

        public void Reset()
        {
            jointList.RemoveRange(0, 12);
            boneList.RemoveRange(0, 12);
            resistiveForceList.RemoveRange(0, 12);
            restoringForceList.RemoveRange(0, 12);
            gravityList.RemoveRange(0, 12);
            jointList.Add(new Joint(1, 150, 125, null));
            jointList.Add(new Joint(1, 160, 50, jointList[0]));
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
            jointList[0].setParent(jointList[1]);
            foreach (Joint joint in jointList)
            {
                joint.assignChildren(this);
                if (joint.getParent() != null)
                {
                    
                    boneList.Add(new Bone(1, joint, joint.getParent()));
                    joint.setParentBone(boneList[boneList.Count - 1]);
                    restoringForceList.Add(new RestoringForce(boneList[boneList.Count - 1], joint));
                }
                gravityList.Add(new Gravity(joint));
                resistiveForceList.Add(new ResistiveForce(joint));
            }
        }

        public void Update(int fps, int time)
        {
            foreach(Joint joint in jointList)
            {
                if(time!=null)
                    joint.Function(time);
                joint.updateAcceleration(this);
                joint.updateVelocity(fps);
                joint.updatePosition(fps);
            }
            foreach(Bone bone in boneList)
            {
                bone.updateLength();
            }
            score = this.getPosition().X;
        }

        public Point getPosition()
        {
            foreach (Joint joint in jointList)
            {
                position.X += joint.getPosition().X;
                position.Y += joint.getPosition().Y;
            }
            position.X /= jointList.Count;
            position.Y /= jointList.Count;

            return position;
        }

        public double getScore() => score;
    }
}
