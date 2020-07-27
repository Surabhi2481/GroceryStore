using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GroceryStore.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Vendor")]
    public class VendorController : ControllerBase
    {

        private readonly DataContext db;
        public VendorController(DataContext context)
        {
            db = context;
        }
        // GET: api/<VendorController>
        [HttpGet]
        public IEnumerable<Vendor> Get()
        {
            return db.vendors; ;
        }

        // GET: api/Main/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var vendor = db.vendors.Find(id);
            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor);
        }

        [HttpPost]
        public void Post([FromBody] Vendor u)
        {
            db.vendors.Add(u);
            db.SaveChanges();
        }

        // PUT: api/Main/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vendor usr)
        {
            var entity = db.vendors.FirstOrDefault(u => u.UserId == id);
            entity.fullName = usr.fullName;
            entity.dob = usr.dob;
            entity.contactNumber = usr.contactNumber;
            entity.address = usr.address;
            entity.password = usr.password;
            //entity.confirmPassword = usr.confirmPassword;
            db.SaveChanges();
        }

        //DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var v = db.vendors.Find(id);
            if (v == null)
            {
                return BadRequest("No Record found against this User Id");
            }
            db.Remove(v);
            db.SaveChanges();
            return Ok("User Deleted");
        }



    }
}




