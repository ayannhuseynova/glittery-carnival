using System;
using Final_Project.Models;
using System.Reflection;
using Final_Project.Services.Implementations;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

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
            SeedDatabase(employeeService, branchService);

        Login:
            string username = "Luna";
            string password = "11july2020";
            Console.Write("Please enter ur username: ");
            string username1 = Console.ReadLine();
            Console.Write("Please enter ur password: ");
            string password1 = Console.ReadLine();

            if (username == username1 && password == password1)
            {
            MainMenu:
                Console.Clear();
                Console.WriteLine($"Welcome back, {username}");
                Console.WriteLine("Choose one:");
                Console.WriteLine("1. Branch Operations");
                Console.WriteLine("2. Employee Operations");
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Type in a number! Press any key to continue");
                    Console.ReadKey();
                    goto MainMenu;
                }
                if (choice >= 0 || choice < 6 || choice == 10)
                {
                MenuSec:
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            FirstMenu();
                            int firstMenuOperations;
                            try
                            {
                                firstMenuOperations = int.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Type in a number! Press any key to continue");
                                Console.ReadKey();
                                goto MainMenu;
                            }
                            if (firstMenuOperations >= 0 || firstMenuOperations <= 5 || firstMenuOperations == 10)
                            {
                                switch (firstMenuOperations)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Please enter Name, Address, Budget on the NewBranch: ");
                                        string newname1 = Console.ReadLine();
                                        string newaddress1 = Console.ReadLine();
                                        decimal newbudget1 = decimal.Parse(Console.ReadLine());
                                        if (newname1 != null && newaddress1 != null && newbudget1 != 0)
                                        {
                                            Branch branew = new Branch(newname1, newaddress1, newbudget1);
                                            branchService.Create(branew);
                                            Console.WriteLine(branew.Name + ", " + branew.Address + ", " + branew.Budget + "\n");
                                            branchService.GetEverything();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Pls enter input that is not null or zero, press any key to return Menu");
                                        }
                                        Console.ReadKey();
                                        goto MenuSec;
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("Type in the name of a branch which you want to delete");
                                        string delName = Console.ReadLine();
                                        if (delName != null)
                                        {
                                            branchService.Delete(delName);
                                        }
                                        Console.ReadKey();
                                        goto MenuSec;
                                    case 3:
                                        Console.Clear();
                                        Console.WriteLine("Type in the name of a branch to update the address and the budget");
                                        string updName = Console.ReadLine();
                                        Console.WriteLine("Type in the new address and on the new line new budget");
                                        string updAddress = Console.ReadLine();
                                        decimal updBudget = decimal.Parse(Console.ReadLine());
                                        if (updBudget != 0 && updAddress != null && updName != null)
                                        {
                                            branchService.Update(updName, updBudget, updAddress);
                                            branchService.GetEverything();
                                        }
                                        Console.ReadKey();
                                        goto MenuSec;
                                    case 4:
                                        Console.Clear();
                                        Console.Write("Type in the name of a branch to find it: ");
                                        string getName1 = Console.ReadLine();
                                        if (getName1 != null)
                                        {
                                            branchService.Get(getName1);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No such branch was found! Press any key to try again");
                                            Console.ReadKey();
                                            goto MenuSec;
                                        }
                                        Console.ReadKey();
                                        goto MenuSec;
                                    case 5:
                                        Console.Clear();
                                        branchService.GetEverything();
                                        Console.WriteLine("To go back press any key");
                                        Console.ReadKey();
                                        goto MenuSec;
                                    case 6:
                                        Console.Clear();
                                        Console.WriteLine("Type in the name of a branch to sum up a profit");
                                        string braNameProf = Console.ReadLine();
                                        branchService.GetProfit(braNameProf);
                                        Console.WriteLine("Press any key to return to menu");
                                        Console.ReadKey();
                                        goto MenuSec;
                                    case 7:                                          //HireEmployee
                                                                                     //Console.Clear();
                                                                                     //Console.WriteLine("Pls enter Branch name to Hire employee");
                                                                                     //string hireBraName = Console.ReadLine();
                                                                                     //Branch hireBranch = branchService.Get(hireBraName);
                                                                                     //if (hireBranch == null)
                                                                                     //{
                                                                                     //    Console.WriteLine(" Branch is not available");
                                                                                     //}

                                        //Console.WriteLine("Pls enter Employee name to Hire employee");
                                        //string hireEmpName = Console.ReadLine();
                                        //Employee hireEmployee = employeeService.Get(hireEmpName);
                                        //if (hireEmployee != null)
                                        //{
                                        //    if (hireEmployee.Salary < hireBranch.Budget)
                                        //    {
                                        //        hireBranch.Employees.Add(hireEmployee);
                                        //        Console.WriteLine("Employee hired successfully");
                                        //    }
                                        //    else
                                        //    {
                                        //        Console.WriteLine("Budget is not enough");
                                        //    }
                                        //}
                                        //else
                                        //{
                                        //    Console.WriteLine("employee is not available");
                                        //}
                                        Console.ReadKey();
                                        goto MenuSec;
                                    case 8:
                                        Console.Clear();
                                        Console.WriteLine("Type in the name of branches and the name of an employee whom you want to transfer");
                                        string fromBraName = Console.ReadLine();
                                        string toBraName = Console.ReadLine();
                                        string nameEmp = Console.ReadLine();
                                        branchService.TransferEmployee(fromBraName, toBraName, nameEmp);
                                        Console.ReadKey();
                                        goto MenuSec;
                                    //case 9:
                                    //    Console.Clear();
                                    //    Console.Write("Select First Branch :");
                                    //    var first__branch = Console.ReadLine();
                                    //    Console.Write("Select Second Branch :");
                                    //    var second__branch = Console.ReadLine();
                                    //    Console.Write("Enter Budget :");
                                    //    decimal budget = decimal.Parse(Console.ReadLine());
                                    //    branchService.TransferMoney(first__branch, second__branch, budget);
                                    //    Console.ReadKey();
                                    //    goto MenuSec;
                                    case 10:
                                        Console.Clear();
                                        Console.WriteLine("Going back to main menu, press any key to continue");
                                        Console.ReadKey();
                                        goto MenuSec;
                                    case 0:
                                        Console.Clear();
                                        Console.WriteLine("Press any key to quit !");
                                        Console.ReadKey();
                                        Environment.Exit(0);
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid! Press any key to return to Main Menu");
                                Console.ReadKey();
                                goto MainMenu;
                            }
                            break;

                        case 2:
                            Console.Clear();
                            SecondMenu();
                            int secondMenuOperations;
                            try
                            {
                                secondMenuOperations = int.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Type in a number! Press any key to continue");
                                Console.ReadKey();
                                goto MainMenu;
                            }
                            if (secondMenuOperations >= 0 || secondMenuOperations <= 5 || secondMenuOperations == 10)
                            {
                                switch (secondMenuOperations)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Type in the Name, Surname and the salary");
                                        string newName2 = Console.ReadLine();
                                        string newSurname2 = Console.ReadLine();
                                        decimal newSalary = decimal.Parse(Console.ReadLine());
                                        string newProfess = Console.ReadLine();
                                        if (newName2 != null && newSurname2 != null && newProfess != null && newSalary != 0)
                                        {
                                            Employee empnew = new Employee(newName2, newSurname2, newSalary, newProfess, false);
                                            employeeService.Create(empnew);
                                            Console.WriteLine($"You hired a new employee: {newName2} {newSurname2} with salary {newSalary} for the {newProfess} position");
                                            employeeService.GetEverything();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid! Press any key to return to Main Menu");
                                        }
                                        Console.ReadKey();
                                        goto MenuSec;

                                    case 2:
                                        Console.Clear();
                                        Console.Write("Type in the name of an employee to delete it: ");

                                        string delName1 = Console.ReadLine();
                                        if (delName1 != null)
                                        {
                                            employeeService.Delete(delName1);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid! Press any key to return to Main Menu");
                                        }
                                        Console.WriteLine("Press any key to return to main menu");
                                        Console.ReadKey();
                                        goto MenuSec;
                                    case 3:
                                        Console.Clear();
                                        Console.WriteLine("Type in the name of an employee whom you want to update");
                                        string updName1 = Console.ReadLine();
                                        if (updName1 != null)
                                        {
                                            Console.WriteLine("Type in the new salary and the new profession");
                                            decimal updSalary1 = decimal.Parse(Console.ReadLine());
                                            string updProfess1 = Console.ReadLine();
                                            if (updProfess1 != null && updSalary1 != 0)
                                            {
                                                employeeService.Update(updName1, updSalary1, updProfess1);
                                                employeeService.GetEverything();
                                            }
                                        }
                                        Console.WriteLine("Press any key to return to main menu");
                                        Console.ReadKey();
                                        goto MenuSec;
                                    case 4:
                                        Console.Clear();
                                        Console.Write("Type in the name of an employee to find it: ");
                                        string getName2 = Console.ReadLine();
                                        if (getName2 != null)
                                        {
                                            employeeService.Get(getName2);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid! Press any key to return to Main Menu");
                                        }
                                        Console.WriteLine("Press any key to return Menu");
                                        Console.ReadKey();
                                        goto MenuSec;
                                    case 5:
                                        Console.Clear();
                                        employeeService.GetEverything();
                                        Console.WriteLine("Press any key to return to main menu");
                                        Console.ReadKey();
                                        goto MenuSec;
                                    case 10:
                                        Console.Clear();
                                        Console.WriteLine("Going back to main menu, press any key to continue");
                                        Console.ReadKey();
                                        goto MenuSec;
                                    case 0:
                                        Console.Clear();
                                        Console.WriteLine("Press any key to quit!");
                                        Console.ReadKey();
                                        Environment.Exit(0);
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid! Press any key to return to Main Menu");
                                Console.ReadKey();
                                goto MainMenu;
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid! Press any key to return to Main Menu");
                    Console.ReadKey();
                    goto MainMenu;
                }
            }
            else
            {
                Console.WriteLine("Either the username or the password is incorrect! Press any key to try again");
                Console.ReadKey();
                goto Login;
            }

            static void FirstMenu()
            {
                Console.WriteLine("Choose one from the list shown below: ");
                Console.WriteLine("Press 1 to Create");
                Console.WriteLine("Press 2 to Delete");
                Console.WriteLine("Press 3 to Update");
                Console.WriteLine("Press 4 to Get");
                Console.WriteLine("Press 5 to GetEverything");
                Console.WriteLine("Press 6 to Sum Profit");
                Console.WriteLine("Press 7 to Hire a new employee");
                Console.WriteLine("Press 8 to Transfer an employee");
                Console.WriteLine("---------------------");
                Console.WriteLine("---------------------");
                Console.WriteLine("---------------------");
                Console.WriteLine("Press 10 to go back to Main Menu");
                Console.WriteLine("Press 0 to quit and then press Enter to Quit");
            }

            static void SecondMenu()
            {
                Console.WriteLine("Choose one from the list shown below: ");
                Console.WriteLine("Click 1 to Create");
                Console.WriteLine("Click 2 to Delete");
                Console.WriteLine("Click 3 to Update");
                Console.WriteLine("Click 4 to Get");
                Console.WriteLine("Click 5 to Get All");
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

            branchService.bank.Datas.Add(branch1);
            branchService.bank.Datas.Add(branch2);
            branchService.bank.Datas.Add(branch3);

            branch1.Employees.Add(employee1);
            branch1.Employees.Add(employee2);
            branch2.Employees.Add(employee3);
            branch2.Employees.Add(employee4);
            branch3.Employees.Add(employee5);

            employeeService.bank.Datas.Add(employee1);
            employeeService.bank.Datas.Add(employee2);
            employeeService.bank.Datas.Add(employee3);
            employeeService.bank.Datas.Add(employee4);
            employeeService.bank.Datas.Add(employee5);
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

//IBankService - hər iki service-lərin ortaq methodlarını özündə cəmləyir. Bunlar Create, Update, Delete, Get, GetEverything methodlarıdır.
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
//GetEverything - SoftDelete`i false olan bütün dataları qaytarır.
//Delete - Silmək istədiyimiz elementin softDelete`ini true edin.


//Sonuncu mərhələ yəni UI (Console)
//Manager Login olur. Menyuda 2 seçim çıxır - Branch və Employee. Manager hansını seçsə ekrana ona uyğun methodları çıxır.
//Yəni müvafiq service-ə uyğun methodlar adlarına görə sıralanacaq, seçdiyi əməliyyatı aparacaq.
//Hər əməliyyat bitdikdə menyu ən ilk halına qayıdacaq. 

//Optional olaraq - quit və back funksionallığı əlavə edə bilərsiniz.

//Uğurlar!

