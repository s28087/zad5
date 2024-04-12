namespace zadanie.Models;

public enum Kategoria
{
    pies,
    kot,
    gryzon
}

public class Zwierze
{
    public int IdZwierze { get; set; }
    public string Imie { get; set; }
    public Kategoria Kategoria{ get; set; }
    public double Masa { get; set; }
    public string KolorSiersci { get; set; }
    
    
    
}