USE [Movies]
GO
/****** Object:  StoredProcedure [dbo].[GetMoviesByGenreGetPagination_SP]    Script Date: 23/05/2025 12:21:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		JA
-- Create date: 23/05/2025
-- Description:	Returns Pagination Parent Dataset for Movies filtered by @Genre
-- =============================================
ALTER PROCEDURE [dbo].[GetMoviesByGenreGetPagination_SP]
	 @Genre nvarchar(50)
	,@PageSize int = NULL
	,@PageNumber int = NULL
AS
DECLARE @RecordCount int
DECLARE @TotalPages int
SET NOCOUNT OFF;

BEGIN

	SELECT @RecordCount = COUNT(ID)	FROM [dbo].[Movies]	WHERE CHARINDEX(@Genre, [Genre]) > 0;
	IF (@RecordCount > 0) 
		BEGIN
			SET @TotalPages = 
				CASE WHEN @PageSize > @RecordCount THEN 1
					 WHEN @RecordCount % @PageSize = 0 THEN @RecordCount / @PageSize
					 WHEN @RecordCount % @PageSize <> 0 THEN @RecordCount / @PageSize + 1
				END
			END
	ELSE 
		BEGIN
			SET @TotalPages = 0
		END
END
	BEGIN
		SELECT 
			 @RecordCount AS TotalRecordCount
			,@PageSize AS PageSize
			,@PageNumber AS PageNumber
			,@TotalPages AS TotalPages
			,CASE WHEN @PageNumber > 1 THEN 1
				ELSE 0 END AS HasPrevious
		   ,CASE WHEN @PageNumber < @TotalPages THEN 1
				ELSE 0 END AS HasNext 
	END

SET NOCOUNT ON;