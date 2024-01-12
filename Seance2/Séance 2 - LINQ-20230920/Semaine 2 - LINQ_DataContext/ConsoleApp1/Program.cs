using LINQDataContext;

DataContext dc = new DataContext();

//Exo1
Console.WriteLine("EXO 1 : ");

Student? jdepp = (from student in dc.Students
                  where student.Login == "jdepp"
                  select student).SingleOrDefault();

if (jdepp != null)
{
    Console.WriteLine(jdepp.First_Name +" "+ jdepp.Last_Name);
}

//Exo2
Console.WriteLine("EXO 2 : ");

var students2 = (from student in dc.Students
                select new { student.First_Name, student.Last_Name, student.BirthDate, student.Student_ID });

if(students2 != null)
{
    foreach (var s in students2)
    {
        Console.WriteLine( s.First_Name + " " + s.Last_Name + " " + s.Student_ID + " " + s.BirthDate );
    }
}

//Exo3
Console.WriteLine("Exo3 : ");

var students3 = (from student in dc.Students
                 where student.BirthDate.Year < 1955
                 select new { student.Last_Name, student.Year_Result, student.});