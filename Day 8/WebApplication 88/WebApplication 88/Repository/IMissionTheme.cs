using Authentication.Model;
using Authentication.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication_88.Repository
{
    public interface IMissionTheme
    {
        Task<List<MissionThemeModel>> GetAllThemeDetails();
        Task<string> CreateMissionTheme(MissionTheme model);
        Task<MissionThemeModel> GetMissionThemeDetailsById(int missionId);
        Task<string> DeleteMissionTheme(int id);
        Task<string> UpdateMissionThemedata(int missionId, Entities.MissionTheme change3);
    }
}
