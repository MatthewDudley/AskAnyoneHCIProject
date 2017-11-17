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

            InsertNewQuestion("Are waffles better than pancakes?");
            InsertNewQuestion("Is pluto a planet ?", "No, pluto is not a planet");
        }

        public void AnswerFirstQuestion(string answer)
        {
            Button questionButton = (Button)MyQuestions.Children[0];
            AnswerQuestion(questionButton, answer);
        }

        void AnswerQuestion(Button question, string answer)
        {
            RemoveAnswer(question);
            SetUpQuestion(question, question.Text, answer);
            question.Image = "exc.png";
        }

        public void StartAnswerTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(answerDelay), () =>
            {
                AnswerFirstQuestion("The ask anyone group!");
                return false;
            });
        }

        public void InsertNewQuestion(string questionText, string answerText = "-")
        {
            MyQuestions.Children.Insert(0, CreateQuestionAnswerButton(questionText, answerText));
        }
        public void InsertNewAnswer(string questionText, string answerText = "-")
        {
            MyAnswersList.Children.Insert(0, CreateQuestionAnswerButton(questionText, answerText));
        }

        Button CreateQuestionAnswerButton(string questionText, string answerText)
        {
            Button newQuestion = new Button
            {
                BackgroundColor = Color.Transparent,
                MinimumHeightRequest = 75,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            SetUpQuestion(newQuestion, questionText, answerText);
            newQuestion.Clicked += Handle_ViewQuestionClicked;
            newQuestion.Image = "hollowCircle.png";
            return newQuestion;
        }

        void SetUpQuestion(Button button, string question, string answer)
        {
            button.Text = question + "\n" + answer;
        }

        void RemoveAnswer(Button button)
        {
            int x = button.Text.IndexOf('\n');
            if (x > 0)
            {
                button.Text = button.Text.Substring(0, x);
            }
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
                button.Image = "hollowCircle.png";

            }
            catch (Exception ex)
            {
                //display error if caught
                DisplayAlert("Exception on Question Button:", ex.Message, "Ok", "Cancel");
            }
        }
    }
}