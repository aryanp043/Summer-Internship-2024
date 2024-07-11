﻿using Authentication.Entities;
using Authentication.Model;

namespace Authentication.Repository
{
    public interface IMission
    {
        Task<List<MissionViewModel>> GetMissionsWithDetails();
        Task<string> CreateMission(MissionDto model);
        Task<MissionViewModel> GetMissionDetailsById(int missionId);
        Task<string> UpdateMissiondata(int missionId, MissionDto change);

        Task<string> DeleteMission(int id);
    }
}
