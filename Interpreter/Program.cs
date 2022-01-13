using System;
using System.Collections.Generic;

namespace Interpreter
{
    internal class Context
    {
        public Context(string input) => Input = input;

        public string Input { get; set; }

        public int Output { get; set; }
    }

    internal abstract class Phrase
    {
        public void Interpreter(Context context)
        {
            if (context.Input.Length == 0)
                return;

            if (context.Input.StartsWith(Nine()))
            {
                context.Output += Multiplier() * 9;
                context.Input = context.Input[Nine().Length..];
            }
            if (context.Input.StartsWith(Five()))
            {
                context.Output += Multiplier() * 5;
                context.Input = context.Input[Five().Length..];
            }
            if (context.Input.StartsWith(Four()))
            {
                context.Output +=  Multiplier() * 4;
                context.Input = context.Input[Four().Length..];
            }
            while (context.Input.StartsWith(One()))
            {
                context.Output += Multiplier() * 1;
                context.Input = context.Input[One().Length..];
            }
        }

        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();
    }

    internal class PhraseOnes : Phrase
    {
        public override string One() => "I";
        public override string Four() => "IV";
        public override string Five() => "V";
        public override string Nine() => "IX";
        public override int Multiplier() => 1;
    }

    internal class PhraseTens : Phrase
    {
        public override string One() => "X";
        public override string Four() => "XL";
        public override string Five() => "L";
        public override string Nine() => "XC";
        public override int Multiplier() => 10;
    }
    internal class PhraseHundreds : Phrase
    {
        public override string One() => "C";
        public override string Four() => "CD";
        public override string Five() => "D";
        public override string Nine() => "CM";
        public override int Multiplier() => 100;
    }
    internal class PhraseThousands : Phrase
    {
        public override string One() => "M";
        public override string Four() => " ";
        public override string Five() => " ";
        public override string Nine() => " ";
        public override int Multiplier() => 1000;
    }

    public static class Apka
    {
        private static void Main()
        {
            var tree = new List<Phrase>
            {
                new PhraseThousands(),
                new PhraseHundreds(),
                new PhraseTens(),
                new PhraseOnes()
            };

            var roman = "MDXLIII";
            var context = new Context(roman);
            foreach (var item in tree)
            {
                item.Interpreter(context);
            }
            Console.WriteLine(roman + " = " + context.Output);

            roman = "CMXVII";
            context = new Context(roman);
            foreach (var item in tree)
            {
                item.Interpreter(context);
            }
            Console.WriteLine(roman + " = " + context.Output);
        }
    }
}