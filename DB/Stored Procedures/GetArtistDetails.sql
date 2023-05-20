CREATE PROCEDURE dbo.GetArtistDetails
	@artistID INT

AS 
BEGIN
	SET NOCOUNT ON;

	SELECT 
		ar.artistID, 
		ar.title as artistTitle, 
		ar.biography, 
		ar.imageURL as artistImageURL, 
		ar.heroURL,
		a.albumID, 
		a.title as albumTitle, 
		a.imageURL as albumImageURL, 
		s.songID, 
		s.title as songTitle,
		s.bpm
	FROM Artist ar
	LEFT JOIN Album a ON ar.artistID = a.artistID
	LEFT JOIN Song s ON ar.artistID = s.artistID
	WHERE ar.artistID = @artistID
END
