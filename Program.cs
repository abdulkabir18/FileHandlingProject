string path = @"C:\Users\USER\Desktop\sysbeamsExecrise";
bool isActive = true;
string filePath = "";
int track = 0;

while (isActive)
{
    Console.WriteLine("Press 1 to create folder\nPress 2 to create file\nPress 3 to write to the file\nPress 4 to print from the file");
    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        Console.Write("Input the name of the folder: ");
        string input = Console.ReadLine();

        CreateFolder(input);

        Console.WriteLine("Press 1 to run again\nPress 2 to close the program");
        int press = int.Parse(Console.ReadLine());
        if (press != 1)
            isActive = false;
    }
    else if (choice == 2)
    {
        Console.Write("Enter the folder name you want to create file to: ");
        string foldername = Console.ReadLine();

        if (CheckFolder(foldername))
        {
            Console.Write("Enetr the file name to create: ");
            string fileName = Console.ReadLine();

            CreateFile(foldername, fileName);

            Console.WriteLine("Press 1 to run again\nPress 2 to close the program");
            int press = int.Parse(Console.ReadLine());
            if (press != 1)
                isActive = false;
        }
        else
        {
            Console.WriteLine($"The ({foldername}) folder does not found\n");

            Console.WriteLine("Press 1 to run again\nPress 2 to close the program");
            int press = int.Parse(Console.ReadLine());
            if (press != 1)
                isActive = false;
        }
    }
    else if (choice == 3)
    {
        Console.WriteLine("Enter the folder name where the file is located");
        string folderName = Console.ReadLine();
        Console.Write("Enter the file name you want to write to: ");
        string fileName = Console.ReadLine();

        bool flag = CheckFile(folderName, fileName);

        if (flag)
        {
            Console.WriteLine("Enter the sentences you want to save");
            string word = Console.ReadLine();

            WriteToFile(word);

            Console.WriteLine("Press 1 to run again\nPress 2 to close the program");
            int press = int.Parse(Console.ReadLine());
            if (press != 1)
                isActive = false;
        }

    }
    else if (choice == 4)
    {
        Console.WriteLine("Enter the folder name where the file is stored");
        string folderName = Console.ReadLine();
        if (CheckFolder(folderName))
        {
            Console.Write("Enter the file name to print from: ");
            string fileName = Console.ReadLine();

            if (CheckFile(folderName, fileName))
            {
                ReadFromFile();

                Console.WriteLine("Press 1 to run again\nPress 2 to close the program");
                int press = int.Parse(Console.ReadLine());
                if (press != 1)
                    isActive = false;
            }
        }

    }
    else
    {
        track++;
        Console.WriteLine($"Invalid input {track}");
        if (track == 3)
        {
            Console.WriteLine($"You enter invalid input {track} times");
            isActive = false;
        }
    }

}

void CreateFolder(string folderName)
{
    string createFolder = Path.Combine(path, folderName);
    Directory.CreateDirectory(createFolder);
    Console.WriteLine($"({folderName}) folder is created succefully ");
}

void CreateFile(string folderName, string fileName)
{
    string filePath = Path.Combine(path, folderName, fileName);
    File.Create(filePath);
    Console.WriteLine($"({fileName}) file created succefully under ({folderName}) folder");
}

bool CheckFolder(string folderName)
{
    string checkFolder = Path.Combine(path, folderName);

    if (Directory.Exists(checkFolder))
    {
        return true;
    }
    return false;
}

bool CheckFile(string folderName, string fileName)
{
    if (CheckFolder(folderName) == true)
    {
        string checkedFolder = Path.Combine(path, folderName, fileName);

        if (File.Exists(checkedFolder))
        {
            filePath = checkedFolder;
            return true;
        }
        else
        {
            Console.WriteLine($"({fileName}) file does not exist");
            return false;
        }
    }
    else
    {
        Console.WriteLine($"({folderName}) folder does not exist");
        return false;
    }
}

void WriteToFile(string text)
{
    using (StreamWriter streamWriter = new StreamWriter(filePath))
    {
        streamWriter.WriteLine(text);
    }
}

void ReadFromFile()
{
    string[] file = File.ReadAllLines(filePath);
    foreach (string word in file)
    {
        Console.WriteLine(word);
    }
}

int a = 9;
Console.WriteLine(a);