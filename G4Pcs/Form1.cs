﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace G4Pcs
{
    public partial class Form1 : Form
    {
        public static int groundLevel = 250;
        public static int fpr = 480;

        public int updateCount = 0;

        public bool ASAP = false;

        public int specimenIndex = 0;
        public int generationIndex = 0;

        private Specimen currentSpecimen;
        private Generation currentGeneration;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            frameTimer.Start();
            fpsTimer.Start();
            Generation();
            currentSpecimen = currentGeneration.getSpecimen(0);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!ASAP)
            {
                foreach (Joint joint in currentSpecimen.jointList)
                {
                    e.Graphics.FillEllipse(new SolidBrush(Color.Black), joint.getPosition().X - 4 /*- currentSpecimen.getPosition().X + 250*/, joint.getPosition().Y - 4, 8, 8);
                }
                foreach (Bone bone in currentSpecimen.boneList)
                {
                    e.Graphics.DrawLine(new Pen(Color.Black), bone.getJoint1().getPosition().X /*- currentSpecimen.getPosition().X + 250*/, bone.getJoint1().getPosition().Y, bone.getJoint2().getPosition().X /*- currentSpecimen.getPosition().X + 250*/, bone.getJoint2().getPosition().Y);
                }
                e.Graphics.DrawString("FPS:" + fps.ToString(), new Font(FontFamily.GenericSansSerif, 12f), new SolidBrush(Color.Black), 10, 10);
            }
            e.Dispose();
        }

        int fps = 32;
        int fc;
        int prevfc = 0;
        private void frameTimer_OnTick(object sender, EventArgs e)
        {
            fc++;
            Update();
            updateCount++;
            if(updateCount>=fpr)
            {
                specimenIndex++;
                currentSpecimen = currentGeneration.getSpecimen(specimenIndex);
                updateCount = 0;
            }
            
        }

        private new void Update()
        {
            updateCount++;
            label1.Text = "Generation:" + generationIndex;
            label2.Text = "Specimen:" + specimenIndex;
            label3.Text = "Score:" + currentSpecimen.getScore() + "\n" + currentGeneration.getSpecimen(0).getScore();
            //foreach (Joint joint in currentSpecimen.jointList)
            //{
            //    joint.updateAcceleration(currentSpecimen);
            //    if(!ASAP)
            //    {
            //        joint.updateVelocity(fps);
            //        joint.updatePosition(fps);
            //    }
            //    else
            //    {
            //        joint.updateVelocity(32);
            //        joint.updatePosition(32);
            //    }
            //}
            if (!ASAP)
                currentSpecimen.Update(fps, updateCount);
            else
                currentSpecimen.Update(32, updateCount);
            this.Invalidate();
        }

        private void fpsTimer_Tick(object sender, EventArgs e)
        {
            fps = fc - prevfc;
            prevfc = fc;
            this.Invalidate();
        }

        private void Run()
        {
            currentSpecimen = currentGeneration.getSpecimen(specimenIndex);
            if (ASAP)
            {
                for (int i = 0; i < fpr; i++)
                {
                    Update();
                    updateCount++;
                }
            }
            updateCount = 0;
            specimenIndex++; 
        }
        private void Generation()
        {
            try {
                currentGeneration = currentGeneration.Mutated();
            } catch(NullReferenceException e) {
                currentGeneration = new G4Pcs.Generation();
            }
            if(ASAP)
            {
                for(int i = specimenIndex; i < G4Pcs.Generation.generationSize; i++)
                {
                    Run();
                }
            }
            specimenIndex %= G4Pcs.Generation.generationSize;
            generationIndex++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frameTimer.Stop();
            fpsTimer.Stop();
            ASAP = true;
            for (int i = 0; i < Int32.Parse(textBox1.Text); i++)
            {
                Generation();
            }
            ASAP = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ASAP = false;
            Generation();
            fpsTimer.Start();
            frameTimer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fpsTimer.Stop();
            frameTimer.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            player.Show();
        }
    }
}
