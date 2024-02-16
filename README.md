 for (int i = 0; i < dtProduct.Items.Count; i++)
 {
     TbТовары a = dtProduct.Items[i] as TbТовары;
     _context.TbТовары.AddOrUpdate(a);
     _context.SaveChanges();
 }
 MessageBox.Show("Сохранено");
 dtProduct.ItemsSource = _context.TbТовары.Include(mk => mk.TbКатегории).ToList();
----------------------------------------------------------------------------------------------------
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
-------------------------------------------------------------------------------------------
                    </StackPanel>
                </StackPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
</ScrollViewer>
