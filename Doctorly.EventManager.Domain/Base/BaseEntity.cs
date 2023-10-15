using System.ComponentModel.DataAnnotations;

namespace Doctorly.EventManager.Domain.Base;

public abstract class BaseEntity : BaseEntity<int>
{
    public BaseEntity()
    {
        CreateOn = DateTime.Now;
        UpdateOn = DateTime.Now;
    }
}

public abstract class BaseEntity<TKey>
{
    [Key]
    public TKey Id { get; set; }
    public DateTime CreateOn { get; set; }
    public DateTime UpdateOn { get; set; }
}