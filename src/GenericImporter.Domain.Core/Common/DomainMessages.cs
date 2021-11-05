namespace GenericImporter.Domain.Core.Common
{
    public class DomainMessages
    {
        public static DomainMessage CommitFailed => new DomainMessage("There was an error saving data.");
        public static DomainMessage RequiredField => new DomainMessage("Please, ensure you enter {0}.");
    }
}
