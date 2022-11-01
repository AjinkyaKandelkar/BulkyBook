using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Utility
{
    public static class SD
    {
        public const string Role_User_Indi = "Indivisual";
        public const string Role_User_Comp = "Company";
        public const string Role_User_Admin = "Admin";
        public const string Role_User_Emp = "Employee";

        public const string Status_Pending = "Pending";
        public const string Status_Approved = "Approved";
        public const string Status_InProcess = "InProcess";
        public const string Status_Shipped = "Shipped";
        public const string Status_Canceled = "Canceled";
        public const string Status_Refund = "Refund";

        public const string PaymentStatus_Pending = "Pending";
        public const string PaymentStatus_Approved = "Approved";
        public const string PaymentStatus_Delayed = "Delayed";
        public const string PaymentStatus_Rejected = "Rejected";
    }
}
