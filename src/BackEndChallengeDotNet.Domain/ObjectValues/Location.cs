namespace BackEndChallengeDotNet.Domain.ObjectValues
{
    public class Location
    {
        public Location(Street street, string city, string state, string postcode, Coordinates coordinates, Timezone timezone)
        {
            Street = street;
            City = city;
            State = state;
            Postcode = postcode;
            Coordinates = coordinates;
            Timezone = timezone;
        }

        public Street Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Postcode { get; private set; }
        public Coordinates Coordinates { get; private set; }
        public Timezone Timezone { get; private set; }
    }
}
