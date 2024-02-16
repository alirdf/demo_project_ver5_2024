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
using System.Windows.Shapes;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using demo_project_ver_5.DB_;


namespace demo_project_ver_5.WIN_
{
    /// <summary>
    /// Interaction logic for EditWindows.xaml
    /// </summary>
    public partial class EditWindows : Window
    {
        public EditWindows()
        {
            InitializeComponent();
            using (var _context = new DB_.demo_ver5Entities())
            {
                dtProduct.ItemsSource = _context.TbТовары.Include(mk => mk.TbКатегории).ToList();
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var _context = new DB_.demo_ver5Entities())
            {
                dtProduct.ItemsSource = _context.TbТовары.Include(mk => mk.TbКатегории).Where(mk => mk.Название.Contains(tbSearch.Text) ||
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

                    for (int i = 0; i < dtProduct.Items.Count; i++)
                    {
                        TbТовары a = dtProduct.Items[i] as TbТовары;
                        _context.TbТовары.AddOrUpdate(a);
                        _context.SaveChanges();
                    }
                    MessageBox.Show("Сохранено");
                    dtProduct.ItemsSource = _context.TbТовары.Include(mk => mk.TbКатегории).ToList();
                }

            }
            catch { }
        }

        private void btDell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var _context = new DB_.demo_ver5Entities())
                {
                    var r1 = dtProduct.SelectedItems.Cast<TbТовары>().ToList();
                    if (MessageBox.Show($"Точно удалть {r1.Count} элементов", "Внимание",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question) ==
                        MessageBoxResult.Yes)
                    {
                        var r2 = r1.Select(mk => mk.Код_товара).ToList();
                        var r3 = _context.TbТовары.Where(mk => r2.Contains(mk.Код_товара)).ToList();
                        _context.TbТовары.RemoveRange(r3);
                        _context.SaveChanges();
                        MessageBox.Show("Удалено");
                        dtProduct.ItemsSource = _context.TbТовары.Include(mk => mk.TbКатегории).ToList();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
