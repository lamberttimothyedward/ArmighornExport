using FileHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExportHarness
{
    [DelimitedRecord(",")]
    public class MatrixModel
    {
        public string uid { get; set; }
        public string learner { get; set; }
        [Description("ABUSE & MISSING PERSONS: AN OVERVIEW (R-AU)")]
        public string Mandatory1 { get; set; }
        [Description("AGED CARE QUALITY STANDARDS (R-AU)")]
        public string Mandatory2 { get; set; }
        [Description("ASSISTING CLIENTS WITH MEDICATION")]
        public string Mandatory3 { get; set; }
        [Description("Chemical Awareness (Diversey)")]
        public string Mandatory4 { get; set; }
        [Description("FIRE SAFETY: THE BASIC PRINCIPLES")]
        public string Mandatory5 { get; set; }
        [Description("FOOD SAFETY")]
        public string Mandatory6 { get; set; }
        [Description("INFECTION CONTROL: AN OVERVIEW (R-AU)")]
        public string Mandatory7 { get; set; }
        [Description("INFECTION CONTROL: LAUNDRY AND CLEANING")]
        public string Mandatory8 { get; set; }
        [Description("Manual Handling - Competency (Face to Face)")]
        public string Mandatory9 { get; set; }
        [Description("Medication Administration - Documentation")]
        public string Mandatory10 { get; set; }
        [Description("Medication Competency")]
        public string Mandatory11 { get; set; }
        [Description("WHS: PREVENTING MUSCULOSKELETAL INJURY AT WORK (R-AU)")]
        public string Mandatory12 { get; set; }
        [Description("LOCATION CODE")]
        public string LocationCode { get; set; }
        [Description("MANAGER")]
        public string Manager { get; set; }
        [Description("MANAGER EMAIL")]
        public string ManagerEmail { get; set; }
        [Description("POSITION")]
        public string Position { get; set; }
    }
}
