using DWFSWPFUserInterface.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DWFSWPFUserInterface.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}