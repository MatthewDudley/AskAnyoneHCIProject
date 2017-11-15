using System;
using Xamarin.Forms;

namespace AskAnyone
{
    public partial class DisplayPage : ContentPage
    {
        public DisplayPage()
        {
            InitializeComponent();
        }

        public void DisplayQuestion(String question)
        {
            QuestionLabel.Text = GetQuestion(question);
            AnswerLabel.Text = GetAnswer(question);
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
                return buttonText.Substring(x + 1, 20);
            }
            return null;
        }
    }
}