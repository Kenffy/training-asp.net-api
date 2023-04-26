using api.Models;
using api.Models.DTO;
using api.repository.IReposirory;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        private readonly IVillaNumberRepository _dbVillaNbr;
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        protected APIResponse _res;

        public VillaNumberController(IVillaNumberRepository dbVillaNbr, IVillaRepository dbVill, IMapper mapper)
        {
            _dbVillaNbr = dbVillaNbr;
            _dbVilla = dbVill;
            _mapper = mapper;
            this._res = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {
                IEnumerable<VillaNumber> villas = await _dbVillaNbr.GetAllAsync();
                _res.Result = _mapper.Map<List<VillaNumberDTO>>(villas);
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

        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _res.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_res);
                }
                var villa = await _dbVillaNbr.GetAsync(v => v.villaNo == id);
                if (villa == null)
                {
                    _res.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_res);
                }
                _res.Result = _mapper.Map<VillaNumberDTO>(villa);
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
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDTO createDTO)
        {
            try
            {
                if (await _dbVillaNbr.GetAsync(v => v.villaNo == createDTO.villaNo) != null)
                {
                    ModelState.AddModelError("CustomError", "Villa Number already Exists!");
                    return BadRequest(ModelState);
                }
                if(await _dbVilla.GetAsync(v => v.id == createDTO.villaId) == null)
                {
                    ModelState.AddModelError("CustomError", "Villa Id is invalid!");
                    return BadRequest(ModelState);
                }
                
                if (createDTO == null) { return BadRequest(createDTO); }

                VillaNumber villa = _mapper.Map<VillaNumber>(createDTO);

                await _dbVillaNbr.CreateAsync(villa);
                _res.Result = _mapper.Map<VillaNumberDTO>(villa);
                _res.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVillaNumber", new { id = villa.villaNo }, _res);
            }
            catch (Exception ex)
            {
                _res.isSuccess = false;
                _res.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _res;
        }

        [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _res.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_res);
                }
                var villa = await _dbVillaNbr.GetAsync(v => v.villaNo == id);
                if (villa == null)
                {
                    _res.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_res);
                }

                await _dbVillaNbr.RemoveAsync(villa);
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

        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.villaNo) { return BadRequest(); }
                if (await _dbVilla.GetAsync(v => v.id == updateDTO.villaId) == null)
                {
                    ModelState.AddModelError("CustomError", "Villa Id is invalid!");
                    return BadRequest(ModelState);
                }
                VillaNumber model = _mapper.Map<VillaNumber>(updateDTO);
                await _dbVillaNbr.UpdateAsync(model);
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

        //[HttpPatch("{id:int}", Name = "UpdatePartialVillaNumber")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdatePartialVillaNumber(int id, [FromBody] JsonPatchDocument<VillaNumberUpdateDTO> patchDTO)
        //{
        //    try
        //    {
        //        if (patchDTO == null || id == 0) { return BadRequest(); }
        //        var villa = await _dbVillaNbr.GetAsync(v => v.villaNo == id, tracked: false);

        //        VillaNumberUpdateDTO villaDTO = _mapper.Map<VillaNumberUpdateDTO>(villa);
        //        patchDTO.ApplyTo(villaDTO, ModelState);
        //        VillaNumber model = _mapper.Map<VillaNumber>(villaDTO);

        //        await _dbVillaNbr.UpdateAsync(model);

        //        if (!ModelState.IsValid) { return BadRequest(ModelState); }
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return NoContent();
        //        //_res.isSuccess = false;
        //        //_res.ErrorMessages = new List<string>() { ex.ToString() };
        //    }
        //    //return _res;
        //}
    }
}
