using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using Npgsql.Replication.PgOutput.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Form.UpdateStatus
{
    public class UpdateStatusFromCommandHandler : IRequestHandler<UpdateStatusFromCommand, string>
    {
        private readonly IFormRepository _formRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateStatusFromCommandHandler(IFormRepository formRepository, ICurrentUserService currentUserService)
        {
            _formRepository = formRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(UpdateStatusFromCommand request, CancellationToken cancellationToken)
        {
            var form = await _formRepository.FindAsync(x => x.ID == request.FormID && x.DeletedAt == null, cancellationToken)
            ?? throw new NotFoundException("Không tìm thấy form nào");
            if (!form.Status.Equals(FormStatus.PENDING))
            {
                return "Form đã được xử lý !!!";
            }

            form.Status = request.Status;
            form.LastestUpdateAt = DateTime.Now;
            form.UpdaterID = _currentUserService.UserId;
            _formRepository.Update(form);
            return await _formRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
