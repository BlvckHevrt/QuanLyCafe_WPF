﻿using System;
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

namespace GUI_QuanLyCafe.AddForm
{
    /// <summary>
    /// Interaction logic for GUI_AddSanPham.xaml
    /// </summary>
    public partial class GUI_AddSanPham : Window
    {
        public GUI_AddSanPham()
        {
            InitializeComponent();
        }

        private void imgClose_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
