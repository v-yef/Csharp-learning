namespace Task_2
{
    internal class MyShop
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public MyShop()
        {
            Name = "No name";
            Address = "No address";
            Description = "No description";
            PhoneNumber = "000-000-000";
            Email = "No email";
        }

        public MyShop(
            string name, string address, string description, string phoneNumber, string email)
        {
            Name = name;
            Address = address;
            Description = description;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Name:        " + Name);
            Console.WriteLine("Address:     " + Address);
            Console.WriteLine("Description: " + Description);
            Console.WriteLine("PhoneNumber: " + PhoneNumber);
            Console.WriteLine("Email:       " + Email);
        }
    }
}
