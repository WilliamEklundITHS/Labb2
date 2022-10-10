using System;
using System.Collections;
using System.Reflection;
using System.Xml.Linq;


IDevice deviceModel = new DeviceModel();
deviceModel.UserInterface();

public interface IDevice
{
    void UserInterface();
    protected string Type { get; set; }
    protected string Brand { get; set; }
    protected bool IsFunctioning { get; set; }
}

class DeviceModel : IDevice
{
    private string? _type;
    string IDevice.Type
    {
        get => _type;
        set => _type = value;
    }
    private string _brand;
    string IDevice.Brand
    {
        get { return _brand; }

        set { _brand = value; }
    }
    private bool _isFunctioning;
    bool IDevice.IsFunctioning
    {
        get => _isFunctioning;
        set => _isFunctioning = value;
    }

    private List<DeviceModel> deviceList = new List<DeviceModel>();
    private DeviceModel? NewDevice { get; set; }


    static private List<DeviceModel> DefaultDeviceList()
    {

        List<DeviceModel> defaultDeviceList = new List<DeviceModel>()
        {
            new DeviceModel() { _type = "Vattenkokare",
            _brand = "Siemens",
            _isFunctioning = true, },

            new DeviceModel() {

                _type = "Kastrull",
            _brand = "Phillips",
            _isFunctioning = false,
            },
             new DeviceModel() {
                _type = "Kaffebryggare",
            _brand = "Samsung",
            _isFunctioning = true,
            },
        };
        //var ff = defaultDeviceList.FindAll(x => x._isFunctioning == true);
        //Console.WriteLine(ff.Count);
        return defaultDeviceList;
    }

    private void InsertDefaultDeviceList()
    {
        if (deviceList.Count == 0) { deviceList.AddRange(DefaultDeviceList()); }
        return;
    }

    private string[] navOptionsArr = { "1. Använd köksapparat", "2. Lägg till köksapparat", "3. Lista köksapparater", "4. Ta bort köksapparat", "5. Avsluta" };
    private void DisplayMenuOptions()
    {
        string navOptions = "";
        foreach (string option in navOptionsArr)
        {
            navOptions += $"\n{option}";
        }
        Console.WriteLine(navOptions);
    }

    private void GetSelectedOption()
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
                continue;
            }
            conditions(number);
            void conditions(int userInput)
            {
                if (userInput == 1) { UseDevice(); }
                if (userInput == 2) { AddDevice(); }
                if (userInput == 3) { ListDevices(); }
                if (userInput == 4) { RemoveDevice(); }
                if (userInput == 5) { ExitProgram(); }
            }
        } while (isNumber);

        UserInterface();
    }

    private int GetSelectedDevice()
    {
        int number = 0;
        bool isNumber = true;
        var input = Console.ReadLine();
        foreach (var device in deviceList)
        {
            isNumber = int.TryParse(input, out number);
            if (!isNumber || number > deviceList.Count)
            {
                isNumber = true;
                Console.WriteLine("Felaktig inmatning\n");
                UserInterface();
            }

        }
        return number;
    }
    //-------USE DEVICE-------
    private void UseDevice()
    {
        ListDevices();
        Console.Write("Välj köksapparat: ");
        DeviceModel dd = SelectedDevice;
        Console.WriteLine("Använder => " + dd._type);
    }

    //-------ADD DEVICE-------
    private void AddDevice()
    {
        NewDevice = new DeviceModel();
        Console.Write("Ange typ: ");
        NewDevice._type = Console.ReadLine();

        Console.Write("ange märke/namn: ");
        NewDevice._brand = Console.ReadLine();

        Console.Write("ange om den fungerar (j/n): ");

        if (Console.ReadLine() == "j")
        {
            NewDevice._isFunctioning = true;
            deviceList.Add(NewDevice);
            NewDevice = new DeviceModel();
            Console.WriteLine(deviceList.Count);
            Console.WriteLine("Tillagd!\n");
        }
        else if (Console.ReadLine() == "n")
        {
            NewDevice._isFunctioning = false;
            deviceList.Add(NewDevice);
            NewDevice = new DeviceModel();
            Console.WriteLine("köksapparaten är trasig");
            Console.WriteLine("Tillagd!\n");
        }
    }
    private DeviceModel SelectedDevice => deviceList.ElementAt(GetSelectedDevice() - 1);

    private void PrintActionMsg(string actionTypeMsg, string ax)
    {
        if (SelectedDevice._isFunctioning == false) { Console.WriteLine("Köksapparaten är trasig\n"); }
        Console.WriteLine(actionTypeMsg, ax);
    }
    //-------LIST DEVICE-------
    protected List<DeviceModel> ListDevices()
    {
        int index = 0;
        foreach (var device in deviceList)
        {
            string PrintDeviceFunctionStatus()
            {
                string functionStatus = "";
                if (device._isFunctioning == true) functionStatus = "Fungerar";

                else if (device._isFunctioning == false) functionStatus = "Fungerar ej";

                return functionStatus;
            }
            index++;
            Console.WriteLine($"\n{index}: Typ: {device._type}");
            Console.WriteLine("Märke: " + device._brand);
            Console.WriteLine("Funktionsstatus: " + PrintDeviceFunctionStatus() + "\n----------------");
        }
        Console.WriteLine("Totalt: " + deviceList.Count);
        return deviceList;
    }
    //-------REMOVE DEVICE-------
    private void RemoveDevice()
    {
        ListDevices();
        Console.Write("\nTa bort köksapparat: ");
        var deviceToRemove = SelectedDevice;
        deviceList.Remove(deviceToRemove);
        if (!deviceList.Contains(deviceToRemove))
        {
            //UPDATE LIST
            deviceList = new(ListDevices());
        }
        Console.WriteLine("Tog bort => " + deviceToRemove._type);
        UserInterface();
    }
    //------EXIT PROGRAM-------
    private static void ExitProgram()
    {
        Environment.Exit(0);
    }
    //-------USER INTERFACE-------
    public void UserInterface()
    {
        InsertDefaultDeviceList();
        DisplayMenuOptions();
        GetSelectedOption();
    }
}












