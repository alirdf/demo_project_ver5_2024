using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;
using demo_project_ver_5.DB_;


namespace demo_project_ver_5.WIN_
{
    public partial class EditWindows : Window
    {
        private List<TbКатегории> categories;

        public EditWindows()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var _context = new DB_.demo_ver5Entities())
            {
                dtProduct.ItemsSource = _context.TbТовары.Include(mk => mk.TbКатегории).ToList();
                categories = _context.TbКатегории.ToList();
                cbCategories.ItemsSource = categories;
                cbCam.ItemsSource = categories;
                
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var _context = new DB_.demo_ver5Entities())
            {
                dtProduct.ItemsSource = _context.TbТовары.Include(mk => mk.TbКатегории).Where(
                  mk => mk.Название.Contains(tbSearch.Text) ||
                  mk.TbКатегории.Название.Contains(tbSearch.Text) ||
                  mk.Описание.Contains(tbSearch.Text)).ToList();
            }
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var _context = new DB_.demo_ver5Entities())
                {
                    for (int i = 0; i < dtProduct.Items.Count - 1; i++)
                    {
                        TbТовары tb = dtProduct.Items[i] as TbТовары;
                        _context.TbТовары.AddOrUpdate(tb);
                        _context.SaveChanges();
                    }
                    MessageBox.Show("Сохранено ");
                    dtProduct.ItemsSource = _context.TbТовары.Include(mk => mk.TbКатегории).ToList();
                }
            }
            catch { MessageBox.Show("Ошибока"); }
        }

        private void btDell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var _context = new DB_.demo_ver5Entities())
                {
                    var r1 = dtProduct.SelectedItems.Cast<TbТовары>().ToList();
                    if (MessageBox.Show($" Точно удалить {r1.Count}", "Внимание",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) ==
                        MessageBoxResult.Yes)
                    {
                        var r2 = r1.Select(m => m.Код_товара).ToList();
                        var r3 = _context.TbТовары.Where(m => r2.Contains(m.Код_товара)).ToList();
                        _context.TbТовары.RemoveRange(r3);
                        _context.SaveChanges();
                        MessageBox.Show("Удалено");
                        dtProduct.ItemsSource = _context.TbТовары.Include(mk => mk.TbКатегории).ToList();
                    }
                }
            }
            catch { MessageBox.Show("Ошибока"); }
        }

        private void cbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var _context = new DB_.demo_ver5Entities())
            {
                var selectedCategory = cbCategories.SelectedItem as TbКатегории;
                dtProduct.ItemsSource = _context.TbТовары.Include(mk => mk.TbКатегории)
                    .Where(t => t.Категория == selectedCategory.Код_категории)
                    .ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addProductWindow = new AddProduct(null);
            addProductWindow.ShowDialog();
            LoadData(); // Refresh the data grid after adding a new product
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var addProductWindow = new AddProduct((sender as Button).DataContext as TbТовары);
            addProductWindow.ShowDialog();
        }
    }
}