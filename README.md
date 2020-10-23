# Assignment 4 of PRN292 (SEMESTER 5/9)

**1**.Tạo database: BookStore , gồm bảng Books (BookID int indentity, BookName varchar(50), BookPrice float ) , Employee( EmpID char(10), EmpPassword char(15) , EmpRole bit [true,false])

**2**.Thiết kế và coding : form tên frmLogin : kiểm tra đăng nhập của Employee , nếu nhân viên có role = flase thì mở 1 form mới tên frmChangeAccount hiển chi tiết thông tin của
nhân viên đó và cho phép nhân viên thay đổi password . Nếu nhân viên có role = true thì mở form mới tên frmMaintainBooks : dùng để thực hiện :di chuyển trên các record ( first,last,previous,next), thêm , xóa, sửa , lọc (theo BookName với ký tự bất kỳ) các cuốn sách và hiển thị tổng cột BookPrice ( trong thao tác lọc dữ liệu ), Thêm vào form này 1 button để hiển thị 1 form mới tên frmBookReport : liệt kê tất cả các cuốn sách theo thứ tự giảm dần cột BookPrice hiển thị trên DataGridView

## Technology
1. Visual Studio 2019 Community
2. Window form .NET Framework 4.1.7
3. ADO.NET
4. SQL server 2019 Express
