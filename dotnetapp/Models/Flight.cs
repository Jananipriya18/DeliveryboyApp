namespace dotnetapp.Models
{
    public class Flight
    {
        public int ID { get; set; } // Unique identifier for each flight
        public string Departure { get; set; }
        public string Duration { get; set; }
        public string Arrival { get; set; }
        public string Price { get; set; }
        public string Airline { get; set; }
        public string FlightNumber { get; set; }

        // Parameterless constructor
        public Flight()
        {
        }

        // Constructor to initialize flight information
        public Flight(int id, string departure, string duration, string arrival, string price, string airline, string flightNumber)
        {
            ID = id;
            Departure = departure;
            Duration = duration;
            Arrival = arrival;
            Price = price;
            Airline = airline;
            FlightNumber = flightNumber;
        }
    }
}
