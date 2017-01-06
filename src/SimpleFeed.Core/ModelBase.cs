namespace SimpleFeed.Core
{
    using System;

    public abstract class ModelBase
    {
        public readonly Guid Id;
        private Guid? _creator;

        protected ModelBase(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            CreationDate = DateTime.Now;
        }

        public DateTime CreationDate { get; private set; }

        public Guid? Creator
        {
            get { return _creator; }
            protected set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Creator));
                _creator = value;
            }
        }
    }
}
