using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Threading;
using System.Threading.Tasks;

namespace Test.Views;

public partial class MainWindow : Window
{
    private Window? wnd = null;

    public MainWindow()
    {
        InitializeComponent();
    }

    public void OnButtonClick(object? sender, RoutedEventArgs e)
    {
        wnd = new Window();
        wnd.Title = "test window";
        wnd.Width = 200;
        wnd.Height = 200;
        wnd.Show();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        //Open the menu
        MenuItem options = this.GetControl<MenuItem>("TestMenu");
        options.Open();

        //Click the "open window" option
        MenuItem button = this.GetControl<MenuItem>("OpenWindow");
        var clickEvent = new RoutedEventArgs(MenuItem.ClickEvent);
        button.RaiseEvent(clickEvent);

        //Close the opened window immediately
        wnd?.Close();
    }
}
