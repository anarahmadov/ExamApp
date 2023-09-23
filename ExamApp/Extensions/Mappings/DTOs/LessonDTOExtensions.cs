using ExamApp.DataAccess.Entities;
using ExamApp.Models.ViewModels;
using ExamApp.Services.DTOs;

namespace ExamApp.Extensions.Mappings.DTOs
{
    public static class LessonDTOExtensions
    {
        public static Lesson ToEntity(this LessonDTO lessonDTO)
        {
            if (lessonDTO is not null)
            {
                return new Lesson()
                {
                    ID = lessonDTO.ID,
                    LessonCode = lessonDTO.LessonCode,
                    LessonName = lessonDTO.LessonName,
                    ClassNumber = lessonDTO.ClassNumber,
                    TeacherName = lessonDTO.TeacherName,
                    TeacherSurname = lessonDTO.TeacherSurname
                };
            }

            return null;
        }

        //public static RegisterLessonViewModel ToViewModel(this LessonDTO lessonDTO)
        //{
        //    if (lessonDTO is not null)
        //    {
        //        return new Lesson()
        //        {
        //            ID = lessonDTO.ID,
        //            LessonCode = lessonDTO.LessonCode,
        //            LessonName = lessonDTO.LessonName,
        //            ClassNumber = lessonDTO.ClassNumber,
        //            TeacherName = lessonDTO.TeacherName,
        //            TeacherSurname = lessonDTO.TeacherSurname
        //        };
        //    }

        //    return null;
        //}
    }
}
