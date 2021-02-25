using System;


namespace MathLib
{
    /// <summary>
    /// Eine Klasse zur Darstellung von Brüchen.
    /// </summary>
    public class MyFraction
    {
        /// <summary>
        /// Der Zähler des Bruchs.
        /// </summary>
        public int Numerator { get; private set; }
        /// <summary>
        /// Der Nenner des Bruchs.
        /// </summary>
        public uint Denominator { get; private set; }

        /// <summary>
        /// Erstellt eine neue Instanz der Bruch-Klasse.
        /// </summary>
        /// <param name="numerator">Der Zähler der neuen Instanz.</param>
        /// <param name="denominator">Der Nenner der neuen Instanz.</param>
        public MyFraction(int numerator, uint denominator)
        {
            // Weise die neuen Werte für Zähler und Nenner zu.
            Numerator = numerator;
            Denominator = denominator;

            format();
        }
        /// <summary>
        /// Privater Konstruktor der nur für die interne Instanziierung von leeren Instanzen verwendet wird.
        /// </summary>
        private MyFraction()
        {
            Numerator = 0;
            Denominator = 1;
        }
        /// <summary>
        /// Privater Konstruktor der nur für den Impliziten Umwandlungsoperator von int nach Fraction genutzt werden soll.
        /// </summary>
        /// <param name="numerator">Der Zähler der neuen Instanz.</param>
        private MyFraction(int numerator)
        {
            Numerator = numerator;
            Denominator = 1;
        }

        public override string ToString()
        {
            if (Denominator == 1)
                return Numerator.ToString();
            else
            {
                string fractionstring = (Numerator < 0 ? "- " : "");
                fractionstring += Math.Abs(Numerator).ToString();
                fractionstring += " / ";
                fractionstring += Denominator.ToString();
                return fractionstring;
            }
        }

        /// <summary>
        /// Private Funktion zum Formatieren eines Bruchs, sprich Kürzen und überprüfen ob der Nenner nicht 0 ist (und damit nicht durch 0 geteilt wird).
        /// </summary>
        private void format()
        {
            // Wenn der Nenner eines Bruchs 0 ist soll eine DivideByZeroException ausgelöst werden.
            if (Denominator == 0)
                throw new DivideByZeroException("Der Nenner des Bruchs war 0.");

            // Berechne den größten gemeinsamen Teiler von Zähler und Nenner und teile beide durch diesen.
            int gcd = MathHelper.GetGCD(Numerator, (int)Denominator);
            Numerator /= gcd;
            Denominator /= (uint)gcd;

            if (Numerator == 0)
                Denominator = 1;
        }

        public static bool operator ==(MyFraction op1, MyFraction op2)
        {
            return op1.Numerator == op2.Numerator && op1.Denominator == op2.Denominator;
        }
        public static bool operator !=(MyFraction op1, MyFraction op2)
        {
            return op1.Numerator != op2.Numerator || op1.Denominator != op2.Denominator;
        }
        // In diesen Ungleichheits-VergleichOperatoren werden die Zähler der beiden Operanden so erweitert, dass sie quasi auf dem gleichen Nenner (kleinstes
        // gemeinsames Vielfaches) basieren, auch wenn keine wirklichen neuen MyFraction-Instanzen generiert werden. Diese angepassten Zähler werden dann
        // miteinander verglichen.
        public static bool operator <(MyFraction op1, MyFraction op2)
        {
            int denominatorLCM = MathHelper.GetLCM((int)op1.Denominator, (int)op2.Denominator);
            return (op1.Numerator * (denominatorLCM / op1.Denominator)) < (op2.Numerator * (denominatorLCM / op2.Denominator));
        }
        public static bool operator >(MyFraction op1, MyFraction op2)
        {
            int denominatorLCM = MathHelper.GetLCM((int)op1.Denominator, (int)op2.Denominator);
            return (op1.Numerator * (denominatorLCM / op1.Denominator)) > (op2.Numerator * (denominatorLCM / op2.Denominator));
        }
        public static bool operator <=(MyFraction op1, MyFraction op2)
        {
            int denominatorLCM = MathHelper.GetLCM((int)op1.Denominator, (int)op2.Denominator);
            return (op1.Numerator * (denominatorLCM / op1.Denominator)) <= (op2.Numerator * (denominatorLCM / op2.Denominator));
        }
        public static bool operator >=(MyFraction op1, MyFraction op2)
        {
            int denominatorLCM = MathHelper.GetLCM((int)op1.Denominator, (int)op2.Denominator);
            return (op1.Numerator * (denominatorLCM / op1.Denominator)) >= (op2.Numerator * (denominatorLCM / op2.Denominator));
        }

