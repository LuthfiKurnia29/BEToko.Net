using application.common.interfaces;
using domain.entity;
using MediatR;

namespace application.features.barang.Queries.All;

public class GetAllBarangQueryHandler : IRequestHandler<GetAllBarangQuery, List<Barang>>
{
    private readonly IBarangRepository _barangRepository;

    public GetAllBarangQueryHandler(IBarangRepository barangRepository)
    {
        _barangRepository = barangRepository;
    }

    public async Task<List<Barang>> Handle(GetAllBarangQuery request, CancellationToken cancellationToken)
    {
        return await _barangRepository.GetAllBarang();
    }
}