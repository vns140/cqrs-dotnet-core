using System.Threading.Tasks;

namespace Domain.Shared.Events
{
    public interface IHandler<in T> where T : Message
    {
        Task HandleAsync(T message);
    }
}