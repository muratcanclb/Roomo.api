namespace roomo.api.Domain.Dto
{
    public class RoomListDto
    {
        public Guid id { get; set; }
        public decimal price { get; set; }
        public int number_of_beds { get; set; }
        public int number_of_people { get; set; }
        public int status_id { get; set; }
        public int cleaning_status_id { get; set; }
        public int room_no { get; set; }
        public string status_name { get; set; }
        public string cleaning_status_name { get; set; }
    }
}
