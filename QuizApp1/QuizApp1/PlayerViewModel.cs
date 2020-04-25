using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Xamarin.Forms;

namespace QuizApp1
{
    public class PlayerViewModel : INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;
        public static int age;
        public static int Age { get; set; }

        public static string name;
        public string Name { get { return name; } set { if (name != value) { name = ProcessName(value); OnPropertyChanged(Name); } } }
             
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ProcessName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return name;

                if (name.Length > 20)
                    name = name.Substring(0, 20);

                string pattern = "[^-A-Za-z.' ]";

                if (Regex.IsMatch(name, pattern))
                    name = name.Remove(name.Length - 1, 1);

                return name;
            }
            catch (Exception e)
            {
                name = e.ToString();
                return name;
            }
        }     

        public PlayerViewModel(string name, int age)
        {
            Name = name;
            Age = age;           
        }      

        public static IList<PlayerViewModel> Player { private set; get; }
    }
}
