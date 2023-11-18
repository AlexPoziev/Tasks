SELECT
    Products.ProductName, Categories.CategoryName
FROM
    Products
LEFT JOIN
    ProductCategory ON Products.ProductID = ProductCategory.ProductID
LEFT JOIN
    Categories ON ProductCategory.CategoryID = Categories.CategoryID;