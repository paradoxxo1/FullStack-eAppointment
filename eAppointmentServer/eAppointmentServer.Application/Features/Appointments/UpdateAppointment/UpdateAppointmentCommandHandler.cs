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
        DateTime startDate = Convert.ToDateTime(request.StartDate);
        DateTime endDate = Convert.ToDateTime(request.EndDate);

        Appointment appointment =
             await appointmentRepository
             .GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if (appointment is null)
        {
            return Result<string>.Failure("Appointment is not Found");
        }
        appointment.StartDate = Convert.ToDateTime(request.StartDate);
        appointment.EndDate = Convert.ToDateTime(request.EndDate);

        bool isAppointmentDateNotAvailable =
            await appointmentRepository
            .AnyAsync(p => p.DoctorId == appointment.DoctorId &&
             ((p.StartDate < endDate && p.StartDate >= startDate) || // Mevcut randevunun bitişi, diğer randevunun başlangıcıyla çakışıyor
             (p.EndDate > startDate && p.EndDate <= endDate) || // Mevcut randevunun başlangıcı, diğer randevunun bitişiyle çakışıyor
             (p.StartDate >= startDate && p.EndDate <= endDate) || // Mevcut randevu, diğer randevu içinde tamamen
             (p.StartDate <= startDate && p.EndDate >= endDate)), // Mevcut randevu, diğer randevuyu tamamen kapsıyor
             cancellationToken);

        if (isAppointmentDateNotAvailable)
        {
            return Result<string>.Failure("Another patient has made an appointment for that time, try a different date");
        }


        //appointmentRepository.Update(appointment); // GetByExpressionWithTrackingAsync bu method tracking yaptığı için bu alan yazılmıyor.
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Appointment update is successful...";

    }
}
