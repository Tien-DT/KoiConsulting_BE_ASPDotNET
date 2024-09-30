namespace SWP.KoiConsulting.API.RequestModel
{
    public class UserRequestModel
    {
        public string? FullName { get; set; }

        public string? Email { get; set; }

        public int? Yob { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        public bool? Gender { get; set; }
    }
}
