using UniRoute.Domain.Entities;
using UniRoute.Domain.Interfaces.Repositories;
using UniRoute.Infrastructure.Repositories.Base;

namespace UniRoute.Infrastructure.Repositories;

public class AddressRepository : BaseRepository<Address>, IAddressRepository
{
}
