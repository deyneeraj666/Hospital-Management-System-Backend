using AppointmentScheduling_API.DTO;
using AppointmentScheduling_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling_API.Repository
{
    public interface IAppointmentRepository
    {
        Task<IActionResult> CreateAppointmentAsync(AppointmentsDto appointment);
        Task<List<AppointmentsDto>> GetAllAppointmentAsync();
        Task<List<AppointmentsDto>> GetAppointmentByIdAsync(string P_Id);
        Task<IActionResult> RemoveAppointmentByidAsync(int Id);
        Task<IActionResult> UpdateAppointmentByidAsync(int Id,AppointmentsDto appointment);
        Task<IEnumerable<AppointmentsDto>> GetAppointmentsByIdAndStatusConfirmed(string patientId);
    }
}
