using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Targv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUp_Page : ContentPage
    {
        Button alertListButton;
        Dictionary<string, Color> varvid;
        public PopUp_Page()
        {
            varvid = new Dictionary<string, Color>();
            varvid.Add("Sinine", Color.Blue);
            varvid.Add("Must", Color.Black);
            varvid.Add("Valge", Color.White);
            Button alertButton = new Button
            {
                Text = "Teade",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertButton.Clicked += AlertButton_Clicked;
            Button alertYesNoButton = new Button
            {
                Text = "Jah või ei",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertYesNoButton.Clicked += AlertYesNoButton_Clicked;
            alertListButton = new Button
            {
                Text = "Valik",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertListButton.Clicked += AlertListButton_Clicked;
            Button alertQuestButton = new Button
            {
                Text = "Küsimus",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertQuestButton.Clicked += AlertQuestButton_Clicked;
            Content = new StackLayout { Children = { alertButton, alertYesNoButton, alertListButton, alertQuestButton } };
        }
        private void Varvi_muutus(string varv)
        {
            Content.BackgroundColor = varvid[varv];
            //alertListButton.BackgroundColor = varvid[varv];
        }
        private async void AlertListButton_Clicked(object sender, EventArgs e)
        {
            string valik = await DisplayActionSheet("Mis värv sulle meeldib", "Loobu", "Kinni", "Sinine", "Must", "Valge");
            Varvi_muutus(valik);
        }
        private void AlertButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Teade", "Mul on tähtis teade!", "Sulge");
        }
        private async void AlertQuestButton_Clicked(object sender, EventArgs e)
        {

            string rez = await DisplayPromptAsync("Küsimus", "Mis päev täna on?", "Ok", "Cancel", "Siia kirjuta päeva nimetus", keyboard: Keyboard.Chat);
            Varvi_muutus(rez);
            string rez2=await DisplayPromptAsync("Teine küsimus","Millega võrdub 2+2?","Vastan","Ei vasta",initialValue:"10",maxLength:3,keyboard:Keyboard.Numeric);
        }

        private async void AlertYesNoButton_Clicked(object sender, EventArgs e)
        {
            bool vastus=await DisplayAlert("Tee valik -jah- või -ei-", "Kas tuju on hea?", "Jah", "Ei");
            await DisplayAlert("Vastus oli antud", "Sinu valik oli: " + (vastus ? "Jah" : "Ei ole"), "Sulge");
        }
    }
}