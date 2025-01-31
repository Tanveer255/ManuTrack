namespace JwtAuthentication.Interface
{
    public  interface IJwtAuthenticationService
    {

        public string GenerateJwtToken(string username);
    }
}
