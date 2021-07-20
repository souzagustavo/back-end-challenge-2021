namespace BackEndChallengeDotNet.Domain.ObjectValues
{
    public class Id
    {
        public Id(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public string Value { get; private set; }
    }
}
