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
using System.Data.Entity;
using demo_project_ver_5.DB_;
using demo_project_ver_5.WIN_;

namespace demo_project_ver_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            var alltyp = demo_ver5Entities.GetContext().TbКатегории.ToList();
            alltyp.Insert(0, new DB_.TbКатегории
            {
                Название = "Все типы"
            });

            cbCategories.ItemsSource = alltyp;
            cbCategories.SelectedIndex = 0;
            liProduct.ItemsSource = demo_ver5Entities.GetContext().TbТовары.Include(v => v.TbКатегории).ToList();
            //cbCategories.ItemsSource = _context.TbТовары.Include(v => v.TbКатегории).ToList();

        }


        private void UpdateProductList()
        {
            var selectedCategory = cbCategories.SelectedItem as TbКатегории;
            IQueryable<TbТовары> query = demo_ver5Entities.GetContext().TbТовары.Include(mk => mk.TbКатегории);

            if (selectedCategory.Код_категории != 0)
            {
                query = query.Where(t => t.Категория == selectedCategory.Код_категории);
            }

            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                query = query.Where(t => t.Название.Contains(tbSearch.Text) ||
                                        t.TbКатегории.Название.Contains(tbSearch.Text) ||
                                        t.Описание.Contains(tbSearch.Text));
            }

            switch (cbSort.SelectedIndex)
            {
                case 0: 
                    break;
                case 1:
                    query = query.OrderByDescending(t => t.Название);
                    break;
                case 2: 
                    query = query.OrderBy(t => t.Название);
                    break;
            }

            liProduct.ItemsSource = query.ToList();
        }


        private void btOpenEdit_Click(object sender, RoutedEventArgs e)
        {
            WIN_.EditWindows a = new WIN_.EditWindows();
            a.ShowDialog();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProductList();
        }


        private void cbCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProductList();
        }


        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProductList();
        }

        private void btAuto_Click(object sender, RoutedEventArgs e)
        {
            WIN_.Auto a = new Auto();
            a.ShowDialog();
        }
    }
}
