﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SortItOut.DataAccess.Csc.Models
{
    public partial class Address
    {
        public Address()
        {
            Manufacturer = new HashSet<Manufacturer>();
            Storage = new HashSet<Storage>();
        }

        public int AddressId { get; set; }
        public int PostalCode { get; set; }
        public string AdressLine { get; set; }
        public bool? IsPrimary { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Manufacturer> Manufacturer { get; set; }
        public virtual ICollection<Storage> Storage { get; set; }
    }
}