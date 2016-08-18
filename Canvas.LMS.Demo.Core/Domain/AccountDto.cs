namespace Canvas.LMS.Demo.Core.Domain
{
    public class AccountDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentAccountId { get; set; }

        public int RootAccountId { get; set; }

        public int DefaultStorageQuotaMb { get; set; }

        public int DefaultUserStorageQuotaMb { get; set; }

        public int DefaultGroupStorageQuotaMb { get; set; }

        public string DefaultTimeZone { get; set; }

        public string SISAccountId { get; set; }

        public string IntegrationId { get; set; }

        public int SISImportId { get; set; }

        public string LTIGuid { get; set; }

        public string WorkflowState { get; set; }
    }
}