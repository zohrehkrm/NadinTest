using NadinTest.Core.Models.Base;
using NadinTest.Core.Models.Users;
using NadinTest.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinTest.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext DbContext;
        public UserRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public User Create(User user)
        {
            DbContext.Users.Add(user);
            DbContext.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            var res = GetById(user.Id);
            DbContext.Users.Remove(res);
            DbContext.SaveChanges();

        }

        public List<User> GetAll(User product)
        {
            return DbContext.Users
                .Select(x => new User
                { PassWord = x.PassWord 
                , Id = x.Id
                ,UserName = x.UserName
                    
                })
                .ToList();
        }

        public User GetById(Guid Id)
        {
            var res = DbContext.Users.FirstOrDefault(x => x.Id == Id);
            if (res == null)
            {
                throw new Exception("کاربر مورد نظر یافت نشد.");
            }
            return res;
        }

        public User Update(User user)
        {
            var res = GetById(user.Id);
            DbContext.Users.Update(res);
            DbContext.SaveChanges();
            return res;
        }


        //public async Task AddAsync(User user, string password, CancellationToken cancellationToken)
        //{
        //    var exists = await TableNoTracking.AnyAsync(p => p.UserName == user.UserName);
        //    if (exists)
        //        throw new BadRequestException("نام کاربری تکراری است");

        //    var passwordHash = SecurityHelper.GetSha256Hash(password);
        //    user.PassWord = passwordHash;
        //    await base.AddAsync(user, cancellationToken);
        //}

    }
}
