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
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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

        // Declaring Gauge object for using Gauge Chart in XAML.
        public Gauge CPUData { get; set; } = new Gauge();
        public Gauge RAMData { get; set; } = new Gauge();
        public Gauge DiskData { get; set; } = new Gauge();

        public Gauge GPUUsage { get; set; } = new Gauge();
        public Gauge GPUTemp { get; set; } = new Gauge();
        public AngularGauge FanSpeed { get; set; } = new AngularGauge();



        public Func<double, string> YFormatter { get; set; }

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
                clientComboBox.ItemsSource = DataBaseHandler.GetAvailableClients();

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
                mSelectedClient = clientComboBox.SelectedItem.ToString(); 

               

                // Fetch and update real-time data for the selected client
                //GetRealTimeData(null); 

                mDataFetchTimer = new Timer(GetRealTimeData, null, 1000, 1000); 

                UsageModel usageModel = DataBaseHandler.GetUsageData(mSelectedClient);

                // Update the UI with the latest data using Dispatcher
                Application.Current.Dispatcher.Invoke(() =>
                {
                    CPUData.Value = usageModel.mCPUUsage;
                    RAMData.Value = usageModel.mRAMUsage;
                    DiskData.Value = usageModel.mDiskUsage;
                    GPUUsage.Value = usageModel.mGPULoad;
                    GPUTemp.Value = usageModel.mGPUTemp;
                    FanSpeed.Value = usageModel.mFanSpeed;
                });
            }
        }

        private void GetRealTimeData(object state)
        {
            // Fetch updated data from the database for the selected client
            UsageModel usageData = DataBaseHandler.GetUsageData(mSelectedClient);

            // Method to get averarge data of all machines.


            //Check if the client is connected
            if (!usageData.mIsConnected)
            {
                MessageBox.Show("Client is not connected to the remote server.");
                return; // Exit the method if the client is not connected
            }

            // Update UI with the latest data using Dispatcher
            Application.Current.Dispatcher.Invoke(() =>
            {
                UpdateUI(usageData);
            });
        }


        private void UpdateUI(UsageModel usageData)
        {
            // Update data according to incoming data.

            CPUData.Value = usageData.mCPUUsage;
            RAMData.Value = usageData.mRAMUsage;
            DiskData.Value = usageData.mDiskUsage;
            GPUUsage.Value = usageData.mGPULoad;
            GPUTemp.Value = usageData.mGPUTemp;
            FanSpeed.Value = usageData.mFanSpeed;

            DataContext = this;
        }

        // Mouse Event on Image.
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Fetch System info.
            // Creating Object of UsageModel Class.
            UsageModel usageModel = new UsageModel();

            if (sender is Image clickedImage)
            {
                if (clickedImage.Name == "cpuImage")
                {
                    // Display CPU data or perform an action
                    // For example:
                    MessageBox.Show("CPU data clicked!");
                }
                else if (clickedImage.Name == "ramImage")
                {
                    // Display RAM data or perform an action
                    // For example:
                    MessageBox.Show("RAM data clicked!");
                }
                else if (clickedImage.Name == "diskImage")
                {
                    // Display Disk data or perform an action
                    // For example:
                    MessageBox.Show("Disk data clicked!");
                }
            }
        }

        /// ----------------------------------------------------
        /// Private Members of Class.

        private Timer mDataFetchTimer;

        private string mSelectedClient = "DefaultClient";

    }
}
