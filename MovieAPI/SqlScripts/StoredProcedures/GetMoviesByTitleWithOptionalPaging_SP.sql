USE [Movies]
GO
/****** Object:  StoredProcedure [dbo].[GetMoviesByTitleWithOptionalPaging_SP]    Script Date: 22/05/2025 14:19:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		JA
-- Create date: 21/05/2025
-- Description:	Filters Movie extract by Title contains @MovieTitle input param
--				Optionally returns <@PageSize> results for <@PageNumber> X
--				Sorts on @SortColumn, defaulting to 'Title'
-- =============================================
ALTER PROCEDURE [dbo].[GetMoviesByTitleWithOptionalPaging_SP]

	 @MovieTitle nvarchar(50)  
	,@PageNumber int = NULL
	,@PageSize int = NULL
	,@SortColumn nvarchar(50)

AS

BEGIN
	SET NOCOUNT OFF;

	IF (@PageNumber IS NULL)
		BEGIN
			SELECT [Release_Date]
					,[Title]
					,[Overview]
					,[Popularity]
					,[Vote_Count]
					,[Vote_Average]
					,[Original_Language]
					,[Genre]
					,[Poster_Url]
					,[ID]
				FROM [dbo].[Movies]
				WHERE CHARINDEX(@MovieTitle, [Title]) > 0 
				ORDER BY 
						CASE WHEN @SortColumn = 'Release_Date' THEN Release_Date
							  ELSE NULL END,
						CASE WHEN @SortColumn = 'Title' THEN Title
							  ELSE NULL END
		END
	ELSE
		BEGIN
			SELECT [Release_Date]
				,[Title]
				,[Overview]
				,[Popularity]
				,[Vote_Count]
				,[Vote_Average]
				,[Original_Language]
				,[Genre]
				,[Poster_Url]
				,[ID]
			FROM [dbo].[Movies]
			WHERE CHARINDEX(@MovieTitle, [Title]) > 0 
			ORDER BY 
				CASE WHEN @SortColumn = 'Release_Date' THEN Release_Date
						ELSE NULL END,
				CASE WHEN @SortColumn = 'Title' THEN Title
						ELSE NULL END
			OFFSET (@PageNumber - 1) * @PageSize ROWS
			FETCH NEXT @PageSize ROWS ONLY
		END
		
  SET NOCOUNT ON;
END
