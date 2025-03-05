using System;
using System.Collections.Generic;

class Program
{
    static List<Appointment> appointments = new List<Appointment>();
    static int idCounter = 1;

    static void Main()
    {
        BaseAppointment instance;
        instance = new Appointment(1, "Abishek Khadka", DateTime.Now);
        instance.ShowDetails();

         //BaseAppointment obj = new BaseAppointment(1, "John Doe", DateTime.Now);

        while (true)
        {
            Console.WriteLine("\n--- Appointment Management System ---");
            Console.WriteLine("1. Add Appointment");
            Console.WriteLine("2. View Appointments");
            Console.WriteLine("3. Delete Appointment");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddAppointment();
                    break;
                case "2":
                    ViewAppointments();
                    break;
                case "3":
                    DeleteAppointment();
                    break;
                case "4":
                    Console.WriteLine("Exiting the system...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Try again.");
                    break;
            }
        }
    }

    static void AddAppointment()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Date (yyyy-MM-dd HH:mm): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Appointment newAppointment = new Appointment(idCounter++, name, date);
            appointments.Add(newAppointment);
            newAppointment.Add();
        }
        else
        {
            Console.WriteLine("Invalid date format! Try again.");
        }
    }

    static void ViewAppointments()
    {
        if (appointments.Count == 0)
        {
            Console.WriteLine("No appointments found.");
            return;
        }

        Console.WriteLine("\n--- Appointments List ---");
        foreach (var appointment in appointments)
        {
            appointment.ShowDetails();
        }
    }

    static void DeleteAppointment()
    {
        Console.Write("Enter Appointment ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var appointment = appointments.Find(a => a.Id == id);
            if (appointment != null)
            {
                appointments.Remove(appointment);
                appointment.Delete();
            }
            else
            {
                Console.WriteLine("Appointment not found!");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID! Try again.");
        }
    }
}
