using GraphQLBasic.Models;

namespace GraphQLBasic.IService
{
    public interface ISchoolService
    {
       // List<Student> GetStudents();
        //   Student GetStudentById(string id);
       // Task<List<Course>> FetchSubjects();
        //List<Student> GetStudentsFromDb();

        Task<List<Student>> GetStudentsFromDb();
        //  Course GetCourseById(string id);   
        //  Course GetCourseByName(string courseName);

    }
}
