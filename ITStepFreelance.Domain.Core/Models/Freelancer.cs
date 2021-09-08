using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITStepFreelanceApp.Domain.Core.Models {
  public class Freelancer {
    public int FreelancerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string CellphoneNumber { get; set; }
    public DateTime RegistrationDate { get; set; }
  }
}
