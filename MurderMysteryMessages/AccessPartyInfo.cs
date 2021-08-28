using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace MurderMysteryMessages
{
    public class AccessPartyInfo
    {
        private string fileName = "PartyInfo.xml";
        private List<Party> masterParties = new List<Party>();
        private List<CharFile> m_filesNames { get; } = new List<CharFile>();

        public AccessPartyInfo()
        {
            getPartyInfo();
        }
        /// <summary>
        /// get all the jpg files in the images folder
        /// </summary>
        /// <returns></returns>
        public List<CharFile>  GetFileNames()
        {
            m_filesNames.Clear(); //reset filenames

            string currDir = Environment.CurrentDirectory;
            string imagesDir = System.IO.Path.GetFullPath(System.IO.Path.Combine(currDir, "..\\..\\..\\images\\"));

            //get a list of all jpg files
            DirectoryInfo di = new DirectoryInfo(imagesDir);
            FileInfo[] files = di.GetFiles("*.JPG");
            foreach (FileInfo file in files)
            { m_filesNames.Add(new CharFile(file.Name, false)); }

            m_filesNames.Add(new CharFile("genZom.JPG", false));

            return m_filesNames;
        }
        /// <summary>
        /// Reads party and peoples info from xml
        /// </summary>
        /// <returns>List of parties and people</returns>
        public List<Party> getPartyInfo()
        {
            XmlTextReader xmlR = new XmlTextReader(fileName);

            xmlR.Read();
            
            masterParties = new List<Party>();
            Party party = new Party();
            bool isFirst = true;

            while (xmlR.Read())
            {
                if (xmlR.IsStartElement())
                {
                    if (xmlR.Name == "Party")
                    {
                        if (!isFirst)
                        {
                            masterParties.Add(party);
                        }
                        isFirst = false;
                        
                        party = new Party();
                        party.Name = xmlR.GetAttribute("Name");
                    }

                    else if (xmlR.Name == "Person")
                    {
                        Person person = new Person();

                        //get person info
                        person.Name = xmlR.GetAttribute("Name");
                        person.PhoneNum = xmlR.GetAttribute("PhoneNum");
                        person.Email = xmlR.GetAttribute("Email");
                        person.CharacterAssignment = xmlR.GetAttribute("CharAssign");
                        string isSent = xmlR.GetAttribute("IsSent");

                        if (isSent == "true" || isSent=="True")
                        { person.CharacterAssignemtsSent = true; }
                        else { person.CharacterAssignemtsSent = false; }
                        
                        party.People.Add(person);
                    }
                }
            }
            masterParties.Add(party);
            xmlR.Close();

            return masterParties;
        }
        /// <summary>
        /// Write all the parties and their people to xml file
        /// </summary>
        /// <param name="parties">list containing the parties we want to write to the xml file</param>
        public void setPartyInfo(List<Party> parties)
        {
            masterParties = parties;

            System.Xml.XmlTextWriter xmlW = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);

            xmlW.Formatting = Formatting.Indented;
            xmlW.WriteStartDocument();
            xmlW.WriteStartElement("root");

            foreach (Party party in parties)
            {
                xmlW.WriteStartElement("Party");
                xmlW.WriteAttributeString("Name", party.Name);

                foreach (Person person in party.People)
                {
                    xmlW.WriteStartElement("Person");
                    xmlW.WriteAttributeString("Name", person.Name);
                    xmlW.WriteAttributeString("PhoneNum", person.PhoneNum);
                    xmlW.WriteAttributeString("Email", person.Email);
                    xmlW.WriteAttributeString("CharAssign", person.CharacterAssignment);
                    xmlW.WriteAttributeString("IsSent", person.CharacterAssignemtsSent.ToString());
                    xmlW.WriteEndElement();
                }

                xmlW.WriteEndElement();
            }


            xmlW.WriteEndElement();
            xmlW.WriteEndDocument();
            xmlW.Flush();
            xmlW.Close();

        }
    }
}
