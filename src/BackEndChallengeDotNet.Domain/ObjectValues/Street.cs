namespace BackEndChallengeDotNet.Domain.ObjectValues
{
    public class Street
    {
        public Street(string number, string name)
        {
            Number = number;
            Name = name;
        }

        public string Number { get; private set; }
        public string Name { get; private set; }
    }
}
