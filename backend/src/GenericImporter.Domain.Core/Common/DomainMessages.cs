namespace GenericImporter.Domain.Core.Common
{
    public static class DomainMessages
    {
        public static DomainMessage CommitFailed => new("There was an error saving data.");
        public static DomainMessage RequiredField => new("Please, ensure you enter {0}.");
        public static DomainMessage AlreadyInUse => new("The informed {0} is already in use.");
        public static DomainMessage InvalidFormat => new("The informed {0} is invalid.");
        public static DomainMessage NotFound => new("The informed {0} was not found.");
        public static DomainMessage InUseByAnotherEntity => new("The informed {0} is in use by {1}.");
    }
}
