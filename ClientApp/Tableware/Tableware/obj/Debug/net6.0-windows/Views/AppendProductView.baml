   M S B A M L   `   `   `  ����D  @Tableware, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tableware.ViewsTableware.Views  5      '    !Tableware.Views.AppendProductView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Tableware.Views     5      .��5	      � .+�5
   
   �� $
��20px(�6   $��Comic Sans MS)�6$   $��Center=�6?   $	��Top=�6\   !Добавить продукт6�   � 5   
   ���#76E383$��50q�6$     � RowDefinitions  5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $��Center=�6?   $	��350��6\   .+�5      �� $
��16px(�6   $��Comic Sans MS)�6,   $��Center=�6G   Изображение:6p   �� 5      $��10q�6   $	��150��6%   ��61   �� *LoadProductImageCommand+.��6]   '%Выбрать изображение6r   5      �� 5      $ 
Horizontal=�6   $��1��62   $��Center=�6?   $	��350��6\   .+�5      �� $
��16px(�6   $��Comic Sans MS)�6,   $��Center=�6G   Артикул:6m   �� 5      $��10q�6   $	��150��6&   $��Center=�62   $
��16px(�6T   $��Comic Sans MS)�6d   ��6   �� *ProductArticleNumber+6�   5      �� 5       $ 
Horizontal=�6   $��2��62   $��Center=�6?   $	��350��6\   .+�5!      �� $
��16px(�6   $��Comic Sans MS)�6,   $��Center=�6G   Наименование:6q   �� 5"      $��10q�6   $	��150��6&   $��Center=�62   $
��16px(�6T   $��Comic Sans MS)�6d   ��6   �� *ProductName+6�   5#      �� 5$      $ 
Horizontal=�6   $��3��62   $��Stretch=�6?   $	��350��6]   .+�5%      �� $
��16px(�6   $��Comic Sans MS)�6,   $��Center=�6G   Категория:6n   �� 5&      $��10q�6   $	��150��6'   $��Center=�63   $
��16px(�6U   $��Comic Sans MS)�6e    �� SelectedIndex$ 0��6�   ��6�   �� *
Category+ �� SelectedItem 6�   �� *ProductSelectCategory+6�   5'      �� 5(      $ 
Horizontal=�6   $��4��62   $��Center=�6?   $	��350��6\   .+�5)      �� $
��16px(�6   $��Comic Sans MS)�6,   $��Center=�6G   )'Количество на складе:6y   �� 5*      $��10q�6   $	��150��6&   $��Center=�62   $
��16px(�6T   $��Comic Sans MS)�6d   ��6   �� *ProductQuantityInStock+6�   5+      �� 5,      $ 
Horizontal=�6   $��5��62   $��Center=�6?   $	��350��6\   .+�5-      �� $
��16px(�6   $��Comic Sans MS)�6,   $��Center=�6G   $"Единица измерения:6v   �� 5.      $��10q�6   $	��150��6&   $��Center=�62   $
��16px(�6T   $��Comic Sans MS)�6d   ��6   �� *ProductUnit+6�   5/      �� 50      $ 
Horizontal=�6   $��6��62   $��Center=�6?   $	��350��6\   .+�51      �� $
��16px(�6   $��Comic Sans MS)�6,   $��Center=�6G   Поставщик:6n   �� 52      $��10q�6   $	��150��6&   $��Center=�62   $
��16px(�6T   $��Comic Sans MS)�6d   ��6   �� *ProductProvider+6�   53      �� 54      $ 
Horizontal=�6   $��7��62   $��Center=�6?   $	��350��6\   .+�55      �� $
��16px(�6   $��Comic Sans MS)�6,   $��Center=�6G   )'Стоимость за единицу:6y   �� 56      $��10q�6   $	��150��6&   $��Center=�62   $
��16px(�6T   $��Comic Sans MS)�6d   ��6   �� *ProductCost+6�   57      �� 58      $ 
Horizontal=�6   $��8��62   $��Center=�6?   $	��350��6\   .+�59      �� $
��16px(�6   $��Comic Sans MS)�6,   $��Center=�6G   &$Подробное описание:6w   �� 5:      $��10q�6   $	��150��6&   $��Center=�62   $
��16px(�6T   $��Comic Sans MS)�6d   ��6   �� *ProductDescription+6�   5;      �� 5<      $ 
Horizontal=�6   $��9��62   $��Center=�6?   $	��350��6\   .+�5=      �� $
��16px(�6   $��Comic Sans MS)�6,   $��Center=�6G   Производитель:6r   �� 5>      $��10q�6   $	��150��6&   $��Center=�62   $
��16px(�6T   $��Comic Sans MS)�6d   ��6   �� *ProductManufacturer+6�   5?      5@      �� 5A   
   $��10q�6   $	��150��6   $��Bottom=�6)   ��6D   �� *CreateProductCommand+.��6m   Сохранить6x   5B      5C      