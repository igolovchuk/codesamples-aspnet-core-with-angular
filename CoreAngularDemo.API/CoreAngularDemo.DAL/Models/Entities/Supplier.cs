﻿using System;
using System.Collections.Generic;
using CoreAngularDemo.DAL.Models.Entities.Abstractions;

namespace CoreAngularDemo.DAL.Models.Entities
{
    public class Supplier : IAuditableEntity, IBaseEntity
    {
        public Supplier()
        { 
            IssueLog = new HashSet<IssueLog>();
            SupplierParts = new HashSet<SupplierPart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public string FullName { get; set; }
        public int? CountryId { get; set; }
        public int? CurrencyId { get; set; }
        public string Edrpou { get; set; }

        public virtual Country Country { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual User Create { get; set; }
        public virtual User Mod { get; set; }

        public virtual ICollection<IssueLog> IssueLog { get; set; }
        public virtual ICollection<SupplierPart> SupplierParts { get; set; }
    }
}
