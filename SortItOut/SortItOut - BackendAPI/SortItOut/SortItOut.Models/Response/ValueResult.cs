using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SortItOut.Models.Response
{
    [DataContract]
    public class ValueResult
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string? Description { get; set; }
    }
}
