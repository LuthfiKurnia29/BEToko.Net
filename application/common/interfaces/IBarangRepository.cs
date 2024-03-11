using domain.entity;

namespace application.common.interfaces;

public interface IBarangRepository
{
    Task<List<Barang>> GetAllBarang();
    Task<Barang> GetBarangById(Guid idBarang);
    Task<Barang> AddBarang(Barang barang);
}