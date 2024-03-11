using application.common.interfaces;
using domain.entity;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.repository;

public class BarangRepository : IBarangRepository
{
    private readonly IAppDbContext _context;

    public BarangRepository(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Barang>> GetAllBarang()
    {
        return await _context.Barangs.ToListAsync();
    }

    public async Task<Barang> GetBarangById(Guid idBarang)
    {
        return await _context.Barangs.Where(x => x.IdBarang == idBarang).FirstAsync();
    }

    public async Task<Barang> AddBarang(Barang barang)
    {
        await _context.Barangs.AddAsync(barang);
        await _context.SaveChangesAsync();
        return barang;
    }
}