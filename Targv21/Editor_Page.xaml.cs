﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Targv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editor_Page : ContentPage
    {
        Editor editor;
        Button tagasi_btn;
        Label lbl;
        public Editor_Page()
        {
            editor = new Editor
            {
                TextColor=Color.White,
                Placeholder="Sisesta siia tekst",
                BackgroundColor=Color.Gray
            };
            editor.TextChanged += Editor_TextChanged;
            lbl = new Label
            {
                Text="...",
                TextColor=Color.Gray,
                BackgroundColor=Color.White
            };

            tagasi_btn = new Button { Text = "Tagasi" };
            tagasi_btn.Clicked += Tagasi_btn_Clicked;
            StackLayout stack= new StackLayout 
            { 
                Children = {editor,lbl,tagasi_btn} 
            };
            stack.BackgroundColor = Color.Gold;
            Content= stack;
        }
        int i = 0;
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lbl.Text=editor.Text;
            //editor.TextChanged -= Editor_TextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';

            if (key == 'A' || key=='a')
            {
                i++;
                lbl.Text = key.ToString() + ": " + i;
            }
            //editor.TextChanged += Editor_TextChanged;
        }

        private async void Tagasi_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}