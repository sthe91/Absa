CREATE PROCEDURE spSearchEntries
@SearchText NVARCHAR(50)
AS
BEGIN
    SELECT TOP 10 *
    FROM [Absa].[Entries]
    WHERE [Name] LIKE @SearchText + '%'
END