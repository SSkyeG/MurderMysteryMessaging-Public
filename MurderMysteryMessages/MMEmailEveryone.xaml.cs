using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MurderMysteryMessages
{
    /// <summary>
    /// Interaction logic for MMEmailEveryone.xaml
    /// </summary>
    public partial class MMEmailEveryone : Window
    {
        string SenderEmail = ""; //email using to send (I used a google email and allow less secure things)
        string SenderPassword = ""; //password to google email

        private List<Party> allParties = new List<Party>();
        private List<SimplePeople> simplePeople = new List<SimplePeople>();

        public MMEmailEveryone(List<Party> peeps)
        {
            InitializeComponent();
            emailTextBox.AcceptsReturn = true;

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
        }
        /// <summary>
        /// Send the email with the text boxes as body and subject
        /// </summary>
        /// <param name="receiverEmail">email address you are sending the email to</param>
        /// <param name="subject">subject of email</param>
        /// <param name="body">body of the email</param>
        private void sendEmail(string receiverEmail, string subject, string body)
        {
            MailMessage mail = new MailMessage(SenderEmail, receiverEmail);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 465);

            client.Port = 587;
            client.Host = "smtp.gmail.com"; //for gmail host  
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            mail.Subject = subject;
            mail.Body = body;
            //mail.IsBodyHtml = true;

            client.Send(mail);
            mail.Dispose();
            client.Dispose();

        }
        #region buttons
        /// <summary>
        /// clear textbox and subject textbox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            emailTextBox.Text = "";
            subjectTextBox.Text = "";
        }
        /// <summary>
        /// Send a test of the email to myself 
        /// to get an idea of what the email looks like and if it works
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendMeButton_Click(object sender, RoutedEventArgs e)
        {
            sendEmail("youremail@gmail.com", subjectTextBox.Text, emailTextBox.Text);
        }
        /// <summary>
        /// send the email to everyone on the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendEveryoneButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you ready to send this to everyone?", "Send to Everyone?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                foreach (Party party in allParties)
                {
                    foreach (Person person in party.People)
                    {
                        if (person.Email != "")
                        {
                            sendEmail(person.Email, subjectTextBox.Text, emailTextBox.Text);
                        }
                    }
                }
                MessageBox.Show("Sent");
            }
        }
        /// <summary>
        /// go back to main window. 
        /// open main window and close this one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        /// <summary>
        /// Send email to everyone who is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendSelectedButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you ready to send this to everyone selected?", "Send to Everyone Selected?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
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

                foreach (Party party in allParties)
                {
                    foreach (Person person in party.People)
                    {
                        if (person.IsSelected)
                        {
                            if (person.Email != "")
                            {
                                sendEmail(person.Email, subjectTextBox.Text, emailTextBox.Text);
                            }
                        }
                    }
                }

                MessageBox.Show("Sent to Everyone Selected");
            }
        }
        #endregion buttons
    }
}
