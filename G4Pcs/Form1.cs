using System;
using System.Drawing;
using System.Windows.Forms;

namespace G4Pcs
{
    public partial class Form1 : Form
    {
        public static int groundLevel = 250;

        public Form1()
        {
            InitializeComponent();
            Initialize();
            this.DoubleBuffered = true;
            frameTimer.Start();
            fpsTimer.Start();
        }

        private void Initialize()
        {
            Joint.jointList.Add(new Joint(1, 30, 250));       
            Joint.jointList.Add(new Joint(1, 75, 250));
            Joint.jointList.Add(new Joint(1, 75, 200));
            Joint.jointList.Add(new Joint(1, 150, 125));
            Joint.jointList.Add(new Joint(1, 225, 200));
            Joint.jointList.Add(new Joint(1, 225, 250));
            Joint.jointList.Add(new Joint(1, 270, 250));
            Joint.jointList.Add(new Joint(1, 150, 50));
            Joint.jointList.Add(new Joint(1, 85, 70));
            Joint.jointList.Add(new Joint(1, 20, 50));
            Joint.jointList.Add(new Joint(1, 215, 70));
            Joint.jointList.Add(new Joint(1, 280, 50));
            Bone.boneList.Add(new Bone(1, Joint.jointList[0], Joint.jointList[1]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[1], Joint.jointList[2]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[2], Joint.jointList[3]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[3], Joint.jointList[4]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[4], Joint.jointList[5]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[5], Joint.jointList[6]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[3], Joint.jointList[7]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[7], Joint.jointList[8]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[8], Joint.jointList[9]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[7], Joint.jointList[10]));
            Bone.boneList.Add(new Bone(1, Joint.jointList[10], Joint.jointList[11]));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[0]));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[1]));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[2]));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[3]));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[4]));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[5]));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[6]));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[7]));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[8]));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[9]));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[10]));
            Gravity.gravityList.Add(new Gravity(Joint.jointList[11]));
            ResistiveForce.resistiveForceList.Add(new ResistiveForce(Joint.jointList[0]));
            ResistiveForce.resistiveForceList.Add(new ResistiveForce(Joint.jointList[1]));
            ResistiveForce.resistiveForceList.Add(new ResistiveForce(Joint.jointList[2]));
            ResistiveForce.resistiveForceList.Add(new ResistiveForce(Joint.jointList[3]));
            ResistiveForce.resistiveForceList.Add(new ResistiveForce(Joint.jointList[4]));
            ResistiveForce.resistiveForceList.Add(new ResistiveForce(Joint.jointList[5]));
            ResistiveForce.resistiveForceList.Add(new ResistiveForce(Joint.jointList[6]));
            ResistiveForce.resistiveForceList.Add(new ResistiveForce(Joint.jointList[7]));
            ResistiveForce.resistiveForceList.Add(new ResistiveForce(Joint.jointList[8]));
            ResistiveForce.resistiveForceList.Add(new ResistiveForce(Joint.jointList[9]));
            ResistiveForce.resistiveForceList.Add(new ResistiveForce(Joint.jointList[10]));
            ResistiveForce.resistiveForceList.Add(new ResistiveForce(Joint.jointList[11]));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Joint joint in Joint.jointList)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Black), joint.getPosition().X - 5, joint.getPosition().Y - 5, 10, 10);
            }
            foreach (Bone bone in Bone.boneList)
            {
                e.Graphics.DrawLine(new Pen(Color.Black), bone.getJoint1().getPosition(), bone.getJoint2().getPosition());
            }
            e.Graphics.DrawString("FPS:"+fps.ToString(), new Font(FontFamily.GenericSansSerif, 12f), new SolidBrush(Color.Black), 10, 10);       
        }

        int fps = 32;
        int fc;
        int prevfc = 0;
        private void frameTimer_OnTick(object sender, EventArgs e)
        {
            fc++;
            foreach(Joint joint in Joint.jointList)
            {
                joint.updateAcceleration();
                joint.updateVelocity(fps);
                joint.updatePosition(fps);
            }
            this.Refresh();
        }

        private void fpsTimer_Tick(object sender, EventArgs e)
        {
            fps = fc - prevfc;
            prevfc = fc;
            this.Refresh();
        }

    }
}
