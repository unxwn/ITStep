using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (CarContext context = new CarContext())
            {
                context.Database.Initialize(true);
                context.SeedData();
            }

            UdpClient udpServer = new UdpClient(12345);
            IPEndPoint clientEndpoint = new IPEndPoint(IPAddress.Any, 0);

            Console.WriteLine("Server started...");

            while (true)
            {
                byte[] requestBytes = udpServer.Receive(ref clientEndpoint);
                string request = Encoding.UTF8.GetString(requestBytes);
                Console.WriteLine($"Received: {request}");

                string response = HandleRequest(request);
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                udpServer.Send(responseBytes, responseBytes.Length, clientEndpoint);
            }
        }

        static string HandleRequest(string request)
        {
            using (CarContext context = new CarContext())
            {
                if (request.StartsWith("Id:"))
                {
                    int id = int.Parse(request.Substring(3));
                    var car = context.Cars.FirstOrDefault(c => c.Id == id);
                    return car != null ? FormatCar(car) : "Car not found.";
                }
                else if (request.StartsWith("Price:"))
                {
                    string[] range = request.Substring(6).Trim().Split('-');
                    decimal min = decimal.Parse(range[0]);
                    decimal max = decimal.Parse(range[1]);
                    var cars = context.Cars.Where(c => c.Price >= min && c.Price <= max && c.IsAvailable).ToList();
                    return cars.Any() ? string.Join("\n", cars.Select(FormatCar)) : "No cars found in this price range.";
                }
                else if (request.StartsWith("Brand:"))
                {
                    string brand = request.Substring(6).Trim();
                    var cars = context.Cars.Where(c => c.Brand == brand).ToList();
                    return cars.Any() ? string.Join("\n", cars.Select(FormatCar)) : "Car not found.";
                }
                else if (request.StartsWith("Model:"))
                {
                    string model = request.Substring(6).Trim();
                    var cars = context.Cars.Where(c => c.Model == model).ToList();
                    return cars.Any() ? string.Join("\n", cars.Select(FormatCar)) : "Car not found.";
                }
                else if (request.StartsWith("Remove:"))
                {
                    int id = int.Parse(request.Substring(7));
                    var car = context.Cars.FirstOrDefault(c => c.Id == id);
                    if (car != null)
                    {
                        car.IsAvailable = false;
                        context.SaveChanges();
                        return "Car removed from sale.";
                    }
                    return "Car not found.";
                }
                else
                {
                    return "Invalid request.";
                }
            }
        }

        static string FormatCar(Car car)
        {
            return $"Id: {car.Id}, Brand: {car.Brand}, Model: {car.Model}, Price: {car.Price}, Available: {car.IsAvailable}";
        }
    }
}
