using System;
using System.Diagnostics.Metrics;
using collatzproblem.collatzcomputationclass;

namespace collatzproblem
{
    class Program
    {
        public static List<CollatzComputation> collatzcomputations = new List<CollatzComputation>();
        
        public static void Main()
        {
            long startnumber = 0;
            
            while (startnumber < 10000)
            {
                collatzcomputations.Add(collatzcompute(startnumber));
                startnumber++;
            }

            long largesttermcounter = 0;
            long nthtermoflargestseq = 0;

            foreach (CollatzComputation computation in collatzcomputations)
            {
                if(computation.TermCounter > largesttermcounter)
                {
                    largesttermcounter = computation.TermCounter;

                    nthtermoflargestseq = computation.NthTerm;

                }
            }

            System.Console.WriteLine($"Longest Collatz sequence begins with n={nthtermoflargestseq} which has the longest sequence of {largesttermcounter} terms");


            

        }

        private static CollatzComputation collatzcompute(long nthterm)
        {
            // Term counter is at 1 to include starting term.
            long termcounter = 1;
            
            long input = nthterm;

            while (input > 1)
            {
                // Modulus gets remainder of input term when divided by 2, determining if the input is odd or even.
                if(input%2 == 0)
                {
                    // n -> n / 2
                    input = input/2;

                    termcounter++;
                
                }

                else
                {
                    // n -> 3n + 1
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
