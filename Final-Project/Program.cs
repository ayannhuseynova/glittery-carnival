using System;
using Final_Project.Models;
using System.Reflection;
using Final_Project.Services.Implementations;
using System.Collections.Generic;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            BranchService branchService = new BranchService();
            EmployeeService employeeService = new EmployeeService();

        Login:
            string username = "Luna";
            string password = "11july2020";
            Console.Write("Please enter ur username: ");
            string username1 = Console.ReadLine();
            Console.Write("Please enter ur password: ");
            string password1 = Console.ReadLine();

            if (username == username1 && password == password1)
            {
                Again:
                Console.Clear();
                Console.WriteLine($"Welcome back, {username}");
                Console.WriteLine("Press 1 to choose branch");
                Console.WriteLine("Press 2 to choose employee");
                Console.Write("Please choose one: ");
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Format is not correct, press any key to start again.");
                    Console.ReadKey();
                    goto Again;
                }
                if (choice == 1 || choice == 2)
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            FirstMenu();
                            int firstMenuChoices;
                            try
                            {
                                firstMenuChoices = int.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Format is not correct, press any key to start again");
                                Console.ReadKey();
                                goto Again;
                            }
                            if (firstMenuChoices < 0 || firstMenuChoices > 11)
                            {
                                switch (firstMenuChoices)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Enter name, address and the new budget for a new branch");
                                        string createName = Console.ReadLine();
                                        string createAddress = Console.ReadLine();
                                        decimal createBudget = decimal.Parse(Console.ReadLine());

                                        if (createName != null && createAddress != null && createBudget != 0)
                                        {
                                            Branch newBranch = new Branch(createName, createAddress, createBudget);
                                            branchService.Create(newBranch);
                                            Console.WriteLine($"New branch is ready! Name {createName}, address {createAddress}, and the budget is {createBudget}");
                                            branchService.GetEverything();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Enter a valid data");
                                        }
                                        Console.ReadKey();
                                        goto Again;
                                    case 2:
                                        Console.Clear();
                                        Console.Write("Type in the name of a branch which you want to delete: ");
                                        string deleteBranch = Console.ReadLine();
                                        if (deleteBranch != null)
                                        {
                                            branchService.Delete(deleteBranch);
                                        }
                                        Console.ReadKey();
                                        goto Again;
                                    case 3:
                                        Console.Clear();
                                        Console.Write("Type in the name of a branch which you want to update: ");
                                        string updateName = Console.ReadLine();
                                        Console.WriteLine("Type in the address and the budget");
                                        string updateAddress = Console.ReadLine();
                                        decimal updateBudget = decimal.Parse(Console.ReadLine());

                                        if (updateBudget != 0 && updateAddress != null && updateName != null)
                                        {
                                            branchService.Update(updateName, updateBudget, updateAddress);
                                            branchService.GetEverything();
                                        }
                                        Console.ReadKey();
                                        goto Again;
                                    case 4:
                                        Console.Clear();
                                        Console.Write("Type in the name of a branch to find it: ");
                                        string typeName = Console.ReadLine();
                                        if (typeName != null)
                                        {
                                            branchService.Get(typeName);
                                        }
                                        else
                                        {
                                            Console.WriteLine("no such information considering the type-in");
                                        }
                                        Console.ReadKey();
                                        goto Again;
                                    case 5:
                                        Console.Clear();
                                        branchService.GetEverything();
                                        Console.ReadKey();
                                        goto Again;
                                    case 6:
                                        Console.Clear();
                                        branchService.GetProfit();
                                        Console.ReadKey();
                                        goto Again;
                                    case 7:
                                        Console.Clear();
                                        Console.Write("Type in the name of a new employee: ");
                                        string newEmployee = Console.ReadLine();
                                        branchService.HireEmployee(newEmployee);
                                        Console.ReadKey();
                                        goto Again;
                                    case 8:
                                        Console.Clear();
                                        branchService.TransferEmployee();
                                        Console.ReadKey();
                                        goto Again;
                                    case 9:
                                        Console.Clear();
                                        Console.Write("Select the first branch: ");
                                        string firstBranch = Console.ReadLine();
                                        Console.Write("Select the second branch: ");
                                        string secondBranch = Console.ReadLine();
                                        Console.Write("Type in the budget: ");
                                        int budget = int.Parse(Console.ReadLine());
                                        branchService.TransferMoney(firstBranch, secondBranch, budget);
                                        branchService.GetEverything();
                                        Console.ReadKey();
                                        goto Again;
                                    case 10:
                                        Console.Clear();
                                        Console.WriteLine("Press any key to go back to the main menu");
                                        Console.ReadKey();
                                        goto Again;
                                    case 0:
                                        Console.Clear();
                                        Console.WriteLine("Press any key to quit");
                                        Console.ReadKey();
                                        Environment.Exit(0);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Press the digit that exists on screen");
                                Console.ReadKey();
                                goto Again;
                            }
                            break;

                        case 2:
                            Console.Clear();
                            SecondMenu();
                            int secondMenuChoices;
                            try
                            {
                                secondMenuChoices = int.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Format is not correct, press any ket to star again");
                                Console.ReadKey();
                                goto Again;
                            }
                            if (secondMenuChoices < 0 || secondMenuChoices > 11)
                            {
                                switch (secondMenuChoices)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Enter the name, surname, salary and the profession by order: ");
                                        string newName = Console.ReadLine();
                                        string newSurname = Console.ReadLine();
                                        decimal newSalary = int.Parse(Console.ReadLine());
                                        string newProfession = Console.ReadLine();
                                        if (newName != null || newSurname != null && newProfession != null)
                                        {
                                            Employee newEmployee = new Employee(newName, newSurname, newSalary, newProfession, false);
                                            employeeService.Create(newEmployee);
                                            Console.WriteLine($"New employee {newName + " " + newSurname}, Salary is {newSalary}, profession is {newProfession}");
                                            employeeService.GetEverything();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Wrong format, press any key to begin again");
                                            Console.ReadKey();
                                            goto Again;
                                        }
                                        break;
                                    case 2:
                                        Console.Clear();
                                        Console.Write("Type in the name of an employee to delete it: ");
                                        string deleteEmployee = Console.ReadLine();
                                        if (deleteEmployee != null)
                                        {
                                            employeeService.Delete(deleteEmployee);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Wrong format, press any key to start again");
                                            Console.ReadKey();
                                            goto Again;
                                        }
                                        break;
                                    case 3:
                                        Console.Clear();
                                        Console.WriteLine("Type in the name of an employee to update");
                                        string updateName = Console.ReadLine();
                                        if (updateName != null)
                                        {
                                            Console.WriteLine("Type in the new salary and the name of a new profession");
                                            decimal updateSalary = decimal.Parse(Console.ReadLine());
                                            string updateProfession = Console.ReadLine();
                                            if (updateProfession != null && updateSalary != 0)
                                            {
                                                employeeService.Update(updateName, updateSalary, updateProfession);
                                                employeeService.GetEverything();
                                            }
                                        }
                                        Console.ReadKey();
                                        goto Again;
                                    case 4:
                                        Console.Clear();
                                        Console.Write("Type in the name of an employee to find it: ");
                                        string findEmployee = Console.ReadLine();
                                        if (findEmployee != null)
                                        {
                                            branchService.Get(findEmployee);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Wrong format, press any key to start again");
                                        }
                                        Console.ReadKey();
                                        goto Again;
                                    case 5:
                                        Console.Clear();
                                        employeeService.GetEverything();
                                        Console.ReadKey();
                                        goto Again;
                                    case 10:
                                        Console.Clear();
                                        Console.WriteLine("Press any key, to go back to the main menu");
                                        Console.ReadKey();
                                        goto Again;
                                    case 0:
                                        Console.Clear();
                                        Console.WriteLine("Press any key to quit");
                                        Console.ReadKey();
                                        Environment.Exit(0);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Press the digit that exists on screen");
                                Console.ReadKey();
                                goto Again;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Either the username or the password is incorrect, try again! :((");
                Console.ReadKey();
                goto Login;
            }

            static void FirstMenu()
            {
                Console.WriteLine("Please select your transaction");
                Console.WriteLine("Press 1 to to Create");
                Console.WriteLine("Press 2 to to Delete");
                Console.WriteLine("Press 3 to to Update");
                Console.WriteLine("Press 4 to to Get");
                Console.WriteLine("Press 5 to to GetAll");
                Console.WriteLine("---------------------");
                Console.WriteLine("---------------------");
                Console.WriteLine("---------------------");
                Console.WriteLine("Press 10 to go back to Main Menu");
                Console.WriteLine("Press 0 to quit and then press Enter to Quit");
            }

            static void SecondMenu()
            {
                Console.WriteLine("Please select your transaction");
                Console.WriteLine("Click 1 to to Create");
                Console.WriteLine("Click 2 to to Delete");
                Console.WriteLine("Click 3 to to Update");
                Console.WriteLine("Click 4 to to Get");
                Console.WriteLine("Click 5 to to Get All");
                Console.WriteLine("Click 6 to to Get Profit");
                Console.WriteLine("Click 7 to to Hire Employee");
                Console.WriteLine("Click 8 to to Transfer Employee");
                Console.WriteLine("Click 9 to to Transfer Money");
                Console.WriteLine("---------------------");
                Console.WriteLine("---------------------");
                Console.WriteLine("---------------------");
                Console.WriteLine("Press 10 to go back to Main Menu");
                Console.WriteLine("Press 0 to quit and then press Enter to Quit");
            }

        }
        public static void SeedDatabase(EmployeeService employeeService, BranchService branchService)
        {
            List<Employee> employees = new List<Employee>();
            Employee employee1 = new Employee("Lola", "Lolka", 3400, "Cutie Pie", false);
            Employee employee2 = new Employee("Kyla", "Kylka", 2100, "Smol Bean", false);
            Employee employee3 = new Employee("Sammy", "Sam", 1700, "Sweety", false);
            Employee employee4 = new Employee("Tinky", "Winky", 4500, "Cutest Dog Ever", false);
            Employee employee5 = new Employee("Glittery", "Carnival", 2304, "Bright Carnival", false);


            Branch branch1 = new Branch("New York", "5th Avenue", 70000);
            Branch branch2 = new Branch("San-Francisco", "Kingway West", 53000);
            Branch branch3 = new Branch("Toronto", "Kingsley", 23555);
        }
    }
}

