namespace EWAL.Models
{
    public class User
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

        internal User(long id, string name)
        {
            _id = id;
            _name = name;
        }

        internal User() { }
    }

    public class UserFactory
    {
        public User Create(long id, string name) => new User(id, name);
    }
}
