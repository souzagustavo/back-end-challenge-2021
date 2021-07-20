namespace BackEndChallengeDotNet.Domain.ObjectValues
{
    public class Coordinates
    {
        public Coordinates(string latitude, string longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Latitude { get; private set; }
        public string Longitude { get; private set; }
    }
}
