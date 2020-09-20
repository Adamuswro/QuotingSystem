using QuotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuotingSystem.DAL
{
    public class QuotesContext:DbContext
    {
        public QuotesContext(): base("MyDb")
        {
        }

        public DbSet<Quote> Quotes { get; set; }
    }
}