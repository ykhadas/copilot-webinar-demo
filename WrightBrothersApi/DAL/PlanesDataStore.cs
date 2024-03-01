using System.Text.RegularExpressions;
using WrightBrothersApi.Models;

namespace WrightBrothersApi.DAL
{
    public class PlanesDataStore : IDataStore
    {
        private static List<Plane> Planes =>
            new()
            {
                new Plane()
                {
                    Id = 1,
                    Name = "Wright Flyer",
                    Description =
                        "The Wright Flyer (often retrospectively referred to as Flyer I or 1903 Flyer) was the first successful heavier-than-air powered aircraft. It was designed and built by the Wright brothers. They flew it four times on December 17, 1903, near Kill Devil Hills, about four miles (6.4 km) south of Kitty Hawk, North Carolina. Today, the airplane is exhibited in the National Air and Space Museum in Washington D.C. The U.S. Smithsonian Institution describes the aircraft as \"the first powered, heavier-than-air machine to achieve controlled, sustained flight with a pilot aboard.\"",
                    Year = 1904,
                    RegistrationNumber = "N12345"
                },
                new Plane()
                {
                    Id = 2,
                    Name = "Spirit of St. Louis",
                    Description =
                        "The Spirit of St. Louis is the custom-built, single-engine, single-seat monoplane that was flown solo by Charles Lindbergh on May 20–21, 1927, on the first non-stop flight from New York to Paris for which Lindbergh won the $25,000 Orteig Prize.",
                    Year = 1928,
                    RegistrationNumber = "N23456"
                },
                new Plane()
                {
                    Id = 3,
                    Name = "Plane 3",
                    Description = "Description of Plane 3",
                    Year = 2022,
                    RegistrationNumber = "N34567"
                },
                new Plane()
                {
                    Id = 4,
                    Name = "Plane 4",
                    Description = "Description of Plane 4",
                    Year = 2023,
                    RegistrationNumber = "N45678"
                },
                new Plane()
                {
                    Id = 5,
                    Name = "Plane 5",
                    Description = "Description of Plane 5",
                    Year = 2024,
                    RegistrationNumber = "N56789"
                }
            };

        public List<Plane> GetPlanes()
        {
            return Planes;
        }

        public Plane GetPlane(int id)
        {
            return Planes.First(p => p.Id == id);
        }

        public void AddPlane(Plane plane)
        {
            if (Planes.Any(p => p.Id == plane.Id))
            {
                throw new Exception("Plane with the same ID already exists.");
            }
            Planes.Add(plane);
        }

        public void UpdatePlane(Plane plane)
        {
            var existingPlane = Planes.FirstOrDefault(p => p.Id == plane.Id);
            if (existingPlane == null)
            {
                throw new Exception("Plane not found.");
            }

            existingPlane.Name = plane.Name;
            existingPlane.Description = plane.Description;
            existingPlane.Year = plane.Year;
            existingPlane.RegistrationNumber = plane.RegistrationNumber;
        }
    }}
