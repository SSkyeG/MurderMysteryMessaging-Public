using System.Collections.Generic;

namespace MurderMysteryMessages
{
    public class Party
    {
        public List<Person> People { get; set; } = new List<Person>();
        public string Name { get; set; } = "";
    }
}