using AppointmentScheduling_API.DTO;
using AppointmentScheduling_API.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduling_API.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentScheduling_API.DataManager
{

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentContext _databaseContext;

        public AppointmentRepository(AppointmentContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        async Task<IActionResult> IAppointmentRepository.CreateAppointmentAsync(AppointmentsDto appointment)
        {
            var newAppointment = new Appointment()
            {
                p_id = appointment.p_id,
                patientName = appointment.patientName,
                physician = appointment.physician,
                meetingTitle = appointment.meetingTitle,
                status = appointment.status,
                startDateTime = ConvertDateUTCtoISD(appointment.startDateTime),
                endDateTime = ConvertDateUTCtoISD(appointment.endDateTime),
                description = appointment.description,
                physicianId = appointment.physicianId
            };

            await _databaseContext.AppointmentDetails.AddAsync(newAppointment);
            int i= _databaseContext.SaveChanges();
            if(i<=0)
            {
                return new JsonResult("something went wrong");
            }
            else
            {
                return new JsonResult("record Created successfully");
            }
             
        }
        async Task<List<AppointmentsDto>> IAppointmentRepository.GetAllAppointmentAsync()
        {
            var lst = _databaseContext.AppointmentDetails.ToList();
            List<AppointmentsDto> lstappointmentdto = new List<AppointmentsDto>();

            foreach (Appointment appointment in lst)
            {
                lstappointmentdto.Add(new AppointmentsDto()
                {   
                    id=appointment.id,
                    p_id = appointment.p_id,
                    patientName = appointment.patientName,
                    physician = appointment.physician,
                    meetingTitle = appointment.meetingTitle,
                    status = appointment.status,
                    startDateTime = appointment.startDateTime,
                    endDateTime = appointment.endDateTime,
                    description = appointment.description,
                    physicianId=appointment.physicianId
                });
            }
            return lstappointmentdto;
        }

        async Task<List<AppointmentsDto>> IAppointmentRepository.GetAppointmentByIdAsync(string p_Id)
        {
            var lst = _databaseContext.AppointmentDetails.Where(x => x.p_id.Equals(p_Id)).Select(s => s);
            List<AppointmentsDto> lstappointmentdto = new List<AppointmentsDto>();

            foreach (Appointment appointment in lst)
            {
                lstappointmentdto.Add(new AppointmentsDto()
                {
                    id = appointment.id,
                    p_id = appointment.p_id,
                    patientName = appointment.patientName,
                    physician = appointment.physician,
                    meetingTitle = appointment.meetingTitle,
                    status = appointment.status,
                    startDateTime = appointment.startDateTime,
                    endDateTime = appointment.endDateTime,
                    description = appointment.description,
                    physicianId=appointment.physicianId
                });
            }
            return lstappointmentdto;
        }

       async Task<IActionResult> IAppointmentRepository.RemoveAppointmentByidAsync(int Id)
        {
           Appointment appointment =  _databaseContext.AppointmentDetails.Where(x => x.id.Equals(Id)).Select(s => s).FirstOrDefault();
            if (appointment == null)
            {
                return new JsonResult("records does not exist");
            }
            else
            {
                _databaseContext.AppointmentDetails.Remove(appointment);
                AppointmentsDto Removedappointment = new AppointmentsDto()
                {
                    p_id = appointment.p_id,
                    patientName = appointment.patientName,
                    physician = appointment.physician,
                    meetingTitle = appointment.meetingTitle,
                    status = appointment.status,
                    startDateTime = appointment.startDateTime,
                    endDateTime = appointment.endDateTime,
                    description = appointment.description,
                    physicianId = appointment.physicianId
                };
                _databaseContext.SaveChanges();
                return new JsonResult("records deleted successfully");
            }
        }
        async Task<IActionResult> IAppointmentRepository.UpdateAppointmentByidAsync(int Id, AppointmentsDto appointment)
        {
            Appointment _appointment = _databaseContext.AppointmentDetails.Where(x => x.id.Equals(Id)).Select(s => s).FirstOrDefault();
            if (_appointment == null)
            {
                return new JsonResult("records does not exist");
            }
            else
            {
                _appointment.p_id = appointment.p_id;
                _appointment.patientName = appointment.patientName;
                _appointment.physician = appointment.physician;
                _appointment.meetingTitle = appointment.meetingTitle;
                _appointment.status = appointment.status;
                _appointment.startDateTime = ConvertDateUTCtoISD(appointment.startDateTime);
                _appointment.endDateTime = ConvertDateUTCtoISD(appointment.endDateTime);
                _appointment.description = appointment.description;
                _appointment.physicianId = appointment.physicianId;
                _databaseContext.SaveChanges();
                return new JsonResult("records updated successfully");
            }
        }

        public DateTime ConvertDateUTCtoISD(DateTime _date)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(_date,
                   TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        }
    }
}
