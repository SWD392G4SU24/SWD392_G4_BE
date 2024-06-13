# Giai đoạn build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Thiết lập thư mục làm việc
WORKDIR /app

# Sao chép các tệp dự án và khôi phục các gói phụ thuộc cho từng dự án
COPY ["Jewelry_Sales_System/Jewelry_Sales_System.API.csproj", "Jewelry_Sales_System/"]
COPY ["JewelrySalesSystem.Application/JewelrySalesSystem.Application.csproj", "JewelrySalesSystem.Application/"]
COPY ["JewelrySalesSystem.Domain/JewelrySalesSystem.Domain.csproj", "JewelrySalesSystem.Domain/"]
COPY ["JewelrySalesSystem.Infrastructure/JewelrySalesSystem.Infrastructure.csproj", "JewelrySalesSystem.Infrastructure/"]
RUN dotnet restore "Jewelry_Sales_System/Jewelry_Sales_System.API.csproj"

# Sao chép tất cả các tệp còn lại và build ứng dụng
COPY . .
WORKDIR "/app/Jewelry_Sales_System"
RUN dotnet publish -c Release -o out

# Giai đoạn runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/Jewelry_Sales_System/out .

# Cấu hình để chạy ứng dụng
ENTRYPOINT ["dotnet", "Jewelry_Sales_System.API.dll"]