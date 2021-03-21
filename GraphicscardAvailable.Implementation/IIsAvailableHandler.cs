
using System.Threading.Tasks;

namespace GraphicscardAvailable.Implementation 
{
    public interface IIsAvailableHandler 
    {
        Task<IsAvailableResponse> Handle(IsAvailableRequest request);
    }
}