namespace Task_1
{
    internal class MyWebSite
    {
        public string Name { get; set; }
        public string WebAddress { get; set; }
        public string IpAddress { get; set; }
        public string Description { get; set; }

        public MyWebSite()
        {
            Name = "No name";
            WebAddress = "No web-address";
            IpAddress = "No ip-address";
            Description = "No description";
        }

        public MyWebSite(
            string name, string webAddress, string ipAddress, string description)
        {
            Name = name;
            WebAddress = webAddress;
            IpAddress = ipAddress;
            Description = description;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Name:        " + Name);
            Console.WriteLine("WebAddress:  " + WebAddress);
            Console.WriteLine("IpAddress:   " + IpAddress);
            Console.WriteLine("Description: " + Description);
        }
    }
}
