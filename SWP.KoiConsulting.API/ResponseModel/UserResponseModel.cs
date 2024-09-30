namespace SWP.KoiConsulting.API.ResponseModel
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int? Yob { get; set; }

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        public int? AddressId { get; set; }

        public int? Status { get; set; }

        public bool? Gender { get; set; }

        public int? Role { get; set; }

        public int? ElementId { get; set; }
    }
}
