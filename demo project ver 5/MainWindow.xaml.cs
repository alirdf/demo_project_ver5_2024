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
            using(var _context = new DB_.demo_ver5Entities())
            {
                
                var alltyp = _context.TbКатегории.ToList();
                alltyp.Insert(0, new DB_.TbКатегории
                {
                    Название = "все типы"
                });

                cbSearch.ItemsSource = alltyp;
                cbSearch.SelectedIndex = 0;
                liProduct.ItemsSource = _context.TbТовары.Include(v=>v.TbКатегории).ToList();
                //cbSearch.ItemsSource = _context.TbТовары.Include(v => v.TbКатегории).ToList();
            }
        }
        private void Uppcat()
        {
            using (var _context = new DB_.demo_ver5Entities())
            {
                //var datacater = _context.TbКатегории.ToList();
                //if (cbSearch.SelectedIndex > 0) ;
                //datacater = datacater.Where(p => p.TbТовары.Contains(cbSearch.SelectedItem as TbКатегории)).ToList();
                //int selectedCategoryId = (cbSearch.SelectedItem as TbКатегории)?.Код_категории ?? 0; 
                //datacater = datacater.Where(p => p.Код_категории == selectedCategoryId).ToList();
            }
            
        }

      

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            using(var _context = new DB_.demo_ver5Entities())
            {
                liProduct.ItemsSource = _context.TbТовары.Include(mk=>mk.TbКатегории).Where(mk=>mk.Название.Contains(tbSearch.Text)||
                mk.TbКатегории.Название.Contains(tbSearch.Text)||
                mk.Описание.Contains(tbSearch.Text)).ToList();  
            }
        }

        private void btOpenEdit_Click(object sender, RoutedEventArgs e)
        {
            WIN_.EditWindows a = new WIN_.EditWindows();
            a.ShowDialog();
        }

       
        private void cbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Uppcat();
            //using (var _context = new DB_.demo_ver5Entities())
            //{
            //    int selectedIndex = cbSearch.SelectedIndex;
            //    if (selectedIndex >= 0) 
            //    {
            //        var selectedCategory = _context.TbКатегории
            //            .Include(c => c.TbТовары)
            //            .Single(c => c.Код_категории == selectedIndex);
            //        liProduct.ItemsSource = selectedCategory.TbТовары.ToList();
            //    }
            //    else
            //    {
            //        liProduct.ItemsSource = _context.TbТовары.Include(v => v.TbКатегории).ToList();
            //    }
            //}
        }
    }
}
