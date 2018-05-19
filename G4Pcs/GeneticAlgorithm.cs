using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4Pcs
{
    class GeneticAlgorithm
    {
        public Generation Next(Generation generation)
        {
            generation.sortByScore();
            int half = Generation.generationSize / 2;
            Specimen[] result = new Specimen[Generation.generationSize];
            for(int i = 0; i < half; i++)
            {
                generation.setSpecimen(i, generation.getSpecimen(i + half).Mutated());
            }
            return new Generation(result);
        }
    }
}
