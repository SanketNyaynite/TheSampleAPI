
using System.Text.Json;
using TheSampleAPI.Models;

namespace TheSampleAPI.Data
{
    public class CourseData
    {
        public List<CourseModel> Courses { get; private set; }
            
        public CourseData()                         //all this does is read the json file and deserialize it into a list of CourseModel objects
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Data",
                "coursedata.json");

            string json = File.ReadAllText(filePath);
            Courses = JsonSerializer.Deserialize<List<CourseModel>>(json, options) ?? new();
        }
           
    }
}