        public static MyFraction operator -(MyFraction op)
        {
            MyFraction returnvalue = new MyFraction();
            returnvalue.Numerator = -op.Numerator;
            returnvalue.Denominator = op.Denominator;
            return returnvalue;
        }
        // Auch für Addition und Subtraction werden die Zähler der Brüche so erweitert, dass sie auf einem gemeinsamen Zähler basieren. Diese Zähler werden
        // dann addiert oder subtrahiert um den Zähler des Rückgabewertes zu erhalten und der Nenner der neuen Instanz ist eben dieser gemeinesame Zähler
        // (kleinstes gemeinsames Vielfaches).
        public static MyFraction operator +(MyFraction op1, MyFraction op2)
        {
            int denominatorLCM = MathHelper.GetLCM((int)op1.Denominator, (int)op2.Denominator);
            MyFraction returnvalue = new MyFraction();
            returnvalue.Numerator = (int)((op1.Numerator * (denominatorLCM / op1.Denominator)) + (op2.Numerator * (denominatorLCM / op2.Denominator)));
            returnvalue.Denominator = (uint)denominatorLCM;
            returnvalue.format();
            return returnvalue;
        }
        public static MyFraction operator -(MyFraction op1, MyFraction op2)
        {
            int denominatorLCM = MathHelper.GetLCM((int)op1.Denominator, (int)op2.Denominator);
            MyFraction returnvalue = new MyFraction();
            returnvalue.Numerator = (int)((op1.Numerator * (denominatorLCM / op1.Denominator)) - (op2.Numerator * (denominatorLCM / op2.Denominator)));
            returnvalue.Denominator = (uint)denominatorLCM;
            returnvalue.format();
            return returnvalue;
        }
        // Die Multiplikation zwerier Brüche gestaltet sich einfach, man muss lediglich die beiden Zähler miteinander multiplizieren für den Zähler der neuen
        // Instanz und die beiden Nenner für den neuen Nenner. Durch Aufruf des Standard-Constructors werden diese Werte auch automatisch richtig gekürzt.
        public static MyFraction operator *(MyFraction op1, MyFraction op2)
        {
            return new MyFraction(op1.Numerator * op2.Numerator, op1.Denominator * op2.Denominator);
        }
        // Die Division läuft ähnlich ab zur Multiplikation. Es gibt jedoch eine Besonderheit: für den neuen Nenner werden der Nenner von op1 und der Zähler
        // von op2 miteinander Multipliziert, letzterer kann jedoch auch negativ sein und somit kann der ganze neue Nenner auch negativ sein. Das Minus
        // bekommen wir zwar weg indem wir mit Math.Abs() den Betrag bilden, dieses muss jedoch das Vorzeichen des neuen des neuen Zählers umkehren.
        public static MyFraction operator /(MyFraction op1, MyFraction op2)
        {
            long newDenominator = op1.Denominator * op2.Numerator;
            MyFraction returnvalue = new MyFraction();
            returnvalue.Numerator = (int)(op1.Numerator * op2.Denominator);
            if (newDenominator < 0)
                returnvalue.Numerator = -returnvalue.Numerator;
            returnvalue.Denominator = (uint)Math.Abs(newDenominator);
            returnvalue.format();
            return returnvalue;
        }

        public static implicit operator MyFraction(int op)
        {
            return new MyFraction(op);
        }
    }
}
