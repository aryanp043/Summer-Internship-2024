using Authentication.Entities;
using Authentication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repository
{
    public class Mission:IMission

    {
        private readonly AuthContext _authContext;

        public Mission(AuthContext authContext)
        {
            _authContext = authContext;
        }

        public async Task<List<MissionViewModel>> GetMissionsWithDetails()
        {
            try
            {
              
                var missionsWithDetails = await _authContext.Missions.Select(mission => new MissionViewModel
                {
                    MissionId = mission.MissionId,
                    MissionTitle = mission.Title,
                    MissionDescription = mission.Description,
                    // CityName = _authContext.Cities.FirstOrDefault(c => c.CityId == mission.CityId).CityName,
                    //CountryName = _authContext.Countries.FirstOrDefault(c => c.CountryId == mission.CountryId).CountryName,
                    StartDate = mission.StartDate.ToString(),
                    EndDate = mission.EndDate.ToString(),
                    Deadline = mission.Deadline.ToString()
                }).ToListAsync();

                return missionsWithDetails;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<string> CreateMission(MissionDto model)
        {
            var mission = new MissionDto
            {
                Title = model.Title,
                Description = model.Description,
                CityId = model.CityId,
                CountryId = model.CountryId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Deadline = model.Deadline
            };

            _authContext.Missions.Add(mission);
            await _authContext.SaveChangesAsync();

            return "Mission Created Succesfully";
        }

        public async Task<MissionViewModel> GetMissionDetailsById(int missionId)
        {
            var missionWithDetails = await _authContext.Missions
                .Where(mission => mission.MissionId == missionId)
                .Select(mission => new MissionViewModel
                {
                    MissionId = mission.MissionId,
                    MissionTitle = mission.Title,
                    MissionDescription = mission.Description,
                   // CityName = _authContext.Cities.FirstOrDefault(c => c.CityId == mission.CityId).CityName,
                   // CountryName = _authContext.Countries.FirstOrDefault(c => c.CountryId == mission.CountryId).CountryName,
                    StartDate = mission.StartDate.ToString(),
                    EndDate = mission.EndDate.ToString(),
                    Deadline = mission.Deadline.ToString(),
                    SeatsLeft = mission.SeatsLeft,
                 //   OrganizationName = _authContext.Organizations.FirstOrDefault(r => r.OrganizationId == mission.OrganizationId).OrganizationName,
                 ////   Rating = _authContext.Organizations.FirstOrDefault(r => r.OrganizationId == mission.OrganizationId).Rating,
                  //  ImageURL = _authContext.MissionImage.FirstOrDefault(i => i.MissionId == mission.MissionId).ImageURL,
                 //   ThemeName = _authContext.MissionThemes.FirstOrDefault(t => t.ThemeId == mission.ThemeId).ThemeName,
                    Challenge = mission.Challenge,
                    MissionType = mission.MissionType,
                    MissionObject = mission.MissionObject,
                    MissionAchieved = mission.MissionAchieved,
                    Availability = mission.Availability,

            
                })
                .FirstOrDefaultAsync();

            return missionWithDetails;
        }

        public async Task<string> DeleteMission(int id)
       {
            var mission = await _authContext.Missions.FindAsync(id);
            if (mission == null)
            {
                return "Mission not found";
            }

            _authContext.Missions.Remove(mission);
           await _authContext.SaveChangesAsync();

           return "Mission Deleted Successfully";
        }

        public async Task<string> UpdateMissiondata(int missionId, MissionDto change)
        {
            try
            {
                using (var transaction = await _authContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var existingUser = await _authContext.Missions.FirstOrDefaultAsync(x => x.MissionId == missionId);
                        if (existingUser == null)
                        {
                            return "Mission details do not found !!!";
                        }
                        else
                        {
                            //main update code

                            //existingUser.MissionId = change.MissionId;
                            existingUser.Title = change.Title;
                            existingUser.Description = change.Description;
                            existingUser.Introduction = change.Introduction;
                            existingUser.Challenge = change.Challenge;
                            existingUser.TotalSeats = change.TotalSeats;
                            existingUser.SeatsLeft = change.SeatsLeft;
                            existingUser.StartDate = change.StartDate;
                            existingUser.EndDate = change.EndDate;
                            existingUser.Deadline = change.Deadline;
                            existingUser.ThemeId = change.ThemeId;
                            existingUser.OrganizationId = change.OrganizationId;
                            existingUser.CityId = change.CityId;
                            existingUser.CountryId = change.CountryId;
                            existingUser.MissionImage = change.MissionImage;
                            existingUser.MissionType = change.MissionType;
                            existingUser.MissionObject = change.MissionObject;
                            existingUser.MissionAchieved = change.MissionAchieved;
                            existingUser.Availability = change.Availability;
                            
                            await _authContext.SaveChangesAsync();
                            await transaction.CommitAsync();
                            return "Mission details updated successfully";
                        }
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        return "Failed to update mission details";
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
