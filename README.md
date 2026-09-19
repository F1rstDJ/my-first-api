# My First API

Простой CRUD API для управления товарами.

## Технологии
- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL

## Эндпоинты
- `GET /api/product` — все товары
- `GET /api/product/{id}` — товар по ID
- `GET /api/product/category/{category}` — товары по категории
- `GET /api/product/price/{minPrice}` — товары дороже цены
- `GET /api/product/top` — топ-3 дорогих товаров
- `POST /api/product` — создать товар
- `PUT /api/product/{id}` — обновить товар
- `DELETE /api/product/{id}` — удалить товар

## Как запустить
1. Установить PostgreSQL
2. Обновить строку подключения в `appsettings.json`
3. Применить миграции: `dotnet ef database update`
4. Запустить: `dotnet run`
