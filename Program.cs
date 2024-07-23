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
        //write code to subscribe to an online course
    }
}

public class OfflineCourse : Course
{
    public override void Subscribe(Student std)
    {
        //write code to subscribe to a offline course
    }
}