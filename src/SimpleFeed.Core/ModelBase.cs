namespace SimpleFeed.Core
{
    using System;

    public abstract class ModelBase
    {
        public readonly Guid Id;
        private Guid? _creator;

        protected ModelBase(Guid? id = null)
        {
            if (id.HasValue)
            {
                Id = id.Value;
                return;
            }
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }

        public DateTime CreationDate { get; }

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
