using DWFSWPFUserInterface.Models;
using System.Threading.Tasks;

namespace DWFSWPFUserInterface.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}