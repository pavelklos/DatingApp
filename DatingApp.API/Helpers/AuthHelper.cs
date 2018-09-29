using RestSharp;

namespace DatingApp.API.Helpers
{
    public class AuthHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // Dispose
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            // Dispose
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }

            return true;
        }

        public static void Postman()
        {
            // RestSharp
            // http://restsharp.org/
            // [DatingApp.API.csproj]
            // <PackageReference Include="RestSharp" Version="106.4.2"

            var client = new RestClient("http://localhost:5000/api/auth/register");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "aa013e43-e9af-4705-9fe8-444c888f2618");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\n\t\"username\" : \"Test 2\",\n\t\"password\" : \"password\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
    }
}