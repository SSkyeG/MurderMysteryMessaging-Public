namespace MurderMysteryMessages
{
    public class SimplePeople
    {
        public string Name { get; set; } = "";
        public bool IsSelected { get; set; } = false;

        public SimplePeople(string n, bool sel)
        {
            Name = n;
            IsSelected = sel;
        }
    }
}