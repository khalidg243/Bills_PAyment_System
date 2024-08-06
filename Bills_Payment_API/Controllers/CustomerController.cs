using Bills_Payment_API.Services;
using BPS_Shared.Models;
using Microsoft.AspNetCore.Mvc;



namespace Bills_Payment_API.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : GenericController<Customer>
    {
        public CustomerController(IServiceProvider provider) : base(provider)
        {
        }  
    }
}