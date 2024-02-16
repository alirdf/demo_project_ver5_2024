try
{
    using(var _context = new DB_.demo_ver5Entities())
    {
        for(int i = 0; i<dtProduct.Items.Count -1; i++)
        {
            TbТовары tb = dtProduct.Items[i] as TbТовары;
            _context.TbТовары.AddOrUpdate(tb);
            _context.SaveChanges();
        }
        MessageBox.Show("Сохранено ");
        dtProduct.ItemsSource = _context.TbТовары.Include(mk => mk.TbКатегории).ToList();
    }
}
catch { MessageBox.Show("Сохранено с ошибокой "); }
----------------------------------------------------------------------------------------------------
  try
 {
     using(var _context = new DB_.demo_ver5Entities())
     {
        var r1 = dtProduct.SelectedItems.Cast<TbТовары>().ToList();
        if(MessageBox.Show($" Точно удалить {r1.Count} элементов", "Внимание" , 
            MessageBoxButton.YesNo , 
            MessageBoxImage.Question)
             ==MessageBoxResult.Yes)
         {
            var r2 = r1.Select(m => m.Код_товара).ToList();
            var r3 = _context.TbТовары.Where(m => r2.Contains(m.Код_товара)).ToList();
             _context.TbТовары.RemoveRange(r3);
             _context.SaveChanges() ;
             MessageBox.Show("Удалено");
             dtProduct.ItemsSource = _context.TbТовары.Include(mk => mk.TbКатегории).ToList();

         }
     }
 }catch { MessageBox.Show("Удалено с ошибокой "); }
-------------------------------------------------------------------------------------------
                    </StackPanel>
                </StackPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
</ScrollViewer>
