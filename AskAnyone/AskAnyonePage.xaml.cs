using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AskAnyone
{
    public partial class AskAnyonePage : TabbedPage
    {

        public AskAnyonePage()
        {
            InitializeComponent();

            DefaultQuestion.Text = "Is pluto a planet?\nNo, pluto is not a planet.";
            DefaultQuestion.Image = "icecream.png";
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
                DisplayAlert("Exception", ex.Message, "Ok", "Cancel");
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
                DisplayAlert("Exception", ex.Message, "Ok", "Cancel");
            }
        }
    }
}