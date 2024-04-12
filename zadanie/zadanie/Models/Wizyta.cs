namespace zadanie.Models;

public class Wizyta
{
    public DateTime DataWizyty { get; set; }
    public Zwierze Zwierze { get; set; }
    public string Opis { get; set; }
    public double Cena { get; set; }
}