//Bank Application

//Layihəmiz folder məntiqi ilə qurulmalıdır. Ümumi 3 folderə bölünəcək.

//1-ci folder:Data.Data folderi özündə Generic Bank class-ı saxlayacaq.Bank database məqsədi daşıyır.

//2-ci folder:Models.Models folderi bizim bütün proyektimizdə olan modelləri saxlayır.
//Bu modellər: Manager,Branch,Employee.Manager bizim bütün prosesi idarə edən "admin"-dir.
//Branch və Employee isə üzərində əməliyyatlar apardığımız modellərdir.
//Database funksiyası daşıyan Bank özündə Employee və Branch saxlayacaq.Manageri yox.

//Manager Properties: name,surname,username,password,SoftDelete
//Employee Properties: name,surname,salary,profession,SoftDelete
//Branch Properties: name,address,budget,employees,SoftDelete
//Ortaq property-lər əlavə modelə çıxarılsın.

//3-cü folder:Services.Services özündə Interfaces və Implementations folderlərini saxlayır. Interfaces folderində 
//interface-lər, implementations folderində onların implementationları olur.

//Interfaces - IBankService, IEmployeeService, IBranchService
//Implementations - EmployeeService, BranchService

//IBankService - hər iki service-lərin ortaq methodlarını özündə cəmləyir. Bunlar Create, Update, Delete, Get, GetAll methodlarıdır.
//IEmployeeService - yalnız employee-yə aid olan methodları saxlayır. Bunlar: Employeenin özünəməxsus methodu yoxdur. IBankService-dəki methodları işlədəcək.
//IBranchService - yalnız branch-a aid olan methodları saxlayır. Bunlar:  HireEmployee,GetProfit,TransferMoney,TransferEmployee



