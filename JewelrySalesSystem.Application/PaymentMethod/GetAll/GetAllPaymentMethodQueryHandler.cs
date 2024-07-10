using AutoMapper;
using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.PaymentMethod.GetAll
{
    public class GetAllPaymentMethodQueryHandler : IRequestHandler<GetAllPaymentMethodQuery, List<PaymentMethodDto>>
    {
        private readonly IPaymentMethodRepository _repository;
        private readonly IMapper _mapper;
        public GetAllPaymentMethodQueryHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _repository = paymentMethodRepository;
            _mapper = mapper;
        }
        public async Task<List<PaymentMethodDto>> Handle(GetAllPaymentMethodQuery request, CancellationToken cancellationToken)
        {

            var responseList = await _repository.FindAllAsync(x => x.DeletedAt == null, cancellationToken);
            if (responseList == null)
            {
                throw new NotFoundException("Không tìm thấy Role nào");
            }
            return responseList.MapToPaymentMethodDtoList(_mapper);
        }
    }
}
