using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizApp1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        IList<Quizy> quizy;

        public IList<PlayerViewModel> playerViewModel;
       
        public Quizy currentQuizy { get; set; }
        public int currentScore { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            //characters = Characters.Play;
            quizy = Quizy.Play;
            playerViewModel = PlayerViewModel.Player;

            if (quizy.Count >= 0)
            {
                int index = 0;
                currentQuizy = quizy.First();
                showQuiz.Text = currentQuizy.Ask;
                
                if (index <= quizy.Count)

                {

                    index = 0;                   

                }
            }
            else
            {
                showQuiz.Text = "Quiz Unavailable";
            }
           
            currentScore = 0;

        }
      
        public void begin_clicked(Object sender, EventArgs args)
        //public async void begin_clicked(Object sender, EventArgs args)
        {

            begin_btn.IsVisible = false;

            if (string.IsNullOrEmpty(Name.Text)) return;
            PlayerViewModel.name = Name.Text;
            
            //else
            //{
            //    await DisplayAlert("Alert", "Please enter a name", "OK");
            //}    
            //else
            //{
            //    await DisplayAlert("Alert", "Please enter age", "OK");
            //}
            showText.Text = $"Player Name is:  { Name.Text}, aged { Age.Text}";

            Name.IsVisible = false;

            Age.IsVisible = false;

            falseBtn.IsVisible = true;

            trueBtn.IsVisible = true;

            begin_quiz.IsVisible = true;

            showQuiz.IsVisible = true;

            YoResults.IsVisible = true;

            trueQ.IsVisible = true;

            falseQ.IsVisible = true;

            party.IsVisible = true;

            quizyChange();

        }

        private void quizyChange()
        {
            //int index;
            int checkQuizCount = quizy.IndexOf(currentQuizy);

            if (checkQuizCount < quizy.Count - 1) 
            {
                currentQuizy = quizy.ElementAt(quizy.IndexOf(currentQuizy) + 1);
                showQuiz.Text = currentQuizy.Ask;
                trueQ.Text = currentQuizy.TrueQ;
                falseQ.Text = currentQuizy.FalseQ;
              
            }
            else
            {
                checkPlayer();
            } 
        }

        private void checkPlayer()
        {           
            //if (PlayerViewModel.name.Length < 3 && PlayerViewModel.age > 10)
            //{               
            //     currentScore += 5;
            //     players.Text = $"Hello {Name.Text}, you represent 'Fandom' character - Luke Skywalker. :)";

            //}
            //else if (PlayerViewModel.name.Length > 3 && PlayerViewModel.age < 20)
            //{
            //    currentScore += 10;
            //    players.Text = $"Hello {Name.Text}, you represent 'Fandom' character - Princess Leia. :)";

            //}
            //else if (PlayerViewModel.name.Length == 5 && PlayerViewModel.age > 20)
            //{
            //    currentScore += 15;
            //    players.Text = $"Hello {Name.Text}, you represent 'Fandom' character - Chewbacca. :)";

            //}
            //else if (PlayerViewModel.name.Length == 6 && PlayerViewModel.age > 20)
            //{
            //    currentScore += 20;
            //    players.Text = $"Hello {Name.Text}, you represent 'Fandom' character - Darth Vader. :)";

            //}
            falseBtn.IsVisible = false;

            trueBtn.IsVisible = false;

            resultbtn.IsVisible = true;

        }

        public void trueButton(object sender, EventArgs args)
        {
            currentScore += currentQuizy.TruePoint;
            quizyChange();
            //YoResults.Text = $"YoResults is: { currentScore}";
            //YoResults.Text = $"Hello {Name.Text}, currently YoResults  is: { currentScore}";
        }        


         public void falseButton(object sender, EventArgs args)
         {
            currentScore += currentQuizy.FalsePoint;
            quizyChange();
            //YoResults.Text = $"YoResults is: { currentScore}";
            //YoResults.Text = $"Hello {Name.Text}, YoResults currently is: { currentScore}";
            //YoResults.Text = $"Hello {Name.Text}, YoResults is: { currentScore}, You're  goofy at {Age.Text}";
         }
        
        public void resultClicked(object sender, EventArgs args)
        {
            YoResults.Text = $"Hello {Name.Text}, YoResults is: { currentScore}";

            if (PlayerViewModel.name.Length < 3 && PlayerViewModel.age > 10)
            {
                currentScore += 5;
                players.Text = $" {Name.Text}, you represent 'Fandom' character - Luke Skywalker. :)";

            }
            else if (PlayerViewModel.name.Length > 3 && PlayerViewModel.age < 20)
            {
                currentScore += 10;
                players.Text = $" {Name.Text}, you represent 'Fandom' character - Princess Leia. :)";

            }
            else if (PlayerViewModel.name.Length == 5 && PlayerViewModel.age > 20)
            {
                currentScore += 15;
                players.Text = $" {Name.Text}, you represent 'Fandom' character - Chewbacca. :)";

            }
            else if (PlayerViewModel.name.Length == 6 && PlayerViewModel.age > 20)
            {
                currentScore += 20;
                players.Text = $" {Name.Text}, you represent 'Fandom' character - Darth Vader. :)";

            }
            resultbtn.IsVisible = false;//just to hide the button to stop accidentally pressing it and changing the score
        }

        public void AgeCompleted(object sender, EventArgs args)
        {
            //PlayerViewModel.age = new PlayerViewModel.Age();
            Age.Completed += AgeCompleted;
            //if (int.TryParse(age.Text, out var Age))
            //PlayerViewModel.age = Age;
        }
        public void NameCompleted(object sender, EventArgs args)
        {
            if (string.IsNullOrEmpty(Name.Text)) return;
            Name.Completed += NameCompleted;
        }       
    }
}
