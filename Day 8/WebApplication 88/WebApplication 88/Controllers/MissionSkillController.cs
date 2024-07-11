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
using WebApplication_88.Entities;


namespace WebApplication_88.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionSkillController : ControllerBase
    {
        private readonly IMissionSkill _missionRep2;

        public MissionSkillController(IMissionSkill missionRepos)
        {
            _missionRep2 = missionRepos;

        }
        [HttpPost("CreateMissionSkill")]
        public async Task<IActionResult> CreateMissionSkill([FromBody] Repository.MissionSkill model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var missionA = await _missionRep2.CreateMissionSkill(model);

            return Ok(missionA);
        }

        [HttpGet("GetAllSkillsDetails")]
        public async Task<IActionResult> GetAllSkillsDetails()
        {
            var missionB = await _missionRep2.GetAllSkillsDetails();
            return Ok(missionB);
        }


        [HttpGet("GetMissionSkillDetailsById/{missionId}")]
        public async Task<IActionResult> GetMissionSkillDetailsById(int missionId)
        {
            var missionC = await _missionRep2.GetMissionSkillDetailsById(missionId);
            return Ok(missionC);
        }

        [HttpDelete("DeleteMissionSkill/{id}")]
        public async Task<IActionResult> DeleteMissionSkill(int id)
        {
            var resultD = await _missionRep2.DeleteMissionSkill(id);

            if (resultD == "MissionSkill do not found")
            {
                return NotFound(resultD);
            }

            return Ok(resultD);
        }

        [HttpPost]
        [Route("UpdateMissionSkilldata")]
        public async Task<IActionResult> UpdateMissionSkilldata(int missionId, Entities.MissionSkill change8)
        {
            var result6 = await _missionRep2.UpdateMissionSkilldata(missionId, change8);
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (result6 == null)
                {
                    return NotFound("MissionState detail not found");
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
