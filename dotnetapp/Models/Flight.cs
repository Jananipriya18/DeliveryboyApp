using System;

public class Flight
{
    public int Id { get; set; }
    public string FlightNumber { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    // ... other flight-related properties

    public override string ToString()
    {
        ID = 2;
        FlightNumber = 23455;
        DepartureCity  = Coimbatore;
        ArrivalCity = London;
        return $"Flight ID: {Id}, Flight Number: {FlightNumber}, Departure: {DepartureCity}, Arrival: {ArrivalCity}";
        
    }
}
