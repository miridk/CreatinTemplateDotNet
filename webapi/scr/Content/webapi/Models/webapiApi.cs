using System.ComponentModel.DataAnnotations;

namespace webapiApiService.Models
{
    public class webapiApi
    {
        [Key]
        [Required]
        public int Id { get; set; }
        //x
        [Required]
        public string FirstName { get; set; }
        //x
        [Required]
        public string LastName { get; set; }
    } 
}