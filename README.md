# Pierre's Bakery 2: Bakery Hullabaloo!

#### By **Greg Ramsower**

##### *This time, it's flavorful*

## Technologies Used
* VSCode
* GitBash
* C#
* .NET6 SDK
* MSTest
* Windows Powershell
* Razor
* CSS
* HTML
* MySQL Server
* Identity

### Description
* This web-based application allows a user to create a unique profile, add baked goods, add flavor categories, and link the items and use flavor tags in a many-to-many relationship.
* This app utilizes simple authentication for basic security and user-entered data integrity.
* This app requires the user to use database migration to construct the necessary SQL database on their local machine.
* All users, regardless of authentication, can view a list of goods available for sale (and the flavor tags linked to that item).
* Only logged-in users can add or edit the list of items and flavor tags.
* Specifically, a logged-in user can:
- Add and delete baked goods (items)
- Add and delete flavor tags
- Assign items to specific flavor tags, or assign flavor tags to specific items
- View a list of all baked goods entered by the user
- View a list of all flavor tags entered by the user

### Application Instructions
* NOTE: In order to run this application, you will need to ensure the following software packages are installed locally:
  - .NET6
  - MySQL and MySQL workbench
  - A code editor of your choice (VSCode, Sublime Text, etc.)

#### Installing .NET and MySQL
1. Install .NET6 if you have not done so. Visit [this link](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) to download the recommended versions of both software packages.
2. Follow the installer prompts to install the software. Use the default settings.
3. In a terminal, install `dotnet-script` by entering the following command: `$ dotnet tool install -g dotnet-script`. You will also need to configure your environment to access this tool. See [this link](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-dotnet-script).
4. Install MySQL.  Follow the instructions at [this link](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql).

#### Initial Setup 
5. Clone this repository.
6. Open the terminal and navigate to this project's production directory, named "Bakery".
7. If you have not previously added the following packages globally, Add the following packages within the production directory ("Bakery"):
```bash
$ dotnet add package Microsoft.EntityFrameworkCore -v 6.0.0 
$ dotnet add package Pomelo.EntityFarmeworkCore.MySql -v 6.0.0
```
8. Within the production directory, create a new file called appsettings.json.
9. Open your code editor and navigate to appsetings.json.
10. Within appsettings.json, add the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL.

```json
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=pierre_bakery_2;uid=[uid];pwd=[pwd];"
  }
}
```

11. Use database migration to construct a shiny new database locally:
* In a terminal window, navigate to the project's root directory, named "PierreBakery2-SOlution-Main".
* Run the following commands:
```bash
$ dotnet ef migrations add Initial
$ dotnet ef database update
```
* These two commands will instantiate a local database conforming to the program requirements.

#### Running the Program
12. Open a terminal and navigate to this project's production directory ("Bakery") if you have not already done so.
13. Type `dotnet watch run` in the command line to start the project in development mode with a watcher.
* If the build fails, revisit steps 1 - 3 and 7 above to ensure that .NET6 and the required packages have been properly installed.
14. Open the browser to _https:localhost:5001_. 
  * If you cannot access localhost:5001, it is likely because you have not configured a .NET developer security certificate for HTTPS. (Please see [this page](https://www.learnhowtoprogram.com/c-and-net-part-time/c-web-applications/redirecting-to-https-and-issuing-a-security-certificate) for instructions on how to fix this issue. 

## Known Bugs
* None

## License
* **SEE LICENSE [HERE](./LICENSE.txt)** 