using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLPI_MySQL.Models
{
    public class Excel_Docs
    {
        public byte[] GetPhoneReport(IQueryable<PhoneNumber> phones)
        {
            var phoneReport = new PhoneReport
            {
                PhoneNumberRows = phones.Select(f => GetPhoneRow(f)),
            };
            return phoneReport.Export();
        }

        private PhoneRow GetPhoneRow(PhoneNumber phoneNumber)
        {
            var phoneRow = new PhoneRow()
            {
                PhoneNumber = GetPhoneData(phoneNumber)
            };

            return phoneRow;
        }

        private PhoneNumber GetPhoneData(PhoneNumber phoneNumber)
        {
            return new PhoneNumber
            {
                Firstname = phoneNumber.Firstname,
                Realname = phoneNumber.Realname,
                Department = phoneNumber.Department,
                ContactNumber = phoneNumber.ContactNumber
            };
        }
    }
}
