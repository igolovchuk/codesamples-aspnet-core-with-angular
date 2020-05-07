﻿using System;
using System.Collections.Generic;
using CoreAngularDemo.DAL.Models.Entities.Abstractions;

namespace CoreAngularDemo.DAL.Models.Entities
{
    public class MalfunctionGroup : IAuditableEntity, IBaseEntity
    {
        public MalfunctionGroup()
        {
            MalfunctionSubgroup = new HashSet<MalfunctionSubgroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public virtual User Create { get; set; }
        public virtual User Mod { get; set; }
        public virtual ICollection<MalfunctionSubgroup> MalfunctionSubgroup { get; set; }
    }
}
