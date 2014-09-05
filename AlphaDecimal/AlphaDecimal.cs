using System;
using System.Collections.Generic;
using System.Linq;

namespace AlphaDecimal.Console
{
    public struct AlphaDecimal
    {
        private const int BASE = 36;
        private static Dictionary<char, int> tabela;
        private static readonly List<char> TabelaIndex;

        static AlphaDecimal()
        {
            TabelaIndex = new List<char>();
            TabelaIndex.AddRange("0123456789ABCDEFGHIJLKMNOPQRSTUVWXYZ".ToCharArray());
        }

        public AlphaDecimal(string value)
            : this()
        {
            Value = value ?? "0";
        }

        public string Value { get; set; }

        private static Dictionary<char, int> Tabela
        {
            get
            {
                if (tabela != null)
                    return tabela;
                tabela = new Dictionary<char, int>();
                int contador = 0;
                foreach (char chr in TabelaIndex)
                    tabela.Add(chr, contador++);
                return tabela;
            }
        }

        public override string ToString()
        {
            return Value;
        }

        public static AlphaDecimal operator +(AlphaDecimal a, AlphaDecimal b)
        {
            return (int)a + (int)b;
        }

        public static implicit operator AlphaDecimal(string a)
        {
            return new AlphaDecimal(a);
        }

        public static implicit operator AlphaDecimal(int decimalValue)
        {
            int resto;
            var lista = new List<char>();
            do
            {
                resto = decimalValue % BASE;
                decimalValue = decimalValue / BASE;
                lista.Add(TabelaIndex[resto]);
            } while (resto > BASE);
            if (decimalValue != 0)
                lista.Add(TabelaIndex[decimalValue]);
            return new AlphaDecimal(new string(lista.ToArray().Reverse().ToArray()));
        }

        public static implicit operator int(AlphaDecimal alpha)
        {
            return alpha.Value.ToCharArray().Reverse().Select(chr => Tabela[chr]).Select((i, index) => (int)Math.Pow(BASE, index) * i).Sum();
        }
    }
}