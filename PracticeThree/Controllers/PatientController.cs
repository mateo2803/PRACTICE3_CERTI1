using Microsoft.AspNetCore.Mvc;
using UPB.CoreLogic.Managers;
using UPB.CoreLogic.Models;

namespace UPB.PracticeThree.Controllers;

[ApiController]
[Route("patients")]
public class PatientController : ControllerBase
{

    private PatientManager _patientManager;
    public PatientController()
    {
        _patientManager = new PatientManager();
    }

    [HttpGet]
    public List<Patient> Get()
    {
        return _patientManager.GetAll();
    }

    [HttpGet]
    [Route("{ci}")]
    public Patient GetByCI([FromRoute] int ci)
    {
        return _patientManager.GetByCI(ci);
    }

    [HttpPut]
    [Route("{ci}")]
    public Patient Put([FromRoute] int ci)
    {
        return _patientManager.Update(ci);
    }

    [HttpPost]
    public Patient Post([FromBody]Patient patientToCreate)
    {
        return _patientManager.Create(patientToCreate.Name, patientToCreate.LastName, patientToCreate.CI);
    }

    [HttpDelete]
    public Patient Delete([FromRoute] int id)
    {
        return _patientManager.Delete(id);
    }
}