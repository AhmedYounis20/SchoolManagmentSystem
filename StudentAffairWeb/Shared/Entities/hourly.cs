namespace StudentAffairWeb.Shared;

public class Hourly
{
    public List<string>? time { get; set; }
    public List<double>? temperature_2m { get; set; }
    public List<int>? relativehumidity_2m { get; set; }
    public List<double>? windspeed_10m { get; set; }
    public List<double>? windspeed_80m { get; set; }
    public List<double>? windspeed_120m { get; set; }
    public List<double>? windspeed_180m { get; set; }
    public List<int>? winddirection_10m { get; set; }
    public List<int>? winddirection_80m { get; set; }
    public List<int>? winddirection_120m { get; set; }
    public List<int>? winddirection_180m { get; set; }
    public List<double>? windgusts_10m { get; set; }
    public List<double>? temperature_80m { get; set; }
    public List<double>? temperature_120m { get; set; }
    public List<double>? temperature_180m { get; set; }
    public List<double>? soil_temperature_0cm { get; set; }
    public List<double>? soil_temperature_6cm { get; set; }
    public List<double>? soil_temperature_18cm { get; set; }
    public List<double>? soil_temperature_54cm { get; set; }
    public List<double>? soil_moisture_0_1cm { get; set; }
    public List<double>? soil_moisture_1_3cm { get; set; }
    public List<double>? soil_moisture_3_9cm { get; set; }
    public List<double>? soil_moisture_9_27cm { get; set; }
    public List<double>? soil_moisture_27_81cm { get; set; }

}
