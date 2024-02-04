using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;
using System.Data;

namespace BusinessApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Device> SamsungM = new List<Device>();
            List<Device> OppoM = new List<Device>();
            List<Device> InfinixM = new List<Device>();
            List<Device> miXiaomiM = new List<Device>();
            List<Device> TecnoM = new List<Device>();
            List<Device> InfinixL = new List<Device>();
            List<Device> Dell = new List<Device>();
            List<Device> HP = new List<Device>();
            List<Device> iphoneL = new List<Device>();
            List<Device> mibro = new List<Device>();
            List<Device> kieslect = new List<Device>();
            List<Device> ZERO = new List<Device>();
            List<Device> Assortedsw = new List<Device>();
            List<Device> XiaomiE = new List<Device>();
            List<Device> Audionic = new List<Device>();
            List<Device> AssortedE = new List<Device>();
            List<Device> shDevices = new List<Device>();
            string[] feedbacks = new string[100];
            string[] mobileCompanies = new string[5] { "SAMSUNG", "OPPO", "INFINIX", "MI XIAOMI", "TECNO" };
            string[] LaptopCompanies = new string[4] { "INFINIX", "DELL", "HP", "IPHONE" };
            string[] swCompanies = new string[4] { "MIBRO", "KIESLECT", "ZERO", "ASSORTED" };
            string[] EarbudsCompanies = new string[3] { "MI XIAOMI", "AUDIONIC", "ASSORTED" };

            double budget = 0, tempBudget = budget;
            loadDevicedata(SamsungM, "Samsung.txt");
            loadDevicedata(OppoM, "Oppo.txt");
            loadDevicedata(InfinixM, "InfinixM.txt");
            loadDevicedata(miXiaomiM, "MiM.txt");
            loadDevicedata(TecnoM, "Tecno.txt");
            loadDevicedata(InfinixL, "InfinixL.txt");
            loadDevicedata(Dell, "Dell.txt");
            loadDevicedata(HP, "Hp.txt");
            loadDevicedata(iphoneL, "Iphone.txt");
            loadDevicedata(mibro, "Mibro.txt");
            loadDevicedata(kieslect, "Kieslect.txt");
            loadDevicedata(ZERO, "Zero.txt");
            loadDevicedata(Assortedsw, "AssortedS.txt");
            loadDevicedata(XiaomiE, "MiE.txt");
            loadDevicedata(Audionic, "Audionic.txt");
            loadDevicedata(AssortedE, "AssortedE.txt");
            loadDevicedata(shDevices, "Shdevices.txt");
            int feedbackCount = 0;
            loadFeedback(feedbacks, ref feedbackCount);
            Sign[] users = new Sign[100];
            int userCount = 0;
            string mName, mPassword, mRole, mAccount;
            ReadUserInfo(users, ref userCount);

            while (true)
            {
                printHeader();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                int opt;
                string input;
                loginPage();
                Console.WriteLine("Enter the option...");
                input = Console.ReadLine();
                if (checkOptionValidation(input))
                {
                    opt = int.Parse(input);
                    if (opt == 1)
                    {
                        Console.Clear();
                        printHeader();
                        Console.WriteLine("\t \t \t \t \t \t SIGN IN PAGE ");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");

                        string Name, Password;

                        while (true)
                        {
                            while (true)
                            {
                                Console.Write("Enter Username: ");
                                Name = Console.ReadLine();
                                if (string.IsNullOrEmpty(Name))
                                {
                                    Console.WriteLine("UserName cannot be empty.");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            while (true)
                            {
                                Console.Write("Enter Password: ");
                                Password = Console.ReadLine();
                                if (string.IsNullOrEmpty(Password))
                                {
                                    Console.WriteLine("Password cannot be empty.");
                                }
                                else
                                {
                                    break;
                                }
                            }

                            string userRole = SignIn(Name, Password, users, userCount);
                            int accountCount = AccountCount(Name, Password, users, userCount);
                            string upperUserRole = userRole.ToUpper();

                            if (upperUserRole == "ADMIN")
                            {
                                printHeader();
                                Console.WriteLine("Signing in as an ADMIN.");
                                Thread.Sleep(1500);
                                adminMenu(users, userCount, userCount, mobileCompanies, SamsungM, OppoM, InfinixM, miXiaomiM, TecnoM, LaptopCompanies, InfinixL, Dell, HP, iphoneL, swCompanies, mibro, kieslect, ZERO, Assortedsw, EarbudsCompanies, XiaomiE, Audionic, AssortedE, shDevices, ref budget, ref tempBudget, feedbacks, ref feedbackCount);
                                break;
                            }
                            else if (upperUserRole == "CUSTOMER")
                            {
                                printHeader();
                                Console.WriteLine("Signing in as a Customer.");
                                Thread.Sleep(1500);
                                customerMenu(mobileCompanies, SamsungM, OppoM, InfinixM, miXiaomiM, TecnoM, LaptopCompanies, InfinixL, Dell, HP, iphoneL, swCompanies, mibro, kieslect, ZERO, Assortedsw, EarbudsCompanies, XiaomiE, Audionic, AssortedE, shDevices, budget, ref tempBudget, users, accountCount, feedbacks, ref feedbackCount);
                                break;
                            }
                            else
                            {
                                Console.WriteLine(userRole);
                            }
                        }
                    }
                    else if (opt == 2)
                    {
                        Console.Clear();
                        printHeader();
                        Console.WriteLine("\t \t \t \t \t \t SIGN UP PAGE");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine("Instructions for Sign Up => \n Username must be at least 6 characters long and must not contain any special character and contain at least 3 letters \n Password must be at least 8 characters long\n");

                        while (true)
                        {
                            Console.Write("Enter Username: ");
                            mName = Console.ReadLine();
                            if (CheckUserName(mName, users, userCount))
                            {
                                break;
                            }
                        }

                        while (true)
                        {
                            Console.Write("Enter Password: ");
                            mPassword = Console.ReadLine();
                            if (mPassword.Length < 8)
                            {
                                Console.WriteLine("Invalid input. Password does not contain 8 characters.");
                                continue;
                            }
                            break;
                        }

                        while (true)
                        {
                            Console.Write("Enter your role (Admin/Customer): ");
                            mRole = Console.ReadLine().ToUpper();
                            if (mRole != "ADMIN" && mRole != "CUSTOMER")
                            {
                                Console.WriteLine("\nInvalid Role. Please select a valid role.");
                                continue;
                            }
                            break;
                        }

                        if (mRole == "CUSTOMER")
                        {
                            while (true)
                            {
                                Console.Write("Enter your Account Number (Must be 13 digits): ");
                                mAccount = Console.ReadLine();
                                if (mAccount.Length == 13 && checkOptionValidation(mAccount))
                                {
                                    users[userCount] = new Sign(mName, mPassword, mRole, mAccount);
                                    users[userCount].StoreUserInfo();
                                    Console.WriteLine("\nYou have successfully registered your credentials.");
                                    userCount++;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid Account Number / Account Number must be 13 digits.");
                                }
                            }
                        }
                        else if (mRole == "ADMIN")
                        {
                            users[userCount].StoreUserInfo();
                            Console.WriteLine("\nYou have successfully registered your credentials.");
                            userCount++;
                        }
                    }
                    else if (opt == 3)
                    {
                        Console.Clear();
                        printHeader();

                        Console.WriteLine("Thanks for coming here.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Option Selection.");
                        Thread.Sleep(750);
                        Console.Clear();
                        continue;
                    }

                    Console.WriteLine("\n\n\nPress any Key to go to Login Page...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please write valid input.");
                    Thread.Sleep(750);
                    Console.Clear();
                }
            }
        }

        static void printHeader()
        {
            Console.WriteLine("___________________________________________________________________________________________________________________________");
            Console.WriteLine("|                                                                                                                         |");
            Console.WriteLine("|                                                                                                                         |");
            Console.WriteLine("|                              ____  _   _ _____ ___ _  ___   _   _____ _____ ____ _   _                                  |");
            Console.WriteLine("|                             | ___|| | | | ____|_ _| |/ | | | | |_   _| ____| ___| | | |                                 |");
            Console.WriteLine("|                             |___ || |_| |  _|  | || ' /| |_| |   | | |  _| | |  | |_| |                                 |");
            Console.WriteLine("|                              ___)||  _  | |___ | || . \\|  _  |   | | | |__ | |__|  _  |                                 |");
            Console.WriteLine("|                             |____||_| |_|_____|___|_|\\_|_| |_|   |_| |_____|____|_| |_|                                 |");
            Console.WriteLine("|                                                                                                                         |");
            Console.WriteLine("|                                                                                                                         |");
            Console.WriteLine("|                                                                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------");

        }
        static void loginPage()
        {
            Console.WriteLine("\t \t \t \t \t \tLOGIN PAGE ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" 1. Sign In with your credentials.");
            Console.WriteLine(" 2. Sign Up your credentials");
            Console.WriteLine(" 3. Exit");
        }
        static void StoreFeedback(string[] feedbacks, int feedbackCount)
        {
            string path = "Feedback.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(feedbacks[feedbackCount]);
            file.Close();
        }

        static void loadFeedback(string[] feedbacks, ref int feedbackCount)
        {
            string path = "Feedback.txt";
            string record;
            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path);
                while ((record = reader.ReadLine()) != null)
                {
                    feedbacks[feedbackCount] = record;
                    feedbackCount++;
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("Not exists");
            }
        }
        static void loadDevicedata(List<Device> device, string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader file = new StreamReader(fileName);
                string record, model;
                double modelPrice;
                while ((record = file.ReadLine()) != null)
                {
                    model = ParseData(record, 1);
                    modelPrice = double.Parse(ParseData(record, 2));
                    Device newObj = new Device(model, modelPrice);
                    device.Add(newObj);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Not exists");
            }
        }
        static void UpdateDeviceData(List<Device> model, string fileName)
        {
            if (File.Exists(fileName))
            {
                StreamWriter file = new StreamWriter(fileName, false);
                for (int i = 0; i < model.Count; i++)
                {
                    file.Write(model[i].model + "," + model[i].modelPrice);
                    if (i < model.Count - 1)
                    {
                        file.WriteLine();
                    }
                }
                file.Close();

            }
            else
            {
                Console.WriteLine("Not exists");
            }
        }
        static void ReadUserInfo(Sign[] users, ref int userCount)
        {
            string record;
            StreamReader file = new StreamReader("Users.txt");
            while ((record = file.ReadLine()) != null)
            {
                string name = ParseData(record, 1);
                string password = ParseData(record, 2);
                string role = ParseData(record, 3);
                string accountNo = ParseData(record, 4);
                Sign newObj = new Sign(name, password, role, accountNo);
                users[userCount] = newObj;
                userCount++;
            }
            file.Close();
        }
        static void addDeviceData(string addModel, double addModelPrice, List<Device> company, string fileName)
        {
            Device obj = new Device(addModel, addModelPrice);
            company.Add(obj);
            StreamWriter file = new StreamWriter(fileName, true);
            file.WriteLine();
            file.Write($"{addModel},{addModelPrice}");
            file.Close();
        }

        static string ParseData(string record, int field)
        {
            int commaCount = 1;
            string item = "";

            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    commaCount++;
                }
                else if (commaCount == field)
                {
                    item += record[x];
                }
            }

            return item;
        }
        static string UpperLetters(string word)
        {
            string letters = "";

            for (int i = 0; i < word.Length; i++)
            {
                letters += char.ToUpper(word[i]);
            }

            return letters;
        }
        static bool CheckUserName(string word, Sign[] users, int userCount)
        {
            if (ExistedUsername(word, users, userCount))
            {
                Console.WriteLine("Username already taken. Please choose another.");
                return false;
            }

            if (word.Length > 5)
            {
                int letterCount = 0;

                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];

                    if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                    {
                        letterCount++;
                    }
                    else if (!(c >= '0' && c <= '9'))
                    {
                        Console.WriteLine("Invalid character in username. Use only letters and numbers.");
                        return false;
                    }
                }

                if (letterCount >= 3)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid username. Username must contain at least 3 letters.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid username. Username must be at least 6 characters long.");
                return false;
            }
        }
        static string SignIn(string name, string password, Sign[] users, int userCount)
        {
            for (int j = 0; j < userCount; j++)
            {
                if (name == users[j].name && password != users[j].password)
                {
                    return "You have entered the wrong password.";
                }
            }

            for (int j = 0; j < userCount; j++)
            {
                if (name != users[j].name && password == users[j].password)
                {
                    return "You have entered the wrong username.";
                }
            }

            for (int j = 0; j < userCount; j++)
            {
                if (name == users[j].name && password == users[j].password)
                {
                    Console.Clear();
                    return users[j].role;
                }
            }

            return "You are not registered yet.";
        }
        static int AccountCount(string name, string password, Sign[] users, int Count)
        {
            for (int j = 0; j < Count; j++)
            {
                if (name == users[j].name && password == users[j].password)
                {
                    Console.Clear();
                    return j;
                }
            }
            return -1;
        }
        static bool ExistedUsername(string name, Sign[] users, int userCount)
        {
            for (int i = userCount - 1; i >= 0; i--)
            {
                if (name == users[i].name)
                {
                    return true;
                }
            }
            return false;
        }
        static bool CheckMobileCompany(string company)
        {
            if (company == "SAMSUNG" || company == "OPPO" || company == "INFINIX" || company == "MI XIAOMI" || company == "TECNO")
            {
                return true;
            }
            return false;
        }

        static bool CheckLaptopCompany(string company)
        {
            if (company == "INFINIX" || company == "DELL" || company == "HP" || company == "IPHONE")
            {
                return true;
            }
            return false;
        }

        static bool CheckSWCompany(string company)
        {
            if (company == "MIBRO" || company == "KIESLECT" || company == "ZERO" || company == "ASSORTED")
            {
                return true;
            }
            return false;
        }

        static bool CheckEarbudCompany(string company)
        {
            if (company == "MI XIAOMI" || company == "AUDIONIC" || company == "ASSORTED")
            {
                return true;
            }
            return false;
        }

        static bool checkModel(List<Device> models, string modelName)
        {
            for (int j = 0; j < models.Count; j++)
            {
                if (models[j].model == modelName)
                {
                    return true;
                }
            }
            return false;
        }
        static void printMobiles(string[] mobileCompanies, List<Device> SamsungM, List<Device> OppoM, List<Device> InfinixM, List<Device> miXiaomiM, List<Device> TecnoM)
        {
            int mX = 81, mY = 20;
            Console.WriteLine("\t \t \t \t \t \t \t \t Samsung\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < SamsungM.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{SamsungM[i].model}");
                Console.SetCursorPosition(mX, mY);
                Console.WriteLine(SamsungM[i].modelPrice);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Oppo\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < OppoM.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{OppoM[i].model}");
                Console.SetCursorPosition(mX, mY + 8);
                Console.WriteLine(OppoM[i].modelPrice);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Infinix\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < InfinixM.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{InfinixM[i].model}");
                Console.SetCursorPosition(mX, mY + 16);
                Console.WriteLine(InfinixM[i].modelPrice);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t MI Xiaomi\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < miXiaomiM.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{miXiaomiM[i].model}");
                Console.SetCursorPosition(mX, mY + 24);
                Console.WriteLine(miXiaomiM[i].modelPrice);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Tecno\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < TecnoM.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{TecnoM[i].model}");
                Console.SetCursorPosition(mX, mY + 32);
                Console.WriteLine(TecnoM[i].modelPrice);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }

        static void printLaptops(string[] laptopCompanies, List<Device> InfinixL, List<Device> Dell, List<Device> HP, List<Device> iphoneL)
        {
            int mX = 90, mY = 20;

            Console.WriteLine("\t \t \t \t \t \t \t \t Infinix\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < InfinixL.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{InfinixL[i].model}");
                Console.SetCursorPosition(mX, mY);
                Console.WriteLine(InfinixL[i].modelPrice);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
            Console.WriteLine("\t \t \t \t \t \t \t \t Dell\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < Dell.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{Dell[i].model}");
                Console.SetCursorPosition(mX, mY + 8);
                Console.WriteLine(Dell[i].modelPrice);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
            Console.WriteLine("\t \t \t \t \t \t \t \t HP\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < HP.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{HP[i].model}");
                Console.SetCursorPosition(mX + 5, mY + 16);
                Console.WriteLine(HP[i].modelPrice);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
            Console.WriteLine("\t \t \t \t \t \t \t \t iPhone\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < iphoneL.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{iphoneL[i].model}");
                Console.SetCursorPosition(mX, mY + 24);
                Console.WriteLine(iphoneL[i].modelPrice);
                mY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }

        static void printSmartWatches(string[] swCompanies, List<Device> mibro, List<Device> kieslect, List<Device> ZERO, List<Device> Assortedsw)
        {
            int lX = 90, lY = 20;
            Console.WriteLine("\t \t \t \t \t \t \t \t Mibro\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < mibro.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{mibro[i].model}");
                Console.SetCursorPosition(lX, lY);
                Console.WriteLine(mibro[i].modelPrice);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Kieslect\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < kieslect.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{kieslect[i].model}");
                Console.SetCursorPosition(lX + 8, lY + 8);
                Console.WriteLine(kieslect[i].modelPrice);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Zero\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < ZERO.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{ZERO[i].model}");
                Console.SetCursorPosition(lX, lY + 16);
                Console.WriteLine(ZERO[i].modelPrice);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Assorted\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < Assortedsw.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{Assortedsw[i].model}");
                Console.SetCursorPosition(lX, lY + 24);
                Console.WriteLine(Assortedsw[i].modelPrice);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }

        static void printEarbuds(string[] earbudsCompanies, List<Device> XiaomiE, List<Device> Audionic, List<Device> AssortedE)
        {
            int lX = 82, lY = 20;
            Console.WriteLine("\t \t \t \t \t \t \t \t Xiaomi\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < XiaomiE.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{XiaomiE[i].model}");
                Console.SetCursorPosition(lX, lY);
                Console.WriteLine(XiaomiE[i].modelPrice);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Audionic\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < Audionic.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{Audionic[i].model}");
                Console.SetCursorPosition(lX, lY + 8);
                Console.WriteLine(Audionic[i].modelPrice);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Assorted\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < AssortedE.Count; i++)
            {
                Console.WriteLine($"\t \t \t \t{AssortedE[i].model}");
                Console.SetCursorPosition(lX, lY + 16);
                Console.WriteLine(AssortedE[i].modelPrice);
                lY++;
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }
        static void displaySHDevices(List<Device> shDevices)
        {
            int x = 56, y = 15;
            Console.WriteLine("\t \t \t SECOND HAND DEVICES \n");
            Console.WriteLine("---------------------------------------------------------------------------");

            for (int i = 0; i < shDevices.Count; i++)
            {
                Console.Write(shDevices[i].model);
                Console.SetCursorPosition(x, y);
                Console.WriteLine(shDevices[i].modelPrice);
                y++;
            }
        }
        static bool editModelPrice(List<Device> models, string modelName, double newPrice)
        {
            for (int j = 0; j < models.Count; j++)
            {
                if (models[j].model == modelName)
                {
                    models[j].modelPrice = newPrice;
                    return true;
                }
            }
            return false;
        }
        static bool deleteModel(List<Device> model, ref string modelName)
        {
            for (int j = 0; j < model.Count; j++)
            {
                if (model[j].model == modelName)
                {
                    model.RemoveAt(j);
                    return true;
                }
            }
            return false;
        }

        static string editSHDevicePrice(string editshDevice, double editshDevicePrice, List<Device> shDevices)
        {
            for (int i = 0; i < shDevices.Count; i++)
            {
                if (editshDevice == shDevices[i].model)
                {
                    shDevices[i].modelPrice = editshDevicePrice;
                    UpdateDeviceData(shDevices, "Shdevices.txt");

                    return "Device Price Update successfully.";
                }
            }

            return "Device not found.";
        }
        static string deleteSHDevice(string deleteshDevice, List<Device> shDevices)
        {
            for (int i = 0; i < shDevices.Count; i++)
            {
                if (deleteshDevice == shDevices[i].model)
                {
                    shDevices.RemoveAt(i);
                    UpdateDeviceData(shDevices, "Shdevices.txt");
                    return $"{deleteshDevice} deleted successfully";
                }
            }
            return "Wrong Device Name";
        }

        static bool checkOptionValidation(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (ch < '0' || ch > '9')
                {
                    return false;
                }
            }
            return true;
        }
        static void csph()
        {
            Console.Clear();
            printHeader();
        }
        static void adminMenu(Sign[] users, int newCount, int userCount, string[] mobileCompanies, List<Device> SamsungM, List<Device> OppoM, List<Device> InfinixM, List<Device> miXiaomiM, List<Device> TecnoM, string[] LaptopCompanies, List<Device> InfinixL, List<Device> Dell, List<Device> HP, List<Device> iphoneL, string[] swCompanies, List<Device> mibro, List<Device> kieslect, List<Device> ZERO, List<Device> Assortedsw, string[] EarbudsCompanies, List<Device> XiaomiE, List<Device> Audionic, List<Device> AssortedE, List<Device> shDevices, ref double budget, ref double tempBudget, string[] feedbacks, ref int feedbackCount)
        {
            int choice = -1;
            string input;
            do
            {
                int selectOption = -1, x = 35, y = 18;
                string addMobile, addLaptop, addSW, addEarbud, addMobileModel, addLaptopModel, addSWModel, addEarbudModel, deleteMobile, deleteMobileModel, deleteLaptop, deleteLaptopModel, deleteSw, deleteSwModel, deleteEarbud, deleteEarbudModel, editshDevice, deleteshDevice;
                double addMobilePrices, addLaptopPrice, addSWPrice, addEarbudPrice, editshDevicePrice;
                bool foundMobile = false, foundLaptop = false, foundSW = false, foundEarbud = false;

                csph();
                Console.WriteLine("\t \t \t \t \t \t ADMIN MENU ");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Enter 1 to check registered users and admins.");
                Console.WriteLine("Enter 2 to watch devices.");
                Console.WriteLine("Enter 3 to add Device Model.");
                Console.WriteLine("Enter 4 to edit Device Price.");
                Console.WriteLine("Enter 5 to delete Device.");
                Console.WriteLine("Enter 6 to handle second hand devices.");
                Console.WriteLine("Enter 7 to view your sales");
                Console.WriteLine("Enter 8 to see Feedbacks");
                Console.WriteLine("Enter 9 to change Theme ");
                Console.WriteLine("Enter 0 to escape the matrix");

                Console.WriteLine("Enter your choice... ");
                input = Console.ReadLine();
                if (checkOptionValidation(input))
                {
                    choice = int.Parse(input);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Thread.Sleep(750);
                    continue;
                }
                csph();

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\t Registered Admins and Customers are: ");
                        Console.WriteLine("\t Username \t \t Status ");
                        Console.WriteLine("--------------------------------------------------------------");

                        Console.SetCursorPosition(7, 18);
                        for (int i = 0; i < newCount; i++)
                        {
                            Console.Write("\t" + users[i].name);
                            Console.SetCursorPosition(x, y);
                            Console.WriteLine(users[i].role);
                            y++;
                        }

                        Console.WriteLine("\nPress any key to go back to Menu....");
                        Console.ReadKey();
                        break;

                    case 2:
                        do
                        {
                            csph();
                            Console.WriteLine("Enter 1 to watch Mobiles List");
                            Console.WriteLine("Enter 2 to watch Laptops List");
                            Console.WriteLine("Enter 3 to watch Smart Watches List");
                            Console.WriteLine("Enter 4 to watch Wireless Earbuds List");
                            Console.WriteLine("Enter 0 to go back to admin menu\n");
                            Console.Write("Enter your choice... ");
                            input = Console.ReadLine();

                            if (checkOptionValidation(input))
                            {
                                selectOption = int.Parse(input);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                                Thread.Sleep(800);
                                csph();
                                continue;
                            }

                            if (selectOption == 1)
                            {
                                csph();
                                Console.WriteLine("Following is the list of Mobiles with their prices.\n");
                                printMobiles(mobileCompanies, SamsungM, OppoM, InfinixM, miXiaomiM, TecnoM);
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 2)
                            {
                                csph();
                                Console.WriteLine("Following is the list of Laptops with their prices.\n");
                                printLaptops(LaptopCompanies, InfinixL, Dell, HP, iphoneL);
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 3)
                            {
                                csph();
                                Console.WriteLine("Following is the list of Smart Watches with their prices.\n");
                                printSmartWatches(swCompanies, mibro, kieslect, ZERO, Assortedsw);
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 4)
                            {
                                csph();
                                Console.WriteLine("Following is the list of Earbuds with their prices.\n");
                                printEarbuds(EarbudsCompanies, XiaomiE, Audionic, AssortedE);
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption > 4)
                            {
                                Thread.Sleep(800);
                                csph();
                                Console.WriteLine("\n /!\\ Write valid option please.\n\n\n");
                            }
                        } while (selectOption != 0);

                        break;

                    case 3:
                        do
                        {
                            csph();
                            Console.WriteLine("\n\nEnter 1 to add new Mobile Model");
                            Console.WriteLine("Enter 2 to add new Laptops Model");
                            Console.WriteLine("Enter 3 to add new Smart Watches Model");
                            Console.WriteLine("Enter 4 to add new Wireless Earbuds Model");
                            Console.WriteLine("Enter 0 to go back to admin menu\n");
                            Console.Write("Enter your choice... ");
                            input = Console.ReadLine();

                            if (checkOptionValidation(input))
                            {
                                selectOption = int.Parse(input);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                                Thread.Sleep(800);
                                csph();
                                continue;
                            }

                            if (selectOption == 1)
                            {
                                csph();
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of company in which you want to add model...");
                                    addMobile = Console.ReadLine().ToUpper();
                                    if (CheckMobileCompany(addMobile))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Company Name.");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of model you want to add...");
                                    addMobileModel = Console.ReadLine().ToUpper();
                                    if (!string.IsNullOrEmpty(addMobileModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid model name");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the price for this model...");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addMobilePrices = double.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                switch (addMobile)
                                {
                                    case "SAMSUNG":
                                        addDeviceData(addMobileModel, addMobilePrices, SamsungM, "Samsung.txt");
                                        Console.WriteLine("Mobile model added successfully to Samsung.");
                                        break;
                                    case "OPPO":
                                        addDeviceData(addMobileModel, addMobilePrices, OppoM, "Oppo.txt");
                                        Console.WriteLine("Mobile model added successfully to Oppo.");
                                        break;
                                    case "INFINIX":
                                        addDeviceData(addMobileModel, addMobilePrices, InfinixM, "InfinixM.txt");
                                        Console.WriteLine("Mobile model added successfully to Infinix.");
                                        break;
                                    case "MI XIAOMI":
                                        addDeviceData(addMobileModel, addMobilePrices, miXiaomiM, "MiM.txt");
                                        Console.WriteLine("Mobile model added successfully to MI Xiaomi.");
                                        break;
                                    case "TECNO":
                                        addDeviceData(addMobileModel, addMobilePrices, TecnoM, "Tecno.txt");
                                        Console.WriteLine("Mobile model added successfully to Tecno.");
                                        break;
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 2)
                            {
                                csph();
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of company in which you want to add model...");
                                    addLaptop = Console.ReadLine().ToUpper();
                                    if (CheckLaptopCompany(addLaptop))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Company Name.");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of model you want to add...");
                                    addLaptopModel = Console.ReadLine().ToUpper();
                                    if (!string.IsNullOrEmpty(addLaptopModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid model name");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the price for this model...");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addLaptopPrice = double.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                switch (addLaptop)
                                {
                                    case "INFINIX":
                                        addDeviceData(addLaptopModel, addLaptopPrice, InfinixL, "InfinixL.txt");
                                        Console.WriteLine("Laptop model added successfully to Infinix.");
                                        break;
                                    case "DELL":
                                        addDeviceData(addLaptopModel, addLaptopPrice, Dell, "Dell.txt");
                                        Console.WriteLine("Laptop model added successfully to Dell.");
                                        break;
                                    case "HP":
                                        addDeviceData(addLaptopModel, addLaptopPrice, HP, "Hp.txt");
                                        Console.WriteLine("Laptop model added successfully to HP.");
                                        break;
                                    case "IPHONE":
                                        addDeviceData(addLaptopModel, addLaptopPrice, iphoneL, "Iphone.txt");
                                        Console.WriteLine("Laptop model added successfully to iPhone.");
                                        break;
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 3)
                            {
                                csph();
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of company in which you want to add model...");
                                    addSW = Console.ReadLine().ToUpper();
                                    if (CheckSWCompany(addSW))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Company Name.");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of model you want to add...");
                                    addSWModel = Console.ReadLine().ToUpper();
                                    if (!string.IsNullOrEmpty(addSWModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid model name");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the price for this model...");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addSWPrice = double.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                switch (addSW)
                                {
                                    case "MIBRO":
                                        addDeviceData(addSWModel, addSWPrice, mibro, "Mibro.txt");
                                        Console.WriteLine("Smart Watch model added successfully to Mibro.");
                                        break;
                                    case "KIESLECT":
                                        addDeviceData(addSWModel, addSWPrice, kieslect, "Kieslect.txt");
                                        Console.WriteLine("Smart Watch model added successfully to Kieslect.");
                                        break;
                                    case "ZERO":
                                        addDeviceData(addSWModel, addSWPrice, ZERO, "Zero.txt");
                                        Console.WriteLine("Smart Watch model added successfully to ZERO.");
                                        break;
                                    case "ASSORTED":
                                        addDeviceData(addSWModel, addSWPrice, Assortedsw, "AssortedS.txt");
                                        Console.WriteLine("Smart Watch model added successfully to Assorted.");
                                        break;
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 4)
                            {
                                csph();
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of company in which you want to add model...");
                                    addEarbud = Console.ReadLine().ToUpper();
                                    if (CheckEarbudCompany(addEarbud))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Company Name.");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the name of model you want to add...");
                                    addEarbudModel = Console.ReadLine().ToUpper();
                                    if (!string.IsNullOrEmpty(addEarbudModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid model name");
                                    }
                                }
                                while (true)
                                {
                                    Console.WriteLine("Enter the price for this model...");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addEarbudPrice = double.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                switch (addEarbud)
                                {
                                    case "XIAOMI":
                                        addDeviceData(addEarbudModel, addEarbudPrice, XiaomiE, "MiE.txt");
                                        Console.WriteLine("Earbud model added successfully to Xiaomi.");
                                        break;
                                    case "AUDIONIC":
                                        addDeviceData(addEarbudModel, addEarbudPrice, Audionic, "Audionic.txt");
                                        Console.WriteLine("Earbud model added successfully to Audionic.");
                                        break;
                                    case "ASSORTED":
                                        addDeviceData(addEarbudModel, addEarbudPrice, AssortedE, "AssortedE.txt");
                                        Console.WriteLine("Earbud model added successfully to Assorted.");
                                        break;
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption > 4)
                            {
                                Console.WriteLine("Write valid option.");
                            }
                        } while (selectOption != 0);
                        break;

                    case 4:

                        do
                        {
                            csph();
                            Console.WriteLine("Enter 1 to edit Mobile Price");
                            Console.WriteLine("Enter 2 to edit Laptop Price");
                            Console.WriteLine("Enter 3 to edit Smart Watch Price");
                            Console.WriteLine("Enter 4 to edit Earbuds Price");
                            Console.WriteLine("Enter 0 to return to Admin Menu");
                            Console.Write("Choose the option: ");
                            input = Console.ReadLine();

                            if (checkOptionValidation(input))
                            {
                                selectOption = int.Parse(input);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                                Thread.Sleep(750);
                                continue;
                            }

                            if (selectOption == 1)
                            {
                                csph();
                                printMobiles(mobileCompanies, SamsungM, OppoM, InfinixM, miXiaomiM, TecnoM);
                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to edit the mobile price: ");
                                    addMobile = Console.ReadLine().ToUpper();
                                    if (CheckMobileCompany(addMobile))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name for which you want to edit the price: ");
                                    addMobileModel = Console.ReadLine().ToUpper();
                                    if (addMobile == "SAMSUNG" && checkModel(SamsungM, addMobileModel))
                                    {
                                        break;
                                    }
                                    else if (addMobile == "OPPO" && checkModel(OppoM, addMobileModel))
                                    {
                                        break;
                                    }
                                    else if (addMobile == "INFINIX" && checkModel(InfinixM, addMobileModel))
                                    {
                                        break;
                                    }
                                    else if (addMobile == "MI XIAOMI" && checkModel(miXiaomiM, addMobileModel))
                                    {
                                        break;
                                    }
                                    else if (addMobile == "TECNO" && checkModel(TecnoM, addMobileModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the new price: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addMobilePrices = int.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }

                                if (addMobile == "SAMSUNG")
                                {
                                    foundMobile = editModelPrice(SamsungM, addMobileModel, addMobilePrices);
                                    UpdateDeviceData(SamsungM, "Samsung.txt");
                                }
                                else if (addMobile == "OPPO")
                                {
                                    foundMobile = editModelPrice(OppoM, addMobileModel, addMobilePrices);
                                    UpdateDeviceData(OppoM, "Oppo.txt");
                                }
                                else if (addMobile == "INFINIX")
                                {
                                    foundMobile = editModelPrice(InfinixM, addMobileModel, addMobilePrices);
                                    UpdateDeviceData(InfinixM, "InfinixM.txt");
                                }
                                else if (addMobile == "MI XIAOMI")
                                {
                                    foundMobile = editModelPrice(miXiaomiM, addMobileModel, addMobilePrices);
                                    UpdateDeviceData(miXiaomiM, "MiM.txt");
                                }
                                else if (addMobile == "TECNO")
                                {
                                    foundMobile = editModelPrice(TecnoM, addMobileModel, addMobilePrices);
                                    UpdateDeviceData(TecnoM, "Tecno.txt");
                                }

                                if (foundMobile)
                                {
                                    Console.WriteLine("Mobile price updated successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 2)
                            {
                                csph();
                                printLaptops(LaptopCompanies, InfinixL, Dell, HP, iphoneL);

                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to edit the Laptop price: ");
                                    addLaptop = Console.ReadLine().ToUpper();
                                    if (CheckLaptopCompany(addLaptop))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name for which you want to edit the price: ");
                                    addLaptopModel = Console.ReadLine().ToUpper();
                                    if (addLaptop == "INFINIX" && checkModel(InfinixL, addLaptopModel))
                                    {
                                        break;
                                    }
                                    else if (addLaptop == "DELL" && checkModel(Dell, addLaptopModel))
                                    {
                                        break;
                                    }
                                    else if (addLaptop == "HP" && checkModel(HP, addLaptopModel))
                                    {
                                        break;
                                    }
                                    else if (addLaptop == "IPHONE" && checkModel(iphoneL, addLaptopModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the new price: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addLaptopPrice = int.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }

                                if (addLaptop == "INFINIX")
                                {
                                    foundLaptop = editModelPrice(InfinixL, addLaptopModel, addLaptopPrice);
                                    UpdateDeviceData(InfinixL, "InfinixL.txt");
                                }
                                else if (addLaptop == "DELL")
                                {
                                    foundLaptop = editModelPrice(Dell, addLaptopModel, addLaptopPrice);
                                    UpdateDeviceData(Dell, "Dell.txt");
                                }
                                else if (addLaptop == "HP")
                                {
                                    foundLaptop = editModelPrice(HP, addLaptopModel, addLaptopPrice);
                                    UpdateDeviceData(HP, "Hp.txt");
                                }
                                else if (addLaptop == "IPHONE")
                                {
                                    foundLaptop = editModelPrice(iphoneL, addLaptopModel, addLaptopPrice);
                                    UpdateDeviceData(iphoneL, "Iphone.txt");
                                }

                                if (foundLaptop)
                                {
                                    Console.WriteLine("Laptop price updated successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 3)
                            {
                                csph();
                                printSmartWatches(swCompanies, mibro, kieslect, ZERO, Assortedsw);
                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to edit the smart watch price: ");
                                    addSW = Console.ReadLine().ToUpper();
                                    if (CheckSWCompany(addSW))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name for which you want to edit the price: ");
                                    addSWModel = Console.ReadLine().ToUpper();
                                    if (addSW == "MIBRO" && checkModel(mibro, addSWModel))
                                    {
                                        break;
                                    }
                                    else if (addSW == "KIESLECT" && checkModel(kieslect, addSWModel))
                                    {
                                        break;
                                    }
                                    else if (addSW == "ZERO" && checkModel(ZERO, addSWModel))
                                    {
                                        break;
                                    }
                                    else if (addSW == "ASSORTED" && checkModel(Assortedsw, addSWModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }

                                while (true)
                                {
                                    Console.Write("Enter the new price: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addSWPrice = int.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }

                                if (addSW == "MIBRO")
                                {
                                    foundSW = editModelPrice(mibro, addSWModel, addSWPrice);
                                    UpdateDeviceData(mibro, "Mibro.txt");
                                }
                                else if (addSW == "KIESLECT")
                                {
                                    foundSW = editModelPrice(kieslect, addSWModel, addSWPrice);
                                    UpdateDeviceData(kieslect, "Kieslect.txt");
                                }
                                else if (addSW == "ZERO")
                                {
                                    foundSW = editModelPrice(ZERO, addSWModel, addSWPrice);
                                    UpdateDeviceData(ZERO, "Zero.txt");
                                }
                                else if (addSW == "ASSORTED")
                                {
                                    foundSW = editModelPrice(Assortedsw, addSWModel, addSWPrice);
                                    UpdateDeviceData(Assortedsw, "AssortedS.txt");
                                }

                                if (foundSW)
                                {
                                    Console.WriteLine("Smartwatch price updated successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 4)
                            {
                                csph();
                                printEarbuds(EarbudsCompanies, XiaomiE, Audionic, AssortedE);

                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to edit the Earbud price: ");
                                    addEarbud = Console.ReadLine().ToUpper();
                                    if (CheckEarbudCompany(addEarbud))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name for which you want to edit the price: ");
                                    addEarbudModel = Console.ReadLine().ToUpper();
                                    if (addEarbud == "MI XIAOMI" && checkModel(XiaomiE, addEarbudModel))
                                    {
                                        break;
                                    }
                                    else if (addEarbud == "AUDIONIC" && checkModel(Audionic, addEarbudModel))
                                    {
                                        break;
                                    }
                                    else if (addEarbud == "ASSORTED" && checkModel(AssortedE, addEarbudModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the new price: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        addEarbudPrice = int.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                if (addEarbud == "XIAOMI")
                                {
                                    foundEarbud = editModelPrice(XiaomiE, addEarbudModel, addEarbudPrice);
                                    UpdateDeviceData(XiaomiE, "MiE.txt");
                                }
                                else if (addEarbud == "AUDIONIC")
                                {
                                    foundEarbud = editModelPrice(Audionic, addEarbudModel, addEarbudPrice);
                                    UpdateDeviceData(Audionic, "Audionic.txt");
                                }
                                else if (addEarbud == "ASSORTED")
                                {
                                    foundEarbud = editModelPrice(AssortedE, addEarbudModel, addEarbudPrice);
                                    UpdateDeviceData(AssortedE, "AssortedE.txt");
                                }
                                if (foundEarbud)
                                {
                                    Console.WriteLine("Earbuds price updated successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption > 4)
                            {
                                Console.WriteLine("Invalid Option");
                            }
                        } while (selectOption != 0);
                        break;

                    case 5:
                        do
                        {
                            csph();
                            Console.WriteLine("Enter 1 to Delete Mobile");
                            Console.WriteLine("Enter 2 to Delete Laptops");
                            Console.WriteLine("Enter 3 to Delete Smart Watches");
                            Console.WriteLine("Enter 4 to Delete Wireless Earbuds");
                            Console.WriteLine("Enter 0 to return to Admin Menu");
                            Console.Write("Enter your choice... ");
                            input = Console.ReadLine();

                            if (checkOptionValidation(input))
                            {
                                selectOption = int.Parse(input);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid integer.");
                                Thread.Sleep(750);
                                continue;
                            }
                            if (selectOption == 1)
                            {
                                csph();
                                printMobiles(mobileCompanies, SamsungM, OppoM, InfinixM, miXiaomiM, TecnoM);
                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to delete a Mobile model: ");
                                    deleteMobile = Console.ReadLine().ToUpper();
                                    if (CheckMobileCompany(deleteMobile))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name which you want to delete: ");
                                    deleteMobileModel = Console.ReadLine().ToUpper();
                                    if (deleteMobile == "SAMSUNG" && checkModel(SamsungM, deleteMobileModel))
                                    {
                                        break;
                                    }
                                    else if (deleteMobile == "OPPO" && checkModel(OppoM, deleteMobileModel))
                                    {
                                        break;
                                    }
                                    else if (deleteMobile == "INFINIX" && checkModel(InfinixM, deleteMobileModel))
                                    {
                                        break;
                                    }
                                    else if (deleteMobile == "MI XIAOMI" && checkModel(miXiaomiM, deleteMobileModel))
                                    {
                                        break;
                                    }
                                    else if (deleteMobile == "TECNO" && checkModel(TecnoM, deleteMobileModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }

                                if (deleteMobile == "SAMSUNG")
                                {
                                    foundMobile = deleteModel(SamsungM, ref deleteMobileModel);
                                    UpdateDeviceData(SamsungM, "Samsung.txt");
                                }
                                else if (deleteMobile == "OPPO")
                                {
                                    foundMobile = deleteModel(OppoM, ref deleteMobileModel);
                                    UpdateDeviceData(OppoM, "Oppo.txt");
                                }
                                else if (deleteMobile == "INFINIX")
                                {
                                    foundMobile = deleteModel(InfinixM, ref deleteMobileModel);
                                    UpdateDeviceData(InfinixM, "InfinixM.txt");
                                }
                                else if (deleteMobile == "MI XIAOMI")
                                {
                                    foundMobile = deleteModel(miXiaomiM, ref deleteMobileModel);
                                    UpdateDeviceData(miXiaomiM, "MiM.txt");
                                }
                                else if (deleteMobile == "TECNO")
                                {
                                    foundMobile = deleteModel(TecnoM, ref deleteMobileModel);
                                    UpdateDeviceData(TecnoM, "Tecno.txt");
                                }

                                if (foundMobile)
                                {
                                    Console.WriteLine("Mobile model deleted successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 2)
                            {
                                csph();
                                printLaptops(LaptopCompanies, InfinixL, Dell, HP, iphoneL);
                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to delete a Laptop model: ");
                                    deleteLaptop = Console.ReadLine().ToUpper();
                                    if (CheckLaptopCompany(deleteLaptop))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name you want to delete: ");
                                    deleteLaptopModel = Console.ReadLine().ToUpper();
                                    if (deleteLaptop == "INFINIX" && checkModel(InfinixL, deleteLaptopModel))
                                    {
                                        break;
                                    }
                                    else if (deleteLaptop == "DELL" && checkModel(Dell, deleteLaptopModel))
                                    {
                                        break;
                                    }
                                    else if (deleteLaptop == "HP" && checkModel(HP, deleteLaptopModel))
                                    {
                                        break;
                                    }
                                    else if (deleteLaptop == "IPHONE" && checkModel(iphoneL, deleteLaptopModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }

                                if (deleteLaptop == "INFINIX")
                                {
                                    foundLaptop = deleteModel(InfinixL, ref deleteLaptopModel);
                                    UpdateDeviceData(InfinixL, "InfinixL.txt");
                                }
                                else if (deleteLaptop == "DELL")
                                {
                                    foundLaptop = deleteModel(Dell, ref deleteLaptopModel);
                                    UpdateDeviceData(Dell, "Dell.txt");
                                }
                                else if (deleteLaptop == "HP")
                                {
                                    foundLaptop = deleteModel(HP, ref deleteLaptopModel);
                                    UpdateDeviceData(HP, "Hp.txt");
                                }
                                else if (deleteLaptop == "IPHONE")
                                {
                                    foundLaptop = deleteModel(iphoneL, ref deleteLaptopModel);
                                    UpdateDeviceData(iphoneL, "Iphone.txt");
                                }

                                if (foundLaptop)
                                {
                                    Console.WriteLine("Laptop model deleted successfully.");
                                }

                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 3)
                            {
                                csph();
                                printSmartWatches(swCompanies, mibro, kieslect, ZERO, Assortedsw);

                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to delete a Smart Watch model: ");
                                    deleteSw = Console.ReadLine().ToUpper();
                                    if (CheckSWCompany(deleteSw))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name you want to delete: ");
                                    deleteSwModel = Console.ReadLine().ToUpper();
                                    if (deleteSw == "MIBRO" && checkModel(mibro, deleteSwModel))
                                    {
                                        break;
                                    }
                                    else if (deleteSw == "KIESLECT" && checkModel(kieslect, deleteSwModel))
                                    {
                                        break;
                                    }
                                    else if (deleteSw == "ZERO" && checkModel(ZERO, deleteSwModel))
                                    {
                                        break;
                                    }
                                    else if (deleteSw == "ASSORTED" && checkModel(Assortedsw, deleteSwModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }

                                if (deleteSw == "MIBRO")
                                {
                                    foundSW = deleteModel(mibro, ref deleteSwModel);
                                    UpdateDeviceData(mibro, "Mibro.txt");
                                }
                                else if (deleteSw == "KIESLECT")
                                {
                                    foundSW = deleteModel(kieslect, ref deleteSwModel);
                                    UpdateDeviceData(kieslect, "Kieslect.txt");
                                }
                                else if (deleteSw == "ZERO")
                                {
                                    foundSW = deleteModel(ZERO, ref deleteSwModel);
                                    UpdateDeviceData(ZERO, "Zero.txt");
                                }
                                else if (deleteSw == "ASSORTED")
                                {
                                    foundSW = deleteModel(Assortedsw, ref deleteSwModel);
                                    UpdateDeviceData(Assortedsw, "AssortedS.txt");
                                }
                                if (foundSW)
                                {
                                    Console.WriteLine("Smart Watch deleted successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 4)
                            {
                                csph();
                                printEarbuds(EarbudsCompanies, XiaomiE, Audionic, AssortedE);

                                while (true)
                                {
                                    Console.Write("Enter the company name for which you want to delete an Earbud model: ");
                                    deleteEarbud = Console.ReadLine().ToUpper();
                                    if (CheckEarbudCompany(deleteEarbud))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid company name");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write("Enter the model name for which you want to edit the price: ");
                                    deleteEarbudModel = Console.ReadLine().ToUpper();
                                    if (deleteEarbud == "MI XIAOMI" && checkModel(XiaomiE, deleteEarbudModel))
                                    {
                                        break;
                                    }
                                    else if (deleteEarbud == "AUDIONIC" && checkModel(Audionic, deleteEarbudModel))
                                    {
                                        break;
                                    }
                                    else if (deleteEarbud == "ASSORTED" && checkModel(AssortedE, deleteEarbudModel))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }

                                if (deleteEarbud == "Xiaomi")
                                {
                                    foundEarbud = deleteModel(XiaomiE, ref deleteEarbudModel);
                                    UpdateDeviceData(XiaomiE, "MiE.txt");
                                }
                                else if (deleteEarbud == "Audionic")
                                {
                                    foundEarbud = deleteModel(Audionic, ref deleteEarbudModel);
                                    UpdateDeviceData(Audionic, "Audionic.txt");
                                }
                                else if (deleteEarbud == "Assorted")
                                {
                                    foundEarbud = deleteModel(AssortedE, ref deleteEarbudModel);
                                    UpdateDeviceData(AssortedE, "AssortedE.txt");
                                }
                                if (foundEarbud)
                                {
                                    Console.WriteLine("Earbuds deleted successfully.");
                                }
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption > 4)
                            {
                                Console.WriteLine("Invalid Option");
                            }
                        } while (selectOption != 0);
                        break;

                    case 6:
                        do
                        {
                            csph();
                            Console.WriteLine("Enter 1 to watch Second Hand Devices ");
                            Console.WriteLine("Enter 2 to add Second Hand Devices ");
                            Console.WriteLine("Enter 3 to edit Second Hand Device Price");
                            Console.WriteLine("Enter 4 to delete Second Hand Device");
                            Console.WriteLine("Enter 0 to return to Admin Menu");
                            Console.Write("Choose an option...");
                            input = Console.ReadLine();

                            if (checkOptionValidation(input))
                            {
                                selectOption = int.Parse(input);
                            }
                            else
                            {
                                Console.WriteLine("Write valid Input");
                                Thread.Sleep(750);
                                continue;
                            }

                            if (selectOption == 1)
                            {
                                csph();
                                displaySHDevices(shDevices);
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 2)
                            {
                                csph();
                                Console.Write("Enter the name of device (with model and company) to add: ");
                                string model;
                                double modelPrice;
                                model = Console.ReadLine().ToUpper();
                                while (true)
                                {
                                    Console.Write("Enter the price for this device: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        modelPrice = double.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                Device newObj = new Device(model, modelPrice);
                                shDevices.Add(newObj);
                                Console.WriteLine($"\n{model} of price {modelPrice} has been added.");
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 3)
                            {
                                csph();
                                while (true)
                                {
                                    Console.Write("Enter the name of device (with model and company) of which you want to change price: ");
                                    editshDevice = Console.ReadLine().ToUpper();
                                    if (checkModel(shDevices, editshDevice))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }
                                while (true)
                                {
                                    Console.Write($"Enter the new price for {editshDevice}: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        editshDevicePrice = int.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n");
                                    }
                                }
                                Console.WriteLine(editSHDevicePrice(editshDevice, editshDevicePrice, shDevices));
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption == 4)
                            {
                                csph();
                                while (true)
                                {
                                    Console.Write("Enter the name of device (with model and company) to delete: ");
                                    deleteshDevice = Console.ReadLine().ToUpper();
                                    if (checkModel(shDevices, deleteshDevice))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Model not found.");
                                    }
                                }
                                Console.WriteLine(deleteSHDevice(deleteshDevice, shDevices));
                                Console.WriteLine("\nPress any key to go back...");
                                Console.ReadKey();
                            }
                            else if (selectOption > 4)
                            {
                                Console.WriteLine("Enter valid option.");
                            }
                        } while (selectOption != 0);
                        break;
                    case 7:
                        Console.WriteLine("Your Sales: " + tempBudget);
                        Console.WriteLine("\nPress any key to go back to Menu.... ");
                        Console.ReadKey();
                        break;
                    case 8:
                        if (feedbackCount == 0)
                        {
                            Console.SetCursorPosition(35, 12);
                            Console.WriteLine("No Feedbacks Till Now.");
                        }
                        else
                        {
                            Console.WriteLine("                                       FEEDBACKS              ");
                            Console.WriteLine("=======================================================================================================");
                            Console.WriteLine();

                            for (int i = 0; i < feedbackCount; i++)
                            {
                                Console.WriteLine(feedbacks[i]);
                            }
                        }
                        Console.WriteLine("\nPress any key to go back to Menu.... ");
                        Console.ReadKey();
                        break;
                    case 0:
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        Thread.Sleep(800);
                        break;
                }
            } while (choice != 0);
        }

        static void printMobileswithinbudget(double budget, string[] mobileCompanies, List<Device> SamsungM, List<Device> OppoM, List<Device> InfinixM, List<Device> miXiaomiM, List<Device> TecnoM)
        {
            int mX = 81, mY = 20;
            Console.WriteLine("\t \t \t \t \t \t \t \t Samsung\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < SamsungM.Count; i++)
            {
                if (SamsungM[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{SamsungM[i].model}");
                    Console.SetCursorPosition(mX, mY);
                    Console.WriteLine(SamsungM[i].modelPrice);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Oppo\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < OppoM.Count; i++)
            {
                if (OppoM[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{OppoM[i].model}");
                    Console.SetCursorPosition(mX, mY + 8);
                    Console.WriteLine(OppoM[i].modelPrice);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Infinix\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < InfinixM.Count; i++)
            {
                if (InfinixM[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{InfinixM[i].model}");
                    Console.SetCursorPosition(mX, mY + 16);
                    Console.WriteLine(InfinixM[i].modelPrice);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t MI Xiaomi\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < miXiaomiM.Count; i++)
            {
                if (miXiaomiM[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{miXiaomiM[i].model}");
                    Console.SetCursorPosition(mX, mY + 24);
                    Console.WriteLine(miXiaomiM[i].modelPrice);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Tecno\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < TecnoM.Count; i++)
            {
                if (TecnoM[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{TecnoM[i].model}");
                    Console.SetCursorPosition(mX, mY + 32);
                    Console.WriteLine(TecnoM[i].modelPrice);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }

        static void printLaptopswithinbudget(double budget, string[] laptopCompanies, List<Device> InfinixL, List<Device> Dell, List<Device> HP, List<Device> iphoneL)
        {
            int mX = 90, mY = 20;

            Console.WriteLine("\t \t \t \t \t \t \t \t Infinix\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < InfinixL.Count; i++)
            {
                if (InfinixL[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{InfinixL[i].model}");
                    Console.SetCursorPosition(mX, mY);
                    Console.WriteLine(InfinixL[i].modelPrice);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
            Console.WriteLine("\t \t \t \t \t \t \t \t Dell\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < Dell.Count; i++)
            {
                if (Dell[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{Dell[i].model}");
                    Console.SetCursorPosition(mX, mY + 8);
                    Console.WriteLine(Dell[i].modelPrice);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
            Console.WriteLine("\t \t \t \t \t \t \t \t HP\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < HP.Count; i++)
            {
                if (HP[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{HP[i].model}");
                    Console.SetCursorPosition(mX + 5, mY + 16);
                    Console.WriteLine(HP[i].modelPrice);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
            Console.WriteLine("\t \t \t \t \t \t \t \t iPhone\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < iphoneL.Count; i++)
            {
                if (iphoneL[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{iphoneL[i].model}");
                    Console.SetCursorPosition(mX, mY + 24);
                    Console.WriteLine(iphoneL[i].modelPrice);
                    mY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }
        static void printSmartWatcheswithinbudget(double budget, string[] swCompanies, List<Device> mibro, List<Device> kieslect, List<Device> ZERO, List<Device> Assortedsw)
        {
            int lX = 90, lY = 20;
            Console.WriteLine("\t \t \t \t \t \t \t \t Mibro\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < mibro.Count; i++)
            {
                if (mibro[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{mibro[i].model}");
                    Console.SetCursorPosition(lX, lY);
                    Console.WriteLine(mibro[i].modelPrice);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Kieslect\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < kieslect.Count; i++)
            {
                if (kieslect[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{kieslect[i].model}");
                    Console.SetCursorPosition(lX + 8, lY + 8);
                    Console.WriteLine(kieslect[i].modelPrice);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Zero\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < ZERO.Count; i++)
            {
                if (ZERO[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{ZERO[i].model}");
                    Console.SetCursorPosition(lX, lY + 16);
                    Console.WriteLine(ZERO[i].modelPrice);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Assorted\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < Assortedsw.Count; i++)
            {
                if (Assortedsw[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{Assortedsw[i].model}");
                    Console.SetCursorPosition(lX, lY + 24);
                    Console.WriteLine(Assortedsw[i].modelPrice);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }
        static void printEarbudswithinbudget(double budget, string[] earbudsCompanies, List<Device> XiaomiE, List<Device> Audionic, List<Device> AssortedE)
        {
            int lX = 82, lY = 20;
            Console.WriteLine("\t \t \t \t \t \t \t \t Xiaomi\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < XiaomiE.Count; i++)
            {
                if (XiaomiE[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{XiaomiE[i].model}");
                    Console.SetCursorPosition(lX, lY);
                    Console.WriteLine(XiaomiE[i].modelPrice);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Audionic\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < Audionic.Count; i++)
            {
                if (Audionic[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{Audionic[i].model}");
                    Console.SetCursorPosition(lX, lY + 8);
                    Console.WriteLine(Audionic[i].modelPrice);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            Console.WriteLine("\t \t \t \t \t \t \t \t Assorted\n");
            Console.WriteLine("\t \t \t \t \t Model" + new string(' ', 28) + "\t \t Prices\n");
            Console.WriteLine("                              ---------------------------------------------------------------------------\n");

            for (int i = 0; i < AssortedE.Count; i++)
            {
                if (AssortedE[i].modelPrice <= budget)
                {
                    Console.WriteLine($"\t \t \t \t{AssortedE[i].model}");
                    Console.SetCursorPosition(lX, lY + 16);
                    Console.WriteLine(AssortedE[i].modelPrice);
                    lY++;
                }
            }

            Console.WriteLine("                              ---------------------------------------------------------------------------\n");
        }
        static bool ModelExisted(string buyDevice, string buyModel, List<Device> SamsungM, List<Device> OppoM, List<Device> InfinixM, List<Device> miXiaomiM, List<Device> TecnoM, List<Device> InfinixL, List<Device> Dell, List<Device> HP, List<Device> iphoneL, List<Device> mibro, List<Device> kieslect, List<Device> ZERO, List<Device> Assortedsw, List<Device> XiaomiE, List<Device> Audionic, List<Device> AssortedE)
        {
            if (buyDevice == "MOBILE")
            {
                for (int i = 0; i < 10; i++)
                {
                    if (buyModel == SamsungM[i].model || buyModel == OppoM[i].model || buyModel == InfinixM[i].model || buyModel == miXiaomiM[i].model || buyModel == TecnoM[i].model)
                    {
                        return true;
                    }
                }
            }
            else if (buyDevice == "LAPTOP")
            {
                for (int i = 0; i < 10; i++)
                {
                    if (buyModel == InfinixL[i].model || buyModel == Dell[i].model || buyModel == HP[i].model || buyModel == iphoneL[i].model)
                    {
                        return true;
                    }
                }
            }
            else if (buyDevice == "SMART WATCH")
            {
                for (int i = 0; i < 10; i++)
                {
                    if (buyModel == mibro[i].model || buyModel == kieslect[i].model || buyModel == ZERO[i].model || buyModel == Assortedsw[i].model)
                    {
                        return true;
                    }
                }
            }
            else if (buyDevice == "EARBUDS")
            {
                for (int i = 0; i < 10; i++)
                {
                    if (buyModel == XiaomiE[i].model || buyModel == Audionic[i].model || buyModel == AssortedE[i].model)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static double getDevicePrice(string buyModel, List<Device> models)
        {
            for (int i = 0; i < models.Count; i++)
            {
                if (models[i].model == buyModel)
                {
                    return models[i].modelPrice;
                }
            }
            return 0.0;
        }

        static double getSHDevicePrice(string buySHDevice, List<Device> shDevices)
        {
            for (int i = 0; i < shDevices.Count; i++)
            {
                if (buySHDevice == shDevices[i].model)
                {
                    return shDevices[i].modelPrice;
                }
            }
            return 0;
        }
        static bool CheckAccount(string aNo, Sign[] users, int accountCount)
        {
            string accountNo = users[accountCount].accountNo;


            for (int i = 0; i < aNo.Length; i++)
            {
                if (aNo[i] != accountNo[i])
                {
                    return false;
                }
            }
            return true;
        }
        static void customerMenu(
    string[] mobileCompanies, List<Device> SamsungM, List<Device> OppoM, List<Device> InfinixM, List<Device> miXiaomiM, List<Device> TecnoM,
    string[] LaptopCompanies, List<Device> InfinixL, List<Device> Dell, List<Device> HP, List<Device> iphoneL,
    string[] swCompanies, List<Device> mibro, List<Device> kieslect, List<Device> ZERO, List<Device> Assortedsw,
    string[] EarbudsCompanies, List<Device> XiaomiE, List<Device> Audionic, List<Device> AssortedE,
    List<Device> shDevices, double budget, ref double tempBudget, Sign[] users, int accountCount, string[] feedbacks, ref int feedbackCount
)
        {
            int choice = 1;
            string buyDevice, showDevice, buyModel, buySHDevice, aNo;
            double shPrice;
            while (choice != 0)
            {
                Console.Clear();
                printHeader();
                Console.WriteLine("\t \t \t \t \t \t CUSTOMER MENU \n");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------\n");
                Console.WriteLine("\n\n\n");
                Console.WriteLine("Enter 1 to Watch the Device you want (Mobile / Laptop / Smart Watch/ Earbuds)");
                Console.WriteLine("Enter 2 to Add money in your account");
                Console.WriteLine("Enter 3 to Watch the Device (Mobile / Laptop / Smart Watch/ Earbuds) within your budget");
                Console.WriteLine("Enter 4 to Watch Second Hand Devices");
                Console.WriteLine("Enter 5 to Select the Device you Wanna Buy ");
                Console.WriteLine("Enter 6 to Select the Second Hand Device you Want to Buy ");
                Console.WriteLine("Enter 7 to see your bill and remaining amount.");
                Console.WriteLine("Enter 8 to give your feedback");
                Console.WriteLine("Enter 0 to escape the matrix\n");

                Console.Write("Enter your choice... ");
                string input = Console.ReadLine();

                if (checkOptionValidation(input))
                {
                    choice = int.Parse(input);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    Thread.Sleep(750);
                    continue;
                }

                Console.Clear();
                printHeader();
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        printHeader();
                        Console.WriteLine("\t \t \t \t \t \t CUSTOMER MENU ");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------\n\n\n");

                        Console.WriteLine("Enter the name of device (Mobile / Laptop / Smart Watch/ Earbuds) you want to view: ");
                        showDevice = Console.ReadLine().ToUpper();

                        if (showDevice == "MOBILE")
                        {
                            printMobiles(mobileCompanies, SamsungM, OppoM, InfinixM, miXiaomiM, TecnoM);
                        }
                        else if (showDevice == "LAPTOP")
                        {
                            printLaptops(LaptopCompanies, InfinixL, Dell, HP, iphoneL);
                        }
                        else if (showDevice == "SMART WATCH")
                        {
                            printSmartWatches(swCompanies, mibro, kieslect, ZERO, Assortedsw);
                        }
                        else if (showDevice == "EARBUDS")
                        {
                            printEarbuds(EarbudsCompanies, XiaomiE, Audionic, AssortedE);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Device Name.");
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            Console.WriteLine("Enter your Account Number: ");
                            aNo = Console.ReadLine();
                            if (CheckAccount(aNo, users, accountCount) && aNo.Length == 13)
                            {
                                while (true)
                                {
                                    Console.WriteLine("Enter the amount of money you want to add: ");
                                    input = Console.ReadLine();
                                    if (checkOptionValidation(input))
                                    {
                                        budget = double.Parse(input);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Write valid input\n\n");
                                    }
                                }
                                tempBudget = budget;
                                Console.WriteLine($"\n\nYour amount of {budget} has been updated.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Wrong Account Number.");
                            }
                        }
                        break;

                    case 3:
                        if (budget == 0)
                        {
                            Console.WriteLine("Please first Enter the Amount by going to Option 2.");
                        }
                        else
                        {
                            Console.WriteLine("Enter the name of device (Mobile / Laptop / Smart Watch / Earbuds) you want to see under " + budget + ": ");
                            buyDevice = Console.ReadLine().ToUpper();

                            if (buyDevice == "MOBILE")
                            {
                                Console.WriteLine();
                                printMobileswithinbudget(budget, mobileCompanies, SamsungM, OppoM, InfinixM, miXiaomiM, TecnoM);
                            }
                            else if (buyDevice == "LAPTOP")
                            {
                                Console.WriteLine();
                                printLaptopswithinbudget(budget, LaptopCompanies, InfinixL, Dell, HP, iphoneL);
                            }
                            else if (buyDevice == "SMART WATCH")
                            {
                                Console.WriteLine();
                                printSmartWatcheswithinbudget(budget, swCompanies, mibro, kieslect, ZERO, Assortedsw);
                            }
                            else if (buyDevice == "EARBUDS")
                            {
                                Console.WriteLine();
                                printEarbudswithinbudget(budget, EarbudsCompanies, XiaomiE, Audionic, AssortedE);
                            }
                            else
                            {
                                Console.WriteLine("Wrong device Name.");
                            }
                        }
                        break;


                    case 4:
                        displaySHDevices(shDevices);
                        break;

                    case 5:
                        if (budget == 0)
                        {
                            Console.WriteLine("Please first Enter the Amount by going to Option 2.");
                        }
                        else
                        {
                            Console.WriteLine("Enter the name of device (Mobile / Laptop / Smart Watch/ Earbuds) you want to buy: ");
                            buyDevice = Console.ReadLine().ToUpper();

                            if (buyDevice == "MOBILE" || buyDevice == "MOBILES")
                            {
                                Console.WriteLine();
                                printMobileswithinbudget(budget, mobileCompanies, SamsungM, OppoM, InfinixM, miXiaomiM, TecnoM);
                            }
                            else if (buyDevice == "LAPTOP" || buyDevice == "LAPTOPS")
                            {
                                Console.WriteLine();
                                printLaptopswithinbudget(budget, LaptopCompanies, InfinixL, Dell, HP, iphoneL);
                            }
                            else if (buyDevice == "SMART WATCH" || buyDevice == "SMARTWATCH")
                            {
                                Console.WriteLine();
                                printSmartWatcheswithinbudget(budget, swCompanies, mibro, kieslect, ZERO, Assortedsw);
                            }
                            else if (buyDevice == "EARBUDS" || buyDevice == "EARBUD")
                            {
                                Console.WriteLine();
                                printEarbudswithinbudget(budget, EarbudsCompanies, XiaomiE, Audionic, AssortedE);
                            }
                            else
                            {
                                Console.WriteLine("This device ain't available.");
                            }

                            Console.WriteLine();
                            Console.WriteLine("If no device available Enter 'Return' to go back.");

                            while (true)
                            {
                                Console.WriteLine("Enter the name of model: ");
                                buyModel = Console.ReadLine().ToUpper();

                                if (ModelExisted(buyDevice, buyModel, SamsungM, OppoM, InfinixM, miXiaomiM, TecnoM, InfinixL, Dell, HP, iphoneL, mibro, kieslect, ZERO, Assortedsw, XiaomiE, Audionic, AssortedE))
                                {
                                    double devicePrice = 0.0;
                                    if (buyDevice == "MOBILE")
                                    {
                                        devicePrice = getDevicePrice(buyModel, SamsungM) +
                                                      getDevicePrice(buyModel, OppoM) +
                                                      getDevicePrice(buyModel, InfinixM) +
                                                      getDevicePrice(buyModel, miXiaomiM) +
                                                      getDevicePrice(buyModel, TecnoM);
                                    }
                                    else if (buyDevice == "LAPTOP")
                                    {
                                        devicePrice = getDevicePrice(buyModel, InfinixL) +
                                                      getDevicePrice(buyModel, Dell) +
                                                      getDevicePrice(buyModel, HP) +
                                                      getDevicePrice(buyModel, iphoneL);
                                    }
                                    else if (buyDevice == "SMART WATCH")
                                    {
                                        devicePrice = getDevicePrice(buyModel, mibro) +
                                                      getDevicePrice(buyModel, kieslect) +
                                                      getDevicePrice(buyModel, ZERO) +
                                                      getDevicePrice(buyModel, Assortedsw);
                                    }
                                    else if (buyDevice == "EARBUDS")
                                    {
                                        devicePrice = getDevicePrice(buyModel, XiaomiE) +
                                                      getDevicePrice(buyModel, Audionic) +
                                                      getDevicePrice(buyModel, AssortedE);
                                    }
                                    if (devicePrice > 0 && devicePrice <= budget)
                                    {
                                        Console.WriteLine("The selected device " + buyDevice + " (" + buyModel + ") is within your budget and is bought successfully.");
                                        Console.WriteLine("Price: " + devicePrice);
                                        budget -= devicePrice;
                                        break;
                                    }
                                    else if (devicePrice > budget)
                                    {
                                        Console.WriteLine("The selected device " + buyDevice + " (" + buyModel + ")  is out of your budget.");
                                        break;
                                    }
                                }
                                else if (buyModel == "RETURN")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Wrong Model Name");
                                }
                            }
                        }
                        break;

                    case 6:
                        if (budget == 0)
                        {
                            Console.WriteLine("Please first Enter the Amount by going to Option 2.");
                        }
                        else
                        {
                            displaySHDevices(shDevices);
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Enter the name of device you want to buy: ");
                            buySHDevice = Console.ReadLine().ToUpper();
                            shPrice = getSHDevicePrice(buySHDevice, shDevices);

                            if (shPrice > 0 && shPrice <= budget)
                            {
                                Console.WriteLine("The selected device " + buySHDevice + " is within your budget and is bought successfully.");
                                Console.WriteLine("Price: " + shPrice);
                                budget -= shPrice;
                            }
                            else if (shPrice > budget)
                            {
                                Console.WriteLine("The selected device " + buySHDevice + " is out of your budget.");
                            }
                            else if (shPrice == 0)
                            {
                                Console.WriteLine("Invalid selection. Please check your input.");
                            }
                        }
                        break;
                    case 7:
                        Console.WriteLine(" \t \t \t BILL");
                        Console.WriteLine("-------------------------------------------------------------------------\n");
                        Console.WriteLine($"Your Initial Amount: ${tempBudget}");
                        if (true)
                        {
                            tempBudget = tempBudget - budget;
                        }
                        Console.WriteLine($"Your Paid Amount: ${tempBudget}");
                        Console.WriteLine($"Your Remaining Amount: ${budget}");
                        break;

                    case 8:
                        Console.WriteLine();
                        Console.WriteLine();
                        while (true)
                        {
                            Console.WriteLine("Enter your feedback: ");
                            feedbacks[feedbackCount] = Console.ReadLine();
                            if (string.IsNullOrEmpty(feedbacks[feedbackCount]))
                            {
                                Console.WriteLine("Feedback cannot be empty. Please Enter correct feedback.");
                            }
                            else
                            {
                                Console.WriteLine("Thanks for your Feedback.");
                                break;
                            }
                        }
                        StoreFeedback(feedbacks, feedbackCount);
                        feedbackCount++;
                        break;

                    case 0:
                        Console.WriteLine(" ");
                        budget = 0;
                        tempBudget = budget;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;


                }
                if (choice != 0)
                {
                    Console.WriteLine("\n\nPress any key to go back to Menu.... ");
                    Console.ReadKey();
                }

            }
        }
    }
}