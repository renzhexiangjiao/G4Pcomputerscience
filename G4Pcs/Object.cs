using System.Drawing;

namespace G4Pcs
{
    class Object
    {
        protected double mass;
        /*protected*/ public Vector acceleration;
        /*protected*/ public Vector velocity;
        protected Point position;
         
        public Object(double mass)
        {
            this.mass = mass;
            this.velocity = Vector.ZERO;
            this.acceleration = Vector.ZERO;
            this.position = new Point(0, 0);
        }

        public void updateVelocity(int fps)
        {           
            this.velocity = this.velocity.add(acceleration.scaledBy(1.0 / (double)fps));
        }

        public void updateAcceleration()
        {
            foreach (Gravity gravity in Gravity.gravityList)
            {
                if (gravity.getPatient().Equals(this))
                    this.acceleration = gravity.scaledBy(1.0 / this.mass);
            }
        }

        public double getMass() => mass;
        public Point getPosition() => position;
    }
}
