using Bills_Payment_API.Services;
using BPS_Shared.Models;
using BPS_Shared.Services;
//using BPS_Shared.ViewModels;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Mvc;

namespace Bills_Payment_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : GenericController<Company>
    {
        public CompanyController(IServiceProvider provider) : base(provider)
        {
            //var company = Database.Companies.FirstOrDefault(x => x.CP_Email == Request.Email && x.CP_Password == Request.Password);

            //if(company is not null)
            //{

            //    var response = new LoginResponse();
            //    response.Name = company.name;
            //    response.email = company.email;
            //    response.CustomerType = "Customer"

            //    return response;
            //}
        }
    }
}