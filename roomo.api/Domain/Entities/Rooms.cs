using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Room.api.Domain.Entities
{
    public class Rooms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public decimal price { get; set; }
        public int number_of_beds {get; set; }
        public int number_of_people { get; set; }
        public int status_id { get; set; }
        public int cleaning_status_id { get; set; }
        public int room_no { get; set; }
    }
}
