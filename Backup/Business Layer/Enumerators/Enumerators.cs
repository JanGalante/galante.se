using System;
using BusinessLayer.Attributes;

namespace BusinessLayer.Enumerators
{
    /// <summary>
    /// Summary description for Enumerators 
    /// (EnumeratedConstants)
    /// </summary>
    public static class EnumConstants
    {
        /// <summary>
        /// Enum för typ av "turnering".
        /// </summary>
        public enum GameType
        {
            Undefined,
            League,
            WordChampionship,
            EuropeanChampionship
        }

        //public enum LeagueType
        //{ 
        
        //}

        public enum WinningTeam
        { 
            Undefined,
            Hometeam,
            Draw,
            Awayteam
        }

		/// <summary>
		/// Länder
		/// </summary>
		public enum Country
		{
			Undefined,
			/// <summary>
			/// Algeriet
			/// </summary>
			[StringValue("Algeriet")]
			[CountryInfo("DZ")]
			Algeriet,
			/// <summary>
			/// Argentina 
			/// </summary>
			[StringValue("Argentina")]
			[CountryInfo("AR")]
			Argentina,
			/// <summary>
			/// Australien
			/// </summary>
			[StringValue("Australien")]
			[CountryInfo("AU")]
			Australien,
			/// <summary>
			/// Brasilien
			/// </summary>
			[StringValue("Brasilien")]
			[CountryInfo("BR")]
			Brasilien,
			/// <summary>
			/// Chile
			/// </summary>
			[StringValue("Chile")]
			[CountryInfo("CL")]
			Chile,
			/// <summary>
			/// Danmark
			/// </summary>
			[StringValue("Danmark")]
			[CountryInfo("DK")]
			Danmark,
			/// <summary>
			/// Elfenbenskusten
			/// </summary>
			[StringValue("Elfenbenskusten")]
			[CountryInfo("CI")]
			Elfenbenskusten,
			/// <summary>
			/// England
			/// England saknar landskod, jag har därför valt en egen
			/// </summary>
			[StringValue("England")]
			[CountryInfo("EN")]
			England,
			/// <summary>
			/// Frankrike
			/// </summary>
			[StringValue("Frankrike")]
			[CountryInfo("FR")]
			Frankrike,
			/// <summary>
			/// Ghana
			/// </summary>
			[StringValue("Ghana")]
			[CountryInfo("GH")]
			Ghana,
			/// <summary>
			/// Grekland
			/// </summary>
			[StringValue("Grekland")]
			[CountryInfo("GR", LanguageCode = "el")]
			Grekland,
			/// <summary>
			/// Honduras
			/// </summary>
			[StringValue("Honduras")]
			[CountryInfo("HN")]
			Honduras,
			/// <summary>
			/// Irland
			/// </summary>
			[StringValue("Irland")]
			[CountryInfo("IE")]
			Irland,
			/// <summary>
			/// Italien
			/// </summary>
			[StringValue("Italien")]
			[CountryInfo("IT")]
			Italien,
			/// <summary>
			/// Japan
			/// </summary>
			[StringValue("Japan")]
			[CountryInfo("JP")]
			Japan,
			/// <summary>
			/// Kamerun
			/// </summary>
			[StringValue("Kamerun")]
			[CountryInfo("CM")]
			Kamerun,
			/// <summary>
			/// Kroatien
			/// </summary>
			[StringValue("Kroatien")]
			[CountryInfo("HR")]
			Kroatien,
			/// <summary>
			/// Mexiko
			/// </summary>
			[StringValue("Mexiko")]
			[CountryInfo("MX")]
			Mexiko,
			/// <summary>
			/// Nederländerna
			/// </summary>
			[StringValue("Nederländerna")]
			[CountryInfo("NL")]
			Nederländerna,
			/// <summary>
			/// Nigeria
			/// </summary>
			[StringValue("Nigeria")]
			[CountryInfo("NG")]
			Nigeria,
			/// <summary>
			/// Nordkorea
			/// </summary>
			[StringValue("Nordkorea")]
			[CountryInfo("KP")]
			Nordkorea,
			/// <summary>
			/// Nya Zeeland
			/// </summary>
			[StringValue("Nya Zeeland")]
			[CountryInfo("NZ")]
			Nya_Zeeland,
			/// <summary>
			/// Paraguay
			/// </summary>
			[StringValue("Paraguay")]
			[CountryInfo("PY")]
			Paraguay,
			/// <summary>
			/// Polen
			/// </summary
			[StringValue("Polen")]
			[CountryInfo("PL")]
			Polen,
			/// <summary>
			/// Portugal
			/// </summary>
			[StringValue("Portugal")]
			[CountryInfo("PT")]
			Portugal,
			/// <summary>
			/// Ryssland
			/// </summary>
			[StringValue("Ryssland")]
			[CountryInfo("RU")]
			Ryssland,
			/// <summary>
			/// Schweiz
			/// </summary>
			[StringValue("Schweiz")]
			[CountryInfo("CH")]
			Schweiz,
			/// <summary>
			/// Serbien
			/// </summary>
			[StringValue("Serbien")]
			[CountryInfo("RS")]
			Serbien,
			/// <summary>
			/// Slovakien
			/// </summary>
			[StringValue("Slovakien")]
			[CountryInfo("SK")]
			Slovakien,
			/// <summary>
			/// Slovenien
			/// </summary>
			[StringValue("Slovenien")]
			[CountryInfo("SI")]
			Slovenien,
			/// <summary>
			/// Spanien
			/// </summary>
			[StringValue("Spanien")]
			[CountryInfo("ES")]
			Spanien,
			/// <summary>
			/// Sverige
			/// </summary>
			[StringValue("Sverige")]
			[CountryInfo("SE")]
			Sverige,
			/// <summary>
			/// Sydafrika
			/// </summary>
			[StringValue("Sydafrika")]
			[CountryInfo("ZA")]
			Sydafrika,
			/// <summary>
			/// Sydkorea 
			/// </summary>
			[StringValue("Sydkorea")]
			[CountryInfo("KR")]
			Sydkorea,
			/// <summary>
			/// Tjeckien
			/// </summary>
			[StringValue("Tjeckien")]
			[CountryInfo("CZ")]
			Tjeckien,
			/// <summary>
			/// Tyskland
			/// </summary>
			[StringValue("Tyskland")]
			[CountryInfo("DE")]
			Tyskland,
			/// <summary>
			/// Ukraina
			/// </summary>
			[StringValue("Ukraina")]
			[CountryInfo("UA")]
			Ukraina,
			/// <summary>
			/// Uruguay 
			/// </summary>
			[StringValue("Uruguay")]
			[CountryInfo("UY")]
			Uruguay,
			/// <summary>
			/// USA
			/// </summary>
			[StringValue("USA")]
			[CountryInfo("US")]
			USA
		}

