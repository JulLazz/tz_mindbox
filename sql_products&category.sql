use tz_mindbox;

create table Category
(
	CategoryId int not null primary key identity(1,1),
	CategoryName nvarchar(100) not null
)

create table Product
(
	ProductId int not null primary key identity(1,1),
	ProductName nvarchar(100) not null
)

create table ProductCategory
(
	CategoryId int not null,
	ProductId int not null,
	primary key(CategoryId, ProductId),
	foreign key (CategoryId) references Category(CategoryId) on delete cascade,
	foreign key (ProductId) references Product(ProductId) on delete cascade,
)

INSERT INTO Product values ('product1'), ('product2'), ('product3'), ('product4'), ('product5');
INSERT INTO Category values ('category1'), ('category2');
INSERT INTO ProductCategory values  (3, 6), (3, 7), (4, 8), (4, 10);

select 
	p.ProductName as product,
	c.CategoryName as category
from Product p left join ProductCategory pc on p.ProductId = pc.ProductId 
			   left join Category c on c.CategoryId = pc.CategoryId
