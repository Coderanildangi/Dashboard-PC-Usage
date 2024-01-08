using DashBoardApp.DAL;
using DashBoardApp.Model;
using LiveCharts.Wpf;
using LiveCharts;
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
using System.Threading;

namespace DashBoardApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer dataFetchTimer;
        private string selectedClient = "DefaultClient"; // Change this to your logic for selecting a client

        public SeriesCollection CPUData { get; set; } = new SeriesCollection();
        public SeriesCollection RAMData { get; set; } = new SeriesCollection();
        public SeriesCollection DiskData { get; set; } = new SeriesCollection();

        public MainWindow()
        {
            InitializeComponent();
            LoadAvailableClients(); // Load available clients when the window initializes
        }

        private void LoadAvailableClients()
        {
            try
            {
                // Fetch and populate available clients in the ComboBox
                clientComboBox.ItemsSource = DataBaseHandler.GetAvailableClients(); // Assuming this method returns a list of clients
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading clients: {ex.Message}");
                // Handle the error (display message, log, etc.)
            }
        }

        private void ClientSelectionChanged(object sender, EventArgs e)
        {
            if (clientComboBox.SelectedItem != null)
            {
                selectedClient = clientComboBox.SelectedItem.ToString(); // Update selected client

                // Clear previous chart data
                CPUData.Clear();
                RAMData.Clear();
                DiskData.Clear();

                // Fetch and update real-time data for the selected client
                GetRealTimeData(null); // Fetch initial data immediately upon client selection
                dataFetchTimer = new Timer(GetRealTimeData, null, 5000, 5000); // Fetch data every 5 seconds

                // Update the UI with the latest data using Dispatcher
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Bind charts with updated data
                    cpuChart.Series = CPUData;
                    ramChart.Series = RAMData;
                    diskChart.Series = DiskData;
                });
            }
        }

        private void GetRealTimeData(object state)
        {
            // Fetch updated data from the database for the selected client
            UsageModel usageData = DataBaseHandler.GetUsageData(selectedClient);

            // Check if the client is connected
            //if (!usageData.IsConnected)
            //{
            //    MessageBox.Show("Client is not connected to the remote server.");
            //    return; // Exit the method if the client is not connected
            //}

            // Update UI with the latest data using Dispatcher
            Application.Current.Dispatcher.Invoke(() =>
            {
                UpdateUI(usageData);
            });
        }

        private void UpdateUI(UsageModel usageData)
        {
            // Add fetched data points to the respective charts
            CPUData.Add(new LineSeries { Title = "CPU Usage", Values = new ChartValues<double> { usageData.CPUUsage } });
            RAMData.Add(new LineSeries { Title = "RAM Usage", Values = new ChartValues<double> { usageData.RAMUsage } });
            DiskData.Add(new LineSeries { Title = "Disk Usage", Values = new ChartValues<double> { usageData.DiskUsage } });

            // Refresh chart data
            cpuChart.AxisX.Clear(); // Clear axis to update the chart
            ramChart.AxisX.Clear();
            diskChart.AxisX.Clear();

            // Refresh chart data (you might need to update X-axis data accordingly)
            cpuChart.Series = CPUData;
            ramChart.Series = RAMData;
            diskChart.Series = DiskData;
        }
    }
}
