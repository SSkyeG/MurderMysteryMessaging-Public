using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MurderMysteryMessages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccessPartyInfo partyInfo = new AccessPartyInfo();
        List<Party> allParties = new List<Party>();
        List<Person> allPeople = new List<Person>();
        
        public MainWindow()
        {
            InitializeComponent();
            allParties = partyInfo.getPartyInfo();

            foreach(Party party in allParties)
            {
                foreach (Person person in party.People)
                {
                    person.PartyName = party.Name;
                    allPeople.Add(person);
                }
            }

            PartyGuestsData.ItemsSource = allPeople;
        }

        #region window buttons
        /// <summary>
        /// open send characters window and close this one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bringToAssignChar_Click(object sender, RoutedEventArgs e)
        {
            SendCharacters sc = new SendCharacters(allParties, partyInfo);
            sc.Show();
            this.Close();
        }
        /// <summary>
        /// open email everyone window and close this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bringToEmail_Click(object sender, RoutedEventArgs e)
        {
            MMEmailEveryone mmEE = new MMEmailEveryone(allParties);
            mmEE.Show();
            this.Close();

        }
        /// <summary>
        /// open text everyone window and close this one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bringToText_Click(object sender, RoutedEventArgs e)
        {
            MMTextEveryone mmte = new MMTextEveryone(allParties);
            mmte.Show();
            this.Close();
        }
        #endregion window buttons

        /// <summary>
        /// update changed info on data grid to the xml files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateInfo_Click(object sender, RoutedEventArgs e)
        {
            List<Party> newMasterList = new List<Party>();
            List<string> charDontmatch = new List<string>();
            List<string> wasalreadyassigned = new List<string>();
            string currPartyName = "";
            Party newParty = new Party();
            List<CharFile> fileNames = partyInfo.GetFileNames();

            foreach (Person person in allPeople)
            {
                //get new master list of parties to send to update the file
                if (person.PartyName == currPartyName)
                {
                    newParty.People.Add(person);
                    newParty.Name = person.PartyName;
                }
                else 
                {
                    newMasterList.Add(newParty);
                    newParty = new Party();

                    currPartyName = person.PartyName;

                    newParty.People.Add(person);
                    newParty.Name = person.PartyName;
                }

                //check to see if a file is saved with the characters assignment name
                CharFile charF = new CharFile(person.CharacterAssignment + ".JPG", false);
                bool found = false;

                foreach (CharFile cf in fileNames)
                {
                    if (charF.Name == cf.Name)
                    {
                        found = true;
                        if (cf.alreadyAssigned == true)
                        { wasalreadyassigned.Add("- " + person.Name + "'s assignment " + person.CharacterAssignment); }
                        else
                        { cf.alreadyAssigned = true; }
                        break;
                    }
                }
                
                if (!found)
                {
                    charDontmatch.Add("- " + person.Name + "'s assignment " + person.CharacterAssignment);
                }
                
            }

            newMasterList.Add(newParty);

            allParties = newMasterList;

            partyInfo.setPartyInfo(allParties);


            //print out message box with any conflicting character assignment issues
            //ie if a character was assigned multiple times or if a file doesn't exist int he folder with that charcter name
            string message ="";

            if (charDontmatch.Count == 0 && wasalreadyassigned.Count == 0)
            { MessageBox.Show("Info updated\nNo issues"); }
            else
            {
                if (charDontmatch.Count != 0)
                {
                    string charassnomatch = "";
                    foreach (string c in charDontmatch)
                    {
                        charassnomatch += "\n" + c;
                    }
                    message += "The following character assignments \ndo not have matching pngs:\n" + charassnomatch;
                }
                if (wasalreadyassigned.Count != 0)
                {
                    if (charDontmatch.Count != 0)
                    { message += "\n\n\n"; }
                    string alreadyass = "";
                    foreach (string c in wasalreadyassigned)
                    {
                        alreadyass += "\n" + c;
                    }
                    message += "The following were assigned more than once:\n" + alreadyass;
                }
                MessageBox.Show(message, "Warning these may cause problems:");
            }

            foreach (CharFile cf in fileNames)
            { cf.alreadyAssigned = false; }
        }
    }
}
