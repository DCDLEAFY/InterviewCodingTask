using WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace WebApi.Controllers;

[EnableCors("CorsPolicy")]
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerDatabase customerDatabase;

    public CustomerController()
    {
        customerDatabase = new CustomerDatabase();
    }

    [EnableCors("CorsPolicy")]
    [HttpGet]
    public IEnumerable<Customer> Get()
    {
        return customerDatabase.GetAll();
    }

    [EnableCors("CorsPolicy")]
    [HttpGet("{id}")]
    public Customer Get(int id)
    {
        return customerDatabase.GetById(id);
    }

    [EnableCors("CorsPolicy")]
    [HttpPost]
    public void Post([FromBody] Customer customer)
    {
        Console.WriteLine("Out");
        if (ModelState.IsValid)
        {
            Console.WriteLine("In");
            customerDatabase.Add(customer);
        }
    }

    [EnableCors("CorsPolicy")]
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Customer customer)
    {
        customer.id = id;
        if (ModelState.IsValid)
        {
            customerDatabase.Update(customer);
        }
    }

    [EnableCors("CorsPolicy")]
    [HttpDelete]
    public void Delete(int id)
    {
        customerDatabase.Delete(id);
    }


}
