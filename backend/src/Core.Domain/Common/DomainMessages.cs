namespace Core.Domain.Common
{
    public static class DomainMessages
    {
        public static DomainMessage CommitFailed => new("There was an error saving data.");
        public static DomainMessage RequiredField => new("Please, ensure you enter {0}.");
        public static DomainMessage AlreadyInUse => new("The informed {0} is already in use.");
    }
}
