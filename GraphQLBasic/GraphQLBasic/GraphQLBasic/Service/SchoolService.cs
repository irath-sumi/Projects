using GraphQLBasic.IService;
using GraphQLBasic.Models;
using Microsoft.AspNetCore.Authorization;
using HotChocolate;
using HotChocolate.Data;
using GraphQLBasic.Database;
using Microsoft.EntityFrameworkCore;
using GraphQLBasic.DAL;
namespace GraphQLBasic.Service
{
   
    public class SchoolService : ISchoolService
    {
        SchoolRepository _schoolRepository;

        public SchoolService()
        {
            _schoolRepository = new SchoolRepository();
        }
 
      
        List<Student> students = new List<Student>();
      
        //public List<Student> GetStudents()
        //{

        //    for (int i = 1; i < 10; i++)
        //    {
        //        students.Add(new Student()
        //        {
        //            StudentId = i,
        //            Name = "Stud" + i,
        //            Roll = 100 + i
        //        }); ;

        //    }

        //    return students;
        //}


        // Reading from the databse
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task <List<Student>> GetStudentsFromDb()
        {
            
            students =  await _schoolRepository.GetStudentsFromDb();

            return students;
        }


       

    }
}
