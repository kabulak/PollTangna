
IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'Justine' AND IsAdmin = 1)
BEGIN
   
    INSERT INTO Users (Username, Password, IsAdmin)
    VALUES ('Justine', 'velskud', 1); 

END
   
   /* IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'AdminUser1' AND IsAdmin = 1)
BEGIN
    INSERT INTO Users (Username, Password, IsAdmin)
    VALUES ('AdminUser1', 'adminpass1', 1);
END