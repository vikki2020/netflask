using NetFlask.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NetFlask.Models
{
    public class ReviewViewModel
    {
        #region Fields
        private List<ReviewModel> _reviews;
        private List<FeaturedCardModel> _featuredToday;
        private List<FeaturedCardModel> _featuredEntertainement;
        private List<FeaturedCardModel> _alsoLike;
        private List<SliderModel> _slider;
        private int _maxMovie, _maxPage;
        private readonly DataContext ctx;
        #endregion

        #region Properties
        public List<ReviewModel> Reviews
        {
            get
            {
                return _reviews;
            }

            set
            {
                _reviews = value;
            }
        }

        public List<FeaturedCardModel> FeaturedToday
        {
            get
            {
                return _featuredToday;
            }

            set
            {
                _featuredToday = value;
            }
        }

        public List<FeaturedCardModel> FeaturedEntertainement
        {
            get
            {
                return _featuredEntertainement;
            }

            set
            {
                _featuredEntertainement = value;
            }
        }

        public List<FeaturedCardModel> AlsoLike
        {
            get
            {
                return _alsoLike;
            }

            set
            {
                _alsoLike = value;
            }
        }

        

        public List<SliderModel> Slider
        {
            get
            {
                return _slider;
            }

            set
            {
                _slider = value;
            }
        }

        public int MaxMovie
        {
            get
            {
                return _maxMovie;
            }
             
        }
        public int MaxPage
        {
            get
            {
                return _maxPage;
            }

        }
        #endregion

        public ReviewViewModel()
        {
             
            ctx= new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

            //FeaturedToday
            FeaturedToday = ctx.GetFeatured(6).ToList();

            //FeaturedEnt
            FeaturedEntertainement = ctx.GetFeatured(6, "Watch ‘Bombay Velvet’ trailer during WC match").ToList();

            //AlsoLike
            AlsoLike = ctx.GetFeatured(4, "Lorem Ipsum is simply dummy text of the printing and typesetting industry.").ToList();
            //Section Slider
            Slider = new List<SliderModel>();
            Slider.Add(new SliderModel() { Link = "#", Picture = "m1.jpg" });
            Slider.Add(new SliderModel() { Link = "#", Picture = "m2.jpg" });
            Slider.Add(new SliderModel() { Link = "#", Picture = "m3.jpg" });
            Slider.Add(new SliderModel() { Link = "#", Picture = "m4.jpg" });

            _maxMovie = ctx.CountMovies();
            _maxPage = _maxMovie / 5;
        }
        
        public void paginateReviews(string sortOrder="", string searchString=null, int page =1)
        {
            
            Reviews = ctx.GetAllReviewsMovies(sortOrder,searchString,page);
            if(searchString!=null)
            {
                _maxMovie = Reviews.Count();
                _maxPage = Reviews.Count() / 5;
            }
           
        }
    }
}