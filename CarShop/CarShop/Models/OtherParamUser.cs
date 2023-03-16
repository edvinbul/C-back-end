using System.ComponentModel.DataAnnotations;

namespace CarShop.Models
{
    public class OtherParamUser : ParamUser
    {
        public string UserName { get; set; }
        public bool SeniorManager { get; set; } = false;

        [Required]

        public enumProfession Profession { get; set; } 
    }
}
