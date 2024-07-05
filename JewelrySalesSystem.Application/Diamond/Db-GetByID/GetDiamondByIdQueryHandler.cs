using AutoMapper;
using JewelrySalesSystem.Application.Diamond;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.GetByID
{
    public class GetDiamondByIdQueryHandler : IRequestHandler<GetDiamondByIdQuery, DiamondDto>
    {
        private readonly IDiamondRepository _diamondRepository;
        private readonly IMapper _mapper;

        public GetDiamondByIdQueryHandler(IMapper mapper, IDiamondRepository diamondRepository)
        {
            _mapper = mapper;
            _diamondRepository = diamondRepository;
        }
        public async Task<DiamondDto> Handle(GetDiamondByIdQuery request, CancellationToken cancellationToken)
        {
            var diamon = await _diamondRepository.FindAsync(s => s.ID == request.ID, cancellationToken)
                ?? throw new NotFoundException("Không tìm thấy kim cương với ID: " + request.ID);

            return diamon.MapToDiamondDto(_mapper);
        }
    }
}
