using DAL_QuanLyCafe;
using DTO_QuanLyCafe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLyCafe
{
    public class BUS_Employee
    {
        DAL_Employee employee = new DAL_Employee();
        public string encryption(string password)   
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encoding = new UTF8Encoding();
            //encrypt the given password string into Encrypted Data
            encrypt = md5.ComputeHash(encoding.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create new string by using encryted data
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }
        public DataTable getStaff()
        {
            return employee.getStaff();
        }

        public DataTable getStaffInfo(string idEmployee)
        {
            return employee.getStaffInfo(idEmployee);
        }
        public bool DangNhap(DTO_Employee staff)
        {
            return employee.dangNhap(staff);
        }
        public DataTable LoginStatus(string email)
        {
            return employee.loginStatus(email);
        }
        public bool KiemTraEmail(string email)
        {
            return employee.kiemtraEmail(email);
        }
        public bool CapNhatMK(string email, string matkhau)
        {
            return employee.capNhatMK(email, matkhau);
        }
        public bool updateNewMK(string email, string matkhaucu, string matkhaumoi)
        {
            return employee.UpdateMK(email, matkhaucu, matkhaumoi);
        }
        public DataTable VaiTro(string email)
        {
            return employee.vaiTro(email);
        }
        public DataTable GetPageStaff(int pageIndex, int pageSize, int status)
        {
            return employee.GetPagedStaff(pageIndex, pageSize, status);
        }
        public bool insert(DTO_Employee em)
        {
            return employee.insert(em);
        }
        public bool update(DTO_Employee em)
        {
            return employee.update(em);
        }

        public bool delete(string id)
        {
            return employee.delete(id);
        }
    }
}
