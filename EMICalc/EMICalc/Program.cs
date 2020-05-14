using System;

namespace EMICalc
{

    class EMI_Calculator
    {
        //Loan Amount (prinicipal)
        public double P { set; get; }
        //Interest Rate per Month (if the interest per annum is 11% then the rate of interest will be 11/12*100)
        public double R { set; get; }
        //Number of monthly installments
        public double N { set; get; }

        //Rate per Month
        public double r { set; get; }

        public double EMI { set; get; }

        public void Run()
        {
            r = R / (12.0 * 100); // Rate per Month
            //EMI = [P x r x (1+r)^N]/[(1+r)^N - 1]
            EMI = (P * r * Math.Pow((1 + r), N)) / (Math.Pow((1 + r), N) - 1);

            Console.WriteLine("\nPrinicipal={0}\nInterest per Annum={1}\nNumber of monthly installments={2}",P,R,N);
            Console.WriteLine("\nRate per Month={0} \nEMI={1}",r, EMI);
            Console.WriteLine("\nInterest for {0} Months={1}", N, (EMI*N)-P);
            Console.WriteLine("\nPrinicipal + Interest for {0} Months={1}", N, (EMI * N));
            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)

        {
            EMI_Calculator EC = new EMI_Calculator();
            Console.WriteLine("Enter Loan Amount");
            EC.P = Convert.ToDouble(Console.ReadLine().Trim());

            Console.WriteLine("Enter Interest per Annum");
            EC.R = Convert.ToDouble(Console.ReadLine().Trim());

            Console.WriteLine("Enter Number of monthly installments");
            EC.N = Convert.ToDouble(Console.ReadLine().Trim());

            EC.Run();
        }
    }
}
