namespace BackEndChallengeDotNet.Domain.ObjectValues
{
    public class Login
    {
        public Login(string uuid, string username, string password, string salt, string md5, string sha1, string sha256)
        {
            Uuid = uuid;
            Username = username;
            Password = password;
            Salt = salt;
            Md5 = md5;
            Sha1 = sha1;
            Sha256 = sha256;
        }

        public string Uuid { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public string Md5 { get; private set; }
        public string Sha1 { get; private set; }
        public string Sha256 { get; private set; }
    }
}
