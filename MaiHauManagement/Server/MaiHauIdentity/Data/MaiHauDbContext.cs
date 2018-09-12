using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaiHauIdentity.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MaiHauIdentity.Data
{
    public class MaiHauDbContext:IdentityDbContext<User>
    {
        public MaiHauDbContext(DbContextOptions<MaiHauDbContext> options) : base(options)
        {

        }
    }
}
