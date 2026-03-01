using DWFSWPFUserInterface.Models;
using System.Threading.Tasks;

namespace DWFSWPFUserInterface.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);

        Task GetLoggedInUserInfo(string token);
    }
}