namespace JewelrySalesSystem.Application.GoogleLogin.SignInCallback
{
    public class SignInGoogleCallbackResponse
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }

        public SignInGoogleCallbackResponse(string email, string name, string token)
        {
            Email = email;
            Name = name;
            Token = token;
        }
    }
}
