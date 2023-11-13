using Moq;
using Movie_Collection.Movies.DTO;
using Movie_Collection.Movies.Model;
using Movie_Collection.Movies.Repository;
using Movie_Collection.Movies.Service;
using Shouldly;

namespace MovieCollectionTest.UnitTesting.MovieTest
{
    public class MovieTest
    {

        [Fact]
        public void ValidMovie()
        {
            // Arrange
            var movieId = new Guid("4941202c-93c6-430f-9f2a-3c582b4594b1");
            var name = "Godfather3";
            var description = "Best mafia movie of all time";
            var author = "Francis Copola";
            var genre = Genre.Action;
            var releaseDate = new DateOnly(1999, 05, 12);

            // Act
            var movie = new Movie(movieId, name, description, author, genre, releaseDate);

            // Assert
            movie.ShouldNotBeNull();
            Assert.Equal(movieId, movie.MovieId);
            Assert.Equal(releaseDate, movie.ReleaseDate);
        }


        [Fact]
        public void SearchMoviesTest()
        {
            var movieRepositoryMock = new Mock<IMovieRepository>();
            movieRepositoryMock.Setup(m => m.GetAll()).Returns(CreateMovies());
            var movieService = new MovieService(movieRepositoryMock.Object);

            var searchDto = new MovieSearchDTO
            {
                NameSearch = "",       
                AuthorSearch = "Auth",   
                GenreSearch = Genre.Comedy,
                YearSearch = 0
            };

            var result = movieService.SearchMovies(searchDto);

            movieRepositoryMock.Verify(m => m.GetAll(), Times.Once);

            Assert.NotNull(result);
            Console.WriteLine($"Number of movies in result: {result.Count()}");
            Assert.Equal(2, result.Count());
        }

        

        private static List<Movie> CreateMovies()
        {
            var movies = new List<Movie>();

            var movie1 = new Movie
            {
                MovieId = Guid.NewGuid(),
                Name = "Godfather",
                Author = "Author1",
                Genre = Genre.Action,
                ReleaseDate = new DateOnly(2005, 12, 1)
            };

            var movie2 = new Movie
            {
                MovieId = Guid.NewGuid(),
                Name = "Godfather2",
                Author = "Author2",
                Genre = Genre.Comedy,
                ReleaseDate = new DateOnly(1984, 12, 04)
            };

            var movie3 = new Movie
            {
                MovieId = Guid.NewGuid(),
                Name = "Movie3",
                Author = "Author3",
                Genre = Genre.Comedy,
                ReleaseDate = new DateOnly(2005, 5, 22)
            };

            movies.Add(movie1);
            movies.Add(movie2);
            movies.Add(movie3);

            return movies;
        }

        


    }
}
