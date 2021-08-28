namespace MurderMysteryMessages
{
    public class Person
    {
        public string Name { get; set; } = "";
        public string PartyName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNum { get; set; } = "";
        public string CharacterAssignment { get; set; } = "";
        public bool CharacterAssignemtsSent { get; set; } = false;
        public bool IsSelected { get; set; } = false;
    }
}