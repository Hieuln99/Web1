using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web1.Models
{
    public class CourseCategory
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Name can not be null!!")]
        public string Name { get; set; }

        [RegularExpression("^([0-9]{11})$", ErrorMessage = "Description must be more words!!!!!!")]
        [Required(ErrorMessage = "Description can not be null!!")]
        public string Describe { get; set; }


        //----------------------many -> one relationship------------------------------------
        public List<Course> courseowned { get; set; }
        public CourseCategory()
        {
            courseowned = new List<Course>();
        }

        public string ToSeparatedString(string r)
        {
            return $"{this.id}{r}" +
                    $"{this.Name}{r}" +
                    $"{this.Describe}";
        }
        public override string ToString()
        {
            return string.Format("id:{0}; name:{1}; describe:{2}", this.id, this.Name, this.Describe);
        }
    }
}