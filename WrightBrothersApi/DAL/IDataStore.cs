using WrightBrothersApi.Models;

namespace WrightBrothersApi.DAL
{
    public interface IDataStore
    {
        List<Plane> GetPlanes();
        Plane GetPlane(int id);
        void AddPlane(Plane plane);
        void UpdatePlane(Plane plane);
    }
}