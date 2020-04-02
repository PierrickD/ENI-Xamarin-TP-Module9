using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ENI_Xamarin_TP_Module9.Services;

namespace ENI_Xamarin_TP_Module9.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TweetsPage : ContentPage
    {
        public TweetsPage()
        {
            InitializeComponent();
            this.listView.ItemsSource = new TwitterServiceImpl().Tweets;
        }
    }
}