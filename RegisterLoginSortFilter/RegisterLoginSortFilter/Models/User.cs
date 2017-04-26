using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RegisterLoginSortFilter.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string AdditionalInfo { get; set; }

    }

    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

    }

}