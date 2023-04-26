using api.Data;
using api.Models;
using api.Models.DTO;
using api.repository.IReposirory;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        protected APIResponse _res;

        public VillaController(IVillaRepository dbVilla, IMapper mapper)
        {
            _dbVilla = dbVilla;
            _mapper = mapper;
            this._res = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                IEnumerable<Villa> villas = await _dbVilla.GetAllAsync();
                _res.Result = _mapper.Map<List<VillaDTO>>(villas);
                _res.StatusCode = HttpStatusCode.OK;
                return Ok(_res);
            }
            catch(Exception ex)
            {
                _res.isSuccess = false;
                _res.ErrorMessages = new List<string>() { ex.ToString()};
            }
            return _res;
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200), Type = typeof(VillaDTO)]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                if (id == 0) 
                { 
                    _res.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_res); 
                }
                var villa = await _dbVilla.GetAsync(v => v.id == id);
                if (villa == null)
                {
                    _res.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_res);
                }
                _res.Result = _mapper.Map<VillaDTO>(villa);
                _res.StatusCode = HttpStatusCode.OK;
                return Ok(_res);
            }
            catch (Exception ex)
            {
                _res.isSuccess = false;
                _res.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _res;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody]VillaCreateDTO createDTO)
        {
            try
            {
                //if(!ModelState.IsValid) { return BadRequest(ModelState); }
                if (await _dbVilla.GetAsync(v => v.name.ToLower() == createDTO.name.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "Villa already Exists!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null) { return BadRequest(createDTO); }
                //if(villaDTO.id > 0) { return StatusCode(StatusCodes.Status500InternalServerError); }

                Villa villa = _mapper.Map<Villa>(createDTO);

                await _dbVilla.CreateAsync(villa);
                _res.Result = _mapper.Map<VillaDTO>(villa);
                _res.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = villa.id }, _res);
            }
            catch (Exception ex)
            {
                _res.isSuccess = false;
                _res.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _res;
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0) 
                { 
                    _res.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_res); 
                }
                var villa = await _dbVilla.GetAsync(v => v.id == id);
                if (villa == null) 
                {
                    _res.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_res); 
                }

                await _dbVilla.RemoveAsync(villa);
                _res.isSuccess = true;
                _res.StatusCode = HttpStatusCode.NoContent;
                return Ok(_res);
            }
            catch (Exception ex)
            {
                _res.isSuccess = false;
                _res.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _res;
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody]VillaUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.id) { return BadRequest(); }
                Villa model = _mapper.Map<Villa>(updateDTO);
                await _dbVilla.UpdateAsync(model);
                _res.isSuccess = true;
                _res.StatusCode = HttpStatusCode.NoContent;
                return Ok(_res);
            }
            catch (Exception ex)
            {
                _res.isSuccess = false;
                _res.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _res;
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id, [FromBody] JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            try
            {
                if (patchDTO == null || id == 0) { return BadRequest(); }
                var villa = await _dbVilla.GetAsync(v => v.id == id, tracked: false);

                VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
                patchDTO.ApplyTo(villaDTO, ModelState);
                Villa model = _mapper.Map<Villa>(villaDTO);

                await _dbVilla.UpdateAsync(model);

                if (!ModelState.IsValid) { return BadRequest(ModelState); }
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return NoContent();
                //_res.isSuccess = false;
                //_res.ErrorMessages = new List<string>() { ex.ToString() };
            }
            //return _res;
        }
    }
}
