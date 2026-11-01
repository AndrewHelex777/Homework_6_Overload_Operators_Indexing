namespace Homework_6_Overload_Operators_Indexing
{
    class Fraction
    {
        private int numerator;
        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }
        private int denominator;
        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Denominator can't be 0!");
                }
                denominator = value;
            }
        }
        private int Modul(int a)
        {
            if (a < 0) return -a;
            else return a;
        }
        private int FindNOD(int a, int b)
        {
            a = Modul(a);
            b = Modul(b);
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public void Reduce()
        {
            int c = FindNOD(Modul(numerator), Modul(denominator));
            numerator /= c;
            denominator /= c;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }
        public Fraction(int n, int d)
        {
            Numerator = n;
            Denominator = d;
            Reduce();
        }
        public void Print()
        {
            Console.WriteLine($"{numerator}/{denominator}");
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction c = new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator);
            return c;
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction c = new Fraction(a.numerator * b.denominator - b.numerator * a.denominator, a.denominator * b.denominator);
            return c;
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction c = new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
            return c;
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.numerator == 0)
            {
                throw new DivideByZeroException("Divide by 0!");
            }
            Fraction c = new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
            return c;
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.numerator * b.denominator == b.numerator * a.denominator;
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }
    }
    internal class Task2
    {
        static void Main(string[] args)
        {
            try
            {
                Fraction a = new Fraction(2, 4);
                Fraction b = new Fraction(2, 6);
                Console.Write("a = ");
                a.Print();
                Console.Write("b = ");
                b.Print();
                Console.Write("a + b = ");
                Fraction c = a + b;
                c.Print();
                Console.Write("a - b = ");
                Fraction d = a - b;
                d.Print();
                Console.Write("a * b = ");
                Fraction e = a * b;
                e.Print();
                Console.Write("a / b = ");
                Fraction f = a / b;
                f.Print();
                Console.WriteLine($"a == b? {a == b}");
                Console.WriteLine($"a != b? {a != b}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
