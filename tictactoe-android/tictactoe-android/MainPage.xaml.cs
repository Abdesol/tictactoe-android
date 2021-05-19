using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace tictactoe_android
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void single_player_clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new single_player();
            Console.WriteLine("Single Player Clicked");
        }

        public void multi_player_clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new Multi_Player();
            Console.WriteLine("Multi Player Clicked");
        }

        public void Multi_Each_Btn_Clicked(object sender, EventArgs args)
        {

        }
    }
}