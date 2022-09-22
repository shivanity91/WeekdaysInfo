using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Weekdays.Models;
using Weekdays.Services;

namespace Weekdays.Controllers
{
    [Route("api/weekdays")]
    [ApiController]
    public class WeekdaysController : ControllerBase
    {
        private readonly IWeekdaysService _weekdaysService;
        public WeekdaysController(IWeekdaysService weekdaysService)
        {
            _weekdaysService = weekdaysService;
        }

        /// <summary>
        /// To fetch week days
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetWeekDays")]
        [ProducesResponseType(typeof(WeekdaysInfo), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        public IActionResult GetWeekDays([FromQuery] DateTime date)
        {            
            var result = _weekdaysService.GetWeekDaysAsync(date);
            return Ok(result);
        }

        /// <summary>
        /// To save week days
        /// </summary>
        /// <param name="dates"></param>
        /// <returns></returns>
        [HttpPost(Name = "SaveWeekDays")]
        [ProducesResponseType(typeof(List<WeekdaysInfo>), (int)HttpStatusCode.OK)]
        public IActionResult SaveWeekDaysAsync([FromBody] List<DateTime> dates)
        {
            if (dates.Count() == 0 || dates.Count() > 7 || dates.Count() < 7)
            {
                return BadRequest(new Error(){ ErrorMessage = "Date cannot be null and 7 dates are mandatory in request payload."});
            }
            var result = _weekdaysService.SaveWeekDaysAsync(dates);
            return Ok(result);
        }
    }
}
