namespace Globus.Core.Entities
{
    public class OneTimePassword
    {
        public int OneTimePasswordId { get; set; }
        public string Value { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public DateTime GeneratedDate { get; set; }
        public DateTime ValidityTimeSpan { get; set; }
        public bool IsUsed { get; set; }

        public OneTimePassword()
        {
            GeneratedDate = DateTime.Now;
            IsUsed = false;
            ValidityTimeSpan = DateTime.Now.AddMinutes(5);
        }
    }
}
