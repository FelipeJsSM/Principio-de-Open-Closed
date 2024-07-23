public class Student
{
    public string Name { get; set; }
}

public abstract class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; }

    public abstract void Subscribe(Student std);
}

public class OnlineCourse : Course
{
    public override void Subscribe(Student std)
    {
        Console.WriteLine($"{std.Name} esta suscrito al curso online {Title} con el ID {CourseId}.");
    }
}

public class OfflineCourse : Course
{
    public override void Subscribe(Student std)
    {
        Console.WriteLine($"{std.Name} esta suscrito al curso presencial {Title} con el ID {CourseId}.");
    }
}

public class HybridCourse : Course
{
    private List<OnlineCourse> onlineCourses;
    private List<OfflineCourse> offlineCourses;

    public HybridCourse()
    {
        onlineCourses = new List<OnlineCourse>();
        offlineCourses = new List<OfflineCourse>();
    }

    public void AddOnlineCourse(OnlineCourse course)
    {
        onlineCourses.Add(course);
    }

    public void AddOfflineCourse(OfflineCourse course)
    {
        offlineCourses.Add(course);
    }

    public override void Subscribe(Student std)
    {
        foreach (var onlineCourse in onlineCourses)
        {
            onlineCourse.Subscribe(std);
        }

        foreach (var offlineCourse in offlineCourses)
        {
            offlineCourse.Subscribe(std);
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        var person = new Student { Name = "Pedro" };

        var online = new OnlineCourse { CourseId = 201, Title = "Mineria de Datos" };
        var offline = new OfflineCourse { CourseId = 202, Title = "Programación 1" };

        var hybridScience = new HybridCourse();
        hybridScience.AddOnlineCourse(online);
        hybridScience.AddOfflineCourse(offline);

        hybridScience.Subscribe(person);
    }
}
