using Microsoft.EntityFrameworkCore;
using UniRoute.Domain.Entities;
using UniRoute.Domain.Interfaces.Repositories;
using UniRoute.Infrastructure.Data;
using UniRoute.Infrastructure.Repositories.Base;

namespace UniRoute.Infrastructure.Repositories;

public class AddressRepository(AppDbContext appDbContext) : BaseRepository<Address>(appDbContext), IAddressRepository
{
    public async Task<Address?> GetByStudentIdAsync(long studentId)
    {
        return await appDbContext.Addresses.AsNoTracking()
            .FirstOrDefaultAsync(x => x.StudentId == studentId);
    }
}
