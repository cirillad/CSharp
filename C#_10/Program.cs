using System;
using System.Collections;
using System.Collections.Generic;

namespace C__09
{
    public enum Genre
    {
        Comedy,
        Horror,
        Adventure,
        Drama,
    }

    public class Director : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

    public class Movie : ICloneable, IComparable<Movie>
    {
        public string Title { get; set; }
        public Director Director { get; set; }
        public string Country { get; set; }
        public Genre Genre { get; set; }
        public int Year { get; set; }
        public short Rating { get; set; }

        public object Clone()
        {
            Movie cloned = (Movie)this.MemberwiseClone();
            cloned.Director = (Director)this.Director.Clone();
            return cloned;
        }

        public int CompareTo(Movie other)
        {
            return this.Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            return $"{Title}, {Director}, {Country}, {Genre}, {Year}, {Rating}";
        }
    }

    public class CompareByRating : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.Rating.CompareTo(y.Rating);
        }
    }

    public class CompareByYear : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }

    public class Cinema : IEnumerable<Movie>
    {
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public string Address { get; set; }

        public void Sort()
        {
            Movies.Sort();
        }

        public void Sort(IComparer<Movie> comparer)
        {
            Movies.Sort(comparer);
        }

        public IEnumerator<Movie> GetEnumerator()
        {
            return Movies.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return $"{Address}, Movies: {Movies.Count}";
        }
    }

    public class Program
    {
        public static void Main()
        {
            Director director = new Director { FirstName = "John", LastName = "Doe" };
            Movie movie1 = new Movie { Title = "Movie1", Director = director, Country = "USA", Genre = Genre.Comedy, Year = 2020, Rating = 8 };
            Movie movie2 = new Movie { Title = "Movie2", Director = director, Country = "USA", Genre = Genre.Horror, Year = 2018, Rating = 7 };

            Cinema cinema = new Cinema { Address = "123 Main St" };
            cinema.Movies.Add(movie1);
            cinema.Movies.Add(movie2);

            Console.WriteLine(cinema);

            cinema.Sort(new CompareByRating());
            foreach (var movie in cinema)
            {
                Console.WriteLine(movie);
            }

            cinema.Sort(new CompareByYear());
            foreach (var movie in cinema)
            {
                Console.WriteLine(movie);
            }
        }
    }
}
