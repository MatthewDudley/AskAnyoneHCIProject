using System;
using Xamarin.Forms;

namespace AskAnyone
{
    public partial class AskNewQuestionPage : ContentPage
    {
        public AskNewQuestionPage()
        {
            InitializeComponent();
        }
        void Ask_Clicked(object sender, System.EventArgs e)
        {
            String question = AskFeild.Text;
            if (question == null)
            {
                DisplayAlert("Alert", "You must enter a question!", "Ok");
            }
            else
            {
                try
                {
                    //return page
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