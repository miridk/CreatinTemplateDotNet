using System.ComponentModel.DataAnnotations;

namespace webapiApiService.Dtos
{
    public class webapiApiCreateDto
    {
        //x
        [Required]
        public string FirstName { get; set; }
        //x
        [Required]
        public string LastName { get; set; }
    }
}