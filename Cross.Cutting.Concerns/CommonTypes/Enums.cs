namespace Cross.Cutting.Concerns.Common.CommonTypes
{
    /// <summary>
    /// 
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// Represents the context area to which the business rules are bound
        /// </summary>
        public enum BusinessRuleContextArea
        {
            Options,
            FinancialAccount,
            Reports,
            Security,
            Financial,
            UserAccount,
            StudentAccount,
            SupplierLookupData,
            FinancialInstitutionLookupData,
            QualificationLookupData,
            Order,
            ExamScheduler
        }

        /// <summary>
        /// Represents the types of notifications that the system returns
        /// </summary>
        public enum NotificationTypes
        {
            /// <summary>
            /// No Errors occured. Normal operation is possible 
            /// </summary>
            Information,

            /// <summary>
            /// A non-fatal exception occured. Normal operation might be possible
            /// </summary>
            Warning,

            /// <summary>
            /// A fatal exception has occured. Normal operation is not possible
            /// </summary>
            Error,
        }

        /// <summary>
        /// Represents the statuses that exists in the system
        /// </summary>
        public enum Status
        {
            Active = 1,
            Deleted,
            Suspended,
            Processed
        }

        /// <summary>
        /// Represents the titles of the user
        /// </summary>
        public enum Title
        {
            Mr = 1,
            Mrs,
            Ms,
        }

        /// <summary>
        ///  Represents the roles of the user
        /// </summary>
        public enum UserRoles
        {
            /// <summary>
            /// The principal has full, system-wide access
            /// </summary>
            Principal = 1,

            /// <summary>
            /// The dean has access majority of the system
            /// </summary>
            Dean,

            /// <summary>
            /// The secretary is only allowed in the financial aspect domain
            /// </summary>
            Secretary,

            /// <summary>
            /// The lecturer is only allowed with the domain relating to the students.
            /// </summary>
            Lecturer
        }

        /// <summary>
        /// Represents the maritial status of the user
        /// </summary>
        public enum MaritialStatus
        {
            /// <summary>
            /// Person has never married
            /// </summary>
            Single = 1,

            /// <summary>
            /// Person is married
            /// </summary>
            Married,

            /// <summary>
            /// Person has been divorced
            /// </summary>
            Divorced,

            /// <summary>
            /// Person is a widow
            /// </summary>
            Widow
        }

        /// <summary>
        /// Represents the communication types
        /// </summary>
        public enum CommunicationTypes
        {
            Email = 1,
            Sms
        }

        public enum ActionType
        {
            UserLogin = 1,
            UserLogout,
            UserAdded,
            UserModified,
            SendCommunicationNotification,
        }

        public enum ReportType
        {
            
        }

        public enum ChartType
        {
            Bar,
            Pie,
            Line
        }
    }
}
