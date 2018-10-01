using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebAPIWithToken.Models
{
    public class Models
    {

    }

    public class LoginRequest {
        public string Username { get; set; }
        public string Password { get; set; }
   }

    public class LoginResponse
    {
        public LoginResponse() {
        
            this.token="";
            this.responseMsg = new HttpResponseMessage() {StatusCode=System.Net.HttpStatusCode.Unauthorized }; 
        }

        public int id { get; set; }
        public string firstName { get; set; }
        public string token { get; set; }
        public HttpResponseMessage responseMsg { get; set; }
    
    }

   
}