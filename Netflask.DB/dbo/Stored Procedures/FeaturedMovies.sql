 CREATE PROCEDURE FeaturedMovies
 @nb int
 AS
 BEGIN 
 declare  @skip int
  select @skip=RAND()*count(*) from Movie
 
execute('select   * from Movie order by title OFFSET '+ @skip+' ROWS FETCH NEXT '+@nb+' ROWS ONLY')
END