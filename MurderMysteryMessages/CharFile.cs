

namespace MurderMysteryMessages
{
    public class CharFile
    {
        public string Name { get; set; } = "";
        public bool alreadyAssigned { get; set; } = false;

        public CharFile()
        { }
        public CharFile(string n, bool a)
        {
            Name = n;
            alreadyAssigned = a;
        }

        public bool Equals(CharFile n)
        {
            return n.Name == Name;
        }
       
    }
}