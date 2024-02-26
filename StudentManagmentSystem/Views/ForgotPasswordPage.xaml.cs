using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebaseApp;

namespace StudentManagmentSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        UserRepository _userRepository = new UserRepository();
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private async void ButtonSendLink_Clicked(object sender, EventArgs e)
        {
            string email = TxtEmail.Text;
            if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Attention", "Enterer votre adresse e-mail", "Ok");
                return;
            }

            bool isSend = await _userRepository.ResetPassword(email);
            if (isSend)
            {
                await DisplayAlert("réinitialiser le mot de passe", "vous avez reçu un email pour réinitialiser votre mot de passe", "Ok");
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Erreur", "L'envoi du lien a échoué.", "Ok");
            }
        }
    }
}