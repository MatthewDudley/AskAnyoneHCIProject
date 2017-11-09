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
            Label label = new Label();
            label.Text = question;
            label.TextColor = Color.Black;
            DisplayPageStack.Children.Add(label);
        }
    }
}