CREATE DATABASE B_BW3;

CREATE TABLE Products (
idProduct INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
displayName NVARCHAR(max) NOT NULL,
descriptionPro NVARCHAR(max) NOT NULL,
price DECIMAL(10,2) NOT NULL,
imageURL NVARCHAR(max) NOT NULL,
inStock INT NOT NULL
)

CREATE TABLE SecondaryImages (
idSecondaryImages INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
idProduct INT NOT NULL,
imageURL NVARCHAR(max) NULL,
CONSTRAINT FK_SecondaryImages_Products
FOREIGN KEY (idProduct) REFERENCES Products(idProduct)
)

INSERT INTO Products (displayName, descriptionPro, price, imageURL, inStock)
VALUES (
'LEGO 10328 Icons Il Bouquet di Rose',
'Bouquet di fiori finti per decorazione di casa: il set LEGO Icons per adulti Bouquet di Rose è un hobby creativo da costruire da soli, con gli amici o con i familiari',
39.99,
'https://m.media-amazon.com/images/I/81YQvZUOW1L._AC_SL1500_.jpg',
168
)

INSERT INTO Products (displayName, descriptionPro, price, imageURL, inStock)
VALUES (
'LEGO Botanicals Piantine Felici Giocattolo',
'Piante finte LEGO: il set Piantine Felici LEGO Botanicals è un gioco creativo per bambine e bambini da 9 anni in su, che incoraggia la passione dei piccoli per i kit di arti e mestieri, e che offre una bella decorazione da scaffale',
18.39,
'https://m.media-amazon.com/images/I/81JGnQochGL._AC_SX425_.jpg',
278
),
(
'LEGO Botanicals Mini-Orchidea',
'ESPOSIZIONE DI FIORI ARTIFICIALI LEGO: lascia che la tua creatività venga fuori con il kit di costruzioni LEGO Botanicals Mini-Orchidea per adulti, che consente di creare ed esporre un fiore LEGO',
21.90,
'https://m.media-amazon.com/images/I/71EeFX1HCsL._AC_SX425_.jpg',
3789
),
(
'HOGOKIDS, set di bonsai con fiori di ciliegio',
'Due fiori di ciliegio bonsai stili - goditi epiche atmosfere primaverili! Questo fantastico set bonsai 2 in 1 dal design esclusivo trasforma qualsiasi stanza in oasi fiorita.',
33.90,
'https://m.media-amazon.com/images/I/81YU09InVUL._AC_SX425_.jpg',
24
),
(
'LEGO Botanicals Albicocco Giapponese',
'Set LEGO per adulti di fiori finti decorativi: prenditi una pausa o unisciti ad amici e familiari, per vivere un’esperienza di costruzione rilassante con il kit di modellismo per adulti Albicocco giapponese LEGO Botanicals',
26.90,
'https://m.media-amazon.com/images/I/81SPGUu9TRL._AC_SX425_.jpg',
694
)
SELECT * FROM Products