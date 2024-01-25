namespace Task_1
{
    internal class MyShop
    {
        public string Name { get; set; } = "No name";
        public string Address { get; set; } = "No address";
        public string Description { get; set; } = "No description";
        public string PhoneNumber { get; set; } = "000-000-000";
        public string Email { get; set; } = "No email";
        public float Area { get; set; } = 0.0f;

        public MyShop() { }

        public MyShop(string name, string address, string description, string phoneNumber,
            string email, float area)
        {
            Name = name;
            Address = address;
            Description = description;
            PhoneNumber = phoneNumber;
            Email = email;
            Area = area;
        }

        public static MyShop operator +(MyShop shop, float area)
        {
            return new MyShop
            {
                Area = shop.Area + area
            };
        }

        public static MyShop operator -(MyShop shop, float area)
        {
            if (shop.Area - area <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(area), "The substructed area is bigger than shop's area.");
            }

            return new MyShop
            {
                Area = shop.Area - area
            };
        }

        public static bool operator ==(MyShop shop_1, MyShop shop_2) =>
            shop_1.Area == shop_2.Area;

        public static bool operator !=(MyShop shop_1, MyShop shop_2) =>
            shop_1.Area != shop_2.Area;

        public static bool operator >(MyShop shop_1, MyShop shop_2) =>
            shop_1.Area > shop_2.Area;

        public static bool operator <(MyShop shop_1, MyShop shop_2) =>
            shop_1.Area < shop_2.Area;

        public override bool Equals(object? obj)
        {
            if (obj is not MyShop)
            {
                return false;
            }

            return this.ToString() == obj.ToString();
        }

        public override int GetHashCode() =>
            this.ToString().GetHashCode();

        public override string ToString() =>
                        $"Name        : {Name}\n" +
                        $"Address     : {Address}\n" +
                        $"Description : {Description}\n" +
                        $"PhoneNumber : {PhoneNumber}\n" +
                        $"Email       : {Email}\n" +
                        $"Area        : {Area}\n";
    }
}
