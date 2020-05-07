using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.BLL.Exceptions;
using CoreAngularDemo.BLL.Factories;
using CoreAngularDemo.BLL.Services.Interfaces;

namespace CoreAngularDemo.API.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [Authorize(Roles = "ADMIN,ENGINEER,ANALYST")]
    public class DocumentController : FilterController<DocumentDTO>
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IServiceFactory serviceFactory, IFilterServiceFactory filterServiceFactory)
            : base(filterServiceFactory)
        {
            _documentService = serviceFactory.DocumentService;
        }

        [HttpGet("~/api/v1/IssueLog/{issueLogId}/Document")]
        public async Task<IActionResult> GetByIssueLog(int issueLogId)
        {
            return Json(await _documentService.GetRangeByIssueLogIdAsync(issueLogId));
        }

        [HttpGet("~/api/v1/Document/{id}/file")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            try
            {
                var document = await _documentService.GetDocumentWithData(id);
                if (document != null)
                {
                    return File(document.Data, document.ContentType);
                }
                else
                {
                    return null;
                }
            }
            catch (DocumentDownloadException)
            {
                return Content("File isn't accessible");
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] DocumentDTO documentDto)
        {
            try
            {
                var createdEntity = await _documentService.CreateAsync(documentDto);

                if (createdEntity != null)
                {
                    return CreatedAtAction(nameof(Create), createdEntity);
                }
                else
                {
                    return null;
                }
            }
            catch (EmptyDocumentException)
            {
                return Content("file is not selected");
            }
            catch (DocumentContentException)
            {
                return Content("format is not pdf");
            }
            catch (WrongDocumentSizeException)
            {
                return Content("file is too large");
            }
            catch (DocumentException)
            {
                return Content("error with this file, choose different one");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpDelete("~/api/v1/Document/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _documentService.DeleteAsync(id);
            return NoContent();
        }
    }
}