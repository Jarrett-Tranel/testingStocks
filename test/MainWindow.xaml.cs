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

using ServiceStack;
using ServiceStack.Text;


namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var symbol = "MSFT";
            var apiKey = "demo"; // retrieve your api key from https://www.alphavantage.co/support/#api-key
            var monthlyPrices = $"https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY&symbol={symbol}&apikey={apiKey}&datatype=csv"
                            .GetStringFromUrl().FromCsv<List<AlphaVantageData>>();

            monthlyPrices.PrintDump();

            // some simple stats
            var maxPrice = monthlyPrices.Max(u => u.Close);
            var minPrice = monthlyPrices.Min(u => u.Close);
            shown.Text = maxPrice + "";

        }


        public class AlphaVantageData
        {
            public DateTime Timestamp { get; set; }
            public decimal Open { get; set; }

            public decimal High { get; set; }
            public decimal Low { get; set; }

            public decimal Close { get; set; }
            public decimal Volume { get; set; }
        }
    }
}

    // retrieve monthly prices for Microsoft
    
