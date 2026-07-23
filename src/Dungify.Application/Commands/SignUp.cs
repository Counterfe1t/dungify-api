using Dungify.Application.Abstractions;
using System.Text.Json.Serialization;

namespace Dungify.Application.Commands;

public sealed record SignUp(
    string Name,
    string Email,
    string Password,
    string Role) : ICommand
{
    [JsonIgnore]
    public Guid Id { get; set; }
}