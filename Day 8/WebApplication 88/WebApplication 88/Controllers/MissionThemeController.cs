using Authentication.Entities;
using Authentication.Repository;
using Microsoft.AspNetCore.Http;
using Authentication.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication_88.Repository;

using Authentication.Model;
using Authentication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_88.Repository;

namespace WebApplication_88.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionThemeController : ControllerBase
    {
        private readonly IMissionTheme _missionRep2;

        public MissionThemeController(IMissionTheme missionRepos)
        {
            _missionRep2 = missionRepos;

        }
        [HttpPost("CreateMissionTheme")]
        public async Task<IActionResult> CreateMissionTheme([FromBody] MissionTheme model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var missionA = await _missionRep2.CreateMissionTheme(model);

            return Ok(missionA);
        }

        [HttpGet("GetAllThemeDetails")]
        public async Task<IActionResult> GetAllThemeDetails()
        {
            var missionB = await _missionRep2.GetAllThemeDetails();
            return Ok(missionB);
        }


        [HttpGet("GetMissionThemeDetailsById/{missionId}")]
        public async Task<IActionResult> GetMissionThemeDetailsById(int missionId)
        {
            var missionC = await _missionRep2.GetMissionThemeDetailsById(missionId);
            return Ok(missionC);
        }

        [HttpDelete("DeleteMissionTheme/{id}")]
        public async Task<IActionResult> DeleteMissionTheme(int id)
        {
            var resultD = await _missionRep2.DeleteMissionTheme(id);

            if (resultD == "MissionTheme do not found")
            {
                return NotFound(resultD);
            }

            return Ok(resultD);
        }

        [HttpPost]
        [Route("UpdateMissionThemedata")]
        public async Task<IActionResult> UpdateMissionThemedata(int missionId, Entities.MissionTheme change3)
        {
            var result6 = await _missionRep2.UpdateMissionThemedata(missionId, change3);
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (result6 == null)
                {
                    return NotFound("MissionTheme detail not found");
                }

                return Ok(result6);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "error occurred");
            }
        }
    }
}
