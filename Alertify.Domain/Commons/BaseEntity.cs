﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Alertify.Domain.Common;

public abstract class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}
