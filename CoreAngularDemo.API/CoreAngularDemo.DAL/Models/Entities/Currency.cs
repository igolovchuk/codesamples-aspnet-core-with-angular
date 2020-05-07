﻿using System;
using System.Collections.Generic;
using CoreAngularDemo.DAL.Models.Entities.Abstractions;

namespace CoreAngularDemo.DAL.Models.Entities
{
    public class Currency : IAuditableEntity, IBaseEntity
    {
        public Currency()
        {
            Supplier = new List<Supplier>();
            PartsInNavigation = new List<PartIn>();
        }

        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }

        public virtual User Create { get; set; }
        public virtual User Mod { get; set; }
        
        public virtual ICollection<Supplier> Supplier { get; set; }
        public virtual ICollection<PartIn> PartsInNavigation { get; set; }
    }
}
