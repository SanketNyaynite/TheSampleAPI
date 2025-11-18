namespace TheSampleAPI.Models;

public class CourseModel
{
    public int Id { get; set; }
    public bool IsPreorder { get; set; }
    public required string CourseUrl { get; set; }
    public required string CourseType { get; set; }
    public required string CourseName { get; set; }
    public required int CourseLessonCount { get; set; }
    public double CourseLengthInHours { get; set; }
    public string ShortDescription { get; set; }
    public string CourseImage { get; set; }
    public int PriceInUSD { get; set; }
    public string CoursePreviewLink { get; set; }
}

