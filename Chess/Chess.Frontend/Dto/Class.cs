namespace Chess.Frontend.Dto
{
    public class RegisterResponse
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public string userId { get; set; }
    }
}
