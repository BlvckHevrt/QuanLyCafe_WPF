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
using DTO_QuanLyCafe;
using BUS_QuanLyCafe;
using System.Net.Mail;
using System.Data;
using System.Net;


namespace GUI_QuanLyCafe
{
    /// <summary>
    /// Interaction logic for GUI_Login.xaml
    /// </summary>
    public partial class GUI_Login : Window
    {
        public int role { get; set; }
        public int status { get; set; }

        DTO_Employee staff;
        BUS_Employee busStaff;

        public GUI_Login()
        {
            InitializeComponent();
        }  

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
            {
                textEmail.Visibility = Visibility.Collapsed;
            }
            else
            {
                textEmail.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void SendMail(string email, string maxacnhan)
        {
            //Now we must create a new Smtp client to send our email.
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //smtp.gmail.com // For Gmail //Authentication.
                                                                       //This is where the valid email account comes into play. You must have a valid email //account (with password) to give our program a place to send the mail from.
            NetworkCredential cred = new NetworkCredential("baotncps40789@gmail.com", "jflb jhdg dqht lwra");
            //To send an email we must first create a new mailMessage (an email) to send. 
            MailMessage Msg = new MailMessage();
            // Sender e-mail address.
            Msg.From = new MailAddress("baotncps40789@gmail.com"); //Nothing But Above Credentials or your credentials (*******@gmail.com) // Recipient e-mail address.
            Msg.To.Add(email);
            // Assign the subject of our message.
            Msg.Subject = "ANH/CHỊ ĐÃ SỬ DỤNG TÍNH NĂNG QUÊN MẬT KHẨU!";
            // Create the content (body) of our message.
            Msg.Body = "CHÀO ANH/CHỊ. MẬT KHẨU MỚI LÀ: " + maxacnhan;
            // Send our account login details to the client.
            client.Credentials = cred;
            //Enabling SSL (Secure Sockets Layer, encyription) is reqiured by most email providers to send mail
            client.EnableSsl = true;
            client.Send(Msg); // Send our email.

        }

        public bool IsValid(string emailaddress) //kiem tra xem email co hop le khong
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }
            return builder.ToString();
        }

        //Tao so ngau nhien
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private string TaoMK()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));

            string matKhau = builder.ToString();

            return matKhau;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text.Trim().Length == 0)
            {
                txtEmail.Focus();
                return;
            }
            else if (!IsValid(txtEmail.Text.Trim()))
            {
                txtEmail.Focus();
                return;
            }
            else if (txtPassword.Password.Trim().Length == 0)
            {
                txtPassword.Focus();
                return;
            }
            else
            {
                //frmMainQLBH.email = nv.EmailNV;

                staff = new DTO_Employee();
                busStaff = new BUS_Employee();

                staff.email = txtEmail.Text;
                staff.passwordStaff = busStaff.encryption(txtPassword.Password);

                if (busStaff.DangNhap(staff))
                {
                    if (chkGhiNhoTK.IsChecked == true)
                    {
                        Properties.Settings.Default.SavedEmail = txtEmail.Text;
                        Properties.Settings.Default.RememberEmail = true; // Lưu trạng thái của checkbox
                    }
                    else
                    {
                        Properties.Settings.Default.SavedEmail = string.Empty; // Xóa email khi không ghi nhớ
                        Properties.Settings.Default.RememberEmail = false; // Lưu trạng thái của checkbox
                    }
                    Properties.Settings.Default.Save();

                    //frmMainQLCF mainform = new frmMainQLCF();
                    ////frmLoading frmLoading = new frmLoading();

                    //DataTable dt = busStaff.VaiTro(staff.email);
                    //frmMainQLCF.role = dt.Rows[0]["roleStaff"].ToString();
                    //frmMainQLCF.status = 1;
                    //frmMainQLCF.session = 1;
                    //frmMainQLCF.email = staff.email;

                    //frmLoading.Show();

                    //foreach (Form form in Application.OpenForms)
                    //{
                    //    if (form is frmMainQLCF)
                    //    {
                    //        ((frmMainQLCF)form).PhanQuyen();
                    //        break;
                    //    }
                    //}

                    GUI_MainWindow.session = 1;
                    this.Hide();
                    GUI_MainWindow main = new GUI_MainWindow(staff.email);
                    main.ShowDialog();

                    

                }
                else
                {
                    MessageBox.Show("ĐĂNG NHẬP THẤT BẠI!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }
            }
        }

        private void btnForgotPass_Click(object sender, object e)
        {
            if (MessageBoxResult.OK == MessageBox.Show("BẠN MUỐN SỬ DỤNG TÍNH NĂNG QUÊN MẬT KHẨU?", "THÔNG BÁO", MessageBoxButton.OKCancel, MessageBoxImage.Question))
            {
                busStaff = new BUS_Employee();
                if (txtEmail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("VUI LÒNG NHẬP EMAIL!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtEmail.Focus();
                    return;
                }
                else if (!IsValid(txtEmail.Text))
                {
                    MessageBox.Show("VUI LÒNG NHẬP ĐÚNG ĐỊNH DẠNG EMAIL!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtEmail.Focus();
                    return;
                }
                else if (!busStaff.KiemTraEmail(txtEmail.Text))
                {
                    MessageBox.Show("EMAIL KHÔNG TỒN TẠI TRONG HỆ THỐNG!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtEmail.Focus();
                    return;
                }
                else
                {
                    //frmQuenMatKhau frmQuenMatKhau = new frmQuenMatKhau(txtEmail.Text);
                    //frmQuenMatKhau.ShowDialog();

                    string EmailNV = txtEmail.Text;
                    string MatKhauMoi = busStaff.encryption(TaoMK());

                    if (busStaff.CapNhatMK(EmailNV, MatKhauMoi))//cap nhat mat khau thanh cong
                    {

                        SendMail(txtEmail.Text, TaoMK());
                        MessageBox.Show("MẬT KHẨU MỚI ĐÃ ĐƯỢC GỬI VỀ EMAIL!", "THÔNG BÁO", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void chkGhiNhoTK_Checked(object sender, RoutedEventArgs e)
        {
            //Lưu email
            if (chkGhiNhoTK.IsChecked == true)
            {
                Properties.Settings.Default.SavedEmail = txtEmail.Text;
                Properties.Settings.Default.RememberEmail = true;
            }
            else
            {
                Properties.Settings.Default.SavedEmail = string.Empty;
                Properties.Settings.Default.RememberEmail = false;
            }
            Properties.Settings.Default.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem có email đã được lưu không
            if (Properties.Settings.Default.RememberEmail)
            {
                txtEmail.Text = Properties.Settings.Default.SavedEmail;
                chkGhiNhoTK.IsChecked = true;
            }
            else
            {
                chkGhiNhoTK.IsChecked = false;
            }
        }
    }
}
