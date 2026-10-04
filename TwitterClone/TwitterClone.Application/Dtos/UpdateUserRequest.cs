namespace TwitterClone.Application.Dtos
{
    public class UpdateUserRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }
}
