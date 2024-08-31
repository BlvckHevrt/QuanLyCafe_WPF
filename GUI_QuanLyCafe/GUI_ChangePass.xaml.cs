using BUS_QuanLyCafe;
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

namespace GUI_QuanLyCafe
{
    /// <summary>
    /// Interaction logic for GUI_ChangePass.xaml
    /// </summary>
    public partial class GUI_ChangePass : Window
    {
        string stremail; // nhận email từ frmMain
        BUS_Employee busStaff = new BUS_Employee();
        private GUI_MainWindow mainForm;
        public GUI_ChangePass(string email, GUI_MainWindow mainForm)
        {
            InitializeComponent();
            stremail = email;
            txtEmail.Text = stremail;
            txtEmail.IsEnabled = false;
            this.mainForm = mainForm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtNewPassword.Focus();
        }

        private void btnChangePass_Click(object sender, RoutedEventArgs e)
        {
            if (txtOldPassword.Password.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu cũ", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtOldPassword.Focus();
                return;
            }
            else if (txtNewPassword.Password.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtNewPassword.Focus();
                return;
            }
            else if (txtRetypePass.Password.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lại mật khẩu mới", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtRetypePass.Focus();
                return;
            }
            else if (txtRetypePass.Password != txtNewPassword.Password)
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng khớp", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtRetypePass.Focus();
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn đổi mật khẩu", "Thông báo", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    string matkhaumoi = busStaff.encryption(txtNewPassword.Password);
                    string matkhaucu = busStaff.encryption(txtOldPassword.Password);

                    if (busStaff.updateNewMK(txtEmail.Text, matkhaucu, matkhaumoi))
                    {
                        MessageBox.Show("Cập nhật mật khẩu thành công, bạn cần phải đăng nhập lại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        this.Close();
                        // Call checkStatus on the main form
                        if (this.mainForm != null)
                        {
                            //this.mainForm.reLogin();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng, cập nhật mật khẩu không thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        txtNewPassword.Password = null;
                        txtOldPassword.Password = null;
                        txtRetypePass.Password = null;
                    }
                }
                else
                {
                    txtNewPassword.Password = null;
                    txtOldPassword.Password = null;
                    txtRetypePass.Password = null;
                }
            }
        }
    }
}
