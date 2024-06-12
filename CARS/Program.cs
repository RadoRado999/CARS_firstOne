using System;
using System.Collections.Generic;

class SuperCars
{
    static void UnderMenuFeatures(int optionsindex, List<Car> allCars)
    {
        int index = optionsindex;
        switch (index)
        {
            case 0:
                //add element function
                Console.Clear();
                Console.WriteLine("Заполните все характеристики:");
                Car Model = Car.ReadFromConsole();
                allCars.Add(Model);
                Console.WriteLine("Элемент успешно добавлен!" +
                                  "Нажмите Enter чтобы вернуться в главное меню.");
                Console.ReadKey();
                break;
            case 1:
                //dell all elements function
                Console.Clear();
                Console.WriteLine("Вы действительно хотите удалить все элементы? Y/n");
                do
                {
                    ConsoleKeyInfo keyinfo = Console.ReadKey();
                    if (keyinfo.KeyChar == 'Y' || keyinfo.KeyChar == 'y')
                    {
                        allCars.Clear();
                        Console.WriteLine("Все элементы удалены.");
                        break;
                    }
                    else
                    {
                        break;
                    }

                } while (true);
                Console.WriteLine("Нажмите Enter чтобы вернуться в главное меню.");
                Console.ReadKey();
                break;
            case 2:
                //dell element for index function
                Console.Clear();
                Console.WriteLine("Введите номер элемента, который хотите удалить: ");
                foreach (Car car in allCars)
                {
                    Console.WriteLine(car.ToString());
                }

                do
                {
                    int allcarsIndex;
                    if (!int.TryParse(Console.ReadLine(), out allcarsIndex) || allcarsIndex < 1 || allcarsIndex > allCars.Count + 1)
                        Console.WriteLine($"Введите эллемент от 1 до {allCars.Count - 1}");
                    else
                    {
                        allCars.RemoveAt(allcarsIndex - 1);
                        break;
                    }
                } while (true);
                break;
            case 3:
                //show all elements
                Console.Clear();
                if (allCars.Count != 0)
                {
                    Console.WriteLine("Все добавленные эллемениты: ");
                    foreach (Car car in allCars)
                    {
                        Console.Write($"{0 + 1} ");
                        Console.WriteLine(car.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Пока что нет добавленных эллементов.");
                }
                Console.ReadKey();
                break;
        }
    }
    static void Main(string[] args)
    {
        bool indicator = true;

        List<Car> allCars = new List<Car>();

        string[] Options = {"1. Добавить элемент;", "2. Удалить все элементы;", "3. Удалить елемент по индексу;",
                            "4. Показать все элементы."};
        int SelectedOption = 0;

        while (indicator)
        {
            Console.Clear();
            Console.Title = "Приложение МАШИНА";
            for (int i = 0; i < Options.Length; i++)
            {
                if (i == SelectedOption)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(Options[i]);
                Console.ResetColor();
            }

            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.UpArrow)
            {
                SelectedOption = (SelectedOption > 0) ? SelectedOption - 1 : Options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                SelectedOption = (SelectedOption + 1) % Options.Length;
            }
            else if (key == ConsoleKey.Enter)
            {
                UnderMenuFeatures(SelectedOption, allCars);
            }



            //
            //Console.WriteLine("Хотите ли вы добавить новую машину и ее характеристики? Y/n");
            //ConsoleKeyInfo keyInfo = Console.ReadKey();
            //if (keyInfo.KeyChar == 'Y' || keyInfo.KeyChar == 'y')
            //{
            //    Car Model1 = Car.ReadFromConsole();
            //}
            //else
            //{
            //    break;
            //}


            //Console.ReadKey();
            //Console.Clear();
        }

    }
    public class Car
    {
        //brand
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public int Year { get; set; }

        //engine
        public string TypeOfGaz { get; set; }
        public double EngineCapacity { get; set; }
        public string TypeOfTransmission { get; set; }
        public string TypeOfDriveUnit { get; set; }

        //other
        public int AmountOfDoors { get; set; }
        public int CarsWeight { get; set; }
        public int AmountOfSeats { get; set; }

        public static Car ReadFromConsole()
        {
            Car newCar = new Car();

            //brand
            Console.WriteLine("Введите марку: \n");
            newCar.CarBrand = Console.ReadLine();
            Console.WriteLine("Введите модель: \n");
            newCar.CarModel = Console.ReadLine();
            Console.WriteLine("Введите год выпуска: \n");
            do
            {
                int year;
                if (!int.TryParse(Console.ReadLine(), out year) || (year < 1800 || year > DateTime.Now.Year))
                {
                    Console.WriteLine("Значение должно быть целым числом, например 2004.");
                }
                else
                {
                    newCar.Year = year;
                    break;
                }
            } while (true);

            //engine
            Console.WriteLine("Введите тип горючего: \n");
            do
            {
                string[] GazType = { "Газ", "Бензин", "Дизель", "Электро", "Гибрид" };
                Console.WriteLine("Веберите один из ниже перечесленых. Введите цифру: ");
                for (int i = 0; i < GazType.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {GazType[i]}");
                }

                int choosenType;
                if (!int.TryParse(Console.ReadLine(), out choosenType) || choosenType < 1 || choosenType > 5)
                {
                    Console.WriteLine("Вводимое значение должно быть от 1 до 5.");
                }
                else
                {
                    newCar.TypeOfGaz = GazType[choosenType - 1];
                    break;
                }
            } while (true);
            Console.WriteLine("Введите объем двигателя, например 2,4: \n");
            do
            {
                double enginecapacity;
                if (!double.TryParse(Console.ReadLine(), out enginecapacity))
                {
                    Console.WriteLine("Введенное значени должно быть дробным и указано через запятую.");
                }
                else
                {
                    newCar.EngineCapacity = enginecapacity;
                    break;
                }
            } while (true);
            Console.WriteLine("Введите тип коробки передач: \n");
            do
            {
                string[] typeoftransmission = { "Автомат", "Механика", "Полу автомат" };
                Console.WriteLine("Веберите один из ниже перечесленых. Введите цифру: ");
                for (int i = 0; i < typeoftransmission.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {typeoftransmission[i]}");
                }
                int transmissionindex;
                if (!int.TryParse(Console.ReadLine(), out transmissionindex) || transmissionindex < 1 || transmissionindex > 3)
                {
                    Console.WriteLine("Введенное значение должно быть от 1 до 3");
                }
                else
                {
                    newCar.TypeOfTransmission = typeoftransmission[transmissionindex - 1];
                    break;
                }

            } while (true);
            Console.WriteLine("Введите тип привода: \n");
            do
            {
                string[] driversunit = ["Передний", "Задний", "Полний"];
                Console.WriteLine("Веберите один из ниже перечесленых. Введите цифру: ");

                for (int i = 0; i < driversunit.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {driversunit[i]}");
                }

                int unitindex;
                if (!int.TryParse(Console.ReadLine(), out unitindex) || unitindex < 1 || unitindex > 3)
                {
                    Console.WriteLine("ВвеДенное значение должно быть от 1 до 3.");
                }
                else
                {
                    newCar.TypeOfDriveUnit = driversunit[unitindex - 1];
                    break;
                }
            } while (true);

            //other
            Console.WriteLine("Введите количество дверей: \n");
            do
            {
                int amountofdoors;
                if (!int.TryParse(Console.ReadLine(), out amountofdoors) || (amountofdoors < 2 || amountofdoors > 10 || amountofdoors % 2 != 0))
                {
                    Console.WriteLine("Значние должно быть целым числом и быть в пределах от 2 до 10.");
                }
                else
                {
                    newCar.AmountOfDoors = amountofdoors;
                    break;
                }
            } while (true);
            Console.WriteLine("Введите количество массу авто в тоннах: \n");
            do
            {
                int carsweight;
                if (!int.TryParse(Console.ReadLine(), out carsweight) || carsweight < 1 || carsweight > 80)
                {
                    Console.WriteLine("Знанчие должно быть целым числом и не больше 80 тон, например 7.");
                }
                else
                {
                    newCar.CarsWeight = carsweight;
                    break;
                }
            } while (true);
            Console.WriteLine("Введите количесво мест для пассажиров: \n");
            do
            {
                int amountofseats;
                if (!int.TryParse(Console.ReadLine(), out amountofseats) || amountofseats < 2 || amountofseats > 100)
                {
                    Console.WriteLine("Введеное количество должно быть целым числом например 47.");
                }
                else
                {
                    newCar.AmountOfSeats = amountofseats;
                    break;
                }
            } while (true);

            return newCar;
        }

        public override string ToString()
        {
            return $"{CarBrand}: {CarModel} {Year}.";
        }


    }
}