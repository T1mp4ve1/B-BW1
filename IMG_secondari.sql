INSERT INTO SecondaryImages (idProduct, imageURL) 
VALUES
(1, 'https://m.media-amazon.com/images/I/81M7Lrn6NtL._AC_SY450_.jpg'),
(1, 'https://m.media-amazon.com/images/I/81gM0T72FxL._AC_SY450_.jpg'),
(1, 'https://m.media-amazon.com/images/I/81zSwcb2fkL._AC_SY450_.jpg');

INSERT INTO SecondaryImages (idProduct, imageURL) 
VALUES
(2, 'https://m.media-amazon.com/images/I/91v4mEw6-bL._AC_SX425_.jpg'),
(2, 'https://m.media-amazon.com/images/I/71pfzdVBMwL._AC_SX425_.jpg'),
(2, 'https://m.media-amazon.com/images/I/81RleO6dFlL._AC_SX425_.jpg'),
(3, 'https://m.media-amazon.com/images/I/81e7hxV9dyL._AC_SX425_.jpg'),
(3, 'https://m.media-amazon.com/images/I/613M9pKItkL._AC_SX425_.jpg'),
(3, 'https://m.media-amazon.com/images/I/81FB8-5zJhL._AC_SX425_.jpg'),
(4, 'https://m.media-amazon.com/images/I/715JohKCL6L._AC_SX425_.jpg'),
(4, 'https://m.media-amazon.com/images/I/81rdiOHSnkL._AC_SX425_.jpg'),
(4, 'https://m.media-amazon.com/images/I/71OmE-P1aZL._AC_SX425_.jpg'),
(5, 'https://m.media-amazon.com/images/I/81DADmsF9uL._AC_SX425_.jpg'),
(5, 'https://m.media-amazon.com/images/I/61T3MUSZVtL._AC_SX425_.jpg'),
(5, 'https://m.media-amazon.com/images/I/81iU9+bZCSL._AC_SX425_.jpg');

SELECT * FROM SecondaryImages WHERE idProduct = 4;