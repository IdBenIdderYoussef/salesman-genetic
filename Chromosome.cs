using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salesman_Problem
{
    class Chromosome : IComparable
    {
        public Point[] genes;

        public Chromosome(Point[] genes)
        {
            this.genes = genes ;
        }

        public double calculFitness()
        {
            double fitness = 0;
            for (int i = 0; i < genes.Length - 1; i++)
            {
                fitness += genes[i].Distance(genes[i + 1]);
            }
            return fitness;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Chromosome otherChromosome = obj as Chromosome;
            if (otherChromosome != null)
            {
                double fitness1 = calculFitness();
                double fitness2 = otherChromosome.calculFitness();
                return (fitness1.CompareTo(fitness2));
            }
                
            else
                throw new ArgumentException("Object is not a Chromosome");
        }
    }
}

