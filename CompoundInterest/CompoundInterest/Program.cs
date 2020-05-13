using System;

namespace CompoundInterest
{
    class Compound_Interest_Calculator
    {
        public DateTime olddate { set; get; }
        public DateTime today { set; get; }

        public double P { set; get; }  // Principal Amount
        public double R { set; get; }  // Rate per Annum
        public double T { set; get; }  // Time Period of Loan 

        public double C { set; get; }  // Componded per Time

        public double n { set; get; }  // Number of times Interest to be Compounded
        public double rd { set; get; } // Remaining days after Compounded

        public double A { set; get; }  // Final Amount


        public void Run()
        {
         
            R = (R / 365) * C; // Rate per day * Componded Time Period(in days)
            n = Convert.ToInt32(T / C);
            rd = (T % C) / 365;

            A = P * Math.Pow((1 + R / 100), n) * (1 + rd * R / 100);

            Console.WriteLine("\n\nAmount is Rs.{0} after {1} days \n\nIt's compound interest is Rs.{2}", A, T, (A - P));
            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Hard coded values

            /*
            DateTime olddate = new DateTime(2018, 12, 29);
            DateTime today = DateTime.Now;

            double Principal_Amount = 50000; // Principal Amount            
            double Rate_Per_Annum = 12; // Rate per Annum
            //double Time_Period_of_Loan = (today - olddate).Days;  // Time Period of Loan(in days)
            double Time_Period_of_Loan = Convert.ToInt32(6 * (365.0 / 12.0)); // Time Period of Loan (in days, by converting years to days)

            double Componded_Time_Period = Convert.ToInt32(3 * (365.0 / 12.0));// Componded Time Period(in days)  
            */

            // Values taken dynamically

            Console.WriteLine("Enter Loan Taken Date (dd/mm/yyyy)");
            string[] LoanTakenDateString = Console.ReadLine().Trim().Split('/');

            DateTime LoanTakenDate = new DateTime(Convert.ToInt32(LoanTakenDateString[2]), Convert.ToInt32(LoanTakenDateString[1]), Convert.ToInt32(LoanTakenDateString[0]));
            Console.WriteLine(LoanTakenDate.ToLongDateString());

            DateTime today = DateTime.Now;

            Console.WriteLine("Enter Principal Amount");
            double Principal_Amount = Convert.ToDouble(Console.ReadLine().Trim()); // Principal Amount     

            Console.WriteLine("Enter Rate per Annum");
            double Rate_Per_Annum = Convert.ToDouble(Console.ReadLine().Trim()); // Rate per Annum

            double Time_Period_of_Loan = (today - LoanTakenDate).Days;  // Time Period of Loan(in days)
            //double Time_Period_of_Loan = Convert.ToInt32(6 * (365.0 / 12.0)); // Time Period of Loan (in days, by converting years to days)

            Console.WriteLine("Componded Time Period(in months)");
            double Componded_Time_Period = Convert.ToInt32(Convert.ToInt32(Console.ReadLine().Trim()) * (365.0 / 12.0));// Componded Time Period(in days)

            Compound_Interest_Calculator Calc = new Compound_Interest_Calculator();
            Calc.P = Principal_Amount;
            Calc.R = Rate_Per_Annum;
            Calc.T = Time_Period_of_Loan;
            Calc.C = Componded_Time_Period;

            Calc.Run();
        }
    }
}