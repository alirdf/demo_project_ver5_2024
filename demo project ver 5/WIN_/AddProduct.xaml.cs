using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using demo_project_ver_5.DB_;

namespace demo_project_ver_5.WIN_
{
    public partial class AddProduct : Window
    {

        private TbТовары currentТовар = new TbТовары();
        public AddProduct(TbТовары товары)
        {
            if (товары != null)
                currentТовар = товары;
            DataContext = currentТовар;
            InitializeComponent();
            cbCategories.ItemsSource = demo_ver5Entities.GetContext().TbКатегории.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (currentТовар.Код_товара == 0)
                demo_ver5Entities.GetContext().TbТовары.Add(currentТовар);

            demo_ver5Entities.GetContext().SaveChanges();
            MessageBox.Show("Информация сохранена");
            this.Close();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}