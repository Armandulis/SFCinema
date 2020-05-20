using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaAPI.Infrastructure;
using CinemaAPI.Model;
using CinemaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaRepository _repo;

        public CinemaController(ICinemaRepository repo)
        {
            this._repo = repo;
        }

        // GET: api/Cinema
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _repo.GetAll();
        }

        // GET: api/Cinema/5
        [HttpGet("{id}", Name = "Get")]
        public Order Get(int id)
        {
            if (id > 0)
            {
                return _repo.Get(id);
            }

            return null;
        }

        // POST: api/Cinema
        [HttpPost]
        public Order Post([FromBody] Order order)
        {
            if (order == null)
            {
                return null;
            }

            // Call ProductApi to get the food ordered
            RestClient c = new RestClient();

            c.BaseUrl = new Uri("http://desktop-661danr:19081/SFCinema/TicketsApi/api/tickets");
            var requestTicket = new RestRequest(order.Food.ToString(), Method.GET);

            var responseTicket = c.Execute<Ticket>(requestTicket);
            var orderedTicket = responseTicket.Data;

            if (order.TicketQuantity <= orderedTicket.TicketsLeft)
            {
                orderedTicket.TicketsLeft = orderedTicket.TicketsLeft - order.TicketQuantity;
                var updateTicketRequest = new RestRequest(orderedTicket.Id.ToString(), Method.PUT);
                updateTicketRequest.AddJsonBody(orderedTicket);
                var updateTicketResponse = c.Execute(updateTicketRequest);

                if (updateTicketResponse.IsSuccessful)
                {
                    order.Price = order.TicketQuantity * orderedTicket.Price;

                    c.BaseUrl = new Uri("https://sfsynopsis.westeurope.cloudapp.azure.com:19081/SFCinema/FoodApi/api/food");
                    var requestFood = new RestRequest(order.Food.ToString(), Method.GET);

                    var responseFood = c.Execute<Food>(requestFood);
                    var orderedFood = responseFood.Data;

                    if (order.FoodQuantity <= orderedFood.AmountLeft)
                    {
                        orderedFood.AmountLeft = orderedFood.AmountLeft - order.FoodQuantity;
                        var updateFoodRequest = new RestRequest(orderedFood.Id.ToString(), Method.PUT);
                        updateFoodRequest.AddJsonBody(orderedFood);
                        var updateFoodResponse = c.Execute(updateFoodRequest);

                        if (updateFoodResponse.IsSuccessful)
                        {
                            order.Price = order.FoodQuantity * orderedFood.Price;
                            return _repo.Add(order);
                        }
                    }


                    return _repo.Add(order);
                }
            }


            return _repo.Add(order);
        }

        // PUT: api/Cinema/5
        [HttpPut]
        public IActionResult Put([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            _repo.Edit(order);
            return Ok();
        }

        // DELETE: api/Cinema/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Remove(id);
            return Ok();
        }
    }
}
