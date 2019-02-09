using RestWithApstNet.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RestWithApstNet.Data.VO
{
    [DataContract]
    public class BookVO
    {
        //[DataMember (Order = 1, Name = "Código")]
        [DataMember(Order = 1)]
        public long? Id { get; set; }
        [DataMember(Order = 2)]
        public string Title { get; set; }
        [DataMember(Order = 3)]
        public string Author { get; set; }
        [DataMember(Order = 5)]
        public decimal price { get; set; }
        [DataMember(Order = 4)]
        public DateTime LanchDate { get; set; }
    }
}
