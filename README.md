#Download and install Git from git-scm.com.

#During installation, ensure the PATH environment variable is updated to include Git.

#Install Visual Studio with the following workloads:

   - ASP.NET and web development
   - .NET Core cross-platform development

#Ensure you have access to the GitHub repository.

#Install the .NET SDK 8.0 compatible with the project

#Open a command prompt (Windows Terminal or PowerShell).

Navigate to the folder where you want to store the project:

1. Clone the Repository from GitHub:

   A. Open Git Bash or Command Prompt
      - Press Win + R, type cmd and press Enter to open the Command Prompt.
      - Alternatively, you can open Git Bash if you installed Git with the Bash terminal.

   B. Navigate to the Directory Where You Want to Clone the Project
      - Use the cd command to navigate to the directory where you want to store the project. For example:
        cd C:\Users\<YourUsername>\Projects

   C. Clone the Repository
        Once you're in the desired directory, run the following command to clone the repository from GitHub to your local machine:
        git clone https://github.com/arirfan-kid/samplecrudapp.git
        
After this command, the project will be downloaded into a folder with the same name as the repository

2. Open the Project in Visual Studio:

    A. Launch Visual Studio
       - If it's your first time opening Visual Studio, you may be prompted to sign in or select a theme, but this is optional.

    B. Open the Cloned Project
       - In Visual Studio, click on File > Open > Project/Solution.
       - Navigate to the folder where the project was cloned (e.g., C:\Users\<YourUsername>\Projects\samplecrudapp).
       - Select the .sln file (e.g., SampleCrudApp.sln) and click Open.
   
3. Restore Project Dependencies

    A. Restore Dependencies
       - In Visual Studio, open the Tools menu.
       - Select NuGet Package Manager > Package Manager Console.
       - In the Package Manager Console, run the following command to restore the packages:
         dotnet restore

4. Build the Project

    A. Build the Solution
       - Click on Build > Build Solution (or press Ctrl + Shift + B).
       - Visual Studio will compile the project and display any errors or warnings in the Error List panel.

5. Run the Project
    A. Run the Project
       - To run the application, click on Run > Start Debugging (or press F5 or command dotnet watch run).
       - This will launch the application in your default browser or the configured environment.


To Hiring Manager, Hope you like my system and enjoy it


