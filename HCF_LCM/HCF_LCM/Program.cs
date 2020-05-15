using System;
using System.Collections.Generic;
using System.Linq;

namespace HCF_LCM
{
    class Num
    {
        public int Nmbr { set; get; }
        public List<int> Factors { set; get; }
    }
    class CalculatorForHCFandLCM
    {
        //properties
        public List<Num> Nums { set; get; }
        public List<int> CommonFactors { set; get; }
        public int HCF { set; get; }
        public int LCM { set; get; }

        //methods
        public void Run()
        {
            findingFactors();
            findingCommonFactors();
            findingHCFofMultipleNos();
            findingLCMofMultipleNos();
        }
        public void findingFactors()
        {
            for (int i = 0; i < Nums.Count; i++)
            {
                int number = Nums[i].Nmbr;

                int max = (int)Math.Sqrt(number);
                List<int> Factors = new List<int>();

                for (int factor = 1; factor <= max; factor++)
                {
                    if (number % factor == 0)
                    {
                        Factors.Add(factor);

                        if (factor != number / factor)
                        {
                            Factors.Add(number / factor);
                        }
                    }
                }
                Factors.Sort();
                Nums[i].Factors = Factors;
            }
        }
        public void findingCommonFactors()
        {
            List<int> commonFactors = new List<int>();

            for (int i = 0; i < Nums.Count; i++)
            {
                if (i == 0)
                {
                    commonFactors = Nums[i].Factors;
                }
                else
                {
                    commonFactors = commonFactors.Intersect(Nums[i].Factors).ToList();
                }
            }
            commonFactors.Sort();
            this.CommonFactors = commonFactors;
        }
        public int HCFof2Nos(int num1, int num2)
        {
            while (num1 != num2)
            {
                if (num1 > num2)
                {
                    num1 = num1 - num2;
                }
                else
                {
                    num2 = num2 - num1;
                }
            }

            return num1;
        }
        public void findingHCFofMultipleNos()
        {
            int HCF = 0;

            for (int i = 0; i < (Nums.Count - 1); i++)
            {
                if (i == 0)
                    HCF = HCFof2Nos(Nums[i].Nmbr, Nums[i + 1].Nmbr);
                else
                    HCF = HCFof2Nos(HCF, Nums[i + 1].Nmbr);

                this.HCF = HCF;
            }
        }
        public int LCMof2Nos(int num1, int num2)
        {
            return num1 * num2 / HCFof2Nos(num1, num2);
        }
        public void findingLCMofMultipleNos()
        {
            int LCMofFirst2Nos = 0;

            for (int i = 0; i < (Nums.Count - 1); i++)
            {
                if (i == 0)
                    LCMofFirst2Nos = LCMof2Nos(Nums[i].Nmbr, Nums[i + 1].Nmbr);
                else
                {
                    LCMofFirst2Nos = LCMof2Nos(LCMofFirst2Nos, Nums[i + 1].Nmbr);
                }
            }
            LCM = LCMofFirst2Nos;
        }
        public void displayOutput()
        {
            Console.WriteLine();
            Console.WriteLine("Factors of each Number :");
            for (int i = 0; i < Nums.Count; i++)
            {
                Console.Write(Nums[i].Nmbr + " - ");
                for (int k = 0; k < Nums[i].Factors.Count; k++)
                {
                    Console.Write(Nums[i].Factors[k] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Common Factors of the above Numbers are :");
            for (int k = 0; k < CommonFactors.Count; k++)
            {
                Console.Write(CommonFactors[k] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("HCF of the above Numbers is : {0}", HCF);
            Console.WriteLine();
            Console.WriteLine("LCM of the above Numbers is : {0}", LCM);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a count of Numbers");
            Console.WriteLine("Ex:- Find HCF of 108, 360 and 600.");
            Console.WriteLine("(in this problem 3 numbers are given to find HCF so, we should enter 3)");
            Console.WriteLine("On How many numbers would you like to run this code of HCF and LCM ?");
            int lstcount = Convert.ToInt32(Console.ReadLine());
            List<Num> Nums = new List<Num>();

            Console.WriteLine();
            for (int i = 0; i < lstcount; i++)
            {
                Console.WriteLine("Enter Number");
                Nums.Add(new Num() { Nmbr = Convert.ToInt32(Console.ReadLine()) });
            }

            CalculatorForHCFandLCM f = new CalculatorForHCFandLCM();
            f.Nums = Nums;
            f.Run();
            f.displayOutput();
            Console.ReadKey();
        }
    }
}
