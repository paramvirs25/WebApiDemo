using System;
using System.Collections.Generic;
using System.Linq;

//using System.IdentityModel.Tokens.Jwt;
//using System.Text;
//using Microsoft.IdentityModel.Tokens;
//using System.Security.Claims;

using WebAPI.Models;
//using WebAPIDemo.Helpers;
using WebAPI_DB;

namespace WebAPI.Services
{
    //public interface IUserService
    //{
    //    User Authenticate(string username, string password);
    //    IEnumerable<User> GetAll();
    //    User GetById(int id);
    //    User Create(User user, string password);
    //    void Update(User user, string password = null);
    //    void Delete(int id);
    //}

    public class EmployeeService //: IUserService
    {
        //private DataContext _context;

        //public UserService(DataContext context)
        //{
        //    _context = context;
        //}

        public Models.Employee Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            using (var context = new WebAPIDemoDBEntities())
            {
                var emp = context.Employees.SingleOrDefault(x => x.Username == username && x.Password == password);

                // check if user exists
                if (emp == null)
                    return null;

                // authentication successful
                return MapFromDAL(emp);
            }
        }

        public string GetToken(Models.Employee emp)
        {
            //var tokenHandler = new JwtSecurityTokenHandler();
            ////var key = Encoding.ASCII.GetBytes(WebConfigurationManager.AppSettings["DevKey"].ToString());
            //var key = Encoding.ASCII.GetBytes("This is a secret key");
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, emp.Id.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddMinutes(20),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //var tokenString = tokenHandler.WriteToken(token);

            //return tokenString;
            return "ss";
        }

        public List<Models.Employee> MapFromDAL(List<WebAPI_DB.Employee> emp)
        {
            return emp.Select(x => MapFromDAL(x)).ToList();
        }

        public Models.Employee MapFromDAL(WebAPI_DB.Employee emp)
        {
            return new Models.Employee()
            {
                Id = emp.Id,
                Name = emp.Name,
                JoiningDate = emp.JoiningDate,
                Age = emp.Age,
                Username = emp.Username,
                Password = emp.Password
            };
        }

        public WebAPI_DB.Employee MapToDAL(Models.Employee emp, WebAPI_DB.Employee empDAL)
        {
            if (empDAL == null)
            {
                empDAL = new WebAPI_DB.Employee();
            }

            empDAL.Id = emp.Id;
            empDAL.Name = emp.Name;
            empDAL.JoiningDate = emp.JoiningDate;
            empDAL.Age = emp.Age;
            empDAL.Username = emp.Username;
            empDAL.Password = emp.Password;

            return empDAL;
        }

        //public IEnumerable<User> GetAll()
        //{
        //    return _context.Users;
        //}

        //public User GetById(int id)
        //{
        //    return _context.Users.Find(id);
        //}

        //public User Create(User user, string password)
        //{
        //    // validation
        //    if (string.IsNullOrWhiteSpace(password))
        //        throw new AppException("Password is required");

        //    if (_context.Users.Any(x => x.Username == user.Username))
        //        throw new AppException("Username \"" + user.Username + "\" is already taken");

        //    byte[] passwordHash, passwordSalt;
        //    CreatePasswordHash(password, out passwordHash, out passwordSalt);

        //    user.PasswordHash = passwordHash;
        //    user.PasswordSalt = passwordSalt;

        //    _context.Users.Add(user);
        //    _context.SaveChanges();

        //    return user;
        //}

        //public void Update(User userParam, string password = null)
        //{
        //    var user = _context.Users.Find(userParam.Id);

        //    if (user == null)
        //        throw new AppException("User not found");

        //    if (userParam.Username != user.Username)
        //    {
        //        // username has changed so check if the new username is already taken
        //        if (_context.Users.Any(x => x.Username == userParam.Username))
        //            throw new AppException("Username " + userParam.Username + " is already taken");
        //    }

        //    // update user properties
        //    user.FirstName = userParam.FirstName;
        //    user.LastName = userParam.LastName;
        //    user.Username = userParam.Username;

        //    // update password if it was entered
        //    if (!string.IsNullOrWhiteSpace(password))
        //    {
        //        byte[] passwordHash, passwordSalt;
        //        CreatePasswordHash(password, out passwordHash, out passwordSalt);

        //        user.PasswordHash = passwordHash;
        //        user.PasswordSalt = passwordSalt;
        //    }

        //    _context.Users.Update(user);
        //    _context.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    var user = _context.Users.Find(id);
        //    if (user != null)
        //    {
        //        _context.Users.Remove(user);
        //        _context.SaveChanges();
        //    }
        //}

        //// private helper methods

        //private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    if (password == null) throw new ArgumentNullException("password");
        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

        //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}

        //private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        //{
        //    if (password == null) throw new ArgumentNullException("password");
        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
        //    if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
        //    if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

        //    using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        for (int i = 0; i < computedHash.Length; i++)
        //        {
        //            if (computedHash[i] != storedHash[i]) return false;
        //        }
        //    }

        //    return true;
        //}
    }
}