using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NetFlask.DAL.Repositories;
using NetFlask.Entities;

namespace NetFlask.Repositories
{
    public class MovieRepository : BaseRepository<MovieEntity>, IConcreteRepository<MovieEntity>
    {
        public MovieRepository(string cnstr): base(cnstr)
        {

        }

        public bool Delete(MovieEntity toDelete)
        {
            throw new NotImplementedException();
        }

        public List<MovieEntity> Get()
        {
            string requete = "Select * from V_Rating";

            return base.Get(requete);
        }
        public List<MovieEntity> GetByPage(string sortOrder, string searchString, int page)
        {
            string requete = $@"Select * from V_Rating";

            if (!String.IsNullOrEmpty(searchString))
            {
                requete += " WHERE Title LIKE '%" + searchString + "%' ";
            }
            switch (sortOrder)
            {
                case "name_desc":
                    requete += " order by Title DESC ";
                    break;
                case "Date":
                    requete += " order by ReleaseDate ASC ";
                    break;
                case "date_desc":
                    requete += " order by ReleaseDate DESC ";
                    break;
                default:
                    requete += " order by Title ";
                    break;
            }



            int nbParPage = 5;
            int skip = (page - 1) * 5; 
              requete += $@"  OFFSET  {skip} ROWS 
                                FETCH NEXT {nbParPage} ROWS ONLY";

            return base.Get(requete);
        }
        public List<MovieEntity> GetFromGenres(int idGenre)
        {
            string requete = @"Select Movie.* from Movie 
                               inner join MovieGenre
                               ON Movie.IdMovie = MovieGEnre.IdGenre
                                WHERE MovieGenre.IdGenre=" + idGenre; //concat
            return base.Get(requete);
        }


        public List<MovieEntity> GetFeatured(int nb)
        {
            string requete = $"exec FeaturedMovies {nb}" ;

            return base.Get(requete);
        }

        public MovieEntity GetOne(int PK)
        {
            string requete = "Select * from V_Rating where IdMovie =@id"; //TSQL ==> @, PLSQL ==> : 

            return base.GetOne(PK, requete);
        }

        public bool Insert(MovieEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public bool Update(MovieEntity toUpdate)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePicture(int id, string picture)
        {
            string requete = $"Update Movie set Picture='{picture}' WHERE id={id}";

            return base.Update(new MovieEntity(), requete);
        }
    }
}
