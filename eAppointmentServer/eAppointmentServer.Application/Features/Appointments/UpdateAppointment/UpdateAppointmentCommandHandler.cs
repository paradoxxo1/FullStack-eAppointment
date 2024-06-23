using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointments.UpdateAppointment;

internal sealed class UpdateAppointmentCommandHandler(
    IAppointmentRepository appointmentRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateAppointmentCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
    {
        Appointment appointment =
             await appointmentRepository
             .GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if (appointment is null)
        {
            return Result<string>.Failure("Appointment is not Found");
        }
        appointment.StartDate = Convert.ToDateTime(request.StartDate);
        appointment.EndDate = Convert.ToDateTime(request.EndDate);

        //appointmentRepository.Update(appointment); // GetByExpressionWithTrackingAsync bu method tracking yaptığı için bu alan yazılmıyor.
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Appointment update is successful...";

    }
}
