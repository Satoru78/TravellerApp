using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellerApp
{
      public class Traveler
          {
      
            internal int ID { get; set; }
            internal string Name { get; set; }
            internal string Surname { get; set; }
            internal string Patronymic { get; set; }
            internal string Number { get; set; }
            internal string DepartmentCode { get; set; }
            internal DateTime DateOfBirth { get; set; }
            internal string Gender { get; set; }
            internal string Seria { get; set; }
            internal string issuedBy { get; set; }
            internal string Ticket { get; set; }
            internal string Address { get; set; }
            internal DateTime DateOfIssue { get; set; }

           
            


            internal string GetInfo()
            {
                if (!string.IsNullOrEmpty(Name) || !string.IsNullOrEmpty(Surname) || !string.IsNullOrEmpty(Ticket))
                {
                    return $"ID: {ID}, Имя: {Name} Фамилия: {Surname} Билет: {Ticket}";
                }
                else
                {
                    return "Not found";
                }
            }
        }
    }
