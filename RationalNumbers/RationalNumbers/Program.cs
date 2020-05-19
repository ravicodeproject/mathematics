using System;

namespace RationalNumbers
{
    class RationalNumber
    {
        // properties
        public Int64 Numerator { set; get; }
        public Int64 Denominator { set; get; }

        // constructor
        public RationalNumber() { }
        public RationalNumber(long Numerator, long Denominator)
        {
            if (Denominator == 0)
                throw new DivideByZeroException();

            this.Numerator = Numerator;
            this.Denominator = Denominator;

        }

        // methods
        public void reduce()
        {
            //https://www.calculatorsoup.com/calculators/math/fractionssimplify.php
            Int64 a = 0;
            Int64 b = 0;
            Int64 rem = 0;

            int sign;

            sign = 1;
            if (Numerator == 0)
                Denominator = 1;

            if (Numerator < 0 && Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }

            if (Numerator < 0)
            {
                Numerator = -Numerator;
                sign = -1;
            }

            if (Denominator < 0)
            {
                Denominator = -Denominator;
                sign = -1;
            }

            if (Numerator > Denominator)
            {
                a = Numerator;
                b = Denominator;
            }
            else
            {
                a = Denominator;
                b = Numerator;
            }
            // HCF
            while (b != 0)
            {
                rem = a % b;
                a = b;
                b = rem;
            }
            Numerator = sign * Numerator / a;
            Denominator = Denominator / a;
        }
        public RationalNumber Add(RationalNumber r)
        {
            Int64 k = 0;
            Int64 denom = 0;
            Int64 num = 0;

            RationalNumber rn1;

            reduce();
            r.reduce();

            rn1 = new RationalNumber(Denominator, r.Denominator);
            rn1.reduce();
            k = rn1.Denominator;

            denom = Denominator * k;

            num = Numerator * k + r.Numerator * (denom / r.Denominator);

            rn1 = new RationalNumber(num, denom);
            rn1.reduce();

            return rn1;

        }
        public RationalNumber Sub(RationalNumber r)
        {
            Int64 k = 0;
            Int64 denom = 0;
            Int64 num = 0;

            RationalNumber rn1;

            reduce();
            r.reduce();

            rn1 = new RationalNumber(Denominator, r.Denominator);
            rn1.reduce();
            k = rn1.Denominator;

            denom = Denominator * k;

            num = Numerator * k - r.Numerator * (denom / r.Denominator);

            rn1 = new RationalNumber(num, denom);
            rn1.reduce();

            return rn1;

        }
        public RationalNumber Multiply(RationalNumber r)
        {
            RationalNumber rnl, rnl1, rnl2;
            Int64 num, denom;

            reduce();
            r.reduce();

            rnl1 = new RationalNumber(Numerator, r.Denominator);
            rnl1.reduce();
            rnl2 = new RationalNumber(r.Numerator, Denominator);
            rnl2.reduce();

            num = rnl1.Numerator * rnl2.Numerator;
            denom = rnl1.Denominator * rnl2.Denominator;

            rnl = new RationalNumber(num, denom);

            return rnl;
        }
        public RationalNumber Divide(RationalNumber r)
        {
            RationalNumber rnl;
            // compute the reciprocal of r
            rnl = new RationalNumber(r.Denominator, r.Numerator);
            // multiply by the reciprocal
            return Multiply(rnl);
        }
        public bool Equal(RationalNumber r)
        {
            reduce();
            r.reduce();
            if (Numerator == r.Numerator && Denominator == r.Denominator)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return this.Numerator + "/" + this.Denominator;
        }
    }
    class Program
    {
        static void RationalNumberCalculator()
        {
            Int64 Numerator = 0;
            Int64 Denominator = 0;

            Console.WriteLine("Enter Your Choice");
            Console.WriteLine("1 to reduce Rational number into it's lowest terms");
            Console.WriteLine("2 to Add Two Rational numbers");
            Console.WriteLine("3 to Subtract Two Rational numbers");
            Console.WriteLine("4 to Multiply Two Rational numbers");
            Console.WriteLine("5 to Divide a Rational number with another Rational number");
            Console.WriteLine("6 to check Equality of Two Rational numbers");
            Console.WriteLine("7 to Exit");

            int choice = Convert.ToInt16(Console.ReadLine().Trim());

            switch (choice)
            {
                case 1: //reduce

                    Console.WriteLine("Enter a Rational number to reduce to it's lowest terms");

                    Console.WriteLine("Enter Numerator:");
                    Numerator = Convert.ToInt64(Console.ReadLine().Trim());
                    Console.WriteLine("Enter Denominator:");
                    Denominator = Convert.ToInt64(Console.ReadLine().Trim());

                    RationalNumber rn = new RationalNumber(Numerator, Denominator);
                    rn.reduce();
                    Console.WriteLine("The Rational number in lowest terms is : " + rn);
                    Console.ReadKey();
                    break;
                case 2: //add
                    Console.WriteLine("Enter a Two Rational numbers to add");

                    Console.WriteLine("Enter a First Rational number");
                    Console.WriteLine("Enter 1st RN Numerator:");
                    Numerator = Convert.ToInt64(Console.ReadLine().Trim());
                    Console.WriteLine("Enter 1st RN Denominator:");
                    Denominator = Convert.ToInt64(Console.ReadLine().Trim());
                    RationalNumber addrn1 = new RationalNumber(Numerator, Denominator);

                    Console.WriteLine("Enter a Second Rational number");
                    Console.WriteLine("Enter 2nd RN Numerator:");
                    Numerator = Convert.ToInt64(Console.ReadLine().Trim());
                    Console.WriteLine("Enter 2nd RN Denominator:");
                    Denominator = Convert.ToInt64(Console.ReadLine().Trim());
                    RationalNumber addrn2 = new RationalNumber(Numerator, Denominator);

                    Console.WriteLine("The Result of Addition is :" + addrn1.Add(addrn2));

                    RationalNumberCalculator();
                    break;
                case 3: //subtraction
                    Console.WriteLine("Enter Two Rational numbers to Subtract");

                    Console.WriteLine("Enter a First Rational number");
                    Console.WriteLine("Enter 1st RN Numerator:");
                    Numerator = Convert.ToInt64(Console.ReadLine().Trim());
                    Console.WriteLine("Enter 1st RN Denominator:");
                    Denominator = Convert.ToInt64(Console.ReadLine().Trim());
                    RationalNumber subrn1 = new RationalNumber(Numerator, Denominator);

                    Console.WriteLine("Enter a Second Rational number");
                    Console.WriteLine("Enter 2nd RN Numerator:");
                    Numerator = Convert.ToInt64(Console.ReadLine().Trim());
                    Console.WriteLine("Enter 2nd RN Denominator:");
                    Denominator = Convert.ToInt64(Console.ReadLine().Trim());
                    RationalNumber subrn2 = new RationalNumber(Numerator, Denominator);

                    Console.WriteLine("The Result of Subtraction is :" + subrn1.Sub(subrn2));
                    RationalNumberCalculator();
                    break;
                case 4: //multiplication
                    Console.WriteLine("Enter Two Rational numbers to Multiply");

                    Console.WriteLine("Enter a First Rational number");
                    Console.WriteLine("Enter 1st RN Numerator:");
                    Numerator = Convert.ToInt64(Console.ReadLine().Trim());
                    Console.WriteLine("Enter 1st RN Denominator:");
                    Denominator = Convert.ToInt64(Console.ReadLine().Trim());
                    RationalNumber mulrn1 = new RationalNumber(Numerator, Denominator);

                    Console.WriteLine("Enter a Second Rational number");
                    Console.WriteLine("Enter 2nd RN Numerator:");
                    Numerator = Convert.ToInt64(Console.ReadLine().Trim());
                    Console.WriteLine("Enter 2nd RN Denominator:");
                    Denominator = Convert.ToInt64(Console.ReadLine().Trim());
                    RationalNumber mulrn2 = new RationalNumber(Numerator, Denominator);

                    Console.WriteLine("The Result of Multiplication is :" + mulrn1.Multiply(mulrn2));
                    RationalNumberCalculator();
                    break;
                case 5: //divide
                    Console.WriteLine("Enter Two Rational numbers to Divide");

                    Console.WriteLine("Enter a First Rational number");
                    Console.WriteLine("Enter 1st RN Numerator:");
                    Numerator = Convert.ToInt64(Console.ReadLine().Trim());
                    Console.WriteLine("Enter 1st RN Denominator:");
                    Denominator = Convert.ToInt64(Console.ReadLine().Trim());
                    RationalNumber dividern1 = new RationalNumber(Numerator, Denominator);

                    Console.WriteLine("Enter a Second Rational number");
                    Console.WriteLine("Enter 2nd RN Numerator:");
                    Numerator = Convert.ToInt64(Console.ReadLine().Trim());
                    Console.WriteLine("Enter 2nd RN Denominator:");
                    Denominator = Convert.ToInt64(Console.ReadLine().Trim());
                    RationalNumber dividern2 = new RationalNumber(Numerator, Denominator);

                    Console.WriteLine("The Result of Division is :" + dividern1.Divide(dividern2));
                    RationalNumberCalculator();
                    break;
                case 6: //exit
                    Console.WriteLine("Enter Two Rational numbers to check Equality.");

                    Console.WriteLine("Enter a First Rational number");
                    Console.WriteLine("Enter 1st RN Numerator:");
                    Numerator = Convert.ToInt64(Console.ReadLine().Trim());
                    Console.WriteLine("Enter 1st RN Denominator:");
                    Denominator = Convert.ToInt64(Console.ReadLine().Trim());
                    RationalNumber eqrn1 = new RationalNumber(Numerator, Denominator);

                    Console.WriteLine("Enter a Second Rational number");
                    Console.WriteLine("Enter 2nd RN Numerator:");
                    Numerator = Convert.ToInt64(Console.ReadLine().Trim());
                    Console.WriteLine("Enter 2nd RN Denominator:");
                    Denominator = Convert.ToInt64(Console.ReadLine().Trim());
                    RationalNumber eqrn2 = new RationalNumber(Numerator, Denominator);

                    Console.WriteLine("The Result of Equality is :" + eqrn1.Equal(eqrn2));
                    RationalNumberCalculator();
                    break;
                case 7: //exit
                    Console.WriteLine("exit");
                    break;
                default: //default
                    Console.WriteLine("Choose any one of the above options.");
                    RationalNumberCalculator();
                    break;
            }
        }
        static void Main(string[] args)
        {
            RationalNumberCalculator();
        }
    }
}
