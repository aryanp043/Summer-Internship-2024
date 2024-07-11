using System.ComponentModel.DataAnnotations;

namespace WebApplication_88.Entities
{
    public class MissionTheme
    {
        [Key]
        public int Id { get; set; }
        public string ThemeName { get; set; }
        public string Status { get; set; }
    }
}
