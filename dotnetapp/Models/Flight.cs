public class Flight
{
    public string Departure { get; set; }
    public string Duration { get; set; }
    public string Arrival { get; set; }
    public string Price { get; set; }
    public string Airline { get; set; }
    public string FlightNumber { get; set; }

    // Constructor to initialize flight information
    public Flight(string departure, string duration, string arrival, string price, string airline, string flightNumber)
    {
        Departure = departure;
        Duration = duration;
        Arrival = arrival;
        Price = price;
        Airline = airline;
        FlightNumber = flightNumber;
    }
}
