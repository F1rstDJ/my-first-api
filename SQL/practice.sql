-- Неделя 2: практика SQL

-- Чтение и фильтрация
SELECT * FROM "Products";
SELECT "Name", "Price" FROM "Products" WHERE "Category" = 'phones';
SELECT * FROM "Products" WHERE "Price" > 100000;

-- Сортировка и ограничение
SELECT * FROM "Products" ORDER BY "Price" DESC LIMIT 3;

-- Учебные таблицы для JOIN
CREATE TABLE "Customers" (
                             "Id" integer PRIMARY KEY,
                             "Name" text NOT NULL
);

CREATE TABLE "Orders" (
                          "Id" integer PRIMARY KEY,
                          "CustomerId" integer NOT NULL,
                          "Total" numeric NOT NULL
);

-- JOIN: заказы с именами клиентов
SELECT "Orders"."Id", "Customers"."Name", "Orders"."Total"
FROM "Orders"
         JOIN "Customers" ON "Orders"."CustomerId" = "Customers"."Id";

-- LEFT JOIN: все клиенты, даже без заказов
SELECT "Customers"."Name", "Orders"."Total"
FROM "Customers"
         LEFT JOIN "Orders" ON "Customers"."Id" = "Orders"."CustomerId";

-- Агрегация: сколько потратил каждый клиент
SELECT "Customers"."Name", SUM("Orders"."Total") AS "Spent"
FROM "Customers"
         JOIN "Orders" ON "Customers"."Id" = "Orders"."CustomerId"
GROUP BY "Customers"."Name";

-- Индекс
CREATE INDEX "idx_products_category" ON "Products" ("Category");