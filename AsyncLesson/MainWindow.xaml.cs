using AsyncLesson.Data;
using AsyncLesson.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncLesson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // async-await
        private readonly DatabaseContext context;
        private ICollection<Category> categories;
        public MainWindow()
        {
            InitializeComponent();

            context = new DatabaseContext();

            GetData();
        }

        private async Task GetData()
        {
            //using (var context = new DatabaseContext())
            //{
            //    // получить категории

            //}
            //categoryComboBox.ItemsSource = context.Categories.Select(category => category.Name).ToList();


            //Task.Delay(500).Wait(); // имитация длительной работы в отдельном таске

            //categories = context.Categories.ToList();
            categories = await context.Categories.ToListAsync();
            categoryComboBox.ItemsSource = categories.Select(category => category.Name);
        }

        private async void CategorySelected(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());
            //productDataGrid.ItemsSource = context.Products.Where(product => product.Category.Name == categoryComboBox.SelectedValue.ToString()).ToList();

            Task.Delay(2000).Wait(); // имитация длительной работы в отдельном таске

            //productDataGrid.ItemsSource = categories.First(category => category.Name == categoryComboBox.SelectedValue.ToString()).Products;
            productDataGrid.ItemsSource = await context.Products.Where(product => product.Category.Name == categoryComboBox.SelectedValue.ToString()).ToListAsync();
        }

        private Task<int> SumData()
        {
            Thread.Sleep(5000);
            return Task.FromResult(3);
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            context.Dispose();
        }

        private async void WindowLoaded(object sender, RoutedEventArgs e)
        {
            await GetData();
        }
    }
}
