using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellerApp
{
    class Tour
    {
      
            internal int ID { get; set; }
            internal string View { get; set; }
            internal string Duration { get; set; }
            internal string Country { get; set; }
            internal string Ticket { get; set; }
            internal bool Status { get; set; }
            internal double Price { get; set; }

            internal Tour(int id,string country,string view, string duration, string ticket, bool status, double price)
            {
                ID = id;
                View = view;
                Country = country;
                Duration = duration;
                Ticket = ticket; 
                Status = status;
                Price = price;
            }

            internal string GetInfo()
            {
                return $"ID: {ID}, Страна:{Country}, Продолжительность: {Duration}, Вид тура: {View}, Статус: {Status}, Цена: {Price} рублей";
            }
        }
    }

