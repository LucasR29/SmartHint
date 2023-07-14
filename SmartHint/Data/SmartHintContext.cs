using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartHint.Models;

namespace SmartHint.Data;

public partial class SmartHintContext : DbContext
{
    public SmartHintContext()
    {
    }

    public SmartHintContext(DbContextOptions<SmartHintContext> options)
        : base(options)
    {
    }

    public DbSet<ClientsModel> Clients { get; set; }

    
}
