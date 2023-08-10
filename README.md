# Shopping List App

This is a web application built using ASP.NET Core 6. It allows users to create and manage shopping lists, add products to the lists, and track their shopping activities.

## Features

- User Authentication: Users can register, log in, and log out. Admin users have additional privileges for managing categories and products.
- Shopping Lists: Users can create, view, edit, and delete shopping lists.
- Products: Users can view a list of available products, add products to their shopping lists, and mark them as purchased.
- Categories: Admin users can manage product categories, including creating, editing, and deleting categories.
- Responsive Design: The application is designed to be responsive and works well on various screen sizes.

## Installation

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio or your preferred code editor.
3. Open a terminal and navigate to the `MVCCore6App` directory.
4. Run the following commands to apply database migrations: <br>
    `dotnet ef update database`
5. Build and run the application: <br>
    `dotnet build` <br>
    `dotnet run`
6. Open a web browser and navigate to `http://localhost:5000` to access the application.

## Usage

- Register a new user account or log in with an existing account.
- Browse through available products and categories.
- Create a new shopping list and add products to it.
- Edit or delete shopping lists and shopping list items.
- Admin users can manage categories and products.

## Technologies Used

- ASP.NET Core 6
- Entity Framework Core
- Identity Framework
- Razor Pages
- HTML, CSS, JavaScript
- Bootstrap
- Font-Awesome

## Contributing

Contributions are welcome! If you find a bug or have a feature request, please open an issue. Pull requests are also appreciated.

## Contact

For any inquiries, you can contact Kaan Cem Günaydın at gunaydnk@mail.com.


