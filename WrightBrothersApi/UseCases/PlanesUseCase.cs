using WrightBrothersApi.DAL;
using Plane = WrightBrothersApi.Models.Plane;

namespace WrightBrothersApi.UseCases;

public class PlanesUseCase : IPlanesUseCase
{
    private readonly IDataStore _planesDataStore;

    public PlanesUseCase(IDataStore planesDataStore)
    {
        _planesDataStore = planesDataStore;
    }

    public List<Plane> GetPlanes()
    {
        return _planesDataStore.GetPlanes();
    }

    public Plane GetPlane(int id)
    {
        return _planesDataStore.GetPlane(id);
    }

    public void AddPlane(Plane plane)
    {
        _planesDataStore.AddPlane(plane);
    }

    public void SortPlanesByYear(List<Plane> planes)
    {
        planes.Sort((p1, p2) => p1.Year.CompareTo(p2.Year));
    }
}

