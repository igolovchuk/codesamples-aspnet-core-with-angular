﻿using System;
using CoreAngularDemo.DAL.Models.Entities.Abstractions;

namespace CoreAngularDemo.DAL.Models.Entities
{
    /// <summary>
    /// Parts deliveries (поставки деталей).
    /// </summary>
    public class PartIn : IAuditableEntity, IBaseEntity
    {
        public PartIn()
        {

        }

        public int Id { get; set; }
        public uint Amount { get; set; }
        public float Price { get; set; }
        public DateTime ArrivalDate { get; set; }

        /// <summary>
        /// Номер партії.
        /// </summary>
        public string Batch { get; set; }
        public int UnitId { get; set; }
        public int PartId { get; set; }
        public int CurrencyId { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Currency Currency { get; set; }
        public Unit Unit { get; set; }
        public Part Part { get; set; }
    }
}
