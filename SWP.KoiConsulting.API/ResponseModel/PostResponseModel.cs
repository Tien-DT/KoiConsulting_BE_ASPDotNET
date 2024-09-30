namespace SWP.KoiConsulting.API.ResponseModel
{
    public class PostResponseModel
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? OrderId { get; set; }

        public string? Title { get; set; }

        public string? Detail { get; set; }

        public DateTime? CreatedTime { get; set; }

        public DateTime? ExpTime { get; set; }

        public int? ElementId { get; set; }

        public int? KoiId { get; set; }

        public int? Status { get; set; }
    }
}