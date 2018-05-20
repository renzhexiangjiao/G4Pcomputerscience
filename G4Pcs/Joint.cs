using System.Drawing;
using System.Collections.Generic;
using System;

namespace G4Pcs
{
    class Joint : Object
    {
        private Point position;

        private double angle;
        private double deltaAngle;

        private double minAngle, maxAngle;
        private double minDeltaAngle, maxDeltaAngle;

        private Bone parentBone;

        private double[] coefficients = new double[50];

        private Joint parent;
        private List<Joint> children = new List<Joint>();

        public Joint(double mass, Point position, Joint parent, double minAngle, double maxAngle, double minDeltaAngle, double maxDeltaAngle) : base(mass)
        {
            this.position = position;
            this.parent = parent;
        }  
        public Joint(double mass, int x, int y, Joint parent, double minAngle, double maxAngle, double minDeltaAngle, double maxDeltaAngle) : base(mass)
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
            try {
                position.X = getParent().getPosition().X + (int)(getParentBone().getLength() * Math.Cos(Math.Atan2(getParent().getParent().getPosition().Y - getParent().getPosition().Y, getParent().getParent().getPosition().X - getParent().getPosition().X) - angle));
            } catch(NullReferenceException e) { }
            if (this.position.Y >= Form1.groundLevel)
            {
                this.position.Y = Form1.groundLevel;
            }
        }

        public void updateAngle()
        {
            try {
                double ax = getParent().getParent().getPosition().X;
                double ay = getParent().getParent().getPosition().Y;
                double bx = getParent().getPosition().X;
                double by = getParent().getPosition().Y;
                double cx = getPosition().X;
                double cy = getPosition().Y;
                angle = Math.Acos((((ax - bx) * (cx - bx)) + ((ay - by) * (cy - by)) / getParentBone().getLength() * getParentBone().getJoint1().getParentBone().getLength()));
            } catch(NullReferenceException e) { }
            angle = Math.Min(Math.Max(angle + deltaAngle, minAngle), maxAngle);
            if (angle==null)
            {
                angle = 0;
            }
        }

        public void setDeltaAngle(double value)
        {
            deltaAngle = value * Math.PI * 0.1;
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
                coefficients[i] = Math.Pow(2 * random.NextDouble() - 1, i);
            }
        }

        public void setParentBone(Bone parentBone)
        {
            this.parentBone = parentBone;
        }

        public Point getPosition() => position;

        public Joint getParent() => parent;
        public Joint getChild(int index) => children[index];

        public Bone getParentBone() => parentBone;
    }
}
