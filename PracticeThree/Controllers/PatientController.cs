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
        Patient createdPatient = _patientManager.Create(patientToCreate.Name, patientToCreate.LastName, patientToCreate.CI);
         WritePatientsToFile(_patientManager.GetAll());
         return createdPatient;
    }

    [HttpDelete]
    public Patient Delete([FromRoute] int id)
    {
        return _patientManager.Delete(id);
    }

    private const string filePath = "/Users/mateo/Downloads/patients.txt";

    private void WritePatientsToFile(IEnumerable<Patient> patients)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (Patient p in patients)
            {
                string line = $"{p.Name},{p.LastName},{p.CI},{p.Bi}";
                sw.WriteLine(line);
                Console.WriteLine("archivo creado");
            }
        }
    }

    private List<Patient> ReadPatientsFromFile()
    {
        List<Patient> patients = new List<Patient>();
        if (!System.IO.File.Exists(filePath))
        {
            return patients;
        }

        using (StreamReader sr = new StreamReader(filePath))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                Patient p = new Patient()
                {
                    Name = parts[0],
                    LastName = parts[1],
                    CI = int.Parse(parts[2]),
                    Bi = parts[3]
                };
                patients.Add(p);
            }
        }

        return patients;
}
}