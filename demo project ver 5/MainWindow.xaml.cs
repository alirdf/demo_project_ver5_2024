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
                liProduct.ItemsSource = _context.TbТовары.Include(v=>v.TbКатегории).ToList();
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
    }
}
