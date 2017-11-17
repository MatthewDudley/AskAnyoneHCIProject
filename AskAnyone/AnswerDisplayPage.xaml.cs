using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AskAnyone
{
	public partial class AnswerDisplayPage : ContentPage
	{
		public AnswerDisplayPage ()
		{
			InitializeComponent ();
		}

        public void DisplayQuestion(String question)
        {
            QuestionLabel.Text = GetQuestion(question);
        }

        private String GetQuestion(String buttonText)
        {

            int x = buttonText.IndexOf('\n');
            if (x > 0)
            {
                return buttonText.Substring(0, x);
            }
            return buttonText;
        }

        private String GetAnswer(String buttonText)
        {
            int x = buttonText.IndexOf('\n');
            if (x > 0)
            {
                return buttonText.Substring(x + 1, buttonText.Length - (x + 1));
            }
            return null;
        }

        void Handle_AnswerClicked(object sender, System.EventArgs e)
        {
            String answer = AskFeild.Text;
            if (answer == null)
            {
                DisplayAlert("Alert", "You must answer the question!", "Ok");
            }
            else
            {
                try
                {
                    //return page
                    AskAnyonePage basePage = (AskAnyonePage)Navigation.NavigationStack[0];
                    basePage.AnswerFirstAnswer(answer);
                    Navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    DisplayAlert("Exception", ex.Message, "Ok", "Cancel");
                }
            }
        }
    }


}