using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Dtos.AppProgram;
using Capital_Placement.Interfaces;
using Capital_Placement.Mappers;
using Capital_Placement.Models;
using Capital_Placement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Capital_Placement.Controllers
{
    [Route("api/program")]
    [ApiController]
    public class AppProgramController: ControllerBase
    {
        private readonly IAppProgramService _appProgramService;

        public AppProgramController(IAppProgramService appProgramService)
        {
            _appProgramService = appProgramService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateAppProgramDto appProgramDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appProgram = appProgramDto.ToAppProgramFromCreateDto();
            await _appProgramService.Create(appProgram);

            return CreatedAtAction(nameof(GetById), new { appProgramId = appProgram.Id }, appProgram.ToAppProgramDto());
        }
       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _appProgramService.GetAll();

            return Ok(result);
        }

        [HttpGet("{appProgramId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute]Guid appProgramId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appProgram = await _appProgramService.GetById(appProgramId);

            if (appProgram == null) return NotFound();

            return Ok(appProgram.ToAppProgramDto());
        }

        [HttpPut("{appProgramId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromRoute]Guid appProgramId, [FromBody] UpdateAppProgramDto appProgramDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _appProgramService.Update(appProgramId, appProgramDto.ToAppProgramFromUpdateDto());

            if (result == null) return NotFound("Program not found");

            return Ok(result.ToAppProgramDto());
        }

        [HttpDelete("{appProgramId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid appProgramId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _appProgramService.Delete(appProgramId);

            if (!result) return BadRequest();

            return Ok();
        }
    }
}