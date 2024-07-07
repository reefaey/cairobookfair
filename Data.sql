Use CairoBookDB

INSERT INTO Halls (HallNumber) VALUES (1),(2),(3);

INSERT INTO Blocks (Name, HallId) VALUES
('«·ﬁ«⁄… 1', 1),
('«·ﬁ«⁄… 2', 2),
('«·ﬁ«⁄… 3', 3);

INSERT INTO Publishers (Name, NumberOfBooks, ImageUrl, BlockId) VALUES
('œ«— «·‘—Êﬁ', 50, 'shorouk.jpg', 1),
('«·¬œ«»', 40, 'adab.jpg', 2),
('«·„ƒ””… «·⁄—»Ì… ··œ—«”«  Ê«·‰‘—', 30, 'arabic_publishing.jpg', 3);

INSERT INTO Authors (Name, Image, Description, NumberOfBooks) VALUES
('‰ÃÌ» „Õ›ÊŸ', 'naguib.jpg', 'ﬂ« » „’—Ì° Ì⁄œ „‰ √Â„ «·√œ»«¡ «·⁄—».', 10),
('√Õ·«„ „” €«‰„Ì', 'ahlam.jpg', 'ﬂ« »… Ã“«∆—Ì…° ·Â« «·⁄œÌœ „‰ «·—Ê«Ì«  «·‘ÂÌ—….', 5),
('Ã»—«‰ Œ·Ì· Ã»—«‰', 'jubran.jpg', 'ﬂ« » Ê‘«⁄— Ê›Ì·”Ê› ·»‰«‰Ì.', 7);

INSERT INTO Categories (Name, BooksNumber) VALUES
('—Ê«Ì…', 20),
('‘⁄—', 10),
('›·”›…', 5);

INSERT INTO Books (Name, Description, ImageUrl, Price, PublishingYear, PagesNumber, PublisherId, SoundBook, AuthorId, IsAvailableForDonation) VALUES
('À·«ÀÌ… «·ﬁ«Â—…', '—Ê«Ì… „‰  √·Ì› ‰ÃÌ» „Õ›ÊŸ.', 'cairo_trilogy.jpg', 150, '1956', 800, 1, 'cairo_trilogy.mp3', 1, 1),
('–«ﬂ—… «·Ã”œ', '—Ê«Ì… „‰  √·Ì› √Õ·«„ „” €«‰„Ì.', 'memory_of_the_body.jpg', 100, '1993', 400, 2, 'memory_of_the_body.mp3', 2, 0),
('«·‰»Ì', 'ﬂ «» „‰  √·Ì› Ã»—«‰ Œ·Ì· Ã»—«‰.', 'the_prophet.jpg', 80, '1923', 200, 3, 'the_prophet.mp3', 3, 1);

INSERT INTO BooksCategories (BookId, CategoryId) VALUES
(1, 1),
(2, 1),
(3, 3);

