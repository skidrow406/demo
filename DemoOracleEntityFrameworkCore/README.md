Mở cmd/terminal trong folder DemoOracleEntityFrameworkCore và thực hiện các bước sau:  
1. Khôi phục các package
  - dotnet restore
2. Migration database
  - Nếu chưa cài dotnet-ef run lệnh: dotnet tool install --global dotnet-ef
  - Sửa connection string 'TestDb' trong file appsettings.json
  - dotnet ef migrations add InitializeDatabase
  - dotnet ef database update
3. Chạy ứng dụng
  - dotnet run
  - Truy cập: http://localhost:5000/swagger để test api