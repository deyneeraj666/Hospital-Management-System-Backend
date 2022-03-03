using AppointmentScheduling_API.DTO;
using AppointmentScheduling_API.Models;
using AppointmentScheduling_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentsDto appointmentDto)
        {
            
            var result = await _appointmentRepository.CreateAppointmentAsync(appointmentDto);

            return result;
        }

        [HttpGet("GetAll")]

        public async Task<List<AppointmentsDto>> GetAllAppointments()
        {
            return await _appointmentRepository.GetAllAppointmentAsync();
        }

        [HttpGet("GetAppointmentById")]
        public async Task<List<AppointmentsDto>> GetAppointmentById(string id)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(id);
        }

        [HttpGet("AppointmentDeleteById")]
        public async Task<IActionResult> AppointmentDeleteById(int id)
        {
            return await _appointmentRepository.RemoveAppointmentByidAsync(id);
        }

        [HttpPut("AppointmentUpdateById")]
        public async Task<IActionResult> Update(int id, AppointmentsDto Appointment)
        {
            return await _appointmentRepository.UpdateAppointmentByidAsync(id, Appointment);
        }
    }
}