//Proyektdə Dependency Injection istifadə edin.

//HireEmployee - mövcud olan employeelərdən həmin brancha employee əlavə edir.Yenisini yaratmır.Büdcədən həmin işçinin maaşı çıxmalıdır.(optional olaraq - götürdüyünüz işçinin 
//maaşı büdcədən çox ola bilməz)
//GetProfit - həmin filialın gəlirlərini hesablayır.Bu ümumi büdcədən işçilərin maaşını çıxmaqla əldə edilir.
//TransferMoney - həmin branchdan başqa brancha pul köçürməsi edir. Bizim branchın büdcəsindən həmin məbləğ silinir. Göndərmək istədiyimiz branchın budgetinə əlavə olunur.
//TransferEmployee - həmin branchdan başqa brancha employee köçürməsi edir.
//(Köçürmə etmək istədiyiniz branchı adına görə axtara bilərsiniz)
//Create - Daxil elədiyimiz datalara uyğun obyekt yaradır.Database`ə əlavə edir.Yaranan obyektin SoftDelete`i default olaraq false olmalıdır.
//Update - seçilmiş obyektin datalarını yenisi ilə dəyişir(adına görə tapa bilərsiniz).Branchda budgeti, Employeedə salary və profession dəyişdirsin.
//Get - şərtə uyğun obyekti qaytarır
//GetAll - SoftDelete`i false olan bütün dataları qaytarır.
//Delete - Silmək istədiyimiz elementin softDelete`ini true edin.


//Sonuncu mərhələ yəni UI (Console)
//Manager Login olur. Menyuda 2 seçim çıxır - Branch və Employee. Manager hansını seçsə ekrana ona uyğun methodları çıxır.
//Yəni müvafiq service-ə uyğun methodlar adlarına görə sıralanacaq, seçdiyi əməliyyatı aparacaq.
//Hər əməliyyat bitdikdə menyu ən ilk halına qayıdacaq. 

//Optional olaraq - quit və back funksionallığı əlavə edə bilərsiniz.

//Uğurlar!