		///// <summary>
		///// Landskoder
		///// </summary>
		//public enum CountryCode
		//{ 
		//    Undefined,
		//    /// <summary>
		//    /// Argentina 
		//    /// </summary>
		//    AR,
		//    /// <summary>
		//    /// Australien
		//    /// </summary>
		//    AU,
		//    /// <summary>
		//    /// Brasilien
		//    /// </summary>
		//    BR,
		//    /// <summary>
		//    /// Elfenbenskusten
		//    /// </summary>
		//    /// 
		//    /// <summary>
		//    /// Schweiz
		//    /// </summary>
		//    CH,
		//    /// <summary>
		//    /// Elfenbenskusten
		//    /// </summary>
		//    CI,
		//    /// <summary>
		//    /// Chile
		//    /// </summary>
		//    CL,
		//    /// <summary>
		//    /// Kamerun
		//    /// </summary>
		//    CM,
		//    /// <summary>
		//    /// Tjeckien
		//    /// </summary>
		//    CZ,
		//    /// <summary>
		//    /// Tyskland
		//    /// </summary>
		//    DE,
		//    /// <summary>
		//    /// Danmark
		//    /// </summary>
		//    DK,
		//    /// <summary>
		//    /// Algeriet
		//    /// </summary>
		//    DZ,
		//    /// <summary>
		//    /// England
		//    /// England saknar landskod, jag har därför valt en egen
		//    /// </summary>
		//    EN,
		//    /// <summary>
		//    /// Spanien
		//    /// </summary>
		//    ES,
		//    /// <summary>
		//    /// Frankrike
		//    /// </summary>
		//    FR,
		//    /// <summary>
		//    /// Ghana
		//    /// </summary>
		//    GH,
		//    /// <summary>
		//    /// Grekland
		//    /// </summary>
		//    GR,
		//    /// <summary>
		//    /// Honduras
		//    /// </summary>
		//    HN,
		//    /// <summary>
		//    /// Kroatien
		//    /// </summary>
		//    HR,
		//    /// <summary>
		//    /// Irland
		//    /// </summary>
		//    IE,
		//    /// <summary>
		//    /// Nordkorea
		//    /// </summary>
		//    KP,
		//    /// <summary>
		//    /// Italien
		//    /// </summary>
		//    IT,
		//    /// <summary>
		//    /// Japan
		//    /// </summary>
		//    JP,
		//    /// <summary>
		//    /// Mexiko
		//    /// </summary>
		//    MX,
		//    /// <summary>
		//    /// Nigeria
		//    /// </summary>
		//    NE,
		//    /// <summary>
		//    /// Nederländerna
		//    /// </summary>
		//    NL,
		//    /// <summary>
		//    /// Nya Zeeland
		//    /// </summary>
		//    NZ,
		//    /// <summary>
		//    /// Polen
		//    /// </summary>
		//    PL,
		//    /// <summary>
		//    /// Portugal
		//    /// </summary>
		//    PT,
		//    /// <summary>
		//    /// Paraguay
		//    /// </summary>
		//    PY,
		//    /// <summary>
		//    /// Serbien
		//    /// </summary>
		//    RS,
		//    /// <summary>
		//    /// Ryssland
		//    /// </summary>
		//    RU,
		//    /// <summary>
		//    /// Sverige
		//    /// </summary>
		//    SE,
		//    /// <summary>
		//    /// Slovenien
		//    /// </summary>
		//    SI,
		//    /// <summary>
		//    /// Slovakien
		//    /// </summary>
		//    SK,
		//    /// <summary>
		//    /// Ukraina
		//    /// </summary>
		//    UA,
		//    /// <summary>
		//    /// USA
		//    /// </summary>
		//    US,
		//    /// <summary>
		//    /// Uruguay 
		//    /// </summary>
		//    UY,
		//    /// <summary>
		//    /// Sydafrika
		//    /// </summary>
		//    ZA
		//}
    } 
}
