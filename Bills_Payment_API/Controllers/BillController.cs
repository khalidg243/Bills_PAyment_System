using Bills_Payment_API.Services;
using BPS_Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bills_Payment_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : GenericController<Bill>
    {
        public BillController(IServiceProvider provider) : base(provider)
        {
        }
    }
}