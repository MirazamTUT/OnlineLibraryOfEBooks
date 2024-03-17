using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.BusinessLogic.DTO.RequestDTOs;
using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;
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

        [HttpPost("uploadEBook"), DisableRequestSizeLimit]
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

        [HttpGet("download")]
        public async Task<IActionResult> DownloadEBookByIdAsync(int id)
        {
            try
            {
                var fileStream = await _eBookService.GetEBookFileByIdAsync(id);
                if (fileStream == null)
                {
                    return NotFound();
                }

                var eBookResponseDTO = await _eBookService.GetEBookByIdAsync(id);

                return File(fileStream, eBookResponseDTO.ContentType, eBookResponseDTO.Title);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving file: {ex.Message} , StackTrace: {ex.StackTrace}");
                throw new Exception("Error retrieving file.");
            }
        }
    }
}
