﻿using TrackingChangesBimModel.Domain.Common;

namespace TrackingChangesBimModel.Domain.Entities;

public class User : EntityBase
{
    public string? FirstName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public virtual ICollection<Change>? Changes { get; set; }
}
