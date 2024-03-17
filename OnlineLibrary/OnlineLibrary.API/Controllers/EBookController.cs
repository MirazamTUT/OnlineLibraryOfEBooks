using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.BusinessLogic.DTO.RequestDTOs;
using OnlineLibrary.BusinessLogic.DTO.ResponseDTOs;
using OnlineLibrary.BusinessLogic.Service.IServices;
using System.Security.AccessControl;

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

        [HttpGet("downloadEBook")]
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
                _logger.LogInformation("E-Book was found.");
                return File(fileStream, eBookResponseDTO.ContentType, eBookResponseDTO.Title);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving file: {ex.Message} , StackTrace: {ex.StackTrace}");
                throw new Exception("Error retrieving file.");
            }
        }

        [HttpGet("id")]
        public async Task<ActionResult<EBookResponseDTO>> GetEBookAsync(int id)
        {
            try
            {
                var eBookResponseDTO = await _eBookService.GetEBookByIdAsync(id);
                _logger.LogInformation("E-Book was found.");
                return eBookResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving file: {ex.Message} , StackTrace: {ex.StackTrace}");
                throw new Exception("Error retrieving file.");
            }
        }

        [HttpGet("allEBooks")]
        public async Task<ActionResult<List<EBookResponseDTO>>> GetAllEBooksAsync()
        {
            try
            {
                var eBooksResponseDTO = await _eBookService.GetAllEBooksAsync();
                _logger.LogInformation("E-Books were found.");
                return eBooksResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving files: {ex.Message} , StackTrace: {ex.StackTrace}");
                throw new Exception("Error retrieving files.");
            }
        }

        [HttpGet("allEBooksWithoutFile")]
        public async Task<ActionResult<List<EBookWithoutFileResponseDTO>>> GetAllEBooksWithoutFileAsync()
        {
            try
            {
                var eBooksResponseDTO = await _eBookService.GetAllEBooksWithoutFileAsync();
                _logger.LogInformation("E-Books were found.");
                return eBooksResponseDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving files: {ex.Message} , StackTrace: {ex.StackTrace}");
                throw new Exception("Error retrieving files.");
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateEBookAsync(EBookRequestDTO requestDTO)
        {
            try
            {
                var resultId = await _eBookService.UpdateEBookAsync(requestDTO);
                _logger.LogInformation("Updated E-Book.");
                return resultId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating the E-Book: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was updating changes.");
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<int>> DeleteEBookAsync(int id)
        {
            try
            {
                var resultId = await _eBookService.DeleteEBookByIdAsync(id);
                _logger.LogInformation("Deleted E-Book.");
                return resultId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting the E-Book: {ex.Message}, StackTrace: {ex.StackTrace}.");
                throw new Exception("Operation was failed when it was deleting changes.");
            }
        }
    }
}
