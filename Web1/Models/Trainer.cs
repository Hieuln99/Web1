using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web1.Models
{
    public class Trainer
    {
        public int id { get; set; }
        //---------------------
        [Required(ErrorMessage = "Name can not be null!!")]
        public string Name { get; set; }
        //---------------------
        [Required(ErrorMessage = "Type can not be null!!")]
        public bool Type { get; set; }
        //---------------------
        [Required(ErrorMessage = "Work place can not be null!!")]
        public string Workplace { get; set; }
        //---------------------
        [Required(ErrorMessage = "Email can not be null!!")]
        [EmailAddress]
        public String Email { set; get; }
        //---------------------
        [Required(ErrorMessage = "Contact can not be null!!")]
        [RegularExpression(@"^([0-9]{10})$",
        ErrorMessage = "Phone number must be numbers and it has to have 10 numbers!!!!!!")]
        public String Phonenumber { set; get; }

        //-----------------------------many - many -----------------\
        public Trainer()
        {
            courses = new List<Course>();
        }
        public List<Course> courses { get; set; }

        public string ToSeparatedString(string r)
        {
            return $"{this.id}{r}" +
                    $"{this.Name}{r}" +
                    $"{this.Type}{r}" +
                    $"{this.Workplace}{r}" +
                    $"{this.Phonenumber}{r}" +
                    $"{this.Email}";
        }
        public override string ToString()
        {
            return string.Format("id:{0}; Name: {1}; Type:{2}; Workplace: {3}; Phonenumber: {4}; Email: {5}", 
                this.id, this.Name, this.Type, this.Workplace, this.Phonenumber, this.Email);
        }
    }
}