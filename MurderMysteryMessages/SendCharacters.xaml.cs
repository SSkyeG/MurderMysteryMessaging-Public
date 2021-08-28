using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace MurderMysteryMessages
{
    /// <summary>
    /// Interaction logic for SendCharacters.xaml
    /// </summary>
    public partial class SendCharacters : Window
    {
        string SenderEmail = "";//google email
        string SenderPassword = "";//google passward

        private List<Party> allParties = new List<Party>();
        private List<SimplePeople> simplePeople = new List<SimplePeople>();
        private List<Person> allPeople = new List<Person>();
        private AccessPartyInfo partyInfo = new AccessPartyInfo();

        public SendCharacters(List<Party> peps, AccessPartyInfo pInfo)
        {
            InitializeComponent();
            allParties = peps;

            //get all of the peoples data
            foreach (Party party in allParties)
            {
                foreach (Person person in party.People)
                {
                    allPeople.Add(person);
                    SimplePeople sp = new SimplePeople(person.Name, person.IsSelected);
                    simplePeople.Add(sp);
                }
            }

            PeopleData.ItemsSource = allPeople;

            partyInfo = pInfo;
        }

        #region Buttons
        /// <summary>
        /// go back to main window
        /// open main window and close this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //open main window, close this one
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        /// <summary>
        /// set all people to selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (Person person in allPeople)
            {
                person.IsSelected = true;
            }

        }
        /// <summary>
        /// send a attachment test to myself
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendTest_Click(object sender, RoutedEventArgs e)
        {
            string subject = "This is a test";
            string mess = "wow attachment";

            sendEmail("youremail@gmail.com", subject, mess, "Simone Dupain");
        }
        /// <summary>
        /// Send all those selected an email with their characters asignment and 
        /// a text letting them know that they got their assignment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendSelected_Click(object sender, RoutedEventArgs e)
        {
            string partyEmail = "";
            string subject = "";
            string body = "";
            string text = "";

            int numfailed = 0;
            if (MessageBox.Show("Are you sure you are ready to send those who are selected character assignments?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Party party in allParties)
                {
                    foreach (Person person in party.People)
                    {
                        if (person.Email != "")
                        {
                            partyEmail = person.Email;
                        }

                        if (person.IsSelected == true && person.CharacterAssignment != "")
                        {
                            subject = person.Name + "'s Character Assignment";
                            body = "Hello " + person.Name + ",\n\n";
                            int fail = 1;

                            if (person.Email != "")
                            {
                                partyEmail = person.Email;

                                fail = sendEmail(person.Email, subject, body, person.CharacterAssignment);
                                if (fail == -1) { Console.WriteLine(person.Name + " char assignment send failed"); numfailed++; }
                            }
                            else if (partyEmail != "")
                            {
                                fail = sendEmail(partyEmail, subject, body, person.CharacterAssignment);
                                if (fail == -1) { Console.WriteLine(person.Name + " char assignment send failed"); numfailed++; }
                            }

                            if (person.PhoneNum != "" && fail == 0)
                            {
                                //send text letting them know
                                text = ReadTextFile("TextMessage.txt");
                                SendTextMessage(person.PhoneNum, text);
                            }

                            person.CharacterAssignemtsSent = true;
                        }
                    }
                    partyEmail = "";
                }
            }
            updateNow();
        }
        /// <summary>
        /// Send all people an email with their characters asignment and 
        /// a text letting them know that they got their assignment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendToCharAssign_Click(object sender, RoutedEventArgs e)
        {
            string partyEmail = "";
            string subject = "";
            string body = "";
            string text = "";

            int numfailed = 0;

            if (MessageBox.Show("Are you sure you are ready to send eveyones character assignments?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Party party in allParties)
                {
                    foreach (Person person in party.People)
                    {
                        if (person.Email != "")
                        {
                            partyEmail = person.Email;
                        }

                        if (!person.CharacterAssignemtsSent && person.CharacterAssignment != "")
                        {
                            subject = person.Name + "'s Character Assignment";
                            body = "Hello " + person.Name + ",\n\n";
                            int fail = 1;

                            if (person.Email != "")
                            {
                                
                                partyEmail = person.Email;
                                fail = sendEmail(person.Email, subject, body, person.CharacterAssignment);
                                if (fail == -1) { Console.WriteLine(person.Name + " char assignment send failed"); numfailed++; }
                                else { person.CharacterAssignemtsSent = true; }
                            }
                            else if (partyEmail != "")
                            {
                                fail = sendEmail(partyEmail, subject, body, person.CharacterAssignment);
                                if (fail == -1) { Console.WriteLine(person.Name + " char assignment send failed"); numfailed++; }
                                else { person.CharacterAssignemtsSent = true; }
                            }

                            if (person.PhoneNum != "" && person.PhoneNum!= " " && fail==0)
                            {
                                //send text letting them know
                                text = ReadTextFile("TextMessage.txt");
                                SendTextMessage(person.PhoneNum, text);
                            }

                            person.CharacterAssignemtsSent = true;
                        }
                    }
                    partyEmail = "";
                }
            }
            updateNow();
        }
        /// <summary>
        /// unselect all people
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearSelect_Click(object sender, RoutedEventArgs e)
        {
            foreach (Person person in allPeople)
            {
                person.IsSelected = false;
            }
        }
        /// <summary>
        /// call update function to update it the data from grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            updateNow();
        }
        #endregion Buttons

        /// <summary>
        /// send email with player background and image with character assignment
        /// </summary>
        /// <param name="receiverEmail">email address to send to</param>
        /// <param name="subject">subject of email</param>
        /// <param name="body">body of email</param>
        /// <param name="image">name of image to attach</param>
        /// <returns></returns>
        private int sendEmail(string receiverEmail, string subject, string body, string image)
        {

            MailMessage mail = new MailMessage(SenderEmail, receiverEmail);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 465);

            client.Port = 587;
            client.Host = "smtp.gmail.com"; //for gmail host  
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            string realBody = "";

            //mail.IsBodyHtml = true;
            string currDir = Environment.CurrentDirectory;
            string imagesDir = System.IO.Path.GetFullPath(System.IO.Path.Combine(currDir, "..\\..\\..\\images"));

            try
            {
                var attachment = new Attachment(imagesDir + "\\player_background.jpg", MediaTypeNames.Image.Jpeg);
                mail.Attachments.Add(attachment);
            }
            catch { MessageBox.Show("player_background.jpg attachment failed"); }

            if (image == "genZom")
            {
                realBody = body + ReadTextFile("GenZomCharEmail.txt");
                mail.Attachments.Add(new Attachment(imagesDir + @"\genzombie.pdf"));
            }
            else 
            {
                realBody = body + ReadTextFile("NormalCharEmail.txt");
                try
                {

                    var attachment2 = new Attachment(imagesDir +"\\" + image + ".jpg", MediaTypeNames.Image.Jpeg);
                    mail.Attachments.Add(attachment2);
                }
                catch
                {
                    MessageBox.Show(image +".jpg attachment failed");
                    return -1;
                }
            }

            mail.Subject = subject;
            mail.Body = realBody;

            try { client.Send(mail); }
            catch { return -1; }
            
            mail.Dispose();
            client.Dispose();
            MessageBox.Show("sent "+image+" to "+receiverEmail);
            return 0;
        }
        /// <summary>
        /// send text out
        /// </summary>
        /// <param name="phoneNumber">number to text</param>
        /// <param name="messageBody">message to send</param>
        private void SendTextMessage(string phoneNumber, string messageBody)
        {
            var accountSid = "";//get from twilio
            var authToken = "";//get from twilio
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber(phoneNumber));
            messageOptions.MessagingServiceSid = "";//get from twilio
            messageOptions.Body = messageBody;

            try { var message = MessageResource.Create(messageOptions); }
            catch { }
            
        }
        /// <summary>
        /// read text file into a string to later be used as message to email/text
        /// </summary>
        /// <param name="filename">file to read from</param>
        /// <returns>text file as a string</returns>
        private string ReadTextFile(string filename)
        {
            string line = "";
            string message = "";

            StreamReader sr = new StreamReader(filename);

            line = sr.ReadLine();
            message = line;

            while (line!=null)
            {
                line = sr.ReadLine();
                message += "\n" + line;
            }

            sr.Close();
            return message;
        }
        /// <summary>
        /// update master list of any datadrid changes 
        /// write the list to the xml file
        /// </summary>
        private void updateNow()
        {
            List<Party> newMasterList = new List<Party>();
            string currPartyName = "";
            Party newParty = new Party();

            foreach (Person person in allPeople)
            {
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
            }

            newMasterList.Add(newParty);

            allParties = newMasterList;

            partyInfo.setPartyInfo(allParties);

            MessageBox.Show("Info updated");
        }
    }
}
