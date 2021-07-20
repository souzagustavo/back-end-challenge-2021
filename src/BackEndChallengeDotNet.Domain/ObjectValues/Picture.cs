namespace BackEndChallengeDotNet.Domain.ObjectValues
{
    public class Picture
    {
        public Picture(string large, string medium, string thumbnail)
        {
            Large = large;
            Medium = medium;
            Thumbnail = thumbnail;
        }

        public string Large { get; private set; }
        public string Medium { get; private set; }
        public string Thumbnail { get; private set; }
    }
}
