using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HushApi.Data;
using HushApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HushApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        HushDbContext _hushDbContext;

        public ReservationsController(HushDbContext hushDbContext)
        {
            _hushDbContext = hushDbContext;
        }

        [HttpPost]
        public IActionResult Post(Reservation reservation)
        {
            _hushDbContext.Reservations.Add(reservation);
            _hushDbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpGet]
        public IActionResult GetReservations()
        {
            var reservations = _hushDbContext.Reservations;

            return Ok(reservations);
        }
    }
}