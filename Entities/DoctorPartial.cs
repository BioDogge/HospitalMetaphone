using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalMetaphone.Entities
{
    public partial class Doctor
    {
        public string DoctorFioString
        {
            get
            {
                return $"{this.LastName} {this.FirstName} {this.Patronymic}";
            }
        }
    }
}
