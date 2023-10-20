using DoAnLTWin_QuanLyPhongKhamNhaKhoa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTWin_QuanLyPhongKhamNhaKhoa.ModelView
{
    public class EmployeeService
    {
        public Nhanvien GetEmployeeByLogin(string username, string password)
        {
            using (var context = new DaphongkhamnhakhoaContext())
            {
                var account = context.Taikhoans.FirstOrDefault(a => a.TenDangNhap == username && a.MatKhau == password);
                if (account != null)
                {
                    return context.Nhanviens.FirstOrDefault(e => e.MaNv == account.MaNv);
                }
                return null; 
            }
        }
    }
}
