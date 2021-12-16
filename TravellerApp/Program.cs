using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace TravellerApp
{
    class Program
    {
        private static int _action { get; set; }
        private static string _ticket { get; set; }
        private static int _id { get; set; }
        private Tour _tour { get; set; }
        public static List<Traveler> Travelers { get; set; }

        private static List<Tour> _tours { get; set; }
        static void Main(string[] args)
        {
           
                Travelers = new List<Traveler>();

                _tours = new List<Tour>()
            {
                new Tour(01, "Нидерладны", "123", "7 дней", "Приключенческий", false, 13000),
                new Tour(02, "Швеция", "223", "10 дней", "Сельский", false, 18000),
                new Tour(03, "Швейцария", "224", "3 дня", "Лечебно-оздоровительный", false, 21000),
                new Tour(04, "Япония", "225", "14 дней", "Культурно-познавательный", true, 30000),
                new Tour(05, "Китай", "226", "7 дней", "Подводный", false, 20000),
                new Tour(06, "США", "227", "20 дней", "Спортивный", true, 25000),
                new Tour(07, "Германия", "228", "12 дней", "Автомобильный", false, 15000),
                new Tour(08, "Англия", "401", "5 дней", "Культурно-познавательный", false, 23000),
                new Tour(09, "Нигерия", "402", "10 дней", "Охотничий", false, 10500 ),
            };

                while (_action != 3)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Commands();
                    Console.ForegroundColor = ConsoleColor.White;
                    Message("Введите команду: ", ConsoleColor.Yellow);
                    _action = int.Parse(Console.ReadLine());
                    switch (_action)
                    {
                        case 1:
                            foreach (var item in _tours)
                            {
                                if (item.Status == true)
                                {  
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(item.GetInfo());
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                                else
                                {

                                    Console.WriteLine(item.GetInfo());
                                
                            }
                            }
                            Message("Введите ID тура: ", ConsoleColor.Blue);
                            _id = int.Parse(Console.ReadLine());
                            var activ = _tours.FirstOrDefault(item => item.ID == _id).Status;
                            if (activ == false)
                            {
  

                                var selectTour = _tours.FirstOrDefault(item => item.ID == _id);
                                Travelers.Add(Registr(new Traveler()));
                                selectTour.Status = true;
                                Message("Tour is issued!\n", ConsoleColor.Green);
                                Message($"Сумма к оплате: {selectTour.Price} $ | Тур успешно оформлен", ConsoleColor.Green);


                                using (FileStream stream = new FileStream($"{Environment.CurrentDirectory}/traveler.csv", FileMode.Create))
                                {
                                    using (StreamWriter ar = new StreamWriter(stream))
                                    {
                                        ar.WriteLine("ID;Имя;Фамилия;Отчество;Год рождения;Пол;Серия паспрта;Номер паспорта;Адрес регистрации;Дата выдачи;Код подразделения;Кем был выдан;");
                                        foreach (var item in Travelers)
                                        {
                                            ar.WriteLine($"{item.ID};{item.Name};{item.Surname};{item.Patronymic};{item.DateOfBirth};{item.Gender};{item.Seria};{item.Number};{item.Address};{item.DateOfIssue};{item.DepartmentCode};{item.issuedBy};");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Message("Tour closed!\n", ConsoleColor.Red);
                            }
                            break;

                        case 2:
                            if (Travelers.Any())
                            {
                                foreach (var item in Travelers)
                                {
                                    Console.WriteLine(item.GetInfo());
                                }
                            }
                            else
                            {
                                Message("Error!The list is empty", ConsoleColor.Red);
                            }
                            break;
                         case 3:
                            Process.GetCurrentProcess().Kill();
                            break;
                        
                }

                Console.ReadKey();
            }
        }

            public static Traveler Registr(Traveler traveler)
            {
                if (traveler.ID == 0)
                {
                    
                    traveler = new Traveler();
                    Console.WriteLine("Введите паспортные данные ниже");
                    Console.Write("Введите ID путешественника: ");
                    traveler.ID = int.Parse(Console.ReadLine());
                    
                }
                Console.Write("Введите имя: ");
                traveler.Name = Console.ReadLine();
                Console.Write("Введите фамилию: ");
                traveler.Surname = Console.ReadLine();
                Console.Write("Введите отчество: ");
                traveler.Patronymic = Console.ReadLine();
                Console.Write("Введите год рождения: ");
                traveler.DateOfBirth = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите пол: ");
                traveler.Gender = Console.ReadLine();
                Console.Write("Введите серия паспорта: ");
                traveler.Seria = Console.ReadLine();
                Console.Write("Введите номер паспорта: ");
                traveler.Address = Console.ReadLine();
                Console.Write("Введите дата выдачи паспорта: ");
                traveler.DateOfIssue = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите код подразделения: ");
                traveler.DepartmentCode = Console.ReadLine();
                Console.Write("Введите кем был выдан: ");
                traveler.Number = Console.ReadLine();
                Console.Write("Введите адерс регистрации: ");
                traveler.issuedBy = Console.ReadLine();
                traveler.Ticket = _ticket;
                return traveler;
            }
            static void Message(string message, ConsoleColor consoleColor)
            {
                Console.ForegroundColor = consoleColor;
                Console.Write(message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        static void Commands()
        {
            Console.WriteLine("1. Оформить тур");
            Console.WriteLine("2. Вывести данные о путешественнике");
            Console.WriteLine("3. Закрыть программу");
        }

        }
      
    }

