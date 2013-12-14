using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace InterviewGeneratorFramework.Classes
{
    [Serializable]
    public class LocalQuestionAnswer : INotifyPropertyChanged
    {
        private int id;
        private string question, answer;

        [XmlElement]
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [XmlElement]
        public string Question
        {
            get
            {
                return question;
            }
            set
            {
                if (question != value)
                {
                    question = value;
                    NotifyPropertyChanged();
                }
            }
        }

        [XmlElement]
        public string Answer
        {
            get
            {
                return answer;
            }
            set
            {
                if (answer != value)
                {
                    answer = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}