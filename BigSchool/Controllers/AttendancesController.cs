using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ComponentModel.DataAnnotations;
using BigSchool.Models;
using Microsoft.AspNet.Identity;
using BigSchool.DTOs;

namespace BigSchool.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
       public IHttpActionResult Attend(AttendanceDto adto )
        {
            int CourseId = adto.CourseId;
           var userId = User.Identity.GetUserId();
           if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == CourseId))
               return BadRequest("The Attendances are already exists");
           var attendance = new Attendance
           {
               CourseId = CourseId,
               AttendeeId = userId
           };
           _dbContext.Attendances.Add(attendance);
           _dbContext.SaveChanges();
           return Ok();
       }  
    }
}
