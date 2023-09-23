using ExamApp.DataAccess.Entities;
using ExamApp.Services.DTOs;
using System.Collections.Generic;

namespace ExamApp.Extensions.Mappings.Entities
{
    public static class LessonEntityExtensions
    {
        public static LessonDTO ToDTO(this Lesson lesson)
        {
            if (lesson is not null)
            {
                return new LessonDTO()
                {
                    ID = lesson.ID,
                    LessonCode = lesson.LessonCode,
                    LessonName = lesson.LessonName,
                    ClassNumber = lesson.ClassNumber,
                    TeacherName = lesson.TeacherName,
                    TeacherSurname = lesson.TeacherSurname
                };
            }

            return null;
        }

        public static IEnumerable<LessonDTO> ToDTOEnumarable(this IEnumerable<Lesson> lessonEntites)
        {
            List<LessonDTO> lessonDTOs = new List<LessonDTO>();

            foreach (var lessonEntity in lessonEntites)
            {
                LessonDTO lessonDTO = new()
                {
                    ID = lessonEntity.ID,
                    LessonCode = lessonEntity.LessonCode,
                    LessonName = lessonEntity.LessonName,
                    ClassNumber = lessonEntity.ClassNumber,
                    TeacherName = lessonEntity.TeacherName,
                    TeacherSurname = lessonEntity.TeacherSurname
                };

                lessonDTOs.Add(lessonDTO);
            }

            return lessonDTOs;
        }
    }
}
