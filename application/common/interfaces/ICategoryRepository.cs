using domain.entity;

namespace application.common.interfaces;

public interface ICategoryRepository
{
    Task AddCategory(Kategori kategori);
    Task<List<Kategori>> GetByCategory(Guid idKategori);
}