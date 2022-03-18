using Avalonia.Controls;
using Avalonia.Interactivity;
using HW_5.ViewModels;
using System.Windows;

namespace HW_5.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("OpenFile").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                .ShowAsync(this);

                string[]? path = await taskPath;
                var context = (MainWindowViewModel)this.DataContext;
                if (path is not null)
                {
                    context.ReadFileToInput(string.Join("/", path));
                }

            };

            this.FindControl<Button>("SaveFile").Click += async delegate
            {
                var taskPath = new SaveFileDialog()
                .ShowAsync(this);

                string path = await taskPath;
                var context = (MainWindowViewModel)this.DataContext;
                if (path is not null)
                {
                    context.SaveOutputInFile(path);
                }

            };

        }
        public void ShowRegexSetWindow(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new RegexSetWindow();
            dialogWindow.FindControl<TextBox>("RegexInputField").Text = ((MainWindowViewModel)this.DataContext).Regex;
            dialogWindow.ShowDialog(this);
        }
    }
}
