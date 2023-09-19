using System;
using System.Diagnostics.Metrics;

namespace collatzproblem
{
    class Program
    {
        public record CollatzComputation(long nthterm, long termcounter);
        public static List<CollatzComputation> collatzcomputations = new List<CollatzComputation>();
        
        public static void Main()
        {
            long startnumber = 1;
            while (startnumber < 10000)
            {
                collatzcomputations.Add(collatzcompute(startnumber));
                startnumber++;
            }

            long largesttermcounter = 0;
            long nthtermoflargestseq = 0;

            foreach (CollatzComputation computation in collatzcomputations)
            {
                if(computation.termcounter > largesttermcounter)
                {
                    largesttermcounter = computation.termcounter;
                    nthtermoflargestseq = computation.nthterm;

                    
                }
            }

            System.Console.WriteLine($"Longest Collatz sequence begins with nth term {nthtermoflargestseq} which has the longest sequence of {largesttermcounter} terms");


            

        }

        private static CollatzComputation collatzcompute(long nthterm)
        {
            // Term counter is at 1 to include starting term.
            long termcounter = 1;
            
            long input = nthterm;

            while (input > 1)
            {
                if(input%2 == 0)
                {
                    System.Console.WriteLine("Input number is even");
                    input = input/2;
                    termcounter++;
                
                }
                else
                {
                System.Console.WriteLine("Input number is odd");
                input = (3 * input) + 1;
                termcounter++;

                }

            }

            System.Console.WriteLine($"Collatz sequence for {nthterm} has {termcounter} terms. ");
            CollatzComputation newcomputation = new CollatzComputation(nthterm, termcounter);
            return newcomputation;
            


        }
    }
}
