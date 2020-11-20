using System;
using System.Collections.Generic;
using System.Text;
namespace DTO
    {
        public class ThemeDTO : DTOBase
        {
            public Int32 Id  {get; set;} 
            public String Libelle  {get; set;} 
        public ThemeDTO()
            {
                Id = Int32_NullValue;
                Libelle = String_NullValue;
            }
        }
    }
