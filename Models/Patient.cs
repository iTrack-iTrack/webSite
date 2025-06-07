namespace SmartWatchWeb.Models  
{
    public class Patient
    {
        public string ProfilePictureUrl { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }


        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Sickness { get; set; }
        public string Contact {  get; set; }
    }
}