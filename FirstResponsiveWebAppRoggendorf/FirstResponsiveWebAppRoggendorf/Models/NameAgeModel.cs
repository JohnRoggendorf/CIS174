using System.ComponentModel.DataAnnotations;
namespace FirstResponsiveWebAppRoggendorf.Models
{
    public class NameAgeModel
    {
        //Input validation. Aplhabetic characters only
        [Required(ErrorMessage = "Please enter a name")]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Only letters are allowed.")]
        //DOB to show only date not time
        public string? userName { get; set; }
        [Required(ErrorMessage = "Please enter a date of birth")]
        [DataType(DataType.Date)]
        public DateTime? userDOB { get; set; }

        public int DisplayNameAndCurrentAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - userDOB.Value.Year;
            //If birthday has not occured yet, subtract 1
            if(userDOB.Value.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
