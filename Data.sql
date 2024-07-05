Use CairoBookDB

INSERT INTO Halls (HallNumber) VALUES (1),(2),(3);

INSERT INTO Blocks (Name, HallId) VALUES
('������ 1', 1),
('������ 2', 2),
('������ 3', 3);

INSERT INTO Publishers (Name, NumberOfBooks, ImageUrl, BlockId) VALUES
('��� ������', 50, 'shorouk.jpg', 1),
('������', 40, 'adab.jpg', 2),
('������� ������� �������� ������', 30, 'arabic_publishing.jpg', 3);

INSERT INTO Authors (Name, Image, Description, NumberOfBooks) VALUES
('���� �����', 'naguib.jpg', '���� ���� ��� �� ��� ������� �����.', 10),
('����� ��������', 'ahlam.jpg', '����� ������ɡ ��� ������ �� �������� �������.', 5),
('����� ���� �����', 'jubran.jpg', '���� ����� ������� ������.', 7);

INSERT INTO Categories (Name, BooksNumber) VALUES
('�����', 20),
('���', 10),
('�����', 5);

INSERT INTO Books (Name, Description, ImageUrl, Price, PublishingYear, PagesNumber, PublisherId, SoundBook, AuthorId, IsAvailableForDonation) VALUES
('������ �������', '����� �� ����� ���� �����.', 'cairo_trilogy.jpg', 150, '1956', 800, 1, 'cairo_trilogy.mp3', 1, 1),
('����� �����', '����� �� ����� ����� ��������.', 'memory_of_the_body.jpg', 100, '1993', 400, 2, 'memory_of_the_body.mp3', 2, 0),
('�����', '���� �� ����� ����� ���� �����.', 'the_prophet.jpg', 80, '1923', 200, 3, 'the_prophet.mp3', 3, 1);

INSERT INTO BooksCategories (BookId, CategoryId) VALUES
(1, 1),
(2, 1),
(3, 3);

