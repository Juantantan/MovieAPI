using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using MovieAPI.Models;
namespace MovieAPI.Controllers;

public static class MovieEndpoints
{
    public static void MapMovieEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api").WithTags(nameof(Movie));

        //group.MapGet("/", () =>
        //{
        //    return new [] { new Movie() };
        //})
        //.WithName("GetAllMovies")
        //.WithOpenApi();

        //group.MapGet("/{id}", (int id) =>
        //{
        //    //return new Movie { ID = id };
        //})
        //.WithName("GetMoviesByTitleWithOptionalPaging")
        //.WithOpenApi();

        group.MapGet("/GetMoviesByTitle", (string movieTitle, int pageNumber, int pageSize) =>
        {
            return new List<Movie>();
        })
        .WithName("GetMoviesByTitle")
        .WithOpenApi();

        //group.MapGet("/GetMoviesByGenre", (string genre, int pageNumber, int pageSize) =>
        //{
        //    return new List<Movie>();
        //})
        //.WithName("GetMoviesByGenre")
        //.WithOpenApi();

        //group.MapPut("/{id}", (int id, Movie input) =>
        //{
        //    return TypedResults.NoContent();
        //})
        //.WithName("UpdateMovie")
        //.WithOpenApi();

        //group.MapPost("/", (Movie model) =>
        //{
        //    //return TypedResults.Created($"/api/Movies/{model.ID}", model);
        //})
        //.WithName("CreateMovie")
        //.WithOpenApi();

        //group.MapDelete("/{id}", (int id) =>
        //{
        //    //return TypedResults.Ok(new Movie { ID = id });
        //})
        //.WithName("DeleteMovie")
        //.WithOpenApi();
    }
}
