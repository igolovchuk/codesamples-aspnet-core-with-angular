using System.Collections.Generic;
using System.Threading.Tasks;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Services.Interfaces
{
    /// <summary>
    /// Document type model CRUD
    /// </summary>
    public interface IDocumentService : ICrudService<DocumentDTO>
    {
        Task<IEnumerable<DocumentDTO>> GetRangeByIssueLogIdAsync(int issueLogId);

        Task<DocumentDTO> GetDocumentWithData(int documentId);
    }
}
