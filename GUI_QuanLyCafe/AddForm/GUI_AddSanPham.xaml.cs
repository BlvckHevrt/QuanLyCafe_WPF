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

        private void textMaSanPham_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtMaSanPham.Focus();
        }

        private void txtMaSanPham_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaSanPham.Text) && txtMaSanPham.Text.Length > 0)
            {
                textMaSanPham.Visibility = Visibility.Collapsed;
            }
            else
            {
                textMaSanPham.Visibility = Visibility.Visible;
            }
        }

        private void textTenSanPham_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtTenSanPham.Focus();
        }

        private void txtTenSanPham_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenSanPham.Text) && txtTenSanPham.Text.Length > 0)
            {
                textTenSanPham.Visibility = Visibility.Collapsed;
            }
            else
            {
                textTenSanPham.Visibility = Visibility.Visible;
            }
        }
    }
}
