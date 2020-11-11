﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Model
{
    public class Student
    {
        public Student(int id, string name, string email, string image, Profession profession)
        {
            Id = id;
            Name = name;
            Email = email;
            Image = image;
            Profession = profession;
        }

        public Student()
        {

        }
        [Range(0,1000)]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name of Event is required"), MaxLength(30)]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Profession is required")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Image is required")]

        public string Image { get; set; }

        [Required(ErrorMessage = "Profession is required")]

        public Profession Profession { get; set; }
    }
}
