using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repeating
{
    public class UserService
    {
        private readonly ManagementContext _context;

        public UserService(ManagementContext context)
        {
            _context = context;
        }

        public void CreateUser(string name, string surname, string password)
        {
            var user = new User() { Name = name, Surname = surname, Password = password };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User FindUserByName(string name, string surname)
        {
            return _context.Users.Include(a => a.Records).FirstOrDefault(user => user.Name == name && user.Surname == user.Surname);
        }

        public User FindUserByNameAndPassword(string name, string password)
        {
            return _context.Users.Include(u => u.Records).FirstOrDefault(u => u.Name == name && u.Password == password);
        }

        public List<Record> GetUserRecords(User user)
        {
            return user.Records;
        }



    }
}
