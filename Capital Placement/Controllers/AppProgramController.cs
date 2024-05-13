using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capital_Placement.Interfaces;
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
        public async Task<IActionResult> Add(AppProgram appProgram)
        {
            var result = await _appProgramService.Create(appProgram);

            return Ok(result);
        }
       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _appProgramService.GetAll();

            return Ok(result);
        }

        [HttpGet("{appProgramId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid appProgramId)
        {
            var appProgram = await _appProgramService.GetById(appProgramId);

            if (appProgram == null) return NotFound();

            return Ok(appProgram);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid appProgramId, AppProgram appProgram)
        {
            var result = await _appProgramService.Update(appProgramId, appProgram);

            if (result == null) return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{appProgramId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid appProgramId)
        {

            var result = await _appProgramService.Delete(appProgramId);

            if (!result) return BadRequest();

            return Ok();
        }
    }
}