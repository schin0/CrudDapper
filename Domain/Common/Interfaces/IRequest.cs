namespace Domain.Common.Interfaces
{
    public interface IRequest
    {
    }
    
    public interface IRequest<out T> : IRequest
    {
        T ToDomain();
    }
}
