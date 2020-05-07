﻿using System;
using System.Collections.Generic;
using CoreAngularDemo.DAL.Models.Entities.Abstractions;

namespace CoreAngularDemo.DAL.Models.Entities
{
    public class Unit : IBaseEntity, IAuditableEntity
    {
        public Unit()
        {
            Parts = new List<Part>();
            PartsInNavigation = new List<PartIn>();
        }

        public int Id { get; set; }

        public string ShortName { get; set; }

        public string Name { get; set; }

        public ICollection<PartIn> PartsInNavigation { get; set; }

        public string CreatedById { get; set; }

        public virtual User Create { get; set; }

        public string UpdatedById { get; set; }

        public virtual User Mod { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
