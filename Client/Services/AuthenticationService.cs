//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BPS_Client.Services
//{
//    public class AuthenticationService : IAuthenticationService
//    {
//        public Task<LoginResponse> CompanyLogin(LoginRequest request)
//        {

//            //1 send a post request to the server login method
//           var response = await Client.PostAsJsonAsync<TModel>($"/{typeof(TModel).Name}/{nameof(CreateAsync)}", model);

//            if (response.IsSuccessStatusCode)
//            {
//                var responseData = await response.Content.ReadFromJsonAsync<TModel>();

//                return responseData;
//            }

//            var response2 = await response.Content.ReadAsStringAsync();
//            return null;
//            return default;
//            throw new NotImplementedException();
//        }

//        public Task<LoginResponse> CustomerLogin(LoginRequest request)
//        {
//            throw new NotImplementedException();
//        }


//    }
//}
