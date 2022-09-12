using MVC_SIS_Data;
using MVC_SIS_Models;
using MVC_SIS_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_SIS_UI.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentAddVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentAddVM studentVM)
        {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            if (ModelState.IsValid)
            {
                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                return View("Add", studentVM);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentEditVM studentVM = new StudentEditVM();
            studentVM.currentStudent = StudentRepository.Get(id);
            studentVM.SetMajorItems(MajorRepository.GetAll());
            studentVM.SetStateItems(StateRepository.GetAll());
            studentVM.SetCourseItems(CourseRepository.GetAll());
            studentVM.SetSelectedIds(studentVM.currentStudent);
            //viewModel.SetAddressItems(viewModel.currentStudent);
            return View(studentVM);
        }

        [HttpPost]
        public ActionResult Edit(StudentEditVM studentVM)
        {
            studentVM.currentStudent.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.currentStudent.Courses.Add(CourseRepository.Get(id));

            studentVM.currentStudent.Major = MajorRepository.Get(studentVM.currentStudent.Major.MajorId);
            studentVM.currentStudent.Address.State = StateRepository.Get(studentVM.currentStudent.Address.State.StateAbbreviation);

            if (ModelState.IsValid)
            {
                StudentRepository.Edit(studentVM.currentStudent);

                return RedirectToAction("List");
            }

            else
            {
                studentVM.SetMajorItems(MajorRepository.GetAll());
                studentVM.SetStateItems(StateRepository.GetAll());
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetSelectedIds(studentVM.currentStudent);
                return View(studentVM);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            StudentDeleteVM viewModel = new StudentDeleteVM();
            viewModel.currentStudent = StudentRepository.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(StudentDeleteVM viewModel)
        {
            StudentRepository.Delete(viewModel.currentStudent.StudentId);
            return RedirectToAction("List");
        }

    }
}