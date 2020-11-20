using System;
using System.Collections.Generic;
using System.Text;
namespace DTO
    {
        public class AnswerDTO : DTOBase
        {
            public Int32 Id  {get; set;} 
            public String IdQuestion  {get; set;} 
            public String Libelle  {get; set;} 
        public AnswerDTO()
            {
                Id = Int32_NullValue;
                IdQuestion = String_NullValue;
                Libelle = String_NullValue;
            }
        }
    }
