using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NestedObjectsSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Instructor> instructors = new List<Instructor>();

            PopulateInstructorTestData(instructors);

            lstInstructors.DataSource = instructors;
            lstInstructors.DisplayMember = nameof(Instructor.FullName);
        }

        private void PopulateInstructorTestData(List<Instructor> instructors)
        {
            Instructor instructorKen = new Instructor()
            {
                Email = "Ken@cptc.edu",
                FullName = "Dr. Kenneth Meerdink"
            };

            List<Course> kenCourses = new List<Course>()
            {
                new Course()
                {
                    Title = "Data Structures",
                    CourseNumber = "CPW 245",
                    Roster = new List<Student>()
                    {
                        new Student("Jim Halpert"),
                        new Student("Pam Halpert")
                    }
                },
                new Course()
                {
                    Title = "Java II",
                    CourseNumber = "CPW 143",
                    Roster = new List<Student>()
                    {
                        new Student("Dwight Schrute")
                    }
                }
            };

            instructorKen.CourseLoad = kenCourses;

            instructors.Add(instructorKen);
        }

        private void lstInstructors_SelectedIndexChanged(object sender, EventArgs e)
        {
            Instructor currInstructor = lstInstructors.SelectedItem as Instructor;

            List<Course> courses = currInstructor.CourseLoad;

            lstCourses.DataSource = courses;
            // DisplayMember must be a single property
            lstCourses.DisplayMember = nameof(Course.CourseDisplay);
        }

        private void lstCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCourses.SelectedIndex < 0)
                return;

            Course selectedCourse = lstCourses.SelectedItem as Course;

            lstStudents.DataSource = selectedCourse.Roster;
            lstStudents.DisplayMember = nameof(Student.FullName);
        }
    }
}
