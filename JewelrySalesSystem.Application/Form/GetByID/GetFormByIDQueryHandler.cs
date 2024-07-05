using AutoMapper;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Form.GetByID
{
    public class GetFormByIDQueryHandler : IRequestHandler<GetFormByIDQuery, FormDto>
    {
        private readonly IFormRepository _formRepository;
        private readonly IMapper _mapper;

        public GetFormByIDQueryHandler(IFormRepository formRepository, IMapper mapper)
        {
            _formRepository = formRepository;
            _mapper = mapper;
        }
        public async Task<FormDto> Handle(GetFormByIDQuery request, CancellationToken cancellationToken)
        {
            var form = await _formRepository.FindAsync(x => x.ID == request.id,cancellationToken)
            ?? throw new NotFoundException("Form không tồn tại");
            return form.MapToFormDto(_mapper);
        }
    }
}
