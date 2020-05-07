using System;
using System.Collections.Generic;
using CoreAngularDemo.DAL.Models.Entities.Abstractions;

namespace CoreAngularDemo.DAL.Models.Entities
{
    public class ActionType : IAuditableEntity, IBaseEntity
    {
        public ActionType()
        {
            IssueLog = new HashSet<IssueLog>();
            CoreAngularDemoion = new HashSet<CoreAngularDemoion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public bool IsFixed { get; set; }

        public virtual User Create { get; set; }
        public virtual User Mod { get; set; }
        public virtual ICollection<IssueLog> IssueLog { get; set; }
        public virtual ICollection<CoreAngularDemoion> CoreAngularDemoion { get; set; }
    }
}
