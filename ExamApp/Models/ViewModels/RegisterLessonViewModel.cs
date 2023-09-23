﻿namespace ExamApp.Models.ViewModels
{
    public class RegisterLessonViewModel
    {
        public string LessonCode { get; set; } = string.Empty;
        public string LessonName { get; set; } = string.Empty;
        public int ClassNumber { get; set; }
        public string TeacherName { get; set; } = string.Empty;
        public string TeacherSurname { get; set; } = string.Empty;
    }
}
