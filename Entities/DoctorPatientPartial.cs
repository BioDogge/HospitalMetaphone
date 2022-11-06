using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMetaphone.Entities
{
    public partial class DoctorPatient
    {
        public string DoctorFioString
        {
            get
            {
                var doctor = App.Context.Doctor.ToList().First(p => p.Id == this.IdDoctor);
                
                if (doctor != null)
                    return $"{doctor.FirstName} {doctor.LastName} {doctor.Patronymic}";
                else
                    return "";
            }
        }

        public string DoctorSpecialityString
        {
            get
            {
                var doctor = App.Context.Doctor.ToList().First(p => p.Id == this.IdDoctor);

                if (doctor != null)
                    return doctor.Speciality;
                else
                    return "";
            }
        }

        public string PatientFioString
        {
            get
            {
                var patient = App.Context.Patient.ToList().First(p => p.Id == this.IdPatient);

                if (patient != null)
                    return $"{patient.FirstName} {patient.LastName} {patient.Patronymic}";
                else
                    return "";
            }
        }

        public string DiagnosisString
        {
            get
            {
                var diagnosis = App.Context.Diagnosis.ToList().First(p => p.Id == this.IdDiagnosis);

                if (diagnosis != null)
                    return diagnosis.Title;
                else
                    return "";
            }
        }
    }
}
