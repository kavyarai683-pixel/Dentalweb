using Microsoft.AspNetCore.Mvc;
using DentalClinicAPI.Data;
using DentalClinicAPI.Models;

namespace DentalClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly ClinicDbContext _context;

        public AppointmentsController(ClinicDbContext context)
        {
            _context = context;
        }

        // GET all appointments
        [HttpGet]
        public IActionResult GetAppointments()
        {
            return Ok(_context.Appointments.ToList());
        }

        // POST create appointment
        [HttpPost]
        public IActionResult CreateAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return Ok(appointment);
        }

        // GET appointment by ID
        [HttpGet("{id}")]
        public IActionResult GetAppointment(int id)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        // PUT update appointment
        [HttpPut("{id}")]
        public IActionResult UpdateAppointment(int id, Appointment appointment)
        {
            var existing = _context.Appointments.Find(id);

            if (existing == null)
                return NotFound();

            existing.PatientName = appointment.PatientName;
            existing.PhoneNumber = appointment.PhoneNumber;
            existing.Email = appointment.Email;
            existing.AppointmentDate = appointment.AppointmentDate;
            existing.DoctorName = appointment.DoctorName;
            existing.Reason = appointment.Reason;
            existing.Status = appointment.Status;

            _context.SaveChanges();

            return Ok(existing);
        }

        // DELETE appointment
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
                return NotFound();

            _context.Appointments.Remove(appointment);
            _context.SaveChanges();

            return Ok("Appointment deleted");
        }
    }
}