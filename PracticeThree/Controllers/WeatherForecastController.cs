using Microsoft.AspNetCore.Mvc;
using UPB.PracticeThree.Models;

namespace UPB.PracticeThree.Controllers;

[ApiController]
[Route("patients")]
public class PatientController : ControllerBase
{
    public PatientController()
    {
    }

    [HttpGet]
    public List<Patient> Get()
    {
        return new List<Patient>();
    }

    [HttpGet]
    [Route("{ci}")]
    public Patient GetByCI([FromRoute] int ci)
    {
        return new Patient();
    }

    [HttpPut]
    [Route("{ci}")]
    public Patient Put([FromRoute] int ci)
    {
        return new Patient();
    }

    [HttpPost]
    public Patient Post()
    {
        return new Patient();
    }

    [HttpDelete]
    public Patient Delete()
    {
        return new Patient();
    }
}