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
using System.Collections.ObjectModel;

namespace GUI_QuanLyCafe
{
    public partial class GUI_MainWindow : Window
    {
        public GUI_MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { 
            if(e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }

        }

        private void LoadFormNhanVien()
        {
            var nhanVienControl = new GUI_QLNhanVien();
            gridMainContent.Children.Clear();
            gridMainContent.Children.Add(nhanVienControl);
        }

        private void btnQLNhanVien_Click(object sender, RoutedEventArgs e)
        {
            LoadFormNhanVien();
        }

        private void LoadFormSanPham()
        {
            var sanPhamControl = new GUI_QLSanPham();
            gridMainContent.Children.Clear();
            gridMainContent.Children.Add(sanPhamControl);
        }

        private void btnQLSanPham_Click(object sender, RoutedEventArgs e)
        {
            LoadFormSanPham();
        }

        private void imgClose_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
