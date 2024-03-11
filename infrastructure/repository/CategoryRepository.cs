using application.common.interfaces;
using domain.entity;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly IAppDbContext _context;

    public CategoryRepository(IAppDbContext context)
    {
        _context = context;
    }

    public async Task AddCategory(Kategori kategori)
    {
        await _context.Kategoris.AddAsync(kategori);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Kategori>> GetAllCategory()
    {
        return await _context.Kategoris.ToListAsync();
    }
}