 SELECT TOP 100 * FROM Students; -- TOP kasutamine ilma ORDER BY-ta
 SELECT Gender, MemberType, Count(MemberId) as memberCount from Member group by Gender; -- SELECT Gender, MemberType, Count(MemberId) as memberCount from Member group by Gender;
 SELECT DISTINCT Member.*, Entry.TourId from Member, Entry WHERE Member.MemberId = Entry.MemberId; -- JOIN klauslis tingimuse ära jätmine
 SELECT Member.*, Entry.TourId from Member inner join Entry; -- JOIN klauslis tingimuse ära jätmine
 SELECT * from Member;; -- Üleliigne semikoolon
 ;
 SELECT * from Member where; -- WHERE klauslis tingimuse ära jätmine
 SELECT * FROM Ase WHERE ase_id = (SELECT TOP 1 ase_id FROM Magamine GROUP BY ase_id ORDER BY Count(*) DESC); -- Top võib mitu rida tagastada
 SELECT TOP 101 PERCENT * FROM Reserveerimine ORDER BY idk; -- TOP klausliga peab arv olema nullist suurem (koos PERCENT tingimusega <= 100-st)
 --SELECT * FROM Reserveerimine ORDER lopu_aeg; -- Unustatakse BY võtmesõna fraasist ORDER BY/GROUP BY, INTO võtmesõna fraasist INSERT INTO
 SELECT count(*) as arv FROM (select distinct kommentaar from Reserveerimine); -- FROM klausli alampäringul puudub alias
 SELECT TOP 100 Count(*) AS arv FROM Hotell ORDER BY idk; -- Tulemuses on alati üks rida. TOP n või TOP n PERCENT on täiesti üleliigsed.
 SELECT count(*) as arv FROM (select distinct kommentaar from Reserveerimine);
 SELECT * from Member where Gender = 'F' and where MemberType = 'Junior'; -- WHERE kasutamine kaks korda