using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4Pcs
{
    class Generation
    {
        public static int generationSize = 1000;
        private Specimen[] listOfSpecimina = new Specimen[generationSize];

        public Generation(Specimen[] listOfSpecimina)
        {
            this.listOfSpecimina = listOfSpecimina;
        }

        public Generation()
        {
            for(int i = 0; i < generationSize; i++)
            {
                Specimen specimen = new Specimen();
                foreach(Joint joint in specimen.jointList)
                {
                    joint.randomizeFunction();
                }
                this.listOfSpecimina[i] = specimen;
            }
        }

        public void sortByScore()
        {
            for(int i = 0; i < generationSize - 1; i++)
            {
                for(int j = 1; j < generationSize - i; j++)
                {
                    if(listOfSpecimina[j].getScore()<listOfSpecimina[j-1].getScore())
                    {
                        Specimen temp = listOfSpecimina[j];
                        listOfSpecimina[j] = listOfSpecimina[j-1];
                        listOfSpecimina[j-1] = temp;
                    }
                }
            }
        }

        public Generation Mutated()
        {
            this.sortByScore();
            int half = Generation.generationSize / 2;
            Specimen[] result = new Specimen[Generation.generationSize];
            for (int i = 0; i < half; i++)
            {
                result[i] = this.getSpecimen(i + half).Mutated();
            }
            for (int i = half; i < Generation.generationSize; i++)
            {
                result[i] = this.getSpecimen(i);
            }
            return new Generation(result);
        }

        public Specimen getSpecimen(int index) => listOfSpecimina[index];

        public void setSpecimen(int index, Specimen specimen)
        {
            listOfSpecimina[index] = specimen;
        }
    }
}
