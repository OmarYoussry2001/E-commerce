﻿using System.ComponentModel.DataAnnotations;

namespace Domains.Entities.Base
{
    //Base class for entities common properties
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public int CurrentState { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedDateUtc { get; set; }
    }
}
