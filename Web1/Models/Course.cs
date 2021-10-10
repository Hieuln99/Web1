using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace Web1.Models
{
    public class Course
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name can not be null!!")]
        public string Name { get; set; }

        [RegularExpression("^([0-9]{11})$", ErrorMessage = "Description must be more words!!!!!!")]
        [Required(ErrorMessage = "Description can not be null!!")]
        public string Description { get; set; }

        //----------------------one -> many relationship------------------------------------
        [DisplayName("Category Course")]
        public int categoryid { get; set; }
        public CourseCategory category { get; set; }

        //-------------------many- many-----------------------------------
        public List<Trainer> trainers { get; set; }


        //----------------------many -> many relationship------------------------------------
        public List<Trainee> trainee { get; set; }
        //---------------------------------------------------


        //------------------------------------------------------
        public string ToSeparatedString(string r)
        {
            return $"{this.id}{r}" +
                    $"{this.Name}{r}" +
                    $"{this.Description}";
        }

        public override string ToString()
        {
            return string.Format("id:{0}; Name: {1}; Description:{2}", this.id, this.Name, this.Description);
        }
    }
}