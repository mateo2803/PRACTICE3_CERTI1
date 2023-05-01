using Microsoft.AspNetCore.Mvc;
using UPB.PracticeThree.Managers;
using UPB.PracticeThree.Models;

namespace UPB.PracticeThree.Controllers;

[ApiController]
[Route("patients")]
public class PatientController : ControllerBase
{

    private PatientManager _patientmanager;
    public PatientController()
    {
        _patientmanager = new PatientManager();
    }

    [HttpGet]
    public List<Patient> Get()
    {
        return _patientmanager.GetAll();
    }

    [HttpGet]
    [Route("{ci}")]
    public Patient GetByCI([FromRoute] int ci)
    {
        return _patientmanager.GetByCI(ci);
    }

    [HttpPut]
    [Route("{ci}")]
    public Patient Put([FromRoute] int ci)
    {
        return _patientmanager.Update(ci);
    }

    [HttpPost]
    public Patient Post()
    {
        return _patientmanager.Create();
    }

    [HttpDelete]
    public Patient Delete()
    {
        return _patientmanager.Delete();
    }
}