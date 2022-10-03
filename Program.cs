IDevice deviceModel = new DeviceModel();
deviceModel.Use();

//public interface IKitchenDevices
//{
//    void StartMenu();
//}
public interface IDevice
{
    void Use();
    //public string Type { get; set; }
    //public string Brand { get; set; }
    //public bool IsFunctioning { get; set; }

}

sealed class Devicemodel
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public bool IsFunctioning { get; set; }

}
sealed class DeviceModel : IDevice
{
    Devicemodel newDevice = new Devicemodel();

    List<Devicemodel> deviceList = new List<Devicemodel>()
    {
        new Devicemodel(){ Type = "Våffeljärn", Brand="Electrolux", IsFunctioning = true},
         new Devicemodel(){ Type = "Vattenkokare", Brand="Siemens", IsFunctioning = true},
           new Devicemodel(){ Type = "Brödrost", Brand="Philips", IsFunctioning = false},

    };
    public string[] menuOptionsArr = { "1. Använd köksapparat", "2. Lägg till köksapparat", "3. Lista köksapparater", "4. Ta bort köksapparat", "5. Avsluta" };
    public void DisplayMenuOptions()
    {
        string menuOptions = "";
        foreach (string option in menuOptionsArr)
        {
            menuOptions += $"\n{option}";
        }
        Console.WriteLine(menuOptions);
    }

    public int Input(string input)
    {
        int option = 0;

        do
        {
            if (int.TryParse(input, out option) && option <= 5 && option >= 1) break;
            Console.Write("Ange val: ");
            input = Console.ReadLine();
        }
        while (!int.TryParse(input, out option) || option > 5 || option < 1);
        return option;
    }
    //public void GetInput()
    //{
    //    Console.Write("Ange val: ");
    //    if (Input(Console.ReadLine()) == 1)
    //    {
    //        UseDevice();
    //    }
    //    if (Input(Console.ReadLine()) == 2)
    //    {
    //        AddDevice();
    //    }
    //    if (Input(Console.ReadLine()) == 3)
    //    {
    //        ListDevices();
    //    }
    //    Use();
    //}




    public void GetInput()
    {
        bool isNumber = true;
        do
        {
            Console.Write("Ange ett val: ");
            var input = Console.ReadLine();
            isNumber = int.TryParse(input, out int number);
            if (!isNumber)
            {
                isNumber = true;
                Console.Write("Ange ett val: ");
                input = Console.ReadLine();
                continue;
            }
            if (number == 1)
            {
                UseDevice();
                break;
            }
            if (number == 2)
            {
                AddDevice();
                break;
            }
            if (number == 3) { ListDevices(); break; }

            if (number == 4) RemoveDevice(); break;

        } while (isNumber);
        Use();
    }

    public void RemoveDevice()
    {
        ListDevices();
        int count = 0;
        Console.Write("Välj köksapparat: ");
        var input = Console.ReadLine();
        foreach (var device in deviceList)
        {
            count++;
            if (int.Parse(input) == count)
            {
                Console.WriteLine($"Tog bort {device.Type}");
                deviceList.Remove(device);
                return;
            }
        }
    }
    public bool DeviceFunction()
    {
        bool isDeviceFunctioning = true;

        foreach (var device in deviceList)
        {
            isDeviceFunctioning = device.IsFunctioning;
            if (isDeviceFunctioning == true)
            {
                Console.WriteLine($"Använder {device.Type}");
            }
            else
            {
                Console.WriteLine("Trasig");
                return false;
            }
        }
        return isDeviceFunctioning;
    }
    public void UseDevice()
    {
        ListDevices();
        int count = 0;
        Console.Write("Välj köksapparat: ");
        var input = Console.ReadLine();
        foreach (var device in deviceList)
        {
            count++;
            if (int.Parse(input) == count)
            {
                if (device.IsFunctioning == true) Console.WriteLine($"Använder {device.Type}");
                else Console.WriteLine("Trasig"); return;
            }
        }
    }
    public void AddDevice()
    {
        Console.Write("Ange typ: ");
        newDevice.Type = Console.ReadLine();

        Console.Write("ange märke/namn: ");
        newDevice.Brand = Console.ReadLine();

        Console.Write("ange om den fungerar (j/n): ");

        if (Console.ReadLine() == "j")
        {
            newDevice.IsFunctioning = true;
            deviceList.Add(newDevice);
            newDevice = new Devicemodel();
            Console.WriteLine(deviceList.Count);
            Console.WriteLine("Tillagd");
        }
        else if (Console.ReadLine() == "n")
        {
            newDevice.IsFunctioning = false;
            Console.WriteLine("köksapparaten är trasig");
        }
    }
    public void ListDevices()
    {
        int count = 0;
        foreach (var device in deviceList)
        {
            string PrintFunctionStatus()
            {
                string functionStatus = "";
                if (device.IsFunctioning == true) functionStatus = "Fungerar";

                else if (device.IsFunctioning == false) functionStatus = "Fungerar ej";

                return functionStatus;
            }
            count++;
            Console.WriteLine($"\n{count}: Typ: {device.Type}");
            Console.WriteLine("Märke: " + device.Brand);
            Console.WriteLine("Funktionsstatus: " + PrintFunctionStatus() + "\n----------------");
        }

    }

    public void Use()
    {
        DisplayMenuOptions();
        GetInput();
    }
}
