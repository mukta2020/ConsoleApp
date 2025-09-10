//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CodingConsoleApp
//{
//    internal class Class1
//    {
//    }

//    class student
//    {
//        public string name { set; get; }
//    }


class student
{
    private string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}


//    student s1 = new student();
//    s1.name = "xyz";

//     student s2 = s1;

//    s2.name = "rahim";

//        console.writeline(s1.name);



//        List<student> list = new List<student>();

//    list.add(s1);
//        list.add(s2);


//         List<student> list1 = new List<student>();

//    foreach(student s in list )
//        {
//        console.writeline(s.name);
//        list.add(s3);
//        list1.

//}

//API Versioning in ASP.NET Core C#

//List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//// Using IEnumerable (works in-memory)
//IEnumerable<int> evenNumbers = numbers.Where(n => n % 2 == 0);


//IEnumerable<FileLog> fileLogsEnu = _repositoryContext.FileLog.ToList(); // Fetches all users first
//var filtered = fileLogsEnu.Where(w => w.FileType == fileType);          // Filters in-memory

//IQueryable<FileLog> fileLogsQuery = _repositoryContext.FileLog.Where(w => w.FileType == fileType); // Filter at DB level                
//var filteredFiles = fileLogsQuery.ToList();  // Executes SQL query with WHERE condition


//List<FileLog> fileUploadList = await _repositoryContext.FileLog.Where(w => w.FileType == fileType).ToListAsync();
//return fileUploadList;


//using System.Security.Cryptography;
//using System;

//https://api.example.com:8080/user/101?name=john#profile

//Customer { Id, month, Sales}


//6.How do you pivot rows into columns in SQL Server?






//}
