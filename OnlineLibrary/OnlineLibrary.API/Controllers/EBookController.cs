using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.BusinessLogic.DTO.RequestDTOs;
using OnlineLibrary.BusinessLogic.Service.IServices;

namespace OnlineLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EBookController : ControllerBase
    {
        private readonly IEBookService _eBookService;
        private readonly ILogger<EBookController> _logger;

        public EBookController(IEBookService eBookService, ILogger<EBookController> logger)
        {
            _eBookService = eBookService;
            _logger = logger;
        }

        [HttpPost("UploadEBook"), DisableRequestSizeLimit]
        public async Task<ActionResult<int>> UploadEBookAsync([FromForm] EBookRequestDTO eBookRequestDTO)
        {
            try
            {
                if (eBookRequestDTO.formFile is not null)
                {
                    var resultId = await _eBookService.UploadEBookAsync(eBookRequestDTO);
                    _logger.LogInformation("E-Book uploaded to DB");
                    return resultId;
                }
                else
                {
                    throw new Exception("No file uploaded.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while uploading the E-Book: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was uploading changes.");
            }
        }

        [HttpGet("Download E-Book by id")]
        public async Task<ActionResult<File>> DownloadEBookByIdAsync(int id)
        {
            try
            {
                var fileStream = await _eBookService.GetEBookFileByIdAsync(id);
                if (fileStream == null)
                    return NotFound();

                // Set response headers for file download
                var fileName = "filename.ext"; // Replace with the actual file name
                var contentType = "application/octet-stream"; // Set the appropriate content type

                return File(fileStream, contentType, fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving file: {ex.Message} , StackTrace: {ex.StackTrace}");
                throw new Exception("Error retrieving file.");
            }
        }
    }
}
