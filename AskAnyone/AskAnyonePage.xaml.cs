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
            InsertNewAnswer("Who is the most handsom man in CS?", "Definitely Dalton");
            InsertNewAnswer("Was the moonlanding a hoax?");
            ChangeFirstAnswerImage();
        }

        void ChangeFirstAnswerImage()
        {
            Button button = (Button)MyAnswersList.Children[0];
            button.Image = "ques.png";
        }

        public void AnswerFirstQuestion(string answer)
        {
            Button questionButton = (Button)MyQuestions.Children[0];
            AnswerQuestion(questionButton, answer);
            questionButton.Image = "exc.png";
        }
        public void AnswerFirstAnswer(string answer)
        {
            Button answerButton = (Button)MyAnswersList.Children[0];
            AnswerQuestion(answerButton, answer);
            answerButton.Clicked -= Handle_ViewAnswerClicked;
            answerButton.Clicked += Handle_ViewQuestionClicked;
        }

        void AnswerQuestion(Button question, string answer)
        {
            RemoveAnswer(question);
            SetUpQuestion(question, question.Text, answer);
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
            Button button = CreateQuestionAnswerButton(questionText, answerText);
            button.Clicked += Handle_ViewQuestionClicked;
            MyQuestions.Children.Insert(0, button);
        }
        public void InsertNewAnswer(string questionText, string answerText = "-")
        {
            Button button = CreateQuestionAnswerButton(questionText, answerText);
            if (answerText == "-")
            {
                button.Clicked += Handle_ViewAnswerClicked;
            }
            else
            {
                button.Clicked += Handle_ViewQuestionClicked;
            }
            MyAnswersList.Children.Insert(0, button);
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
                DisplayAlert("Exception on Answer Button:", ex.Message, "Ok", "Cancel");
            }
        }

        void Handle_ViewAnswerClicked(object sender, System.EventArgs e)
        {
            try
            {
                //get the button that was pressed
                Button button = sender as Button;
                //get the text from that button (Question)
                String question = button.Text;
                //create a new DisplayPage displayPage
                AnswerDisplayPage displayPage = new AnswerDisplayPage();
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