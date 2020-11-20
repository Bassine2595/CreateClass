using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DTO
{
    public class DTOBase :CommonBase
    {
        [JsonIgnore]
        public bool IsNew { get; set; }
    }
}
