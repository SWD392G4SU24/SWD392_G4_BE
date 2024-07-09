using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Form.Delete
{
    public class DeleteFormCommandHandler : IRequestHandler<DeleteFormCommand, string>
    {
        private readonly IFormRepository _formRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteFormCommandHandler(IFormRepository formRepository, ICurrentUserService currentUserService)
        {
            _formRepository = formRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteFormCommand request, CancellationToken cancellationToken)
        {
            var form = await _formRepository.FindAsync(x => x.ID == request.Id && x.DeletedAt == null, cancellationToken)
               ?? throw new NotFoundException("Không tìm thấy form nào");
            form.DeletedAt = DateTime.Now;
            form.DeleterID = _currentUserService.UserId;
            _formRepository.Update(form);
            return await _formRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa thành công" : "Xóa thất bại";
        }
    }
}
