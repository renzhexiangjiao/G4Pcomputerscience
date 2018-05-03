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
            Joint.jointList.Add(new Joint(1, 150, 125, null));       
            Joint.jointList.Add(new Joint(1, 150, 50, Joint.jointList[0]));
            Joint.jointList.Add(new Joint(1, 75, 200, Joint.jointList[0]));
            Joint.jointList.Add(new Joint(1, 75, 250, Joint.jointList[2]));
            Joint.jointList.Add(new Joint(1, 30, 250, Joint.jointList[3]));
            Joint.jointList.Add(new Joint(1, 225, 200, Joint.jointList[0]));
            Joint.jointList.Add(new Joint(1, 225, 250, Joint.jointList[5]));
            Joint.jointList.Add(new Joint(1, 270, 250, Joint.jointList[6]));
            Joint.jointList.Add(new Joint(1, 85, 70, Joint.jointList[1]));
            Joint.jointList.Add(new Joint(1, 20, 50, Joint.jointList[8]));
            Joint.jointList.Add(new Joint(1, 215, 70, Joint.jointList[1]));
            Joint.jointList.Add(new Joint(1, 280, 50, Joint.jointList[10]));
            foreach(Joint joint in Joint.jointList)
            {
                joint.assignChildren();
                if(joint.getParent()!=null)
                    Bone.boneList.Add(new Bone(1, joint, joint.getParent()));
                Gravity.gravityList.Add(new Gravity(joint));
                ResistiveForce.resistiveForceList.Add(new ResistiveForce(joint));
            }                    
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Joint joint in Joint.jointList)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Black), joint.getPosition().X - 4, joint.getPosition().Y - 4, 8, 8);
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
