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
using TaxiDriverApp.IOTypes;
using TaxiDriverApp.DataTypes;

namespace TaxiDriverApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        private int counter;

        private void AddClientsInfo()
        {
            using (var cont = new DriverContext())
            {
                var modest = new TaxiClient("Модест", "+380964569852");
                var vlad = new TaxiClient("Влад", "+380935263145");
                var yura = new TaxiClient("Юра", "+380965214563");
                var solomiua = new TaxiClient("Соломія", "+380964256312");
                var bohdan = new TaxiClient("Богдан", "+380968145263");

                cont.Clients.Add(modest);
                cont.Clients.Add(vlad);
                cont.Clients.Add(yura);
                cont.Clients.Add(solomiua);
                cont.Clients.Add(bohdan);
                cont.SaveChanges();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            counter = 0;
            clientsInfo = new ClientsDB("../../InputData/ClientsData.txt");
            clientsInfo.ReadFromFile();

            driversInfo = new DriversDB("../../InputData/DriversData.txt");
            driversInfo.ReadFromFile();
        }
        private void startWork_Click(object sender, RoutedEventArgs e)
        {
            currentDriver = driversInfo.FindDriver(driverSurName.Text, driverUserName.Text);
            driverInfoSurnameNameDetails.Content = currentDriver.Surname + " " + currentDriver.Name;
            driverInfoAgeDetails.Content = currentDriver.Age;
            driverInfoCarDetails.Content = currentDriver.CarNumber;
            driverInfoExpDetails.Content = currentDriver.Experience;
            driverInfoCostDetails.Content = currentDriver.PayCheck + " грн";
            driverInfoCostPerMinDetails.Content = currentDriver.CostPerMinute;

            ordersInfo = new OrdersDB("../../InputData/OrdersData.txt", clientsInfo, driversInfo);
            ordersInfo.ReadFromFile();
            ShowOrdersInListView();
        }
        private void endOfWork_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                driversInfo.UpdateDriver(currentDriver);
                driversInfo.WriteToFile();
                ordersInfo.WriteToFile();
                MessageBox.Show(String.Format("Дякуємо за роботу, {0}!", currentDriver.Name), "До побачення");
            }
            catch (Exception)
            { 
            }
            Close();
        }
        private void orders_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null && counter == 0)
            {
                counter++;
                OrderWindow wind = new OrderWindow(item as TaxiOrder);
                wind.Show();
            }
        }
        public void updateCounter()
        {
            counter--;
        }
        public void updateOrders(TaxiOrder orderToUpdate)
        {
            ordersInfo.UpdateOrder(orderToUpdate);
            currentDriver.PayCheck += orderToUpdate.Cost;
            driverInfoCostDetails.Content = currentDriver.PayCheck + " грн";
            ShowOrdersInListView();
        }
        private void ShowOrdersInListView()
        {
            orders.Items.Clear();
            foreach (TaxiOrder order in ordersInfo.AllOrders)
            {
                if (order.Driver.Id == currentDriver.Id)
                {
                    orders.Items.Add(order);
                }
            }
        }
    }
}