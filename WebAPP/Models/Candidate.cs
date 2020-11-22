using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPP.Models
{
    public class Candidate : IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " please enter the First Name"), MaxLength(255)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = " please enter the Last Name"), MaxLength(255)]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = " Please Enter the Mail Address"), EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Experience { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Please Enter the Valid Phone Number"), Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public bool IsEnable { get; set; }

        public string Interviewer { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comments { get; set; }


        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            DateTime nowTime = DateTime.Now;
            DateTime? scheduledStartTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 8, 0, 0, 0); //Specify
            DateTime? scheduledEndTime = new DateTime(nowTime.Year, nowTime.Month, nowTime.Day, 5, 0, 0, 0);
           
            

            if ( StartDate == null)
            {
                yield return new ValidationResult("Please Enter the Start Date");
            }
            

            else if ((scheduledStartTime.Value.Hour < StartDate.Value.Hour ) && (StartDate.Value.Hour < scheduledEndTime.Value.AddMinutes(-30).Hour))
            {

                yield return new ValidationResult("Available Time will be 8:00 AM to 5:00 PM" );
            }
            else
            {
                EndDate = StartDate.Value.AddMinutes(30);
            }
        }
    }
}
