using System.Threading.Tasks;

namespace Cat.EventAggregators.Tests.Helpers;

public interface ICarProcessor
{
    Task ProcessAsync();
}