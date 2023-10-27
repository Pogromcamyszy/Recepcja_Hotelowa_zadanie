namespace WebApplication2.Models
{
    public class Reception
    {
        public int Id { get; set; }

        public string Employee_name { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }

        public DateTime Start_of_reservation { get; set; }

        public DateTime End_of_reservation { get; set; }

        public string Room { get; set; }    

        public string? Description { get; set; }
    }
}
