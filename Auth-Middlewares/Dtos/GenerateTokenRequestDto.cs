namespace Auth_Middlewares.Dtos
{
    public class GenerateTokenRequestDto
    {
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
