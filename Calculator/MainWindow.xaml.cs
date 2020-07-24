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
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;



namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    static class Ext
    {
        public static void Move<T>(this List<T> list, int i, int j)
        {
            var elem = list[i];
            list.RemoveAt(i);
            list.Insert(j, elem);
        }

        public static void Swap<T>(this List<T> list, int i, int j)
        {
            var elem1 = list[i];
            var elem2 = list[j];

            list[i] = elem2;
            list[j] = elem1;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
      
        static async void LogToFileAsync(string message)
        {
            using (StreamWriter file = new StreamWriter("log.log", true))
            {
                 var dateTime = DateTime.Now;
                var msg = $"[{dateTime:G}] INFO : {message}";
                  await file.WriteLineAsync(msg);
            }
        }

        private void bnt_1_Click(object sender, RoutedEventArgs e)
        {
            string expression;                     
            expression = input_expression.Text;
             List<double> vs = new List<double>();
            List<char> action = new List<char>();
            string[] strArr = null;
               int count = 0;
            //заполнение массива со слагаемыми и массива с знаками 
            char[] splitchar = { '+','-','*','/'};
               strArr = expression.Split(splitchar);
           
               for (count = 0; count <= strArr.Length - 1; count++)
               {
                string temp_str;
                temp_str = strArr[count];
                temp_str = temp_str.Trim(new char[] { '(', ')' });
                vs.Add(Convert.ToDouble(temp_str));
                
               }
            string copyexpression = expression;
            char[] arr = expression.ToCharArray();
            foreach(var s in arr)
            {
                if(s=='+'||s=='-'||s=='*'||s=='/')
                {
                    action.Add(s);
                   
                }
            }
            List<char> action_withbracket = new List<char>();
            foreach (var s in arr)
            {
                if (s == '+' || s == '-' || s == '*' || s == '/' || s == '(' || s == ')')
                {
                    action_withbracket.Add(s);

                }
            }


            //////////////скобки
            ///
            /*
            int index_first_bracket=0;
            int index_second_bracket = 0;
            foreach(var s in action_withbracket)
            {
                if(s=='(')
                {
                    index_first_bracket=action_withbracket.IndexOf(s);
                }
            }
            foreach (var s in action_withbracket)
            {
                if (s == ')')
                {
                    index_second_bracket = action_withbracket.IndexOf(s);
                    break;
                }
            }
            bool next = false;
            double result = 0;
            int count_action = action.Count;
            double temp_result = 0;
            double file_result;
            for (int i=index_first_bracket+1;i<index_second_bracket-1;i++)
            {
               
                
                    next = false;
                   
                        if (action_withbracket[i] == '*' || action_withbracket[i] == '/')
                        {
                            /*int index = action.IndexOf(action[i]);
                            vs.Move(index, move_index);
                            vs.Move(index + 1, move_index + 1);
                            action.Move(index, move_index);
                            
                            switch (action[i])
                            {
                                case '*':
                                    result = vs[i] * vs[i + 1];

                                    break;
                                case '/':
                                    result = vs[i] / vs[i + 1];
                                    break;
                            }
                            vs.RemoveAt(i+2);
                            vs.RemoveAt(i+1);
                            vs.Insert(i, result);

                    action_withbracket.RemoveAt(i);

                            next = true;
                        }
            }
            foreach (var s in action_withbracket)
            {
                if (s == '(')
                {
                    index_first_bracket = action_withbracket.IndexOf(s);
                }
            }
            foreach (var s in action_withbracket)
            {
                if (s == ')')
                {
                    index_second_bracket = action_withbracket.IndexOf(s);
                    break;
                }
            }
            if (action.Count != 0)
            {
                for (int j = index_first_bracket; j < index_second_bracket; j++)
                {
                    switch (action_withbracket[j])
                    {
                        case '+':
                            temp_result = vs[j] + vs[j + 1];
                            break;
                        case '-':
                            temp_result = vs[j] - vs[j + 1];
                            break;
                        case '*':
                            temp_result = vs[j] * vs[j + 1];
                            break;
                        case '/':
                            temp_result = vs[j] / vs[j + 1];
                            break;
                    }
                    action_withbracket.RemoveAt(j);
                   vs.RemoveAt(j+2);
                    vs.RemoveAt(j+1);
                    vs.Insert(j, temp_result);

                }

               
            }
            foreach (var s in action_withbracket)
            {
                if (s == ')')
                {
                    index_second_bracket = action_withbracket.IndexOf(s);
                    action_withbracket.RemoveAt(index_second_bracket);
                    action_withbracket.RemoveAt(index_first_bracket);
                    break;
                }
            }
            */
            /////////////
            //////////
            ///////
            //////
            ///////
            //////
            //////
            //////
            /////
            /////
            ////
            ////
            ////
            ////
            ////
            ////
            ///
            ///знаки * и / должны идти впереди
            int move_index = 0;
             bool next = false;
             double result=0;
            do
            {
                next = false;
                for (int i = 0; i < action.Count; i++)
                {
                    if (action[i] == '*' || action[i] == '/')
                    {
                        /*int index = action.IndexOf(action[i]);
                        vs.Move(index, move_index);
                        vs.Move(index + 1, move_index + 1);
                        action.Move(index, move_index);
                        */
                        switch (action[i])
                        {
                            case '*':
                                result = vs[i] * vs[i + 1];

                                break;
                            case '/':
                                result = vs[i] / vs[i + 1];
                                break;
                        }
                        vs.RemoveAt(i);
                        vs.RemoveAt(i);
                        vs.Insert(i, result);

                        action.RemoveAt(i);

                        next = true;
                    }
                    
                }
            } while (next==true);
            //
            //действия + и -
             int count_action = action.Count;
            double file_result;
            double temp_result=0;
             
            if (action.Count != 0)
            {
                for (int i = 0; i < count_action; i++)
                {
                    switch (action[i])
                    {
                        case '+':
                            temp_result = vs[i] + vs[i + 1];
                            break;
                        case '-':
                            temp_result = vs[i] - vs[i + 1];
                            break;
                        case '*':
                            temp_result = vs[i] * vs[i + 1];
                            break;
                        case '/':
                            temp_result = vs[i] / vs[i + 1];
                            break;
                    }
                    vs[i + 1] = temp_result;
                }

                label_result.Content = temp_result;
                file_result = temp_result;
            }
            else {
                label_result.Content = result;
                file_result = result;
            }//

            //логирование в файл
            string message;
            message = expression + " = " + file_result;
            LogToFileAsync(message);


        }
    }
}
