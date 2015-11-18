using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Service.DataContract
{
    [DataContract(Namespace = "urn:www-infosupport-com:wcf:centric-maatwerk-training:2015")]
    public class Boodschap
    {
        [DataMember]
        public string Tekst { get; set; }

        public string DezeIsLokaal { get; set; }
    }
}
