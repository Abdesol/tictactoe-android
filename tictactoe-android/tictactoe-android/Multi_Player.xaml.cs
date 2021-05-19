using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tictactoe_android
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Multi_Player : ContentPage
    {
        private List<List<int>> all_btn_position = new List<List<int>>();
        private List<List<Button>> all_btn_object = new List<List<Button>>();
        public Multi_Player()
        {
            InitializeComponent();

            var btn_first_row = new List<Button>();
            btn_first_row.Add(multi_1_1);
            btn_first_row.Add(multi_1_2);
            btn_first_row.Add(multi_1_3);

            var btn_second_row = new List<Button>();
            btn_second_row.Add(multi_2_1);
            btn_second_row.Add(multi_2_2);
            btn_second_row.Add(multi_2_3);

            var btn_third_row = new List<Button>();
            btn_third_row.Add(multi_3_1);
            btn_third_row.Add(multi_3_2);
            btn_third_row.Add(multi_3_3);

            all_btn_object.Add(btn_first_row);
            all_btn_object.Add(btn_second_row);
            all_btn_object.Add(btn_third_row);


            all_btn_position.Add(new List<int> { 2, 2, 2 });
            all_btn_position.Add(new List<int> { 2, 2, 2 });
            all_btn_position.Add(new List<int> { 2, 2, 2 });
        }

        public void Back_Multi_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new MainPage();
            Console.WriteLine("Back Clicked");

        }

        public bool Who_Won()
        {
            var pos_1 = new List<int>();
            foreach (List<int> i in all_btn_position)
            {
                pos_1.Add(i[0]);
            }

            var pos_2 = new List<int>();
            foreach (List<int> i in all_btn_position)
            {
                pos_2.Add(i[1]);
            }

            var pos_3 = new List<int>();
            foreach (List<int> i in all_btn_position)
            {
                pos_3.Add(i[2]);
            }

            List<int> pos_4 = all_btn_position[0];
            List<int> pos_5 = all_btn_position[1];
            List<int> pos_6 = all_btn_position[2];
            List<int> pos_7 = new List<int>();
            List<int> pos_8 = new List<int>();

            int i_ = 0;
            int j_ = 2;
            foreach (List<int> i in all_btn_position)
            {
                pos_7.Add(i[i_]);
                pos_8.Add(i[j_]);
                i_++;
                j_--;
            }

            var all_pos = new List<List<int>>();
            all_pos.Add(pos_1);
            all_pos.Add(pos_2);
            all_pos.Add(pos_3);
            all_pos.Add(pos_4);
            all_pos.Add(pos_5);
            all_pos.Add(pos_6);
            all_pos.Add(pos_7);
            all_pos.Add(pos_8);

            bool haswon = false;
            foreach (var p in all_pos)
            {
                int init = p[0];
                if (init != 2)
                {
                    var init_lst = new List<int>();
                    foreach (var i in p)
                    {
                        if (i == init)
                        {
                            init_lst.Add(i);
                        }
                    }
                    if (init_lst.Count == 3)
                    {
                        haswon = true;
                        break;
                    }
                }
            }

            return haswon;
        }

        private int turn = 0;
        private bool game_end = false;

        public void Multi_Each_Btn_Clicked(object sender, EventArgs args)
        {
            if (game_end != true)
            {
                var current_btn = sender as Button;

                var column_stack = (StackLayout)current_btn.Parent;
                int i_column = 0;
                foreach (var btn in column_stack.Children)
                {
                    if (btn.Id == current_btn.Id) { break; }
                    i_column++;
                }

                var row_stack = (StackLayout)column_stack.Parent;
                int i_row = 0;

                foreach (var stack in row_stack.Children)
                {
                    if (stack.Id == column_stack.Id) { break; }
                    i_row++;
                }

                if (all_btn_position[i_row][i_column] == 2)
                {
                    all_btn_position[i_row][i_column] = turn;

                    current_btn.BackgroundColor = Color.Transparent;
                    current_btn.FontSize = 30;
                    string current_str = "";
                    if (turn == 0)
                    {
                        current_btn.Text = "X";
                        turn = 1;
                        current_str = "O turn";
                    }
                    else
                    {
                        current_btn.Text = "O";
                        turn = 0;
                        current_str = "X turn";
                    }
                    bool who_won = Who_Won();
                    if (who_won == true)
                    {
                        display_multi_game_status.Text = "You Won!";
                        game_end = true;
                        if (turn == 1) { current_str = "X Won!"; } else { current_str = "O Won!"; }
                    }
                    display_multi_game_status.Text = current_str;
                }
            }
        }

        public void Multi_Reset_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new Multi_Player();
            
        }


    }
}