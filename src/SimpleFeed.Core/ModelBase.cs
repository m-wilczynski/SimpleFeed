namespace SimpleFeed.Core
{
    using System;

    public abstract class ModelBase
    {
        public readonly Guid Id;
        private DateTime? _creationDate;
        private Guid? _creator;

        protected ModelBase(Guid? id = null)
        {
            if (id.HasValue)
            {
                Id = id.Value;
                return;
            }
            Id = Guid.NewGuid();
        }

        public DateTime? CreationDate
        {
            get { return _creationDate; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(CreationDate));
                _creationDate = value;
            }
        }

        public Guid? Creator
        {
            get { return _creator; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Creator));
                _creator = value;
            }
        }
    }
}
