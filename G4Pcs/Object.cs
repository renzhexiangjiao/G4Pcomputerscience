namespace G4Pcs
{
    class Object
    {
        protected double mass;
        protected Vector acceleration;
        protected Vector velocity;
         
        public Object(double mass)
        {
            this.mass = mass;
        }

        public void updateVelocity()
        {

        }

        public double getMass() => mass;       

    }
}
