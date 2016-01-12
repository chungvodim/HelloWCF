using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
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

namespace RealNorthwindHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            ServiceHost MathServiceHost = null;
            try
            {
                //Base Address for MathService
                Uri httpBaseAddress = new Uri("http://localhost:8080/RealNorthwindService/ProductService/");
                Uri tcpBaseAddress = new Uri("net.tcp://localhost:8081/MathService/Calculator");

                //Instantiate ServiceHost
                MathServiceHost = new ServiceHost(typeof(RealNorthwindService.ProductService), httpBaseAddress);

                //Add Endpoint to Host
                MathServiceHost.AddServiceEndpoint(typeof(RealNorthwindService.IProductService), new WSHttpBinding(), "");

                //Metadata Exchange
                ServiceMetadataBehavior serviceBehavior = new ServiceMetadataBehavior();
                serviceBehavior.HttpGetEnabled = true;
                MathServiceHost.Description.Behaviors.Add(serviceBehavior);

                //Open
                MathServiceHost.Open();
                NotificationTextBox.Text = string.Format("Service is live now at : {0}", httpBaseAddress);
            }

            catch (Exception ex)
            {
                MathServiceHost = null;
                NotificationTextBox.Text = string.Format("There is an issue with MathService" + ex.Message);
            }
        }

    }
}
