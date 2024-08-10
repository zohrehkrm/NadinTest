
using NadinTest.Core.JWT;
using NadinTest.Core.Models.Users;
using System.Threading.Tasks;

namespace NadinTest.Service.Services
{
    public interface IJwtService
    {
        Task<string> GenerateAsync(User user);
    }
}