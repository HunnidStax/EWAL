namespace EWAL.Models
{
    public class Report
    {
        private long _id;
        private string _name;

        public long Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        internal Report(long id, string name)
        {
            _id = id;
            _name = name;
        }

        internal Report() { }
    }

    public class ReportFactory
    {
        public Report Create(long id, string name) => new Report(id, name);
    }
}
