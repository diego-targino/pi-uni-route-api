using UniRoute.Domain.Entities.Base;

namespace UniRoute.Domain.Entities;

public class Student : BaseEntity
{
    public string Name { get; set; }
    
    public string Mail { get; set; }
    
    public string Password { get; set; }
    
    public long Salt { get; set; }
}
