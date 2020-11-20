using System;

namespace DTO
{


    public static class DTOParserFactory
    {
        // GetParser
        public static DTOParser GetParser(System.Type DTOType)
        {
            switch (DTOType.Name)
            {
                case "ThemeDTO":
                   return new DTOParser_Theme();
                case "TableInfoDTO":
                    return new DTOParser_TableInfo();

            }
            // Si nous arrivons ici alors c'est que nous n'avons pas réussi à trouver le type correspondant. Nous levons donc une exception.
            throw new Exception("Unknown Type");
        }
    }
}



