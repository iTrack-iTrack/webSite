public class Patient
{
    public int user_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string password { get; set; }
    public DateTime date_of_birth { get; set; }
    public string country { get; set; }
    public string region { get; set; }
    public string street { get; set; }
    public string house_number { get; set; }
    public string contact { get; set; }
    public string sickness { get; set; }
    public string picture { get; set; }

    // Computed properties (add these!)
    public string Name => $"{first_name} {last_name}";
    public string Address => $"{street} {house_number}, {region}, {country}";
}
