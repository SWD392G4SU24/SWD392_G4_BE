using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Form.Update
{
    public class UpdateFormCommandHandler : IRequestHandler<UpdateFormCommand, string>
    {
        private readonly IFormRepository _formRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateFormCommandHandler(IFormRepository formRepository, ICurrentUserService currentUserService)
        {
            _formRepository = formRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
        {
            var form = await _formRepository.FindAsync(x => x.ID == request.FormID && x.DeletedAt == null, cancellationToken)
                ?? throw new NotFoundException("Không tìm thấy form nào");
            if (!string.IsNullOrEmpty(request.Content))
            {
                request.Content = form.Content;
            }
            if (request.AppointmentDate.HasValue)
            {
                form.AppoinmentDate = (DateTime)request.AppointmentDate;
            }
            form.UpdaterID =_currentUserService.UserId;
            form.LastestUpdateAt = DateTime.Now;
            _formRepository.Update(form);
            return await _formRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
