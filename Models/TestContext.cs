using System;
using Microsoft.EntityFrameworkCore;

namespace resilient_polly.Models
{
    public class TestContext: DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        public DbSet<TestItem> TestItems { get; set; }
    }
}
