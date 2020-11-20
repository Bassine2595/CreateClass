using System;
using System.Collections.Generic;
using System.Text;
namespace DTO
    {
        public class QuestionDTO : DTOBase
        {
            public Int32 Id  {get; set;} 
            public String IdTheme  {get; set;} 
            public String Libelle  {get; set;} 
        public QuestionDTO()
            {
                Id = Int32_NullValue;
                IdTheme = String_NullValue;
                Libelle = String_NullValue;
            }
        }
    }
