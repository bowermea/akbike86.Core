using System;
using System.ComponentModel;

namespace akbike86.Zodiac
{
    public enum Polarity : byte
    {
        Positive = 1, Negative = 2, Neutral = 3
    }

    public enum Modality : byte
    {
        Cardinal = 1, Fixed = 2, Mutable = 3
    }

    public class Class1
    {
        public Dictionary<char, string> elems = new Dictionary<char, string>() {
             { '△', "UpTriangle" }
            ,{ '▲', "UpBlkTriangle" }
            ,{ '▽', "DownTriangle" }
            ,{ '▼', "DownBlkTriangle" }
            ,{ '◁', "LeftTriangle" }
            ,{ '▷', "RightTriangle" }
            ,{ '◇', "Diamond" }
            ,{ '◆', "BlkDiamond" }
            ,{ '○', "Circle" }
            ,{ '□', "Square" }
            ,{ '■', "BlkSquare" }

            //,{ '🜁', "Air" }
            //,{ '🜂', "Fire" }
            //,{ '🜃', "Earth" }
            //,{ '🜄', "Water" }
            //,{ '🜊', "[Vinegar]" }
            //,{ '🜔', "[Salt]" }
            //,{ '🜕', "[Nitre]" }
            //,{ '🝯', "[Night]" }
            //,{ '🜲', "[Regulus]" }

        };	
        public const char ANKH             = (char)0x2625; //  '☥' 	U+2625	
        public const char CROSSORTHODOX    = (char)0x2626; // '☦'  U+2626
        public const char CROSSLORRAINE    = (char)0x2628; // '☨'  U+2628
        public const char CROSSJERUSALEM   = (char)0x2629; // '☩'  U+2629
        public const char CHIRHO           = (char)0x2627; // '☧'  U+2627
        public const char CRESCENTSTAR     = (char)0x262A; // '☪'  U+262A
        public const char FARSISYMBOL      = (char)0x262B; // '☫'  U+262B
        public const char ADISHAKTI        = (char)0x262C; // '☬'  U+262C
        public const char PEACESYMBOL      = (char)0x262E; // '☮'  U+262E
        public const char YINYANG          = (char)0x262F; // '☯'  U+262F
        public const char DHARMAWHEEL      = (char)0x2638; // '☸'  U+2638

        public const char ARIES            = (char)0x2648; // '♈️'  ;// U+2648 
        public const char TAURUS           = (char)0x2649; // '♉️'  ;// U+2649 
        public const char GEMINI           = (char)0x264A; // '♊️'  ;// U+264A 
        public const char CANCER           = (char)0x264B; // '♋️'  ;// U+264B 
        public const char LEO              = (char)0x264C; // '♌️'  ;// U+264C 
        public const char VIRGO            = (char)0x264D; // '♍️'  ;// U+264D 
        public const char LIBRA            = (char)0x264E; // '♎️'  ;// U+264E 
        public const char SCORPIUS         = (char)0x264F; // '♏️'  ;// U+264F 
        public const char SAGITTARIUS      = (char)0x2650; // '♐️'  ;// U+2650 
        public const char CAPRICORN        = (char)0x2651; // '♑️'  ;// U+2651 
        public const char AQUARIUS         = (char)0x2652; // '♒️'  ;// U+2652 
        public const char PISCES           = (char)0x2653; // '♓️'  ;// U+2653 
        public const char OPHIUCHUS        = (char)0x26CE; // '⛎' ;// U+26CE 
        public const char MERCURY          = (char)0x263F; // '☿' 	U+263F	
        public const char EARTH            = (char)0x2641; // '♁' 	U+2641	
        public const char JUPITER          = (char)0x2643; // '♃' 	U+2643	
        public const char SATURN           = (char)0x2644; // '♄' 	U+2644	
        public const char URANUS           = (char)0x2645; // '♅' 	U+2645	
        public const char NEPTUNE          = (char)0x2646; // '♆' 	U+2646	
        public const char PLUTO            = (char)0x2647; // '♇' 	U+2647	
        public const char CERES            = (char)0x26B3; // '⚳' 	U+26B3  
        public const char PALLAS           = (char)0x26B4; // '⚴' 	U+26B4  
        public const char JUNO             = (char)0x26B5; // '⚵' 	U+26B5  
        public const char VESTA            = (char)0x26B6; // '⚶' 	U+26B6  
        public const char CHIRON           = (char)0x26B7; // '⚷' 	U+26B7  
        public const char BLACKMOONLILITH  = (char)0x26B8; // '⚸' 	U+26B8  

        public const char FEMALE           = (char)0x2640; // '♀' 	U+2640	
        public const char MALE             = (char)0x2642; // '♂' 	U+2642	
        public const char WHITEFLAG        = (char)0x2690; // '⚐' 	U+2690	 
        public const char BLACKFLAG        = (char)0x2691; // '⚑' 	U+2691	 
        public const char CROSSEDSWORDS    = (char)0x2694; // '⚔'  U+2694	 
        public const char HAMMERPICK       = (char)0x2692; // '⚒'  U+2692	 
        public const char HAMMERSICKLE     = (char)0x262D; // '☭'  U+262D
        public const char ANCHOR           = (char)0x2693; // '⚓️'  U+2693
        public const char CADUCEUS         = (char)0x2624; // '☤' 	U+2624	 
        public const char STAFFAESCULAPIUS = (char)0x2695; // '⚕'  U+2695	 
        public const char STAFFHERMES      = (char)0x269A; // '⚚' 	U+269A   
        public const char SCALES           = (char)0x2696; // '⚖'  U+2696	 
        public const char ALEMBIC          = (char)0x2697; // '⚗'  U+2697	 
        public const char FLOWER           = (char)0x2698; // '⚘' 	U+2698	 
        public const char GEAR             = (char)0x2699; // '⚙'  U+2699	 
        public const char SKULLCROSSBONES  = (char)0x2620; // '☠' 	U+2620	
        public const char RADIOACTIVE      = (char)0x2622; // '☢' 	U+2622	
        public const char BIOHAZARD        = (char)0x2623; // '☣' 	U+2623	
        public const char ATOMSYMBOL       = (char)0x269B; // '⚛'  U+269B   
        public const char WARNINGSIGN     = (char)0x26A0; // '⚠️' 	U+26A0  

        public const char SUNWITHRAYS     = (char)0x263C; // '☼' 	U+263C  
        public const char HOTSPRINGS      = (char)0x2668; // '♨️' 	U+2668	
        public const char PERMANENTPAPER  = (char)0x267E; // '♾' 	U+267E	
        public const char FLEURDELIS      = (char)0x269C; // '⚜' 	U+269C  
        public const char OUTLINEDSTAR    = (char)0x269D; // '⚝' 	U+269D	
        public const char VOLT            = (char)0x26A1; // '⚡️' 	U+26A1  
        public const char BLACKSTAR       = (char)0x2605; // '★' 	U+2605	
        public const char WHITESTAR       = (char)0x2606; // '☆' 	U+2606	
        public const char LIGHTNING       = (char)0x2607; // '☇' 	U+2607	
        public const char THUNDERSTORM    = (char)0x2608; // '☈' 	U+2608	
        public const char SUN             = (char)0x2609; // '☉' 	U+2609	
        public const char ASCENDINGNODE   = (char)0x260A; // '☊' 	U+260A  
        public const char DESCENDINGNODE  = (char)0x260B; // '☋' 	U+260B  
        public const char CONJUNCTION     = (char)0x260C; // '☌' 	U+260C  
        public const char OPPOSITION      = (char)0x260D; // '☍' 	U+260D	
    }

}
