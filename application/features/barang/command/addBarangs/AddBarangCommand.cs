using domain.entity;
using MediatR;

namespace application.features.barang.command.addBarangs;

public class AddBarangCommand : IRequest<Barang>
{
    public string NamaBarang { get; set; }
    public int Stok { get; set; }
    public float Harga { get; set; }
    public Guid IdKategori { get; set; }   
}