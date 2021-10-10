using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web1.Models
{
    public class Trainee
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Name can not be null!!")]
        public String Name { get; set; }

        public string UserName { get; set; }

        public int Age { get; set; }

        public DateTime DOB { get; set; }

        public string Edu { get; set; }

        public string Language { get; set; }

        public int Toeic { get; set; }

        public string Exp { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }

        //[Required(ErrorMessage = "Contact can not be null!!")]
        //[RegularExpression(@"^([0-9]{10})$",
        //ErrorMessage = "Contact must be numbers and Contact have to have 10 numbers!!!!!!")]
        //public String Contact { set; get; }

        //---------------------------------------many -> many relationship---------------------------------
        //[DisplayName("Room")]
        public Trainee()
        {
            courses = new List<Course>();
        }
        public List<Course> courses { get; set; }

        //-------------------------------------------------------------------------------



        public string ToSeparatedString(string r)
        {
            return $"{this.id}{r}" +
                    $"{this.Name}{r}" +
                    $"{this.UserName}{r}" +
                    $"{this.Age}{r}" +
                    $"{this.DOB}{r}" +
                    $"{this.Edu}{r}" +
                    $"{this.Language}{r}" +
                    $"{this.Toeic}{r}" +
                    $"{this.Exp}{r}" +
                    $"{this.Department}{r}" +
                    $"{this.Location}";
        }
        public override string ToString()
        {
            return string.Format("id:{0}; name:{1}; username:{2}; age:{3}; dateofbirth:{4}; education:{5}; language:{6}; toeic: {7}; experience:{8}; department:{9};location:{10}"
                , this.id, this.Name, this.UserName, this.Age, this.DOB, this.Edu, this.Language, this.Toeic, this.Exp, this.Department, this.Location);
        }
    }
}