using UPB.CoreLogic.Models;
using System;
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
            throw new Exception("Invalid CI");
        }

        Patient patientFound;
        patientFound = _patients.Find(patient => patient.CI == ci);

        if (patientFound == null)
        {
            throw new Exception("Patient not found");
        }
        patientFound.Name = "Updated";

        return patientFound;
    }

    public Patient Create(string name, string lastname, int ci)
    {
        string[] tiposDeSangre = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
        Random random = new Random();
        int randomIndex = random.Next(tiposDeSangre.Length);
        string randomChoice = tiposDeSangre[randomIndex];
        
        Patient createdPatient = new Patient()
        {
            Name = name,
            LastName = lastname,
            CI = ci,
            Bi = randomChoice
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