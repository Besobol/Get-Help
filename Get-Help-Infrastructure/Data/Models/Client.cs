﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Get_Help.Infrastructure.Data.Models
{
    public class Client : ApplicationUser
    {
        public List<Ticket> Tickets { get; set; } = new();

        public List<Message> Messages { get; set; } = new();
    }
}
