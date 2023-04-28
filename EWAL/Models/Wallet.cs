namespace EWAL.Models
{
    public class Wallet
    {
        private long _id;
        private string _name;
        private string _type;
        private long _userId;

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

        public string Type
        {
            get => _type;
            set => _type = value;
        }

        public long UserId
        {
            get => _userId;
            set => _userId = value;
        }

        internal Wallet(long id, string name, string type, long userId)
        {
            _id = id;
            _name = name;
            _type = type;
            _userId = userId;
        }

        internal Wallet() { }
    }

    public class WalletFactory 
    {
        public Wallet Create(long id, string name, string type, long userId) => new Wallet(id, name, type, long userId);
    }
}
