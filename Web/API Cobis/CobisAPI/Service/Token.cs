namespace CobisAPI.Service
{
    public class Token
    {
        List<string> Tokens;

        public Token()
        {
            this.Tokens = new List<string>()
            {
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyMDAxIiwiaWF0IjoxNzQ5MDAwMDAwfQ.a1B2c3D4e5F6g7H8i9J0K1L2M3N4O5P6Q7R8S9T0",
                "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyMDAyIiwicm9sZSI6ImFkbWluIn0.B8kLmN9pQrS0tUvWxYz1234567890ABCDEFGHIJKLMN",
                "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoidGVzdDAzIiwiZXhwIjoyMDAwMDAwMDAwfQ.ZYXWVUTSRQPONMLKJIHGFEDCBA0987654321abcdef",
                "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoidGVzdDAzIiwiZXhwIjoyMDAwMDAwMDAwfQ.ZYXWVUTSRQPONMLKJIHGFEDCBA0987654321abcdef",
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJuYW1lIjoiSm9obiBEb2UifQ.ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234"
            };
        }

        public string GetToken()
        {
            Random random = new Random();
            // Note: The lower bound is inclusive, upper bound is exclusive
            int rangedInt = random.Next(0, 5);
            return Tokens[rangedInt];
        }

        public bool CheckToken(string token)
        {
            return Tokens.Contains(token);
        }
    }
}
