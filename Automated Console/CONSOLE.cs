using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
class ConsoleApp
{

    private static CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    private static readonly object _lock = new object();
    private static string? _userInput;

    static void Main()
    {

        // Настройка цвета консоли
        Console.BackgroundColor = ConsoleColor.Black; // Цвет фона
        Console.ForegroundColor = ConsoleColor.Green; // Цвет текста
        Console.Clear(); // Применяем изменения

        // Установка кодировки консоли на UTF-8
        Console.OutputEncoding = Encoding.UTF8;


        while (true)
        {
            Console.WriteLine("1. DELETE");
            Console.WriteLine("2. ADD FOLDER OR ADD HIDE FOLDER");
            Console.WriteLine("3. EXPLORER");
            Console.WriteLine("4. CMD");
            Console.WriteLine("5. CONTROL PANEL");
            Console.WriteLine("6. REGEDIT");
            Console.WriteLine("7. PERFMON");
            Console.WriteLine("8. OPEN ZAPRET");
            Console.WriteLine("Q. EXIT");
            Console.WriteLine("R. RESTART");
            Console.WriteLine("Enter the number depending on your choice");

            string? action = Console.ReadLine(); // Используем '?' для указания, что значение может быть null



            //DELETE FOLDER DELETE FOLDER DELETE FOLDER DELETE FOLDER DELETE FOLDER DELETE FOLDER DELETE FOLDER 
            if (action != null && action.Equals("1"))
            {
                Console.Write("Enter the full path to the folder you want to delete: ");
                string? pathToDelete = Console.ReadLine();

                if (pathToDelete == "Q" || pathToDelete == "q" || pathToDelete == "end" || pathToDelete == "END")
                {
                    Environment.Exit(0);
                }

                if (pathToDelete != null)
                {
                    Console.WriteLine($"You want to delete the folder: {pathToDelete}? (Y/N)");
                    string? userInput = Console.ReadLine();

                    if (userInput != null && userInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            if (Directory.Exists(pathToDelete))
                            {
                                Directory.Delete(pathToDelete, true);
                                Console.WriteLine("Folder deleted successfully");
                            }
                            else
                            {
                                Console.WriteLine("Folder not found");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                    }
                    else if (userInput != null && userInput.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Folder deletion cancelled");
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Please enter Y or N");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Folder path cannot be empty");
                }
            }
            //DELETE FOLDER DELETE FOLDER DELETE FOLDER DELETE FOLDER DELETE FOLDER DELETE FOLDER DELETE FOLDER 

            //FOLDER ADD FOLDER ADD FOLDER ADD FOLDER ADD FOLDER ADD FOLDER ADD FOLDER ADD FOLDER ADD FOLDER ADD 
            else if (action != null && action.Equals("2"))
            {
                Console.Write("Enter the name of the folder you want to add (or the full path): ");
                string? pathToAdd = Console.ReadLine();

                if (pathToAdd != null)
                {
                    if (pathToAdd == "Q" || pathToAdd == "q" || pathToAdd == "end" || pathToAdd == "END")
                    {
                        Environment.Exit(0);
                    }

                    try
                    {
                        // Проверяем, содержит ли путь кавычки
                        bool isHidden = pathToAdd.StartsWith("\"") && pathToAdd.EndsWith("\"");

                        // Убираем кавычки, если они есть
                        string folderPath = isHidden ? pathToAdd.Trim('"') : pathToAdd;

                        // Создаем папку
                        Directory.CreateDirectory(folderPath);
                        Console.WriteLine($"Folder '{folderPath}' added successfully");

                        // Если папка была указана в кавычках, делаем ее скрытой
                        if (isHidden)
                        {
                            var directoryInfo = new DirectoryInfo(folderPath);
                            directoryInfo.Attributes |= FileAttributes.Hidden; // Устанавливаем атрибут "Скрытый"
                            Console.WriteLine($"Folder '{folderPath}' is now hidden.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Folder name cannot be empty");
                }
            }
            //FOLDER ADD FOLDER ADD FOLDER ADD FOLDER ADD FOLDER ADD FOLDER ADD FOLDER ADD FOLDER ADD FOLDER ADD 

            //QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT 
            else if (action != null && action.Equals("Q") || (action != null && action.Equals("q")) ||
                        (action != null && action.Equals("END")))
            {
                Console.WriteLine("Exiting the program");
                Environment.Exit(0);
            }
            //QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT QUIT 

            //EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER 
            else if (action != null && action.Equals("3"))
            {
                Console.WriteLine("Opening Explorer...");
                try
                {
                    Process.Start("explorer.exe");
                }
                catch
                {
                    Console.WriteLine("Error opening Explorer");
                }
            }
            //EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER EXPLORER 

            //CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD 
            else if (action != null && action.Equals("4"))
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        UseShellExecute = true,
                        WorkingDirectory = @"C:\",
                        Arguments = "/k color 4 & help",
                    };

                    Process.Start(startInfo);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error opening cmd");
                }
            }
            //CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD CMD 

            //CONTROL PANEL CONTROL PANEL CONTROL PANEL CONTROL PANEL CONTROL PANEL CONTROL PANEL CONTROL PANEL 
            else if (action != null && action.Equals("5"))
            {
                Console.WriteLine("Opening Control Panel...");
                try
                {
                    Process.Start("control.exe");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error opening Control Panel: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("ERROR");
            }
            //CONTROL PANEL CONTROL PANEL CONTROL PANEL CONTROL PANEL CONTROL PANEL CONTROL PANEL CONTROL PANEL 

            //REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT 
            if (action != null && action.Equals("6"))
            {
                Console.WriteLine("Opening Reegedit...");
                try
                {
                    Process.Start("regedit.exe");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("ERROR");
            }
            //REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT REGEDIT 

            //RESOURCE MONITOR RESOURCE MONITOR RESOURCE MONITOR RESOURCE MONITOR RESOURCE MONITOR RESOURCE MONITOR 
            if (action != null && action.Equals("7"))
            {
                Console.WriteLine("Opening RESOURCE MONITOR...");
                try
                {
                    Process.Start("%windir%\\system32\\perfmon.exe /res");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("ERROR");
            }
            //RESOURCE MONITOR RESOURCE MONITOR RESOURCE MONITOR RESOURCE MONITOR RESOURCE MONITOR RESOURCE MONITOR 

            //RESTART RESTART RESTART RESTART RESTART RESTART RESTART RESTART RESTART RESTART RESTART RESTART RESTART 
            {
                if (action != null && action.Equals("R") || action != null && action.Equals("clear") ||
                    action != null && action.Equals("Clear") || action != null && action.Equals("r"))
                {
                    // Получаем путь к исполняемому файлу
                    string exePath = AppDomain.CurrentDomain.BaseDirectory + "Automated Console.exe"; // Замените на имя вашего .exe файла

                    // Запускаем новое приложение
                    Process.Start(exePath);

                    // Завершаем текущее приложение
                    Environment.Exit(0);
                }
                //RESTART RESTART RESTART RESTART RESTART RESTART RESTART RESTART RESTART RESTART RESTART RESTART RESTART 

                if (action != null && action.Equals("8"))
                {
                    Process.Start("\"E:\\Моё\\zapret\\zapret-discord-youtube-1.6.2\\general.bat\"");
                }
            }
        }
    }
}
