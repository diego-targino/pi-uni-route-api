using UniRoute.Domain.Entities.Base;

namespace UniRoute.Domain.Entities;

public class Address : BaseEntity
{
    public long StudentId { get; set; }

    public string Street { get; set; }

    public string PostalCode { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public Student Student { get; set; }
}
