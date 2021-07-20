namespace BackEndChallengeDotNet.Domain.ObjectValues
{
    public class Name
    {
        public Name(string title, string first, string last)
        {
            Title = title;
            First = first;
            Last = last;
        }

        public string Title { get; private set; }
        public string First { get; private set; }
        public string Last { get; private set; }
    }
}
