using System.Windows;
using NeuroServer.Udp;
using NeuroServer.NeuroUtilities;

namespace NeuroServer.v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Server _server = (Server) App.Current.Resources["server"];
        private NeuroController _neuroController = new NeuroController();

        public MainWindow()
        {
            InitializeComponent();

            _server.OnProcess += obj =>
            {
                var values = (double[])obj;
                return _neuroController.Compute(values[0], values[1]);
            };
            _server.Init(int.Parse(PortTextBox.Text));
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _server.Start();
            Log.AppendText("\nServer Started");
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _server.Stop();
            Log.AppendText("\nServer Stopped");
        }
    }
}
