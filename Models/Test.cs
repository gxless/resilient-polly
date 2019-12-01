using System;
namespace resilient_polly.Models
{
    public class TestItem
    {
        public TestItem()
        {

        }

        public TestItem(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; set; }

        public string Name { get; set; }
    }
}
