using System.ComponentModel.DataAnnotations;

namespace ScaleArch.Core;

public abstract class BaseEntity
{

    public BaseEntity() : this(Guid.NewGuid().ToString())
    {
    }
    public BaseEntity(string id)
    {
        this.Id = string.IsNullOrWhiteSpace(id) ? Guid.NewGuid().ToString() : id;
    }

    [Key]
    public virtual string Id { get; set; }
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime UpdatedAt { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; protected set; }
}