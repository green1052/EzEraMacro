using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EzEraMacro
{
    /// <summary>
    ///     MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            string word = WordTextBox.Text;

            if (string.IsNullOrEmpty(word))
                return;

            WordListBox.Items.Add(word);
            WordTextBox.Text = string.Empty;
        }

        private void GetResultButton_Click(object sender, RoutedEventArgs e)
        {
            string tempString = "";

            string[] array = WordListBox.Items.OfType<string>().ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                string str = array[i];

                tempString += str;

                /*
                 * 4번째 = 마지막이면 \e\n 안넣기
                 * 5~6번째 뒤에 나오는 스트링이 )이면 \e\n 안넣기
                 */
                if (str == "*" || str == "(" || str == ")" || array.Length == i + 1 ||
                    array.Length < i + 1 || array[i + 1] == ")")
                    continue;

                tempString += @"\e\n";
            }

            ResultTextBox.Text = tempString;
        }

        private void WordListBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Delete || !(sender is ListBox listBox)) return;
            
            foreach (string listBoxSelectedItem in listBox.SelectedItems.OfType<string>().ToArray())
                listBox.Items.Remove(listBoxSelectedItem);
        }
    }
}