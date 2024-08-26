using DTO_QuanLyCafe;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace DAL_QuanLyCafe
{
    public class DAL_Employee : DBconnect
    {
        SqlConnection conn = new SqlConnection();

        public DataTable getStaff()
        {
            try
            {
                using (conn = new SqlConnection(_conn))
                {
                    SqlCommand cmd = new SqlCommand("AllStaff", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    DataTable dtProduct = new DataTable();
                    dtProduct.Load(cmd.ExecuteReader());
                    return dtProduct;
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public DataTable getStaffInfo(string idEmployee)
        {
            try
            {
                using (conn = new SqlConnection(_conn))
                {
                    SqlCommand cmd = new SqlCommand("StaffInfo", conn);
                    cmd.Parameters.AddWithValue("id", idEmployee);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    DataTable dtProduct = new DataTable();
                    dtProduct.Load(cmd.ExecuteReader());
                    return dtProduct;
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public bool dangNhap(DTO_Employee staff)
        {
            try
            {
                using (conn = new SqlConnection(_conn))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DangNhap";
                    cmd.Parameters.AddWithValue("@email", staff.Email);
                    cmd.Parameters.AddWithValue("@password", staff.PasswordStaff);
                    conn.Open();
                    if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                        return true;
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return false;
        }
        public DataTable loginStatus(string email)
        {
            try
            {
                using (conn = new SqlConnection(_conn))
                {
                    SqlCommand cmd = new SqlCommand("LoginStatus", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", email);
                    conn.Open();
                    DataTable dtProduct = new DataTable();
                    dtProduct.Load(cmd.ExecuteReader());
                    return dtProduct;
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public bool kiemtraEmail(string email)
        {
            try
            {
                using (conn = new SqlConnection(_conn))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "KiemTraEmail";
                    cmd.Parameters.AddWithValue("@email", email);
                    conn.Open();

                    int count = (int)cmd.ExecuteScalar();
                    if (Convert.ToInt16(count) > 0)
                    {
                        return true;
                    }
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return false;
        }
        public bool capNhatMK(string email, string matkhaumoi)
        {
            try
            {
                using (conn = new SqlConnection(_conn))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "NewPass";
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", matkhaumoi);
                    conn.Open();

                    if (Convert.ToInt16(cmd.ExecuteNonQuery()) > 0)
                    {
                        return true;
                    }

                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return false;
        }
        public bool insert(DTO_Employee staff)
        {
            try
            {
                using (conn = new SqlConnection(_conn))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertStaff";

                    cmd.Parameters.AddWithValue("@FullName", staff.FullName);
                    cmd.Parameters.AddWithValue("@ImageStaff", staff.ImageStaff);
                    cmd.Parameters.AddWithValue("@Email", staff.Email);
                    cmd.Parameters.AddWithValue("@Role", staff.RoleStaff);
                    cmd.Parameters.AddWithValue("@Status", staff.StatusStaff);

                    conn.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return false;
        }
        public bool update(DTO_Employee staff)
        {
            try
            {
                using (conn = new SqlConnection(_conn))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateStaff";
                    cmd.Parameters.AddWithValue("@Id", staff.IdStaff);
                    cmd.Parameters.AddWithValue("@FullName", staff.FullName);
                    cmd.Parameters.AddWithValue("@ImageStaff", staff.ImageStaff);
                    cmd.Parameters.AddWithValue("@Email", staff.Email);
                    cmd.Parameters.AddWithValue("@Role", staff.RoleStaff);
                    cmd.Parameters.AddWithValue("@Status", staff.StatusStaff);

                    conn.Open();


                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return false;
        }

        public bool delete(string id)
        {
            try
            {
                using (conn = new SqlConnection(_conn))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteStaff";
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return false;
        }
    }
}
