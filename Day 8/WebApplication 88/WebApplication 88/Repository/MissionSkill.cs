using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Authentication;
using WebApplication_88.Entities;
using Authentication.Entities;
using Authentication.Model;

namespace WebApplication_88.Repository
{
    public class MissionSkill : IMissionSkill
    {
        private readonly AuthContext _dbContext;

        public MissionSkill(AuthContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MissionSkillModel>> GetAllSkillsDetails()
        {
            //return MissionSkill.ToListAsync();

            try
            {

                var mission2 = await _dbContext.MissionSkill.Select(mission => new MissionSkillModel
                {
                    Id = mission.Id,
                    SkillName = mission.SkillName,
                    Status = mission.Status
                    
                }).ToListAsync(); 
                

                return mission2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public async Task<string> CreateMissionSkill(Entities.MissionSkill model)
        {
            var mission3 = new Entities.MissionSkill
            {
                Id = model.Id,
                SkillName = model.SkillName,
                Status = model.Status
                
            };

            _dbContext.MissionSkill.Add(mission3);
            await _dbContext.SaveChangesAsync();

            return "MissionSkill data Created Succesfully";
        }

        
        public async Task<MissionSkillModel> GetMissionSkillDetailsById(int missionId)
        {
            var missionW = await _dbContext.MissionSkill
                .Where(mission => mission.Id == missionId)
                .Select(mission => new MissionSkillModel
                {
                    Id = mission.Id,
                    SkillName = mission.SkillName,
                    Status = mission.Status                    

                })
                .FirstOrDefaultAsync();

            return missionW;
        }

        
        public async Task<string> DeleteMissionSkill(int id)
        {
            var mission4 = await _dbContext.MissionSkill.FindAsync(id);
            if (mission4 == null)
            {
                return "MissionSkill data not found";
            }

            _dbContext.MissionSkill.Remove(mission4);
            await _dbContext.SaveChangesAsync();

            return "MissionSkill Deleted Successfully";
        }


        
        public async Task<string> UpdateMissionSkilldata(int missionId, Entities.MissionSkill change3)
        {
            try
            {
                using (var transaction = await _dbContext.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var existingUser = await _dbContext.MissionSkill.FirstOrDefaultAsync(x => x.Id == missionId);
                        if (existingUser == null)
                        {
                            return "MissionSkill details do not found !!!";
                        }
                        else
                        {
                            //main update code

                            existingUser.Id = change3.Id;
                            existingUser.SkillName = change3.SkillName;
                            existingUser.Status = change3.Status;
                            

                            await _dbContext.SaveChangesAsync();
                            await transaction.CommitAsync();
                            return "MissionSkill details updated successfully";
                        }
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        return "Failed to update missionskill details";
                    }

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        Task<List<MissionSkillModel>> IMissionSkill.GetAllSkillsDetails()
        {
            throw new NotImplementedException();
        }

        Task<string> IMissionSkill.CreateMissionSkill(MissionSkill model)
        {
            throw new NotImplementedException();
        }

        Task<MissionSkillModel> IMissionSkill.GetMissionSkillDetailsById(int missionId)
        {
            throw new NotImplementedException();
        }

        Task<string> IMissionSkill.DeleteMissionSkill(int id)
        {
            throw new NotImplementedException();
        }

        Task<string> IMissionSkill.UpdateMissionSkilldata(int missionId, Entities.MissionSkill change3)
        {
            throw new NotImplementedException();
        }
    }
}
