﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStestProject;
public class Course
{
    private string errorMessageName => "Your name is not correct!";
    public string _name;
    private string errorMessageCourse => "Course members cannot be more 30 persons";
    public HashSet<Student> Students { get; }

    public Course(string name)
    {
        Name = name;
        Students = new HashSet<Student>();
    }

    public virtual string Name
    {
        get
        {
            return this._name;
        }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length <= 0)
            {
                Console.WriteLine(errorMessageName);
            }
            this._name = value;
        }
    }

    public void AddStudent(Student student)
    {
        if (Students.Count >= 30)
        {
           Console.WriteLine(errorMessageCourse);
            return;
        }
        Students.Add(student);
    }
    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
    }

}
