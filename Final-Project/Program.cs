using System;
using Final_Project.Models;
using System.Reflection;

namespace Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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

