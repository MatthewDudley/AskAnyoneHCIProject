using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AskAnyone
{
    public partial class AskAnyonePage : TabbedPage
    {
        List<Button> questions = new List<Button>();
        public AskAnyonePage()
        {
            InitializeComponent();

            SetUpQuestion(DefaultQuestion1, "Is pluto a planet?\nNo, pluto is not a planet");
            questions.Add(DefaultQuestion1);
            SetUpQuestion(DefaultQuestion2, "Smtext\nsmtext");
            questions.Add(DefaultQuestion2);
            questions.Add(HiddenQuestion1);

        }

        void SetUpQuestion(Button button, String text)
        {
            button.Text = text;
            button.Image = "icecream.png";
        }

        void InsertNewQuestion(string questionText)
        {
            for(int i = questions.Count - 1; i > 0; i--)
            {
                SetUpQuestion(questions[i], questions[i - 1].Text);
            }
            SetUpQuestion(questions[0], questionText);
        }

        void Handle_NewQuestionClicked(object sender, System.EventArgs e)
        {
            try
            {
                InsertNewQuestion("test");
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