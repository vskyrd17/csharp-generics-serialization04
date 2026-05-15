
namespace GenericLabLib
{
    public class Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0) throw new DivideByZeroException("Знаменник не може бути нулем.");
            Numerator = numerator;
            Denominator = denominator;
            // Спрощення дробу
        }

        // Перевантаження операторів (+, -, *, /)
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator,
                                a.Denominator * b.Denominator);
        }

        // ... (Інші оператори -, *, /)

        // Ділення на ціле число (потрібно для dynamic)
        public static Fraction operator /(Fraction a, int b)
        {
            return new Fraction(a.Numerator, a.Denominator * b);
        }

        public override string ToString() => $"{Numerator}/{Denominator}";
    }
}