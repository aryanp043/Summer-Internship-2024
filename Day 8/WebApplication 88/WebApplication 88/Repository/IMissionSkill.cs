//using Authentication.Model;
using Authentication.Entities;

using WebApplication_88.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Authentication.Model;

namespace WebApplication_88.Repository
{
    public interface IMissionSkill
    {
        Task<List<MissionSkillModel>> GetAllSkillsDetails();
        Task<string> CreateMissionSkill(MissionSkill model);
        Task<MissionSkillModel> GetMissionSkillDetailsById(int missionId);
        Task<string> DeleteMissionSkill(int id);
        Task<string> UpdateMissionSkilldata(int missionId, Entities.MissionSkill change3);
    }
}
