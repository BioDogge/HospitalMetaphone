using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMetaphone.Entities
{
    public partial class Patient
    {
        public string PatientFioString
        {
            get
            {
                return $"{LastName} {FirstName} {Patronymic}";
            }
        }
    }
}
