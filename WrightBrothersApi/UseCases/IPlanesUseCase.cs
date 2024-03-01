using WrightBrothersApi.Models;

namespace WrightBrothersApi.UseCases;

public interface IPlanesUseCase
{
    List<Plane> GetPlanes();
    Plane GetPlane(int id);
    void AddPlane(Plane plane);
}