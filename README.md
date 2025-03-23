🔐 Tình huống 2: Bạn không có quyền push (không phải thành viên)
Fork dự án về tài khoản cá nhân của bạn:
Trên trang GitHub của dự án, nhấn nút Fork (góc trên bên phải).
Clone từ bản fork của bạn:
git clone https://github.com/yourusername/project.git
Chuyển vào thư mục dự án:
cd project_name
Tạo nhánh mới để sửa code:
git checkout -b sua-code-moi

Sửa code và commit thay đổi:
git add .
git commit -m "Cải thiện tính năng ABC"

Push lên GitHub (vào repo fork của bạn):
git push origin sua-code-moi

Tạo Pull Request (PR) từ bản fork của bạn sang repo gốc:
Vào trang GitHub của repo fork của bạn.
Chọn Compare & pull request.
Gửi yêu cầu merge (PR) để chủ dự án xem xét.
❗ Chú ý:
Nếu bạn không phải là thành viên của dự án, bạn không thể push trực tiếp lên repo gốc mà phải tạo Pull Request (PR) từ bản fork.

Chủ dự án sẽ xem xét và quyết định có merge PR của bạn hay không.

Nếu PR được chấp nhận, code của bạn sẽ được tích hợp vào dự án gốc.
