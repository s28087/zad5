using Microsoft.AspNetCore.Mvc;
using zadanie.Models;

namespace zadanie.Controllers;

[Route("api/zwierzeta")]
[ApiController]
public class ZwierzeController : ControllerBase
{
    
    private static readonly List<Zwierze> _zwierzeta = new()
    {
        new Zwierze { IdZwierze = 1, Imie = "Azor", Kategoria = Kategoria.pies, Masa = 15.0, KolorSiersci = "biały" },
        new Zwierze { IdZwierze = 2, Imie = "Tosia", Kategoria = Kategoria.kot, Masa = 10.0, KolorSiersci = "czarny" }
    };

    [HttpGet]
    public IActionResult GetZwierze()
    {
        return Ok(_zwierzeta);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetZwierze(int id)
    {
        var zwierze = _zwierzeta.FirstOrDefault(zwierze1 => zwierze1.IdZwierze == id);

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
        var zwierzeEdycja = _zwierzeta.FirstOrDefault(zwierze1 => zwierze1.IdZwierze == id);

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
        var zwierzeUsuniecie = _zwierzeta.FirstOrDefault(zwierze1 => zwierze1.IdZwierze == id);

        if (zwierzeUsuniecie == null)
        {
            return NotFound("Zwierze z id " + id + " nie zostało znalezione");
        }


        _zwierzeta.Remove(zwierzeUsuniecie);
        return NoContent();
    }
    

}