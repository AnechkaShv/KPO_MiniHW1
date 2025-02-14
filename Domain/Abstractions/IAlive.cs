namespace Domain.Abstractions;

public interface IAlive
{
    int Food { get; set; }
    bool State { get; set; }
}