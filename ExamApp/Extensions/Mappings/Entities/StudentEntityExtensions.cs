using ExamApp.DataAccess.Entities;
using ExamApp.Services.DTOs;

namespace ExamApp.Extensions.Mappings.Entities
{
    public static class StudentEntityExtensions
    {
        public static StudentDTO ToDTO(this Student student)
        {
            if (student is not null)
            {
                return new StudentDTO()
                {
                    ID = student.ID,
                    StudentNumber = student.StudentNumber,
                    StudentName = student.StudentName,
                    StudentSurname = student.StudentSurname
                };
            }

            return null;
        }

        public static IEnumerable<StudentDTO> ToDTOEnumarable(this IEnumerable<Student> studentEntites)
        {
            List<StudentDTO> studentDTOs = new List<StudentDTO>();

            foreach (var studentEntity in studentEntites)
            {
                StudentDTO studentDTO = new()
                {
                    ID = studentEntity.ID,
                    StudentNumber = studentEntity.StudentNumber,
                    StudentName = studentEntity.StudentName,
                    StudentSurname = studentEntity.StudentSurname
                };

                studentDTOs.Add(studentDTO);
            }

            return studentDTOs;
        }
    }
}
