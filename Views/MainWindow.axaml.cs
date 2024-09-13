using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System.Threading.Tasks;

namespace Test.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void OnButtonClick(object? sender, RoutedEventArgs e)
    {
        StartTest();
    }

    public void StartTest()
    {
        //Infinite loop that keeps opening new windows
        Task.Run(async () =>
        {
            while (true)
            {
                await Task.Delay(20);
                Dispatcher.UIThread.Post(() =>
                {
                    ExecuteTest();
                });
            }
        });
    }

    private static void ExecuteTest()
    {
        Window wnd = new Window();
        wnd.Width = 100;
        wnd.Height = 100;
        wnd.Show();

        Task.Run(async () =>
        {
            //Each window closes 100ms after being shown
            await Task.Delay(100);
            Dispatcher.UIThread.Post(() =>
            {
                wnd.Close();
            });
        });
    }
}
