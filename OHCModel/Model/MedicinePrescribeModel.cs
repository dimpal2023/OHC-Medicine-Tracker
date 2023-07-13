using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OHCModel.Model
{
    public class MedicinePrescribeModel
    {


        public int Id { get; set; }
        [Required(ErrorMessage = "Please Select Employee")]
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Please Enter Chief Complaint")]
        public String Problem { get; set; }
        public String SuggestedDetails { get; set; }
        public string IsActive { get; set; }
        
        public String Gender { get; set; }
        public String Department { get; set; }
        public String DepartmentID { get; set; }
        public String MasterDepartment { get; set; }
        public String Unit { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid email")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile")]
        public String Mobile { get; set; }
        //[Required(ErrorMessage = "Please Enter DOB")]
        public String DOB { get; set; }
        public String Address { get; set; }
        [Required(ErrorMessage = "Please Enter Role")]
        public String RoleType { get; set; }
        [Required(ErrorMessage = "Please Enter Date")]
        public String Date { get; set; }
        [Required(ErrorMessage = "Please Enter Time")]
        public String Time { get; set; }
        [Required(ErrorMessage = "Please Enter Suggested By")]
        public String SuggestedBy { get; set; }
        //[Required(ErrorMessage = "Please Enter Treatment")]
        public String Treatment { get; set; }
        public Boolean VitalCheckUp { get; set; }
        public string CheckUpVital { get; set; }
        public Boolean FirstAidCheckUp { get; set; }
        public Boolean IsReffered { get; set; }
        public string  RefferedDescription { get; set; }
        public string CreatedBy { get; set; }
        public string ReturnMessage { get; set; }
        public int UserUnitID { get; set; }
        public int ReturnCode { get; set; }
        public List<MedicinePrescribeModel> _MedicinePrescribeModelList { get; set; }
        public List<SelectListItem> _MedicineList { get; set; }
        public List<SelectListItem> _EmployeeList { get; set; }
        public List<SelectListItem> _StatusList { get; set; }
        //public List<SelectListItem> _GenderList { get; set; }
        public List<SelectListItem> _DepartmentList { get; set; }
        public List<SelectListItem> _UnitList { get; set; }
        public List<DetailsofMedicine2> _DetailsofMedicineList2 { get; set; }
        public string BatchNo { get; set; }
        public int AvailableQty { get; set; }
        public bool IsOutsideWorker { get; set; }
        [Required(ErrorMessage = "Please Enter Hospital")]
        public string HospitalName { get; set; }
        //[Required(ErrorMessage = "Please Enter Attendee")]
        public string AttendeeName { get; set; }
        public string AttendeeNameforOutsideEmp { get; set; }
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        public string AttendeeMobileNumber { get; set; }
        public string RefferbyVehicle { get; set; }
        public string PatientStatus { get; set; }
        public string PatientStatusCloseDiscription { get; set; }
        public string ReferbyOtherVehicle { get; set; }
        public string PatientFitnessCertificate { get; set; }
        public string CompanyName { get; set; }
        public string EmergencyContactNo { get; set; }
    }
    public class DetailsofMedicine2
    {
        public string Medicinename { get; set; }
        public int Qty { get; set; }
        public string BatchNo { get; set; }
        public string Remark { get; set; }
        public int AvailableQty { get; set; }
    }
}
