using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace DataAccessLayer.Enum
{
    public enum TipoAttitudine
    {
        [Description("Lista per personaggi Biologici")]
        Biologico = 0,
        [Description("Classe di droidi")]
        ClasseDroide = 1,
        [Description("Lista per personaggi droidi")]
        Droide = 2,
        [Description("Lista di innesti per biologici")]
        Innesti = 3,
        [Description("Potenziamenti comuni per droidi")]
        InnestiDroide = 4
    }

    public class EnumUtilities
    {
        public static string GetEnumDescription(System.Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
