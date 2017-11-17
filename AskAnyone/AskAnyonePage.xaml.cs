using System;
using Xamarin.Forms;

namespace AskAnyone
{
    public partial class AskAnyonePage : TabbedPage
    {

        private double answerDelay = 10;
        public AskAnyonePage()
        {
            InitializeComponent();

            InsertNewQuestion("Smtext\nsmtext");
            InsertNewQuestion("Is pluto a planet ?\nNo, pluto is not a planet");
        }

        void SetUpQuestion(Button button, String text)
        {
            button.Text = text;
            button.Image = "icecream.png";
        }

        public void AnswerFirstQuestion(string answer)
        {
            Button questionButton = (Button)MyQuestions.Children[0];
            questionButton.Text = questionButton.Text + "\n" + answer;
        }

        public void StartAnswerTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(answerDelay), () =>
            {
                AnswerFirstQuestion("The ask anyone group!");
                return false;
            });
        }

        public void InsertNewQuestion(string questionText)
        {
            Button newQuestion= new Button
            {
                BackgroundColor = Color.Transparent,
                MinimumHeightRequest = 75,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            SetUpQuestion(newQuestion, questionText);
            newQuestion.Clicked += Handle_ViewQuestionClicked;
            MyQuestions.Children.Insert(0, newQuestion);
        }

        void Handle_NewQuestionClicked(object sender, System.EventArgs e)
        {
            try
            {
                //push the NewQuestionPage to the front
                Navigation.PushAsync(new AskNewQuestionPage());
            }
            catch (Exception ex)
            {
                //display error if caught
                DisplayAlert("Exception on New Question:", ex.Message, "Ok", "Cancel");
            }
        }

        void Handle_ViewQuestionClicked(object sender, System.EventArgs e)
        {
            try
            {
                //get the button that was pressed
                Button button = sender as Button;
                //get the text from that button (Question)
                String question = button.Text;
                //create a new DisplayPage displayPage
                DisplayPage displayPage = new DisplayPage();
                //pass the Display method the question
                displayPage.DisplayQuestion(question);
                //push the DisplayPage to the front
                Navigation.PushAsync(displayPage);

            }
            catch (Exception ex)
            {
                //display error if caught
                DisplayAlert("Exception on Question Button:", ex.Message, "Ok", "Cancel");
            }
        }
    }
}