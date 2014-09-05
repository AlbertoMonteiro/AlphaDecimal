using System;
using System.Collections.Generic;
using System.Linq;

namespace AlphaDecimal
{
    public struct AplhaDecimal
    {
        private const int BASE = 36;
        private static Dictionary<char, int> tabela;
        private static readonly List<char> TabelaIndex;

        static AplhaDecimal()
        {
            TabelaIndex = new List<char>();
            TabelaIndex.AddRange("0123456789ABCDEFGHIJLKMNOPQRSTUVWXYZ".ToCharArray());
        }

        public AplhaDecimal(string value)
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

        public static AplhaDecimal operator +(AplhaDecimal a, AplhaDecimal b)
        {
            return (int)a + (int)b;
        }

        public static implicit operator AplhaDecimal(string a)
        {
            return new AplhaDecimal(a);
        }

        public static implicit operator AplhaDecimal(int decimalValue)
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
            return new AplhaDecimal(new string(lista.ToArray().Reverse().ToArray()));
        }

        public static implicit operator int(AplhaDecimal alpha)
        {
            return alpha.Value.ToCharArray().Reverse().Select(chr => Tabela[chr]).Select((i, index) => (int)Math.Pow(BASE, index) * i).Sum();
        }
    }
}