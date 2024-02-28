﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.CommonAggregate
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DateTimeCreated { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? DateTimeUpdated { get; set; }
    }
}