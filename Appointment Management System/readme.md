# Appointment Management System (C# Console Application)

## Project Overview
This is a **Console-based Appointment Management System** developed in **C#**. It allows users to:
- **Add** appointments
- **View** existing appointments
- **Delete** appointments
- **Exit** the application

The project demonstrates the use of **abstract classes, interfaces, method overriding, and object-oriented principles** in C#.

## Features
- **Abstract Class (`BaseAppointment`)**: Used to enforce structure in derived classes.
- **Interfaces (`IManageable`, `IDisplayable`)**: Demonstrates multiple interface implementation.
- **Method Overriding**: Implements abstract methods from `BaseAppointment`.
- **Constructor in Abstract Class**: Initializes object properties upon instantiation.
- **Exception Handling**: Handles user input errors gracefully.

## Installation & Setup
1. **Prerequisites:**
   - Visual Studio (or any C# compiler)
   - .NET Framework installed
2. **Clone or Download the Repository:**
   ```sh
   git clone https://github.com/your-repo/appointment-management.git
   ```
3. **Open the Project in Visual Studio**
4. **Run the Application**
   - Press `Ctrl + F5` to start without debugging.

## Usage Instructions
1. **Main Menu Options:**
   - Press `1` to add an appointment.
   - Press `2` to view all appointments.
   - Press `3` to delete an appointment.
   - Press `4` to exit the application.
2. **Adding an Appointment:**
   - Enter name and date (format: `yyyy-MM-dd HH:mm`).
3. **Viewing Appointments:**
   - Displays a list of all saved appointments.
4. **Deleting an Appointment:**
   - Enter the appointment ID to remove it from the list.

## Example Code Snippets
### Abstract Class (`BaseAppointment`)
```csharp
abstract class BaseAppointment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    
    public BaseAppointment(int id, string name, DateTime date)
    {
        Id = id;
        Name = name;
        Date = date;
    }
    public abstract void ShowDetails();
}
```

### Interface Implementation (`IManageable`)
```csharp
interface IManageable
{
    void Add();
    void Delete();
}
```

### Appointment Class Implementing Abstract Class & Interfaces
```csharp
class Appointment : BaseAppointment, IManageable
{
    public Appointment(int id, string name, DateTime date) : base(id, name, date) { }
    
    public override void ShowDetails()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Date: {Date}");
    }
    public void Add() { Console.WriteLine("Appointment added successfully!"); }
    public void Delete() { Console.WriteLine("Appointment deleted successfully!"); }
}
```

## Expected Output
```
--- Appointment Management System ---
1. Add Appointment
2. View Appointments
3. Delete Appointment
4. Exit
Choose an option: 1
Enter Name: John Doe
Enter Date (yyyy-MM-dd HH:mm): 2025-03-10 14:30
Appointment added successfully!
```

## Notes
- Abstract classes **cannot be instantiated** directly.
- A class **can implement multiple interfaces** but **cannot inherit multiple abstract classes**.
- All methods in an **interface must be implemented** in a non-abstract class.
- **Abstract classes can have constructors**, but **interfaces cannot**.

## Author
- **Name:** [Your Name]
- **Student ID:** [Your Student ID]
- **Module Code:** [Your Module Code]

## License
This project is open-source and available for educational purposes.

---


