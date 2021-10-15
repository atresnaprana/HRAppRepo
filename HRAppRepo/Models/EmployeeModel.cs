using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRAppRepo.Models
{
    public class EmployeeModel
    {
        public string Employee_Name { get; set; }
        public string Employee_Phone { get; set; }
        public string Employee_Address { get; set; }
        public DateTime? Employee_birthdate { get; set; }
        [Key]
        public string Employee_email_login { get; set; }
        public string Employee_email_login_pass { get; set; }
        public string Employee_Nat_ID { get; set; }
        public string Employee_Nat_ID_Type { get; set; }
        public string Employee_taxnumber { get; set; }
        public string Employee_taxcategory { get; set; }
        public string Employee_position { get; set; }
        public DateTime? Employee_joindate { get; set; }
        public string Employee_wh_type { get; set; }
        public int? Employee_wh_fixed_Count { get; set; }
        public string Employee_wh_dynamic_mon { get; set; }
        public string Employee_wh_dynamic_tue { get; set; }
        public string Employee_wh_dynamic_wed { get; set; }
        public string Employee_wh_dynamic_thu { get; set; }
        public string Employee_wh_dynamic_fri { get; set; }
        public string Employee_wh_dynamic_sat { get; set; }
        public string Employee_wh_dynamic_sun { get; set; }
        public string Employee_bank_name { get; set; }
        public string Employee_bank_code { get; set; }
        public string Employee_bank_number { get; set; }
        public string Employee_BPJS_status { get; set; }
        public string Employee_BPJS_number { get; set; }
        public string Employee_BPJSTK_status { get; set; }
        public string Employee_BPJSTK_number { get; set; }
        public string Employee_JK_status { get; set; }
        public string Employee_JKK_status { get; set; }
        public string Employee_JHT_status { get; set; }
        public string Employee_JP_status { get; set; }


    }
}
