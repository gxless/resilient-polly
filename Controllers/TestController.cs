using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using resilient_polly.Models;

namespace resilient_polly.Controllers
{
    [ApiController]
    [Route("")]
    public class TestingController : ControllerBase
    {
        private readonly TestContext _testContext;

        public TestingController(TestContext testContext)
        {
            _testContext = testContext;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "{\"result\": \"hello world\"}";
        }

        // POST: /test
        [HttpPost("test")]
        public async Task<ActionResult<TestItem>> PostTest(TestItem testItem)
        {
            _testContext.TestItems.Add(testItem);
            await _testContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTestItem), new { id = testItem.Id }, testItem);

        }

        // GET: /test
        [HttpGet("test")]
        public IEnumerable<TestItem> GetTest()
        {
            return _testContext.TestItems.ToList();
        }

        // GET: /test/1
        [HttpGet("test/{id}")]
        public async Task<ActionResult<TestItem>> GetTestItem(long id)
        {
            var testItem = await _testContext.TestItems.FindAsync(id);

            if (testItem == null)
            {
                return NotFound();
            }

            return testItem;
        }


    }
}