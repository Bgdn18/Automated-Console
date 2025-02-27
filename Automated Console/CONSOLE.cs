using System;
using System.IO;
using System.Text;

class ConsoleApp
{
    static void Main()
    {
        // Установка кодировки консоли на UTF-8
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("1. Delete File/Folder");
            Console.WriteLine("2. Add Folder");
            Console.WriteLine("3. Quit");
            Console.WriteLine("Enter the number depending on your choice");

            string? action = Console.ReadLine(); // Используем '?' для указания, что значение может быть null

            //DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE 
            if (action != null && action.Equals("1"))
            {
                // Удаление папки
                Console.Write("Enter the full path to the folder you want to delete: ");
                string? pathToDelete = Console.ReadLine(); // Используем '?' для указания, что значение может быть null

                if (pathToDelete != null)
                {
                    Console.WriteLine($"You want to delete the folder: {pathToDelete}? (Y/N)");
                    string? userInput = Console.ReadLine(); // Используем '?' для указания, что значение может быть null

                    if (userInput != null && userInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            if (Directory.Exists(pathToDelete))
                            {
                                Directory.Delete(pathToDelete, true); // true для удаления всех подкаталогов и файлов
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
            //DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE DELETE 

            //ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD 
            else if (action != null && action.Equals("2"))
            {
                // Добавление папки
                Console.Write("Enter the name of the folder you want to add (or the full path):");
                string? pathToAdd = Console.ReadLine(); // Используем '?' для указания, что значение может быть null

                if (pathToAdd != null)
                {
                    try
                    {
                        // Создание папки
                        Directory.CreateDirectory(pathToAdd);
                        Console.WriteLine($"Folder '{pathToAdd}' added successfully");
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
            //ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD ADD 

            //Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit 
            else if (action != null && action.Equals("3"))
            {
                // Выход из программы
                Console.WriteLine("Exiting the program");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("ERROR: Enter 1, 2 or 3");
            }
            //Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit Quit 
        }
    }
}
