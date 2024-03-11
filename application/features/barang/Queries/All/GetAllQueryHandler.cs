using domain.entity;
using MediatR;

namespace application.features.barang.Queries.All;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<Barang>>
{
    public async Task<List<Barang>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}