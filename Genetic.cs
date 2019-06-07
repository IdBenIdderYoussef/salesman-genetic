using System;
using System.Collections.Generic;
using System.Linq;


namespace Salesman_Problem
{
    class Genetic
    {
        static Random random = new Random();

        static void swapValues<T>(ref T value1 ,ref T value2)
        {
            T t = value1;
            value1 = value2;
            value2 = t;
        }

        static T[] Shuffle<T>(T[] array)
        {
            T[] shuffleArray = new T[array.Length];
            Array.Copy(array, shuffleArray ,array.Length) ;
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + random.Next(n - i);
                T t = shuffleArray[r];
                shuffleArray[r] = shuffleArray[i];
                shuffleArray[i] = t;
            }
            return shuffleArray;
        }


        public static List<Chromosome> CreateInitialPopulation(Chromosome chromosome)
        {
            List<Chromosome> initialPopulation = new List<Chromosome>();
            for (int j = 0; j < 1000; j++)
            {
                Chromosome chromosomeTemp = new Chromosome(Shuffle(chromosome.genes));
                initialPopulation.Add(chromosomeTemp);
            }
            return initialPopulation;
        }


        public static void TwoPointsCutCrossOver(Chromosome chromosome1 , Chromosome chromosome2)
        {
            int n = chromosome1.genes.Length;
            int p1 = random.Next(n);
            int p2 = random.Next(n);

            int point1Chromossome1index = Array.FindIndex<Point>(chromosome1.genes, element => element == chromosome2.genes[p1]);
            int point2Chromossome1index = Array.FindIndex(chromosome1.genes, element => element == chromosome2.genes[p2]);

            int point1Chromossome2index = Array.FindIndex(chromosome2.genes, element => element == chromosome1.genes[p1]);
            int point2Chromossome2index = Array.FindIndex(chromosome2.genes, element => element == chromosome1.genes[p2]);

            swapValues(ref chromosome1.genes[p1], ref chromosome1.genes[point1Chromossome1index]);
            swapValues(ref chromosome1.genes[p2], ref chromosome1.genes[point2Chromossome1index]);

            swapValues(ref chromosome2.genes[p2], ref chromosome2.genes[point2Chromossome1index]);
            swapValues(ref chromosome2.genes[p2], ref chromosome2.genes[point2Chromossome2index]);


        }

        public static void CrossOver(List<Chromosome> population)
        {
            List<Chromosome> populationTemp = new List<Chromosome>();
            for (int i = 0; i < population.Count - 1; i++)
            {
                Chromosome chromosome1 = new Chromosome(population[i].genes);
                Chromosome chromosome2 = new Chromosome(population[i+1].genes);
                TwoPointsCutCrossOver(chromosome1, chromosome2);
                populationTemp.Add(chromosome1);
                populationTemp.Add(chromosome2);
            }
            population = population.Concat(populationTemp).ToList();
        }

        public static void mutationOperator(Chromosome chromosome)
        {
            int n = chromosome.genes.Length;
            int p1 = random.Next(n);
            int p2 = random.Next(n);
            swapValues(ref chromosome.genes[p1], ref chromosome.genes[p2]);
        }

        public static void Mutation(List<Chromosome> population)
        {
            for(int i = 0; i < 80; i++)
            {
                int n = population.Count;
                int p = random.Next(n);
                mutationOperator(population[p]);
            }
        }

        

        public static void Selection(List<Chromosome> population)
        {
            population.Sort();
            population.RemoveRange(1000, population.Count - 1000);
        }


        public static List<Chromosome> genetic(Chromosome chromosome)
        {
            List<Chromosome> population = CreateInitialPopulation(chromosome);
            int i = 0;
            while (i != 100)
            {
                CrossOver(population);
                Mutation(population);
                Selection(population);
                i++;
            }
            return population;
        }

        static void Main(string[] args)
        {   
            
            Point[] points = { new Point(2.2, 15.45) ,new Point(2, 5),new Point(29.2, 125.45),new Point(13, 1.5),
                new Point(72.2, 544),new Point(23, 5.4),  new Point(2, 10), new Point(48, 55)
                     };

             Chromosome chromosome = new Chromosome(points);
             List<Chromosome> population = genetic(chromosome);
            
             Console.ReadKey();

        }
    }
}
