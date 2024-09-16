using BUS_QuanLyCafe;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace GUI_QuanLyCafe
{
    /// <summary>
    /// Interaction logic for GUI_QLNhanVien.xaml
    /// </summary>
    public partial class GUI_QLNhanVien : UserControl
    {
        public GUI_QLNhanVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {

        }
        BUS_Employee busNhanVien = new BUS_Employee();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = busNhanVien.GetPageStaff(1, 10, 1);
            dgvDanhSachNhanVien.ItemsSource = dt.DefaultView;
        }
    }
}
