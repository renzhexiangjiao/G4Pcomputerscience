using System;
using System.Drawing;

namespace G4Pcs
{
    class Vector
    {
        protected double value;
        protected double direction;

        public static Vector ZERO = new Vector(0, 0);

        public Vector(double value, double direction)
        {
            this.value = value;
            this.direction = direction;
        }
        public Vector() { }

        public PointD toPoint() => new PointD(value * Math.Cos(direction), value * Math.Sin(direction));
        public Vector toVector(PointD pointD) => new Vector(Math.Sqrt(pointD.X * pointD.X + pointD.Y * pointD.Y), Math.Atan2(pointD.Y, pointD.X));

        public Vector add(Vector vector)
        {
            return toVector(new PointD(this.toPoint().X + vector.toPoint().X, this.toPoint().Y + vector.toPoint().Y));
        }

        public Vector scaledBy(double factor) => new Vector(this.value * factor, this.direction);

        public double getValue() => value;
        public double getDirection() => direction;

        public void setValue(double value)
        {
            this.value = value;
        }
        public void setDirection(double direction)
        {
            this.direction = direction;
        }
    }
}
