using ABSA.Assessment.Application.PhoneBook.Command;
using ABSA.Assessment.Application.PhoneBook.Query;
using ABSA.Assessment.Domain.Dto;
using ABSA.Assessment.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ABSA.Assessment.PhoneBook.API.Controllers
{
    [EnableCors("_absaAllowSpecificOrigins")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        public PhoneBookController(IMediator mediator, ILogger<PhoneBookController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost("create-phonebook")]
        [SwaggerOperation(Summary = "Create phonebook item", Description = "adds single record to create phonebook item")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreratePhoneBookAsync(CreatePhoneBookRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Creating phonebook item for : {Name}", request.Name);
                var commmand = new CreatePhoneBookCommand { CreatePhoneBookCommandRequest = request };
                await TryUpdateModelAsync(commmand);

                if (!ModelState.IsValid)
                {

                    _logger.LogWarning("Validation Exception while creating phonebook item");
                    return BadRequest(ModelState);
                }
                var result = await _mediator.Send(commmand, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured while creating phonebook item " + request.Name);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-phonebook-entry")]
        [SwaggerOperation(Summary = "Create phonebook entry item", Description = "adds single record to create phonebook entry item")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreratePhoneBookAsync(AddEntryDto request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Creating phonebook entry item for : {Name}-{PhoneNumber}", request.Name, request.PhoneNumber);
                var commmand = new CreatePhoneBookEntryCommand { CreatePhoneBookEntryCommandRequest = new CreatePhoneBookEntryRequest { Entry = request }  };
                await TryUpdateModelAsync(commmand);

                if (!ModelState.IsValid)
                {

                    _logger.LogWarning("Validation Exception while creating phonebook entry item");
                    return BadRequest(ModelState);
                }
                var result = await _mediator.Send(commmand, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while creating phonebook entry item for : {Name}-{PhoneNumber}", request.Name, request.PhoneNumber);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-phonebook")]
        [SwaggerOperation(Summary = "Update phonebook item", Description = "updates single phonebook record")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePhoneBookAsync(UpdatePhoneBookRequest request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Updating phonebook item for : {PhoneBookId}", request.PhoneBookId);
                var commmand = new UpdatePhoneBookCommand { UpdatePhoneBookRequest = request };
                await TryUpdateModelAsync(commmand);

                if (!ModelState.IsValid)
                {

                    _logger.LogWarning("Validation Exception while updating phonebook item");
                    return BadRequest(ModelState);
                }
                var result = await _mediator.Send(commmand, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured while updating phonebook item  {PhoneBookId} " + request.PhoneBookId);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-phonebook-entry")]
        [SwaggerOperation(Summary = "Update phonebook entry", Description = "updates single phonebook entry record")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePhoneBookEntryAsync(UpdateEntryDto request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Updating phonebook entry for : {EntryId}", request.EntryId);
                var commmand = new UpdatePhoneBookEntryCommand { UpdatePhoneBookEntryRequest =  new UpdatePhoneBookEntryRequest { updateEntryDto = request} };
                await TryUpdateModelAsync(commmand);

                if (!ModelState.IsValid)
                {

                    _logger.LogWarning("Validation Exception while updating phonebook entry");
                    return BadRequest(ModelState);
                }
                var result = await _mediator.Send(commmand, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured while updating phonebook entry {EntryId} " + request.EntryId);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search-phonebook/{searchText}")]
        [SwaggerOperation(Summary = "Get phonebook entry", Description = "searches phonebook using keyword proovided")]
        [ProducesResponseType(typeof(IEnumerable<Domain.Entities.PhoneBook>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPhoneBookAsync(string searchText, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Getting phonebook  for : {searchText}", searchText);
                var query = new SearchPhoneBookQuery { GetPhoneBookEntryRequest = new SearchPhoneBookRequest { SearchText = searchText } };
                await TryUpdateModelAsync(query);

                if (!ModelState.IsValid)
                {

                    _logger.LogWarning("Validation Exception while searching phonebook  item");
                    return BadRequest(ModelState);
                }
                var result = await _mediator.Send(query, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while searching phonebook   for : {searchText}", searchText);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search-entry/{searchText}")]
        [SwaggerOperation(Summary = "Get phonebook entry", Description = "searches phonebook erntry using keyword proovided")]
        [ProducesResponseType(typeof(IEnumerable<Entry>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPhoneBookEntryAsync(string searchText, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Getting phonebook  for : {searchText}", searchText);
                var query = new SearchEntryQuery { SearchEntryRequest = new SearchEntryRequest { SearchText = searchText } };
                await TryUpdateModelAsync(query);

                if (!ModelState.IsValid)
                {

                    _logger.LogWarning("Validation Exception while searching phonebook  item");
                    return BadRequest(ModelState);
                }
                var result = await _mediator.Send(query, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while searching phonebook entry  for : {searchText}", searchText);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-phonebook-entry/{entryId}")]
        [SwaggerOperation(Summary = "Get phonebook entry", Description = "get single phonebook entry")]
        [ProducesResponseType(typeof(IEnumerable<Entry>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPhoneBookEntryByIdAsync(int entryId, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Getting phonebook entry for : {entryId}", entryId);
                var query = new GetPhoneBookEntryByIdQuery { GetPhoneEntryByIdRequest = new  GetPhoneEntryByIdRequest { entryId = entryId } };
                await TryUpdateModelAsync(query);

                if (!ModelState.IsValid)
                {

                    _logger.LogWarning("Validation Exception while searching phonebook entry item");
                    return BadRequest(ModelState);
                }
                var result = await _mediator.Send(query, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while searching phonebook entry  for : {entryId}", entryId);
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-phonebook-list")]
        [SwaggerOperation(Summary = "Get phonebook list", Description = "searches phonebook list ")]
        [ProducesResponseType(typeof(IEnumerable<Entry>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPhoneBookListAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Getting phonebook list");
                var query = new GetPhoneBookListQuery();


                var result = await _mediator.Send(query, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while searching phonebook list");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-phonebook/{phoneBookId}")]
        [SwaggerOperation(Summary = "Get phonebook ", Description = "get phonebook  ")]
        [ProducesResponseType(typeof(Entry), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPhoneBookAsync(int phoneBookId, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Getting phonebook item for {phoneBookId}", phoneBookId);
                var query = new GetPhoneBookQuery
                {
                    GetPhoneBookRequest = new GetPhoneBookRequest
                    {
                        PhoneBookId = phoneBookId
                    }
                };


                var result = await _mediator.Send(query, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured while searching phonebook list");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-phonebook/{phoneBookId}")]
        [SwaggerOperation(Summary = "Delete phonebook item", Description = "delete single phonebook record")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePhoneBookAsync(int phoneBookId, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Deleting phonebook item for : {PhoneBookId}", phoneBookId);
                var commmand = new DeletePhoneBookCommand
                {
                    DeletePhoneBookRequest = new DeletePhoneBookRequest
                    {
                        PhoneBookId = phoneBookId
                    }
                };
                await TryUpdateModelAsync(commmand);

                if (!ModelState.IsValid)
                {

                    _logger.LogWarning("Validation Exception while deleting phonebook item");
                    return BadRequest(ModelState);
                }
                var result = await _mediator.Send(commmand, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured while deleting phonebook item  {PhoneBookId} ", phoneBookId);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-phonebook-entry/{entryId}")]
        [SwaggerOperation(Summary = "Delete phonebook entry", Description = "delete single phonebook entry record")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePhoneBookEntryAsync(int entryId, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Deleting phonebook entry for : {EntryId}", entryId);
                var commmand = new DeletePhoneBookEntryCommand { DeletePhoneBookEntryRequest = new DeletePhoneBookEntryRequest { EntryId = entryId } };
                await TryUpdateModelAsync(commmand);

                if (!ModelState.IsValid)
                {

                    _logger.LogWarning("Validation Exception while deleting phonebook EntryId");
                    return BadRequest(ModelState);
                }
                var result = await _mediator.Send(commmand, cancellationToken);

                return Ok(result);
            }   
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occured while deleting phonebook EntryId  {EntryId} ", entryId);
                return BadRequest(ex.Message);
            }
        }
    }
}
