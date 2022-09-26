using WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerDatabase customerDatabase;

    public CustomerController()
    {
        customerDatabase = new CustomerDatabase();
    }

    [HttpGet]
    public IEnumerable<Customer> Get()
    {
        return customerDatabase.GetAll();
    }

    [HttpGet("{id}")]
    public Customer Get(int id)
    {
        return customerDatabase.GetById(id);
    }

    [HttpPost]
    public void Post([FromBody] Customer customer)
    {
        if (ModelState.IsValid)
        {
            customerDatabase.Add(customer);
        }
    }


    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Customer customer)
    {
        customer.id = id;
        if (ModelState.IsValid)
        {
            customerDatabase.Update(customer);
        }
    }

    [HttpDelete]
    public void Delete(int id)
    {
        customerDatabase.Delete(id);
    }


}
