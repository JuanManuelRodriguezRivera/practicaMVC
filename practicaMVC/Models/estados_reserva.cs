using System.ComponentModel.DataAnnotations;


namespace practicaMVC.Models
{
    public class estados_reserva
    {
        [Key]
        [Display(Name = "Estado Reserva ID")]
        public int? estados_res_id { get; set; }

        [Display(Name = "Estado")]
        public string? estado { get; set; }
    }
}
