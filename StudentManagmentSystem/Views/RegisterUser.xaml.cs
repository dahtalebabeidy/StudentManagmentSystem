using StudentManagmentSystem.Views.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinFirebaseApp;

namespace StudentManagmentSystem.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterUser : ContentPage
	{
        UserRepository _userRepository = new UserRepository();
        public RegisterUser ()
		{
			InitializeComponent ();
            bool hasKey = Preferences.ContainsKey("token");
            if (hasKey)
            {
                string token = Preferences.Get("token", "");
                if (!string.IsNullOrEmpty(token))
                {
                    Navigation.PushAsync(new StudentListPage());
                }
            }

        }

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            try
            {
                string name = TxtName.Text;
                string email = TxtEmail.Text;
                string password = TxtPassword.Text;
                string confirmPassword = TxtConfirmPass.Text;
                if (String.IsNullOrEmpty(name))
                {
                    await DisplayAlert("Attention", "enterer un nom valid", "Annuler");
                    return;
                }
                if (String.IsNullOrEmpty(email))
                {
                    await DisplayAlert("Attention", "enterer un adress e-mail valid", "Annuler");
                    return;
                }
                if (password.Length < 6)
                {
                    await DisplayAlert("Attention", "Le mot de passe doit comporter au moins 6 chiffres.", "Ok");
                    return;
                }
                if (String.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Attention", "enterer un mot de passe valid", "Annuler");
                    return;
                }
                if (String.IsNullOrEmpty(confirmPassword))
                {
                    await DisplayAlert("Attention", "Confirmer votre mot de passe", "Ok");
                    return;
                }
                if (password != confirmPassword)
                {
                    await DisplayAlert("Attention", "Les deux mots de passe doivent correspondre", "Ok");
                    return;
                }

                bool isSave = await _userRepository.Register(email, name, password);
                if (isSave)
                {
                    await DisplayAlert("Information", "Inscription terminée avec succès", "Ok");
                    await Navigation.PopModalAsync();
                }
                else
                {
                    await DisplayAlert("Erreur", "L'inscription a échoué", "Ok");
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("EMAIL_EXISTS"))
                {
                    await DisplayAlert("Attention", "Cet email existe", "Ok");
                }
                else
                {
                    await DisplayAlert("Erreur", exception.Message, "Ok");
                }

            }

        }

    }
}