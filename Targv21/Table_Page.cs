using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Targv21
{
    internal class Table_Page: ContentPage
    {
        TableView table;
        SwitchCell sc;
        ImageCell ic;
        TableSection foto;
        public Table_Page()
        {
            sc = new SwitchCell { Text = "Näita veel" };
            sc.OnChanged += Sc_OnChanged;
            ic = new ImageCell
            {
                ImageSource=ImageSource.FromFile("sipsik.png"),
                Text="Foto nimetus",
                Detail="Kirjeldus"
            };
            foto = new TableSection();

            table = new TableView
            {
                Intent=TableIntent.Form,
                Root=new TableRoot("Andmete sisestamine")
                {
                    new TableSection("Põhiandmed:")
                    {
                        new EntryCell
                        {
                            Label="Nimi:",
                            Placeholder="Sisesta nimi",
                            Keyboard=Keyboard.Default
                        }
                    },
                    new TableSection("Kontaktandmed:")
                    {
                        new EntryCell
                        {
                            Label="Telefon:",
                            Placeholder="Sisesta oma telefon nr",
                            Keyboard=Keyboard.Telephone
                        },
                        new EntryCell
                        {
                            Label="Email:",
                            Placeholder="Sisesta email",
                            Keyboard=Keyboard.Email
                        },
                        sc
                    },
                    foto

                }
            };
            Content= table;
        }

        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                foto.Title = "Foto";
                foto.Add(ic);
                sc.Text = "Peida";

            }
            else 
            {
                foto.Title = "";
                foto.Remove(ic);
                sc.Text = "Näita";
            }
        }
    }
}