//Devicemodel newDevice = new Devicemodel();

//    List<Devicemodel> deviceList = new List<Devicemodel>()
//    {
//        new Devicemodel(){ Type = "Våffeljärn", Brand="Electrolux", IsFunctioning = true},
//         new Devicemodel(){ Type = "Vattenkokare", Brand="Siemens", IsFunctioning = true},
//           new Devicemodel(){ Type = "Brödrost", Brand="Philips", IsFunctioning = false},

//    };
//    public string[] menuOptionsArr = { "1. Använd köksapparat", "2. Lägg till köksapparat", "3. Lista köksapparater", "4. Ta bort köksapparat", "5. Avsluta" };
//    public void DisplayMenuOptions()
//    {
//        string menuOptions = "";
//        foreach (string option in menuOptionsArr)
//        {
//            menuOptions += $"\n{option}";
//        }
//        Console.WriteLine(menuOptions);
//    }

//    public int Input(string input)
//    {
//        int option = 0;
//        do
//        {
//            if (int.TryParse(input, out option) && option <= 5 && option >= 1) break;
//            Console.Write("Ange val: ");
//            input = Console.ReadLine();
//        }
//        while (!int.TryParse(input, out option) || option > 5 || option < 1);
//        return option;
//    }

//    public void GetInput()
//    {
//        bool isNumber = true;
//        do
//        {
//            Console.Write("Ange ett val: ");
//            var input = Console.ReadLine();
//            isNumber = int.TryParse(input, out int number);
//            if (!isNumber)
//            {
//                isNumber = true;
//                Console.Write("Ange ett val: ");
//                input = Console.ReadLine();
//                continue;
//            }
//            if (number == 1)
//            {
//                UseDevice();
//                break;
//            }
//            if (number == 2)
//            {
//                AddDevice();
//                break;
//            }
//            if (number == 3) { ListDevices(); break; }

//            if (number == 4) RemoveDevice(); break;

//        } while (isNumber);
//        Use();
//    }

//    public void RemoveDevice()
//    {
//        ListDevices();
//        int count = 0;
//        Console.Write("Ta bort köksapparat: ");
//        var input = Console.ReadLine();
//        foreach (var device in deviceList)
//        {
//            count++;
//            if (int.Parse(input) == count)
//            {
//                Console.WriteLine($"Tog bort {device.Type}");
//                deviceList.Remove(device);
//                return;
//            }
//        }
//    }
//    public bool DeviceFunction()
//    {
//        bool isDeviceFunctioning = true;

//        foreach (var device in deviceList)
//        {
//            isDeviceFunctioning = device.IsFunctioning;
//            if (isDeviceFunctioning == true)
//            {
//                Console.WriteLine($"Använder {device.Type}");
//            }
//            else
//            {
//                Console.WriteLine("Trasig");
//                return false;
//            }
//        }
//        return isDeviceFunctioning;
//    }
//    public void UseDevice()
//    {
//        ListDevices();
//        int count = 0;
//        Console.Write("Välj köksapparat: ");
//        var input = Console.ReadLine();
//        foreach (var device in deviceList)
//        {
//            count++;
//            int.TryParse(input, out int number);
//            if (number == count)
//            {
//                if (device.IsFunctioning == true) Console.WriteLine($"Använder {device.Type}");
//                else Console.WriteLine("Trasig"); return;
//            }
//        }
//    }
//    public int GetSelectedDevice()
//    {
//        Console.Write("Välj köksapparat: ");
//        int count = 0;
//        foreach (var device in deviceList)
//        {
//            count++;
//        }
//        return count;
//    }
//    public void AddDevice()
//    {
//        Console.Write("Ange typ: ");
//        newDevice.Type = Console.ReadLine();

//        Console.Write("ange märke/namn: ");
//        newDevice.Brand = Console.ReadLine();

//        Console.Write("ange om den fungerar (j/n): ");

//        if (Console.ReadLine() == "j")
//        {
//            newDevice.IsFunctioning = true;
//            deviceList.Add(newDevice);
//            newDevice = new Devicemodel();
//            Console.WriteLine(deviceList.Count);
//            Console.WriteLine("Tillagd");
//        }
//        else if (Console.ReadLine() == "n")
//        {
//            newDevice.IsFunctioning = false;
//            deviceList.Add(newDevice);
//            newDevice = new Devicemodel();
//            Console.WriteLine("köksapparaten är trasig");
//            Console.WriteLine("Tillagd");
//        }
//    }
//    public void ListDevices()
//    {
//        int count = 0;
//        foreach (var device in deviceList)
//        {
//            string PrintFunctionStatus()
//            {
//                string functionStatus = "";
//                if (device.IsFunctioning == true) functionStatus = "Fungerar";

//                else if (device.IsFunctioning == false) functionStatus = "Fungerar ej";

//                return functionStatus;
//            }
//            count++;
//            Console.WriteLine($"\n{count}: Typ: {device.Type}");
//            Console.WriteLine("Märke: " + device.Brand);
//            Console.WriteLine("Funktionsstatus: " + PrintFunctionStatus() + "\n----------------");
//        }
//        Console.WriteLine("Totalt: " + count);

//    }

//    public void Use()
//    {
//        DisplayMenuOptions();
//        GetInput();
//    }
//}
