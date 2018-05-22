using System.Drawing;
using System.Collections.Generic;
using System;

namespace G4Pcs
{
    class Joint : Object
    {
        private Point position;

        private double deltaAngle;

        private Bone parentBone;

        private double[] coefficients = new double[50];

        private Joint parent;
        private List<Joint> children = new List<Joint>();

        public Joint(double mass, Point position, Joint parent) : base(mass)
        {
            this.position = position;
            this.parent = parent;
        }  
        public Joint(double mass, int x, int y, Joint parent) : base(mass)
        {
            position = new Point(x, y);
            this.parent = parent;
        }

        public void assignChildren(Specimen specimen)
        {
            foreach(Joint joint in specimen.jointList)
            {
                if (joint.parent!=null&&joint.parent.Equals(this))
                    this.children.Add(joint);
            }
        }

        public void updatePosition(int fps)
        {
            this.position.X += (int)velocity.scaledBy(1.0 / (double)fps).toPoint().X;
            this.position.Y += (int)velocity.scaledBy(1.0 / (double)fps).toPoint().Y;

            double alfa = Math.Atan2(getParent().getPosition().Y - getPosition().Y,
                getParent().getPosition().X - getPosition().X);
            double beta = alfa + deltaAngle;

            position.X += Math.Min((int)(10 *(Math.Cos(beta) - Math.Cos(alfa))), 50);
            position.Y += Math.Min((int)(10 * (Math.Sin(beta) - Math.Sin(alfa))), 50);

            if (this.position.Y >= Form1.groundLevel)
            {
                this.position.Y = Form1.groundLevel;
            }
        }

        public void Function(int time)
        {
            deltaAngle = 0;
            for(int i = 0; i < coefficients.Length; i++)
            {
                deltaAngle += coefficients[i] * Math.Pow(time, i);
            }
        }

        public void mutateFunction()
        {
            Random random = new Random();
            for (int i = 0; i < coefficients.Length; i++)
            {
                coefficients[i] += Math.Pow(random.NextDouble() - 0.5, i);
            }
        }

        public void randomizeFunction()
        {
            Random random = new Random();
            for (int i = 0; i < coefficients.Length; i++)
            {
                coefficients[i] = 2 * Math.Pow(2 * random.NextDouble() - 1, i);
            }
        }

        public void setParentBone(Bone parentBone)
        {
            this.parentBone = parentBone;
        }

        public void setParent(Joint parent)
        {
            this.parent = parent;
        }

        public Point getPosition() => position;

        public Joint getParent() => parent;
        public Joint getChild(int index) => children[index];

        public Bone getParentBone() => parentBone;
    }
}
