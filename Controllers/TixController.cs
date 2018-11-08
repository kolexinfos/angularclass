using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using BuyTixApi.Business;
using BuyTixApi.Models.Movies;
using BuyTixApi.Models.Purchase;
using BuyTixApi.Models.Seats;

namespace BuyTixApi.Controllers
{
    [Route("api/[controller]")]
    public class TixController : Controller
    {
        [HttpGet]
        [Route("GetMovies")]
        [ProducesResponseType(typeof(List<ActiveMovie>), 200)]
        public IActionResult GetAllActiveMovies()
        {
            //Get All Movies in the database
            return Ok(Business.Movies.GetAllActiveMovies());
        }

        [HttpGet]
        [Route("GetSeatingPlan/{ActiveMovieId}")]
        [ProducesResponseType(typeof(SeatingPlan), 200)]
        public IActionResult GetActiveMovieSeatingPlan(int ActiveMovieId)
        {
            return Ok(Business.Movies.GetActiveMovieSeatingPlan(ActiveMovieId));
        }

        [HttpPost]
        [Route("PurchaseTickets")]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult PurchaseTickets([FromBody]Order order) 
        {
           return Ok(Business.Movies.PurchaseTickets(order));
        }
    }
}
