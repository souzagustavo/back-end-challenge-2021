namespace BackEndChallengeDotNet.Domain.ObjectValues
{
    public class Timezone
    {
        public Timezone(string offset, string description)
        {
            Offset = offset;
            Description = description;
        }

        public string Offset { get; private set; }
        public string Description { get; private set; }
    }
}
