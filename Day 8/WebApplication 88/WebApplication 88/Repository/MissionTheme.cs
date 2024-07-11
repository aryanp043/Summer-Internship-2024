using Authentication.Model;
using WebApplication_88.Entities;
//using WebApplication_88.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Authentication;
using WebApplication_88.Entities;
using Authentication.Entities;
// Authentication.Model

namespace WebApplication_88.Repository
{
    public class MissionTheme : IMissionTheme
    {
        private readonly AuthContext _dbsContext;

        public MissionTheme(AuthContext dbsContext)
        {
            _dbsContext = dbsContext;
        }

        public async Task<List<MissionThemeModel>> GetAllThemeDetails()
        {
            //return MissionSkill.ToListAsync();

            try
            {

                var mission22 = await _dbsContext.MissionTheme.Select(mission33 => new MissionThemeModel
                {
                    Id = mission33.Id,
                    ThemeName = mission33.ThemeName,
                    Status = mission33.Status

                }).ToListAsync();


                return mission22;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<string> CreateMissionTheme(Entities.MissionTheme model)
        {
            var mission3 = new Entities.MissionTheme
            {
                Id = model.Id,
                ThemeName = model.ThemeName,
                Status = model.Status

            };

            _dbsContext.MissionTheme.Add(mission3);
            await _dbsContext.SaveChangesAsync();

            return "MissionTheme data Created Succesfully";
        }


        public async Task<MissionThemeModel> GetMissionThemeDetailsById(int missionId)
        {
            var missionW = await _dbsContext.MissionTheme
                .Where(mission => mission.Id == missionId)
                .Select(mission => new MissionThemeModel
                {
                    Id = mission.Id,
                    ThemeName = mission.ThemeName,
                    Status = mission.Status

                })
                .FirstOrDefaultAsync();

            return missionW;
        }


        public async Task<string> DeleteMissionTheme(int id)
        {
            var mission4 = await _dbsContext.MissionTheme.FindAsync(id);
            if (mission4 == null)
            {
                return "MissionTheme data not found";
            }

            _dbsContext.MissionTheme.Remove(mission4);
            await _dbsContext.SaveChangesAsync();

            return "MissionTheme Deleted Successfully";
        }



        public async Task<string> UpdateMissionThemedata(int missionId, Entities.MissionTheme change3)
        {
            try
            {
                using (var transaction = await _dbsContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var existingUser = await _dbsContext.MissionTheme.FirstOrDefaultAsync(x => x.Id == missionId);
                        if (existingUser == null)
                        {
                            return "MissionTheme details do not found !!!";
                        }
                        else
                        {
                            //main update code

                            existingUser.Id = change3.Id;
                            existingUser.ThemeName = change3.ThemeName;
                            existingUser.Status = change3.Status;


                            await _dbsContext.SaveChangesAsync();
                            await transaction.CommitAsync();
                            return "MissionTheme details updated successfully";
                        }
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        return "Failed to update missiontheme details";
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        Task<List<MissionThemeModel>> IMissionTheme.GetAllThemeDetails()
        {
            throw new NotImplementedException();
        }

        Task<string> IMissionTheme.CreateMissionTheme(MissionTheme model)
        {
            throw new NotImplementedException();
        }

        Task<MissionThemeModel> IMissionTheme.GetMissionThemeDetailsById(int missionId)
        {
            throw new NotImplementedException();
        }

        Task<string> IMissionTheme.DeleteMissionTheme(int id)
        {
            throw new NotImplementedException();
        }

        Task<string> IMissionTheme.UpdateMissionThemedata(int missionId, Entities.MissionTheme change3)
        {
            throw new NotImplementedException();
        }
    }
}
