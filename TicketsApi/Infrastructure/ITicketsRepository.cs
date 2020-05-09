using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsApi.Models;

namespace TicketsApi.Infrastructure
{
    public interface ITicketsRepository
    {
        // Create
        Ticket Create(Ticket ticket);

        // Read
        Ticket GetTicket(int id);
        IEnumerable<Ticket> GetAll();

        // Update
        void Edit(Ticket ticket);

        // Delete
        void Delete(int id);


    }
}
