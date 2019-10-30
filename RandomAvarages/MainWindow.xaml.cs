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
//using ConsoleAppTest;

namespace RandomAvarages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // A	Universal	Application	(Windows	Store)	Windows	Presentation	Foundation (WPF)	application	or	a	WinForms	application	can	be	
        // regarded	as	having	a	single thread of  execution that	is	dealing with    the user    interface.	At any given instant this	thread will   
        // be performing  a particular  action.In other   words,	when code	in an event handler is	running	in	response to a particular  event,	
        // such	as	a button press,	it	is	not possible	for	code	in	any other part of the user    interface to  execute.You sometimes   see this   
        // behavior    in badly written applications, where the user interface of  the application becomes unresponsive	while	an action	is	carried	out.
        public MainWindow()
        {
            InitializeComponent();
        }

        private double ComputeTheAverages(double input)
        {
            double total = 0;
            Random random = new Random();
            for (long values = 0; values < input; values++)
            {
                total += random.NextDouble();
            }
            return total / input;
        }

        private static void ButtonClicked(object sender, RoutedEventArgs args)
        {
            MainWindow mw = new MainWindow();
            mw.nameInput.Text = (String)((Button)sender).Tag;
            ((MainWindow)Application.Current.MainWindow).nameInput.Text = (String)((Button)sender).Tag;
            long input = long.Parse(mw.nameInput.Text);
        }


    }
}
