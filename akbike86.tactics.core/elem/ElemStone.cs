using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akbike86.tactics.core.elem
{
    public class Gemstone : int
    {
        [Flags]
        public enum StoneType : byte { na=0,
            // tertiary color = 0x10
            red = 0x20,
            vermillion = red|0x10, // 0x30
            orange = red|yellow,   // 0x60
            amber = orange|0x10,   // 0x70
            yellow = 0x40,
            chartreuse = yellow|0x10, // 0x50
            green  = yellow&blue,  // 0xC0
            teal = green|0x10,     // 0xD0
            blue   = 0x80,
            violet = blue|0x10,    // 0x90
            purple = blue&red,     // 0xA0
            magenta = purple|0x10, // 0xB0
            white = 0xE0,
            black = 0xF0, 
        }

        public String Name { get; protected set; }
        public StoneType Type { get; protected set; }
        public byte R { get; protected set; }
        public byte G { get; protected set; }
        public byte B { get; protected set; }

        protected Gemstone (string name, StoneType type, byte r, byte g, byte b) { }
        protected Gemstone(string name, StoneType type, int color) :
            this(name, type, (byte)(color & 0x000000FF), (byte)((color & 0x0000FF00) >> 8), (byte)((color & 0x00FF0000) >> 16)) { }
        protected Gemstone(string name, StoneType type, Color color) : this(name, type, color.R, color.G, color.B) { }



        // spinal, agate, tourmaline, garnet, opal, zircon, fire opal, beryl, Apatite, Sphene, pezzottaite, labradorite, chrysoberyl
        Moonstone = KnownColor.White,
        Obsidian = KnownColor.Black,
        Onyx = KnownColor.Black,
        ,Nuummite // freckled dark gray

        // pink,
        ,Rhodochrosite 
        ,Kunzite
        ,RoseQuartz
        ,Morganite

        // red , proustite, cuprite, rhodonite, bixbite
        , Garnet = 0x733635
        , Ruby   = 0x9B111E
        , Jasper = 0xd73b3e

        // green, ekanite, hiddenite, moldavite, Prasiolite, Variscite
        , Gaspeite
        , Serpentine = 0xA2B67B
        , Malachite  = 0x0BDA51
        , Jade       = 0X00A86B
        ,Emerald
        ,Maw-sit-sit
        // blue/green, Amazonite
        ,Aquamarine = KnownColor.Aquamarine
        ,Turquoise = KnownColor.Turquoise
        // blue , sodalite, cavansite, lazulite, Benitoite, hawk's eye, dumortierite, hemimorphite
        , Azurite     = 0x0080FF
        , Kyanite     = 0x0058FF
        , Saphhire    = 0x0D52BD
        , LapisLazuli = 0x2832C2
        // violet/purple , Iolite, Aventurine
        , Tanzanite   = 0x835995
        , Amethyst    = 0x9966CC
        , Fluorite    = 0xD7D2FA

        // yellow
        // yellow Legrandite, Sphalerite
        , Calcite = KnownColor.Yellow
        ,Citrine
        ,Peridot
        // brown / orange , tigereye, jasper, bronzite
        , Topaz
        ,Pyrite

        // environment (non-stone materials)
        ,Jet // charcoal
        ,Amber
        ,Coral = KnownColor.Coral // pink
        ,Pearl // blank, white, blue akoya
    }
}
