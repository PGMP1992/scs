namespace SCS.Utility
{
    public static class SD
    {
        // Roles
        public const string Role_Admin = "admin";
        public const string Role_Employee = "employee";
        public const string Role_Customer = "customer";

        //Static Data
        public const string ProductStatusRegistrated = "Registred";
        public const string ProductStatusActive = "Active";
        public const string ProductStatusExpired = "Expired";

        // Order Status
        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        // Payment 
        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusRejected = "Rejected";
        
        // Session
        public const string SessionCart = "SessionCart";
        public const string SessionTempUserId = "SessionTempUserId";
        public const string SessionVoucherId = "SessionVoucherId";

        // Admin User
        public const string AdminEmail = "admin@email.com";
        public const string TempEmail = "temp@email.com";
        public const string Password = "Admin123*";

        // Email
        public const string EmailAddress = "pedro@dkltd.net"; // My Private Email Address to be replaced. 

    }
}
