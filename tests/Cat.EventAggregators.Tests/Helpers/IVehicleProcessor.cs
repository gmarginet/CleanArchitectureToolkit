using System.Threading.Tasks;

namespace Cat.EventAggregators.Tests.Helpers;

public interface IVehicleProcessor
{
    Task ProcessAsync();
}