using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoLoanWebAPI.Models
{
    public class VideoLoanContext : IdentityDbContext
    {
        public VideoLoanContext(DbContextOptions<VideoLoanContext> options) : base(options)
        {

        }

        public DbSet<FilmModel> Films { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
    }
}
