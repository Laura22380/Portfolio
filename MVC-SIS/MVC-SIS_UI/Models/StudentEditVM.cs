using MVC_SIS_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_SIS_UI.Models
{
    public class StudentEditVM : IValidatableObject
    {
        public Student currentStudent { get; set; }
        public List<SelectListItem> CourseItems { get; set; }
        public List<SelectListItem> MajorItems { get; set; }
        public List<SelectListItem> StateItems { get; set; }
        public List<int> SelectedCourseIds { get; set; }



        public StudentEditVM()
        {
            CourseItems = new List<SelectListItem>();
            MajorItems = new List<SelectListItem>();
            StateItems = new List<SelectListItem>();
            SelectedCourseIds = new List<int>();
            currentStudent = new Student();
            currentStudent.Major = new Major();
            currentStudent.Address = new Address();
        }

        public void SetCourseItems(IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                CourseItems.Add(new SelectListItem()
                {
                    Value = course.CourseId.ToString(),
                    Text = course.CourseName
                });
            }
        }

        public void SetSelectedIds(Student currentStudent)
        {
            foreach (var selectedCourse in currentStudent.Courses)
            {
                SelectedCourseIds.Add(selectedCourse.CourseId);
            }
        }

        public void SetMajorItems(IEnumerable<Major> majors)
        {
            foreach (var major in majors)
            {
                MajorItems.Add(new SelectListItem()
                {
                    Value = major.MajorId.ToString(),
                    Text = major.MajorName
                });
            }
        }


        public void SetStateItems(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StateItems.Add(new SelectListItem()
                {
                    Value = state.StateAbbreviation,
                    Text = state.StateName
                });
            }
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (currentStudent == null)
            {
                errors.Add(new ValidationResult("Please enter student information",
                    new[] { "currentStudent" }));
            }

            if (SelectedCourseIds.Count == 0)
            {
                errors.Add(new ValidationResult("Please select at least one Course",
                    new[] { "Student.Courses" }));
            }

            if (currentStudent.Address.Street1 == "" || currentStudent.Address.Street1 == null)
            {
                errors.Add(new ValidationResult("Please enter Street1",
                    new[] { "currentStudent.Address.Street1" }));
            }

            if (currentStudent.Address.City == "" || currentStudent.Address.City == null)
            {
                errors.Add(new ValidationResult("Please enter a City",
                    new[] { "currentStudent.Address.City" }));
            }

            if (currentStudent.Address.State == null)
            {
                errors.Add(new ValidationResult("Please enter a State",
                    new[] { "currentStudent.Address.State" }));
            }

            if (currentStudent.Address.PostalCode == null || currentStudent.Address.PostalCode.Length != 5)
            {
                errors.Add(new ValidationResult("Please enter a 5 digit postal code",
                    new[] { "currentStudent.Address.PostalCode" }));
            }

            return errors;
        }
    }
}