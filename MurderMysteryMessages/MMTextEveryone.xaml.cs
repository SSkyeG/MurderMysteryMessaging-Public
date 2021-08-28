using System;
using System.Collections.Generic;
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
    /// Interaction logic for MMTextEveryone.xaml
    /// </summary>
    public partial class MMTextEveryone : Window
    {
        private List<Party> allParties = new List<Party>();
        private List<SimplePeople> simplePeople = new List<SimplePeople>();
        public MMTextEveryone(List<Party> peeps)
        {
            InitializeComponent();
            allParties = peeps;

            foreach (Party party in allParties)
            {
                foreach (Person person in party.People)
                {
                    SimplePeople sp = new SimplePeople(person.Name, person.IsSelected);
                    simplePeople.Add(sp);
                }
            }

            SelectedData.ItemsSource = simplePeople;

            textMessage.AcceptsReturn = true;
        }
        /// <summary>
        /// Send text to number with message
        /// </summary>
        /// <param name="phoneNumber">number to text</param>
        /// <param name="messageBody">message to send</param>
        private void SendTextMessage(string phoneNumber, string messageBody)
        {
            var accountSid = ""; //twilio code
            var authToken = ""; //token from twilio
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber(phoneNumber));
            messageOptions.MessagingServiceSid = "";//some service number
            messageOptions.Body = messageBody;

            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
        }
        #region Buttons
        /// <summary>
        ///  go back to main window
        ///  open main window and close this one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        /// <summary>
        /// send experimental text to myself to make sure the text looks good
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MeButton_Click(object sender, RoutedEventArgs e)
        {
            SendTextMessage("+1505", textMessage.Text);//your nurmber
        }
        /// <summary>
        /// clear the text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textMessage.Text = "";
        }
        /// <summary>
        /// Send text to everyone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EveryoneButton_Click(object sender, RoutedEventArgs e)
        {
            int numFailed=0;

            if (MessageBox.Show("Are you sure you want to text everyone?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (Party party in allParties)
                {
                    foreach (Person person in party.People)
                    {
                        if (person.PhoneNum != "")
                        {
                            try
                            {
                                SendTextMessage("+1" + person.PhoneNum, textMessage.Text);
                            }
                            catch
                            {
                                Console.WriteLine("Text to " + person.Name + " failed");
                                numFailed++;
                            }
                        }
                    }
                }
                MessageBox.Show("Texts Sent\nNumber Failed: " + numFailed);
            }
        }
        /// <summary>
        /// Select all people
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (Party party in allParties)
            {
                foreach (Person person in party.People)
                {
                    person.IsSelected = true;
                }
            }
        }
        /// <summary>
        /// Send to the selected people
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendSelected_Click(object sender, RoutedEventArgs e)
        {
            int numFailed = 0;
            if (MessageBox.Show("Are you sure you want to text everyone selected?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //update selection data
                foreach (Party party in allParties)
                {
                    foreach (Person person in party.People)
                    {
                        foreach (SimplePeople sp in simplePeople)
                        {
                            if (sp.Name == person.Name)
                            {
                                person.IsSelected = sp.IsSelected;
                            }
                        }
                    }
                }

                foreach (Party party in allParties)
                {
                    foreach (Person person in party.People)
                    {
                        if (person.IsSelected)
                        {
                            if (person.PhoneNum != "")
                            {
                                try
                                {
                                    SendTextMessage("+1" + person.PhoneNum, textMessage.Text);
                                }
                                catch
                                {
                                    Console.WriteLine("Text to " + person.Name + " failed");
                                    numFailed++;
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Texts Sent\nNumber Failed: " + numFailed);
            }
        }
        /// <summary>
        /// Update the selection data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update_Click(object sender, RoutedEventArgs e)
        {
            foreach (Party party in allParties)
            {
                foreach (Person person in party.People)
                {
                    foreach (SimplePeople sp in simplePeople)
                    {
                        if (sp.Name == person.Name)
                        {
                            person.IsSelected = sp.IsSelected;
                        }
                    }
                }
            }
            MessageBox.Show("Data Updated");
        }
        #endregion Buttons
    }
}
