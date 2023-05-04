using UPB.CoreLogic.Models;

namespace UPB.CoreLogic.Managers;

public class PatientManager 
{
    private List<Patient> _patients;
    public PatientManager()
    {
        _patients = new List<Patient>();
    }
    public List<Patient> GetAll()
    {
        return _patients;
    }

    public Patient GetByCI(int ci)
    {
        return _patients.Find(patient => patient.CI == ci);
    }

    public Patient Update(int ci)
    {
        if (ci < 0)
        {
            throw new Exception("CI invalido");
        }

        Patient patientFound;
        patientFound = _patients.Find(patient => patient.CI == ci);

        if (patientFound == null)
        {
            throw new Exception("no se encontro un estudiante");
        }
        patientFound.Name = "Cambiado";

        return patientFound;
    }

    public Patient Create(string name, string lastname, int ci)
    {
        Patient createdPatient = new Patient()
        {
            Name = name,
            LastName = lastname,
            CI = ci
        };
        _patients.Add(createdPatient);
        return createdPatient;
    }

    public Patient Delete (int ci)
    {
        int patientToDeleteIndex = _patients.FindIndex(student => student.CI == ci);
        Patient patientToDelete = _patients[patientToDeleteIndex];
        _patients.RemoveAt(patientToDeleteIndex);
        return patientToDelete;
    }
}