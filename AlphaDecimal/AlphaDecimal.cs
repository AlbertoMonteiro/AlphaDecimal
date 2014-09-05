using System;
using System.Collections.Generic;
using System.Linq;

namespace AlphaDecimal.Console
{
    public struct AlphaDecimal
    {
        private const int BASE = 36;
        private static readonly List<char> TabelaIndex;

        static AlphaDecimal()
        {
            TabelaIndex = new List<char>("0123456789ABCDEFGHIJLKMNOPQRSTUVWXYZ".ToCharArray());
            Tabela = TabelaIndex.Select((c, i) => new { c, i }).ToDictionary(a => a.c, a => a.i);
        }

        public AlphaDecimal(string value)
            : this()
        {
            Value = value ?? "0";
        }

        public string Value { get; private set; }

        public static Dictionary<char, int> Tabela { get; set; }

        public override string ToString()
        {
            return Value;
        }

        public static AlphaDecimal operator +(AlphaDecimal alphaDecimal1, AlphaDecimal alphaDecimal2)
        {
            return (int)alphaDecimal1 + (int)alphaDecimal2;
        }

        public static implicit operator AlphaDecimal(string stringValue)
        {
            return new AlphaDecimal(stringValue);
        }

        public static implicit operator AlphaDecimal(int decimalValue)
        {
            int resto;
            IList<char> lista = new List<char>();
            do
            {
                resto = decimalValue % BASE;
                decimalValue = decimalValue / BASE;
                lista.Add(TabelaIndex[resto]);
            } while (resto > BASE);
            if (decimalValue != 0)
                lista.Add(TabelaIndex[decimalValue]);
            return new AlphaDecimal(new string(lista.Reverse().ToArray()));
        }

        public static implicit operator int(AlphaDecimal alpha)
        {
            return alpha.Value.ToCharArray().Reverse().Select(chr => Tabela[chr]).Select((i, index) => (int)Math.Pow(BASE, index) * i).Sum();
        }
    }
}