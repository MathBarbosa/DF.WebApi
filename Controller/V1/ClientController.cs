using DesafioFinal.Application.UseCase.DeleteClient;
using DesafioFinal.Application.UseCase.GetAllClients;
using DesafioFinal.Application.UseCase.GetClientById;
using DesafioFinal.Application.UseCase.GetClientByName;
using DesafioFinal.Application.UseCase.GetClientTotalRegister;
using DesafioFinal.Application.UseCase.PatchClient;
using DesafioFinal.Application.UseCase.PostCreateClient;
using DesafioFinal.Domain.Enuns;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace DesafioFinal.WebApi.Controller.V1
{

    [Route("api/v1/client")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        #region :: POST

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostCreateClient([FromBody] PostCreateClientInput input, CancellationToken cancelationToken) 
        {
            var response = await _mediator.Send(input, cancelationToken).ConfigureAwait(false);

            return response.Type switch
            {
                EInternalResponseCode.Success => Ok(response.Data),
                EInternalResponseCode.NoFound => BadRequest(response.Errors),
                EInternalResponseCode.FastFailValidation => BadRequest(response.Errors),
                EInternalResponseCode.ServiceError => StatusCode(StatusCodes.Status500InternalServerError),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }

        #endregion

        #region :: GET

        [HttpGet("total-register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTotalRegister([FromBody] GetClientTotalRegisterInput input, CancellationToken cancelationToken)
        {
            var response = await _mediator.Send(input, cancelationToken).ConfigureAwait(false);

            return response.Type switch
            {
                EInternalResponseCode.Success => Ok(response.Data),
                EInternalResponseCode.NoFound => BadRequest(response.Errors),
                EInternalResponseCode.FastFailValidation => BadRequest(response.Errors),
                EInternalResponseCode.ServiceError => StatusCode(StatusCodes.Status500InternalServerError),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }

        [HttpGet("find-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllClients(CancellationToken cancelationToken)
        {
            var response = await _mediator.Send(new GetAllClientsInput(), cancelationToken).ConfigureAwait(false);

            return response.Type switch
            {
                EInternalResponseCode.Success => Ok(response.Data),
                EInternalResponseCode.NoFound => BadRequest(response.Errors),
                EInternalResponseCode.FastFailValidation => BadRequest(response.Errors),
                EInternalResponseCode.ServiceError => StatusCode(StatusCodes.Status500InternalServerError),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllClients([FromRoute] int id, CancellationToken cancelationToken)
        {
            var response = await _mediator.Send(new GetClientByIdInput { Id = id}, cancelationToken).ConfigureAwait(false);

            return response.Type switch
            {
                EInternalResponseCode.Success => Ok(response.Data),
                EInternalResponseCode.NoFound => BadRequest(response.Errors),
                EInternalResponseCode.FastFailValidation => BadRequest(response.Errors),
                EInternalResponseCode.ServiceError => StatusCode(StatusCodes.Status500InternalServerError),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllClients([FromRoute] string name, CancellationToken cancelationToken)
        {
            var response = await _mediator.Send(new GetClientByNameInput { Name = name }, cancelationToken).ConfigureAwait(false);

            return response.Type switch
            {
                EInternalResponseCode.Success => Ok(response.Data),
                EInternalResponseCode.NoFound => BadRequest(response.Errors),
                EInternalResponseCode.FastFailValidation => BadRequest(response.Errors),
                EInternalResponseCode.ServiceError => StatusCode(StatusCodes.Status500InternalServerError),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }

        #endregion

        #region :: PATCH

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchClient([FromRoute] int id, [FromBody] PatchClientInput input,CancellationToken cancelationToken)
        {
            var response = await _mediator.Send(input, cancelationToken).ConfigureAwait(false);

            return response.Type switch
            {
                EInternalResponseCode.Success => Ok(response.Data),
                EInternalResponseCode.NoFound => BadRequest(response.Errors),
                EInternalResponseCode.FastFailValidation => BadRequest(response.Errors),
                EInternalResponseCode.ServiceError => StatusCode(StatusCodes.Status500InternalServerError),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }

        #endregion

        #region :: DELETE

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteClient([FromRoute] int id, CancellationToken cancelationToken)
        {
            var response = await _mediator.Send(new DeleteClientInput { Id = id}, cancelationToken).ConfigureAwait(false);

            return response.Type switch
            {
                EInternalResponseCode.Success => Ok(response.Data),
                EInternalResponseCode.NoFound => BadRequest(response.Errors),
                EInternalResponseCode.FastFailValidation => BadRequest(response.Errors),
                EInternalResponseCode.ServiceError => StatusCode(StatusCodes.Status500InternalServerError),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }
        #endregion
    }
}
