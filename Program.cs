using System;
using System.Collections;
using System.Reflection;
using System.Xml.Linq;


IDevice deviceModel = new DeviceModel();
deviceModel.Use();
public interface IDevice
{
    void Use();
    public string Type { get; set; }
    public string Brand { get; set; }
    public bool IsFunctioning { get; set; }
}


class DeviceModel : IDevice
{

    private string _type;
    string IDevice.Type
    {
        get => _type;
        set => _type = value;
    }
    private string _brand;
    string IDevice.Brand
    {
        get { return _brand; }

        set { }
    }
    private bool _isFunctioning;
    bool IDevice.IsFunctioning
    {
        get => _isFunctioning;
        set => _isFunctioning = value;
    }


    public List<DeviceModel> deviceList = new List<DeviceModel>();
    public DeviceModel? NewDevice { get; set; }

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

    public void InsertDefaultDeviceList()
    {
        if (deviceList.Count == 0) { deviceList.AddRange(DefaultDeviceList()); }
        return;
    }
    public void ListDevices()
    {
        int count = 0;
        foreach (var device in deviceList)
        {
            string PrintDeviceFunctionStatus()
            {
                string functionStatus = "";
                if (device._isFunctioning == true) functionStatus = "Fungerar";

                else if (device._isFunctioning == false) functionStatus = "Fungerar ej";

                return functionStatus;
            }
            count++;
            Console.WriteLine($"\n{count}: Typ: {device._type}");
            Console.WriteLine("Märke: " + device._brand);
            Console.WriteLine("Funktionsstatus: " + PrintDeviceFunctionStatus() + "\n----------------");
        }
        Console.WriteLine("Totalt: " + count);
    }


    public string[] navOptionsArr = { "1. Använd köksapparat", "2. Lägg till köksapparat", "3. Lista köksapparater", "4. Ta bort köksapparat", "5. Avsluta" };
    public void DisplayMenuOptions()
    {
        string navOptions = "";
        foreach (string option in navOptionsArr)
        {
            navOptions += $"\n{option}";
        }
        Console.WriteLine(navOptions);
    }



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
            if (number == 1) { UseDevice(); break; }
            if (number == 2) { AddDevice(); break; }
            if (number == 3) { ListDevices(); break; }
            if (number == 4) { RemoveDevice(); break; }

        } while (isNumber);
        Use();
    }
    //-------ADD DEVICE-------
    public void AddDevice()
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

    public void UseDevice()
    {
        ListDevices();

        Console.Write("Välj köksapparat: ");
        var getSelectedDevice = deviceList.ElementAt(GetSelectedDevice());
        try
        {
            if (getSelectedDevice._isFunctioning == false)
            {
                Console.WriteLine("Köksapparaten är trasig"); return;
            }
            Console.WriteLine($"Använder {getSelectedDevice._type}");
        }
        catch (Exception ex) { Console.WriteLine(ex); }
    }

    public int GetSelectedDevice()
    {
        int number = 0;
        bool isNumber = true;
        var input = Console.ReadLine();
        foreach (var device in deviceList)
        {
            isNumber = int.TryParse(input, out number);
            if (!isNumber)
            {
                isNumber = true;
                Console.WriteLine("Felaktig inmatning\n");
                Use();
            }
        }
        return number;
    }
    public List<DeviceModel> ItemList()
    {
        return deviceList;
    }
    public void RemoveDevice()
    {
        ListDevices();
        Console.Write("\nTa bort köksapparat: ");

        var selectedDevice = deviceList.ElementAt(GetSelectedDevice() - 1);
        if (selectedDevice._isFunctioning == false) { Console.WriteLine("Köksapparaten är trasig"); return; }
        deviceList.Remove(selectedDevice);

        //if (!deviceList.Contains(selectedDevice)){}
        Console.WriteLine($"\nTog bort {selectedDevice._type}");
    }

    public void Use()
    {
        InsertDefaultDeviceList();
        DisplayMenuOptions();
        GetInput();
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
