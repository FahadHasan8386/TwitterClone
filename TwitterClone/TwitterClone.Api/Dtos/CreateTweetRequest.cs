namespace TwitterClone.Api.Dtos
{
    public class CreateTweetRequest
    {
        public required Guid UserId { get; set; }
        public required string Content { get; set; }
    }
}
