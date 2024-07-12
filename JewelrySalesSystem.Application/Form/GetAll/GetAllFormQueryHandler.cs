using AutoMapper;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Form.GetAll
{
    public class GetAllFormQueryHandler : IRequestHandler<GetAllFormQuery, List<FormDto>>
    {
        private readonly IFormRepository _formRepository;
        private readonly IMapper _mapper;

        public GetAllFormQueryHandler(IFormRepository formRepository, IMapper mapper)
        {
            _formRepository = formRepository;
            _mapper = mapper;
        }

        public async Task<List<FormDto>> Handle(GetAllFormQuery request, CancellationToken cancellationToken)
        {
            var responseList = await _formRepository.FindAllAsync(x => x.DeletedAt == null, cancellationToken);
            if(!responseList.Any()) throw new NotFoundException("Không tìm thấy form nào!");
            return responseList.MapToFormDtoList(_mapper);
        }
    }
}
