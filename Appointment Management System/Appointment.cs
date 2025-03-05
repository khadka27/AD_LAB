using System;

class Appointment : BaseAppointment,  IManageable
{
    public Appointment(int id, string name, DateTime date) : base(id, name, date)
    {
    }

    // Implementing abstract method from BaseAppointment
    public override void ShowDetails()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Date: {Date}");
    }

    
    public void Add()
    {
        Console.WriteLine("Appointment added successfully!");
    }

    public void Delete()
    {
        Console.WriteLine("Appointment deleted successfully!");
    }


}
