using FoxLearn.License;
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

namespace GenerateSerialKey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.prodId.Text = ComputerInfo.GetComputerId();
        }

        const int ProductCode= 1;

        private void generate_Click(object sender, RoutedEventArgs e)
        {
            KeyManager key = new KeyManager(prodId.Text);
            KeyValuesClass vc = new KeyValuesClass() {
                Edition = Edition.ULTIMATE,
                Footer = Convert.ToByte(6),
                Header = Convert.ToByte(9),
                Type = LicenseType.FULL,
                Version = 1, ProductCode =(byte)ProductCode
            };
            string ProductKey = string.Empty;



            if (!key.GenerateKey(vc, ref ProductKey))
                prodId.Text = "Error";
            else
                serialKey.Text = ProductKey;


        }
    }
}
