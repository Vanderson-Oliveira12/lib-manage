
using System.ComponentModel.DataAnnotations;

namespace LibManage.DTOs
{
    public class CreateBookDTO
    {

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Quantity { get; set; } = 0;
    }
}
