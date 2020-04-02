using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ENI_Xamarin_TP_Module9.Models;
using ENI_Xamarin_TP_Module9.Services;
using Xamarin.Essentials;
using ENI_Xamarin_TP_Module9.Entities;


namespace ENI_Xamarin_TP_Module9.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        private ITwitterService twitterService;
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;

            this.btnConnexion.Clicked += BtnConnexion_Clicked;
            this.errorLabel.IsVisible = false;
            this.tweetList.IsVisible = false;
            this.twitterService = new TwitterServiceImpl();
        }

        private void BtnConnexion_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("btn clicked");
            String login = this.identifiant.Text;
            String password = this.motDePasse.Text;
            Boolean isRemind = this.memorise.IsToggled;

            String errors = "";

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                errors = this.twitterService.Authenticate(new User() { Login = login, Password = password });
            }
            else
            {
                errors = "Pas de connection internet disponible";
            }

            if (!String.IsNullOrEmpty(errors))
            {
                this.errorLabel.Text = errors;
                this.errorLabel.IsVisible = true;
            }
            else
            {
                this.errorLabel.Text = "";
                this.errorLabel.IsVisible = false;
                this.connectionForm.IsVisible = false;
                Navigation.PushAsync(new TweetsPage());
            }
        }

async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}