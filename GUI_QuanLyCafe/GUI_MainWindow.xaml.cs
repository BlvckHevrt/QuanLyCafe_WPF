using System;
using System.Data;
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
using BUS_QuanLyCafe;
using static System.Collections.Specialized.BitVector32;
using System.Collections;

namespace GUI_QuanLyCafe
{
    public partial class GUI_MainWindow : Window
    {
        string email;
        public static int session = 0; //tình trạng login
        public static string role { set; get; } //kiểm tra vai trò sau đăng nhập
        public static int status { set; get; }
        public GUI_MainWindow(string email)
        {
            InitializeComponent();
            this.email = email;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BUS_Employee busStaff = new BUS_Employee();

            DataTable dt = busStaff.LoginStatus(this.email);

            DataTable dt1 = busStaff.VaiTro(this.email);

            role = dt1.Rows[0]["roleStaff"].ToString();

            int loginStatus = int.Parse(dt.Rows[0][0].ToString());
            if (loginStatus == 0)
            {
                MessageBox.Show("VUI LÒNG ĐỔI MẬT KHẨU (ĐĂNG NHẬP LẦN ĐẦU)", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("BẠN CHẮC CHẮN MUỐN ĐĂNG XUẤT?", "THÔNG BÁO", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                session = 0;
                this.Hide();
                GUI_Login dangNhap = new GUI_Login();
                dangNhap.Show();
            }
        }
    }
}
