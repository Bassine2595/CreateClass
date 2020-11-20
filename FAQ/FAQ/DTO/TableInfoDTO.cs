using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
   public class TableInfoDTO : DTOBase
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public TableInfoDTO()
        {
            Name = String_NullValue;
            Type = String_NullValue;
            IsNew = true;
        }
    }

}
