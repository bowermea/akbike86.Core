using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akbike86.Zodiac
{
    public enum Constellation : byte { None=0, UrsaMajor, UsraMinor, Archer, Ram }
    public enum Source : byte { Unknown=0, Latin, Greek, Scandanavian, Egyptian, Babylonian, Chinese, Indian, Hindu }
    internal class Sign
    {
        public string Name;
        public char Symbol;
        public Constellation Constellation;
        public string Attribute;

        static Sign()
        {
            Aries = new("Aries", Class1.ARIES, Constellation.Ram, "");
        }

        public static readonly Sign Aries;
        public static readonly Sign Ram;
        public static readonly Sign Taurus;
        public static readonly Sign Bull;
        public static readonly Sign Gemini;
        public static readonly Sign Twins;
        public static readonly Sign Cancer;
        public static readonly Sign Crab;
        public static readonly Sign Leo;
        public static readonly Sign Lion;
        public static readonly Sign Virgo;
        public static readonly Sign Maiden;
        public static readonly Sign Libra;
        public static readonly Sign Scales;
        public static readonly Sign Scorpio;
        public static readonly Sign Scorpion;
        public static readonly Sign Sagittarius;
        public static readonly Sign Archer;
        public static readonly Sign Centaur;
        public static readonly Sign Capricorn;
        public static readonly Sign Goat;
        public static readonly Sign Aquarius;
        public static readonly Sign Waterbearer;
        public static readonly Sign Pisces;
        public static readonly Sign Fish;

        private Sign(string name, char symbol, Constellation constellation, string attribute)
        {
            Name = name;
            Symbol = symbol;
            Constellation = constellation;
            Attribute = attribute;
        }

        public Sign this[string name] { 
            get{ return null; } 
        }
    }
}
