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
            PhoneReport phoneReport = new PhoneReport
            {
                PhoneNumberRows = phones.Select(f => GetPhoneRow(f))
            };
            return phoneReport.Export();
        }

        private PhoneRow GetPhoneRow(PhoneNumber phoneNumber)
        {
            PhoneRow phoneRow = new PhoneRow()
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

        public byte[] GetEquipmentReport(IQueryable<Computer> computer)
        {
            EquipmentReport equipmentReport = new EquipmentReport
            {
                EquipmentRow = computer.Select(f => GetEquipmentRow(f))
            };
            return equipmentReport.Export();
        }

        private EquipmentRow GetEquipmentRow(Computer computer)
        {
            EquipmentRow equipmentRow = new EquipmentRow()
            {
                Computer = GetEquipmentData(computer)
            };

            return equipmentRow;
        }

        private Computer GetEquipmentData(Computer computer)
        {
            return new Computer
            {
                Firstname = computer.Firstname,
                Realname = computer.Realname,
                Type = computer.Type,
                Producer = computer.Producer,
                Code = computer.Code,
                Model = computer.Model,
                Serial = computer.Serial
            };
        }
    }
}
