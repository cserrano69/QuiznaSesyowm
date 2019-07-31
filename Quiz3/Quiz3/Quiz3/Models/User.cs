using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz3.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SalesAgent { get; set; }
        public string VehicleName { get; set; }
        public double OSP { get; set; }
        public double DSP { get; set; }
        public double SalesDiscount { get { return ((OSP - DSP) / OSP) * 100 ; }  }

        public string Condition
        {
            get
            {
                if (DSP > SalesDiscount)
                {
                    return "INVALID";
                }
                else
                {
                    return "SUCCESS";
                }
            }
        }
        public double test = 100;
        //add sales agent
    }
}