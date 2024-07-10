using AutoMapper;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Category.GetAll
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        public GetAllCategoryQueryHandler(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery query, CancellationToken cancellationToken)
        {
            var responseList = await _repository.FindAllAsync(x => x.DeletedAt == null, cancellationToken);
            if(responseList == null)
            {
                throw new NotFoundException("Không tìm thấy Category nào");
            }
            return responseList.MapToCategoryDtoList(_mapper);
        }
    }
}
