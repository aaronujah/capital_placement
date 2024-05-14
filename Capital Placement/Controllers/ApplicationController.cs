using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Dtos.Application;
using Capital_Placement.Interfaces;
using Capital_Placement.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Capital_Placement.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController: ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateApplicationDto applicationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var application = applicationDto.ToApplicationFromCreateDto();
            await _applicationService.Create(application);

            return CreatedAtAction(nameof(GetById), new { applicationId = application.Id }, application.ToApplicationDto());
        }
       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _applicationService.GetAll();

            return Ok(result);
        }

        [HttpGet("{applicationId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute]Guid applicationId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var application = await _applicationService.GetById(applicationId);

            if (application == null) return NotFound();

            return Ok(application.ToApplicationDto());
        }

        [HttpPut("{applicationId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute]Guid applicationId, [FromBody] UpdateApplicationDto applicationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _applicationService.Update(applicationId, applicationDto.ToApplicationFromUpdateDto());

            if (result == null) return NotFound("Program not found");

            return Ok(result.ToApplicationDto());
        }

        [HttpDelete("{applicationId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid applicationId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _applicationService.Delete(applicationId);

            if (!result) return BadRequest();

            return Ok();
        }
    }
}