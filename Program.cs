IDevice deviceModel = new DeviceModel();
deviceModel.StartMenu();

//public interface IKitchenDevices
//{
//    void StartMenu();
//}
public interface IDevice
{
    void StartMenu();

}

public class Devicemodel
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public bool IsFunctioning { get; set; }

}
public class DeviceModel : IDevice
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
    public void GetInput()
    {
        bool isNumber = true;
        do
        {
            Console.Write("Ange ett tal: ");
            var input = Console.ReadLine();
            isNumber = int.TryParse(input, out int number);
            if (!isNumber)
            {
                isNumber = true;
                Console.Write("Ange ett tal: ");
                input = Console.ReadLine();
                continue;
            }
            if (number == 1)
            {
                Console.WriteLine("success");
                break;
            }
            if (number == 2)
            {
                AddDevice();
                break;
            }
            if (number == 3) ListDevices(); break;
          
        } while (isNumber);
        StartMenu();

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

        foreach (var device in deviceList)
        {
            string PrintFunctionStatus()
            {
                string functionStatus = "";
                if (device.IsFunctioning == true) functionStatus = "Fungerar";

                else if (device.IsFunctioning == false) functionStatus = "Fungerar ej";

                return functionStatus;
            }

            Console.WriteLine("Typ: " + device.Type);
            Console.WriteLine("Märke: " + device.Brand);
            Console.WriteLine("Funktionsstatus: " + PrintFunctionStatus());
        }

    }
    public void Use()
    {

    }
    public void StartMenu()
    {
        DisplayMenuOptions();
        GetInput();
    }
}

//    public string GetUserInput()
//    {
//        string userInput = Console.ReadLine();
//        bool isNumber = true;
//        do
//        {
//            Console.Write("Ange tal: ");
//            userInput = Console.ReadLine();
//            //input form user

//            //check if input is number
//            isNumber = int.TryParse(userInput, out int number);

//            //if it's letter just skip
//            if (!isNumber)
//            {
//                isNumber = true;
//                Console.WriteLine("Oglitigt");
//                Console.Write("Ange tal: ");
//                userInput = Console.ReadLine();
//                continue;
//            }
//            // if input is greater than 5 continue
//            if (number > 5)
//            {
//                isNumber = true;
//                Console.WriteLine("Oglitigt");
//                Console.Write("Ange tal: ");
//                userInput = Console.ReadLine();
//                continue;
//            }

//            break;
//        }
//        while (isNumber);
//        return userInput;
//    }
//    public void HandelUserInput()
//    {

//        if (GetUserInput() == "1")
//        {
//            Console.WriteLine("1 choosed");
//        }
//        if (GetUserInput() == "2")
//        {
//            kitchenMethods.AddKitchenDevice();
//            StartMenu();
//        }
//        if (GetUserInput() == "3")
//        {
//            kitchenMethods.ListDevices();
//            StartMenu();
//        }
//    }
//    public void StartMenu()
//    {
//        DisplayMenuOptions();
//        HandelUserInput();
//    }
//}
//class KitchenMethods : KitchenMenu
//{

//    List<KitchenDevices> kitchenDeviceList = new List<KitchenDevices>();
//    KitchenDevices kitchenDevice = new KitchenDevices();


//    public void AddKitchenDevice()
//    {
//        List<KitchenDevices> kitchenDeviceList = new List<KitchenDevices>();
//        KitchenDevices kitchenDevice = new KitchenDevices();


//        Console.Write("Ange typ: ");
//        kitchenDevice.Type = new(Console.ReadLine());

//        if (kitchenDevice.Type == null) return;

//        Console.Write("Ange märke/namn: ");
//        kitchenDevice.Brand = new(Console.ReadLine());

//        if (kitchenDevice.Brand == null) return;

//        Console.Write("Ange om den fungerar (j/n): ");
//        if (Console.ReadLine() == "j")
//        {
//            kitchenDeviceList.Add(kitchenDevice);
//            kitchenDevice = new KitchenDevices();
//            Console.WriteLine(kitchenDeviceList.Count);

//            Console.WriteLine("Tillagd!");
//        }
//        else if (Console.ReadLine() == "n")
//        {
//            kitchenDevice.IsFunctioning = false;
//            Console.WriteLine("köksapparaten är trasig");
//        }

//    }

//    public void ListDevices()
//    {
//        foreach (KitchenDevices item in kitchenDeviceList)
//        {
//            Console.WriteLine(item.Type);
//            Console.WriteLine(item.Brand);
//            Console.WriteLine(item.IsFunctioning);
//        }
//    }




//}


