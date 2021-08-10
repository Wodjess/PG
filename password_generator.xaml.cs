using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Passwordgenerator_LITE
{
    public partial class password_generator : Page
    {
        byte one = 1;
        string generation;
        string reversgeneration;
        string word;
        string reverseword;
        int trash;
        int word_ID;
        string result;
        int generation_ID;
        public password_generator()
        {
            InitializeComponent();
        }
        void Exit_app(object sender, RoutedEventArgs s)
        {
            Application.Current.Shutdown();
                
        }
        void Ready(object sender, RoutedEventArgs s)
        {

            try
            {
                generation = password.Text;
                reversgeneration = ReverseString(generation);
                word = SecretWord.SecretWord1;
                reverseword = ReverseString(word);
                word_ID = reverseword.Length;
                generation_ID = generation.Length;
                if ((generation.Length % 4) == 0)
                {
                    trash = 4;
                }
                else
                {
                    if ((generation.Length % 3) == 0)
                    {
                        trash = 3;
                    }
                    else
                    {
                        if ((generation.Length % 2) == 0)
                        {
                            trash = 2;
                        }
                        else
                        {
                            trash = 1;
                        }
                        
                    }
                    
                }

                if (trash == 4)
                {
                    result = EncodingText(word) + EncodingTextfinal(reversgeneration) + word_ID + EncodingText(generation) + generation_ID + EncodingTextfinal(Convert.ToString(word_ID)); 
                }
                if (trash == 3)
                {
                    result = EncodingTextfinal(Convert.ToString(word_ID)) + EncodingText(word) + EncodingText(generation) + EncodingTextfinal(reversgeneration) + word_ID;
                }
                if (trash == 2)
                {
                    result = EncodingText(reversgeneration) + EncodingText(Convert.ToString(generation_ID)) + word_ID + EncodingTextfinal(reversgeneration) + EncodingTextfinal(Convert.ToString(word_ID));
                }
                if (trash == 1)
                {
                    result = EncodingTextfinal(reversgeneration) + EncodingTextfinal(word) + EncodingText(reverseword) + EncodingTextfinal(Convert.ToString(word_ID)) + EncodingText(reversgeneration);
                }

                
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка!");
                result = "Произошла ошибка!";
                one = 1;
            }
            password.Text = result;
        }
        void enter(object sender, RoutedEventArgs s)
        {
            if (one == 1)
            {
                password.Text = "";
                one = 0;
            }
        }
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public string EncodingText(string TEXT)
        {
            string simpleText = TEXT;
            var simpleTextBytes = Encoding.UTF8.GetBytes(simpleText);
            string enText = Convert.ToBase64String(simpleTextBytes);
            string x = enText;
            int x1 = x.Length - 2;
            x = x.Remove(x1);
            return x;
        }
        public string EncodingTextfinal(string TEXT)
        {
            string s = ReverseString(TEXT);
            string simpleText = s;
            var simpleTextBytes = Encoding.UTF8.GetBytes(simpleText);
            string enText = Convert.ToBase64String(simpleTextBytes);
            string x = enText;
            int x1 = x.Length - (x.Length - 2);
            x = x.Remove(x1);
            return x;
        }
    }
}
