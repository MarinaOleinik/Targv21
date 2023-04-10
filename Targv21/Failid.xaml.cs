using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Targv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Failid : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public Failid()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateFileList();
        }
        private void UpdateFileList()
        {
            filesList.ItemsSource = Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f));
            filesList.SelectedItem = null;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            string fileName = fileNameEntry.Text;
            if (String.IsNullOrEmpty(fileName)) return;
            if (File.Exists(Path.Combine(folderPath,fileName)))
            {
                bool isRewrited = await DisplayAlert("Kinnitus", "Fail on juba olemas, kas salvestame ümber?", "Jah", "Ei");
                if (isRewrited == false) return;
            }
            File.WriteAllText(Path.Combine(folderPath,fileName),textEditor.Text);
            UpdateFileList();
        }

        private void filesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            string filename = (string)e.SelectedItem;
            textEditor.Text = File.ReadAllText(Path.Combine(folderPath, filename));
            fileNameEntry.Text = filename;
            filesList.SelectedItem = null;
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            string filename = (string)((MenuItem)sender).BindingContext;
            File.Delete(Path.Combine(folderPath, filename));
            UpdateFileList();
        }
    }
}