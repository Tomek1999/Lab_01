using System;

namespace Lab_01
{
    class Program
    {
        static void Main(string[] args)
        {
            fraction frac = new fraction(12,5);
            string meter = frac.meter.ToString();
            Console.WriteLine(meter);
        }
    }
   
    class fraction {

        public fraction(fraction frac)
        {
            meter = frac.meter;
            denominator = frac.denominator;
        
        }


        public fraction(int Meter, int Denominator)
        {
            meter = Meter;
            denominator = Denominator;
        }
    
        public int meter { get; set; }
        public int denominator { get; set; }

        public override string ToString()
        {
            return this.meter +"/"+ this.denominator;
        }

        /// <summary>
        ///OperatorOverloading
        /// </summary>

        private readonly int num;
        private readonly int den;
        

        public static fraction operator +(fraction a) => a;
        
        public static fraction operator -(fraction a) => new fraction(-a.num, a.den);
        
        public static fraction operator *(fraction a, fraction b)
        => new fraction(a.num * b.num, a.den * b.den);

        public static fraction operator /(fraction a, fraction b)
        {
            if (b.num == 0)
            {
                throw new DivideByZeroException();
            }
            return new fraction(a.num * b.den, a.den * b.num);
        }

    }
}

//https://dirask.com/posts/WSEI-2021-2022-lato-labN-1-ISN-Programowanie-obiektowe-lab-1-pa3ek1
