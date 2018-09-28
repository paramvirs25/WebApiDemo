using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Cors;

using WebAPI_DB;
using WebAPI.Services;

namespace WebAPI.Helpers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); //   
        }

        /// <summary>
        /// USage:
        /// Make a post request to
        /// http://[Server]:[port]/token
        /// Body type: x-www-form-urlencoded
        /// Key - Values
        /// username - [username]
        /// password - [password]
        /// grant_type - password
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        /// {
        ///     "access_token": [actual token here],
        ///     "token_type": "bearer",
        ///     "expires_in": 1199
        /// }
        /// </returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });


            //Models.Employee authenticatedEmployee = new EmployeeService().Authenticate(context.UserName, context.Password);

            //    if (authenticatedEmployee == null)
            //    {
            //        return BadRequest("Username or password is incorrect");
            //    }

            using (var db = new WebAPIDemoDBEntities())
            {
                if (db != null)
                {
                    var empl = db.Employees.ToList();
                    //var user = db.Users.ToList();
                    if (empl != null)
                    {
                        if (!string.IsNullOrEmpty(empl.Where(u => u.Username == context.UserName && u.Password == context.Password).FirstOrDefault().Name))
                        {
                            identity.AddClaim(new Claim("Age", "16"));

                            var props = new AuthenticationProperties(new Dictionary<string, string>
                            {
                                {
                                    "userdisplayname", context.UserName
                                },
                                {
                                     "role", "admin"
                                }
                             });

                            var ticket = new AuthenticationTicket(identity, props);
                            context.Validated(ticket);
                        }
                        else
                        {
                            context.SetError("invalid_grant", "Provided username and password is incorrect");
                            context.Rejected();
                        }
                    }
                }
                else
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    context.Rejected();
                }
                return;
            }
        }
    }
}