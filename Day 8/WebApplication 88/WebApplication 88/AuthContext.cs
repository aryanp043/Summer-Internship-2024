using Authentication.Entities;
using Authentication.Model;
using Microsoft.EntityFrameworkCore;
using WebApplication_88.Entities;
using WebApplication_88.Repository;
using MissionSkill = WebApplication_88.Entities.MissionSkill;

namespace Authentication
{
    public class AuthContext : DbContext
    {

        public AuthContext(DbContextOptions<AuthContext> options): base(options) 
        {
            
        }
        public DbSet<MissionDto> Missions{get;set;}
        public DbSet<User> Users { get; set; }
        public DbSet<MissionSkill> MissionSkill { get; set; }
        public DbSet<WebApplication_88.Entities.MissionTheme> MissionTheme { get; set; }

    }
    
}
