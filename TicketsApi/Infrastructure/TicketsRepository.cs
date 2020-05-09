﻿using Microsoft.CodeAnalysis.Differencing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketsApi.Models;

namespace TicketsApi.Infrastructure
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly DBContext db;
        public TicketsRepository()
        {
            db = new DBContext("Server = tcp:sfcinema.database.windows.net, 1433; Initial Catalog = SFCinema; Persist Security Info = False; User ID = armandas; Password = SFCinema1; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");

        }
        public Ticket Create(Ticket ticket)
        {
            db.Tickets.Add(ticket);
            db.SaveChanges();
            return ticket;
        }

        public void Delete(int id)
        {
            // deletes ticket

            db.Tickets.Remove(GetTicket(id));
            db.SaveChanges();

        }

        public void Edit(Ticket ticket)
        {
            // Edits ticket
            db.Tickets.Add(ticket);
            db.Entry(ticket).State = System.Data.Entity.EntityState.Modified;


            db.SaveChanges();
        }

        public IEnumerable<Ticket> GetAll()
        {
            return db.Tickets.ToList();
        }

        public Ticket GetTicket(int id)
        {

            return db.Tickets.FirstOrDefault(p => p.Id == id);
        }
    }
}