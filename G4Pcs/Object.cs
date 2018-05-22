using System.Drawing;
using System;

namespace G4Pcs
{
    abstract class Object
    {
        protected double mass;
        /*protected*/ public Vector acceleration;
        /*protected*/ public Vector velocity;     
         
        public Object(double mass)
        {
            this.mass = mass;
            this.velocity = Vector.ZERO;
            this.acceleration = Vector.ZERO;
        }

        public void updateVelocity(int fps)
        {           
            this.velocity = this.velocity.add(acceleration.scaledBy(1.0 / (double)fps));
            this.velocity.setValue(Math.Min(this.velocity.getValue(), 300));
        }

        public void updateAcceleration(Specimen specimen)
        {
            foreach (Gravity gravity in specimen.gravityList)
            {
                if (gravity.getPatient().Equals(this))
                    this.acceleration = this.acceleration.add(gravity.scaledBy(1.0 / this.mass));
            }
            foreach (ResistiveForce resistiveForce in specimen.resistiveForceList)
            {
                if (resistiveForce.getPatient().Equals(this))
                    this.acceleration = this.acceleration.add(new ResistiveForce(this).scaledBy(1.0 / this.mass));
            }
            foreach (RestoringForce restoringForce in specimen.restoringForceList)
            {
                if (restoringForce.getPatient().Equals(this))
                    this.acceleration = this.acceleration.add(new RestoringForce(((Joint)this).getParentBone(), this).scaledBy(1.0 / this.mass));
            }
        }

        public double getMass() => mass;
    }
}
