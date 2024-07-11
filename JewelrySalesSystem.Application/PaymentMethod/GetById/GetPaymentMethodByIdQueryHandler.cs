using AutoMapper;
using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.PaymentMethod.GetById
{
    public class GetPaymentMethodByIdQueryHandler : IRequestHandler<GetPaymentMethodByIdQuery, PaymentMethodDto>
    {
        private readonly IPaymentMethodRepository _repository;
        private readonly IMapper _mapper;
        public GetPaymentMethodByIdQueryHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _repository = paymentMethodRepository;
            _mapper = mapper;
        }
        public async Task<PaymentMethodDto> Handle(GetPaymentMethodByIdQuery query, CancellationToken cancellationToken)
        {
            var existEntity = await _repository.FindAsync(x => x.ID == query.ID && x.DeletedAt == null, cancellationToken);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            return existEntity.MapToPaymentMethodDto(_mapper);
        }
    }
}
