using application.common.interfaces;
using AutoMapper;
using domain.entity;
using MediatR;

namespace application.features.barang.command.addBarangs;

public class AddBarangCommandHandler : IRequestHandler<AddBarangCommand, Barang>
{
    private readonly IMapper _mapper;
    private readonly IBarangRepository _barangRepository;

    public AddBarangCommandHandler(IMapper mapper, IBarangRepository barangRepository)
    {
        _mapper = mapper;
        _barangRepository = barangRepository;
    }

    public async Task<Barang> Handle(AddBarangCommand request, CancellationToken cancellationToken)
    {
        var barang = _mapper.Map<Barang>(request);
        await _barangRepository.AddBarang(barang);
        return barang;
    }
}