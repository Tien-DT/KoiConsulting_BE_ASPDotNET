namespace SWP.KoiConsulting.API.RequestModel
{
    public class PostRequestModel
    {
        public string? Title { get; set; }
        public string? Detail { get; set; }
        public int ElementId { get; set; }
        public int UserId { get; set; }
        public int KoiId { get; set; }
    }
}
