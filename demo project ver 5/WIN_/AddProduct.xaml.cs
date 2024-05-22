using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using demo_project_ver_5.DB_;

namespace demo_project_ver_5.WIN_
{
    public partial class AddProduct : Window
    {
        private List<TbКатегории> categories;

        private TbТовары _товары = new TbТовары();
        public AddProduct(TbТовары товары)
        {
            DataContext = товары;
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            using (var _context = new DB_.demo_ver5Entities())
            {
                categories = _context.TbКатегории.ToList();
                cbCategories.ItemsSource = categories;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(_товары.)
            try
            {
                using (var _context = new DB_.demo_ver5Entities())
                {
                    var newProduct = new TbТовары
                    {
                        Название = tbName.Text,
                        Описание = tbDescription.Text,
                        Цена = decimal.Parse(tbPrice.Text),
                        Категория = (cbCategories.SelectedItem as TbКатегории).Код_категории,
                        Путь_фото = tbPhotoPath.Text
                    };

                    _context.TbТовары.Add(newProduct);
                    _context.SaveChanges();
                    MessageBox.Show("Товар добавлен успешно.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}