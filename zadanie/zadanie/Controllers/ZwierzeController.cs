using Microsoft.AspNetCore.Mvc;
using zadanie.Models;

namespace zadanie.Controllers;

[Route("api/zwierzeta")]
[ApiController]
public class ZwierzeController : ControllerBase
{
    
    private static readonly List<Zwierze> _zwierzeta = new()
    {
        new Zwierze { IdZwierze = 1, Imie = "Azor", Kategoria = Kategoria.pies, Masa = 10.0, KolorSiersci = "biały" },
        new Zwierze { IdZwierze = 2, Imie = "Tosia", Kategoria = Kategoria.kot, Masa = 5.0, KolorSiersci = "czarny" },
        new Zwierze { IdZwierze = 3, Imie = "Max", Kategoria = Kategoria.pies, Masa = 11.0, KolorSiersci = "brązowy" },
        new Zwierze { IdZwierze = 4, Imie = "Lucek", Kategoria = Kategoria.gryzon, Masa = 2.0, KolorSiersci = "czarny" },
        new Zwierze { IdZwierze = 5, Imie = "Nero", Kategoria = Kategoria.kot, Masa = 5.0, KolorSiersci = "brązowy" }
    };

    private static readonly List<Wizyta> _wizyty = new()
    {
        new Wizyta { DataWizyty = new DateTime(2024,12,25), Zwierze = _zwierzeta[0], Opis = "Zwykły przegląd", Cena = 60.00},
        new Wizyta { DataWizyty = new DateTime(2024,12,26), Zwierze = _zwierzeta[1], Opis = "Zwykły przegląd", Cena = 60.00},
        new Wizyta { DataWizyty = new DateTime(2024,12,28), Zwierze = _zwierzeta[1], Opis = "Szczepienie", Cena = 50.00}
    };
    

    [HttpGet]
    public IActionResult GetZwierze()
    {
        return Ok(_zwierzeta);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetZwierze(int id)
    {
        var zwierze = _zwierzeta.FirstOrDefault(z => z.IdZwierze == id);

        if (zwierze == null)
        {
            return NotFound("Zwierze z id " + id + " nie zostało znalezione");
        }

        return Ok(zwierze);

    }

    [HttpPost]
    public IActionResult CreateZwierze(Zwierze zwierze)
    {
        _zwierzeta.Add(zwierze);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateZwierze(int id, Zwierze zwierze)
    {
        var zwierzeEdycja = _zwierzeta.FirstOrDefault(z => z.IdZwierze == id);

        if (zwierzeEdycja == null)
        {
            return NotFound("Zwierze z id " + id + " nie zostało znalezione");
        }


        _zwierzeta.Remove(zwierzeEdycja);
        _zwierzeta.Add(zwierze);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteZwierze(int id)
    {
        var zwierzeUsuniecie = _zwierzeta.FirstOrDefault(z => z.IdZwierze == id);

        if (zwierzeUsuniecie == null)
        {
            return NotFound("Zwierze z id " + id + " nie zostało znalezione");
        }


        _zwierzeta.Remove(zwierzeUsuniecie);
        return NoContent();
    }


    [HttpGet("{id:int}/wizyty")]
    public IActionResult GetZwierzeWizyty(int id)
    {
        var zwierze = _zwierzeta.FirstOrDefault(z => z.IdZwierze == id);

        if (zwierze == null)
        {
            return NotFound("Zwierze z id " + id + " nie zostało znalezione");
        }

        var wizytyZwierze = _wizyty.Where(w => w.Zwierze.IdZwierze == id).ToList();
        return Ok(wizytyZwierze);
    }
    
    
    [HttpPost("wizyty")]
    public IActionResult CreateZwierzeWizyty([FromQuery]int id, Wizyta wizyta)
    {
        
        var zwierze = _zwierzeta.FirstOrDefault(z => z.IdZwierze == id);

        if (zwierze == null)
        {
            return NotFound("Zwierze z id " + id + " nie zostało znalezione");
        }

        wizyta.Zwierze = zwierze;
        
        _wizyty.Add(wizyta);
        return StatusCode(StatusCodes.Status201Created);
    }

    
}