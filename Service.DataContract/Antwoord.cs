﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Service.DataContract
{
    [DataContract]
    public class Antwoord
    {
        [DataMember]
        public string Tekst { get; set; }

        public object DezeIsOokLokaal { get; set; }
    }
}
