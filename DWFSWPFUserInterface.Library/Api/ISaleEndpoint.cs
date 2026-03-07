using DWFSWPFUserInterface.Library.Models;
using System.Threading.Tasks;

namespace DWFSWPFUserInterface.Library.Api
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}