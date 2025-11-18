using TheSampleAPI.Data;

namespace TheSampleAPI.Endpoints
{
    public static class CourseEndpoints
    {
        public static void AddCourseEndpoints(this WebApplication app)         //what this method does is add endpoints to the app
        {
            app.MapGet("/courses", LoadAllCourses);
            app.MapGet("/courses/{id}", LoadCourseById);                        //what this does is map the GET request to the            LoadCourseById method
        }

        private static IResult LoadAllCourses(
            CourseData data,
            string? courseType,
            string? search)
        {
            var output = data.Courses;

            if (string.IsNullOrWhiteSpace(courseType) == false)     //what this does is filter the courses by course type if the courseType parameter is not null or whitespace
            {
                output.RemoveAll(x => string.Compare(               //what this does is remove all courses that do not match the course type
                    x.CourseType, 
                    courseType, 
                    StringComparison.OrdinalIgnoreCase) != 0);
            }

            if (string.IsNullOrWhiteSpace(search) == false)         //what this does is filter the courses by search term if the search parameter is not null or whitespace
            {
                output.RemoveAll(x => !x.CourseName.Contains(   //what this does is remove all courses that do not contain the search term in the course name or short description
                    search, 
                    StringComparison.OrdinalIgnoreCase) &&
                    !x.ShortDescription.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            return Results.Ok(output);
        }

        private static IResult LoadCourseById(CourseData data, int id)      //what this method does is load a course by its id
        {
            var output = data.Courses.SingleOrDefault(x => x.Id == id);

            if(output is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(output);
        }
    }
}
