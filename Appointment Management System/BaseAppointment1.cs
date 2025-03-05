using System;

abstract class BaseAppointment1
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }

    public BaseAppointment1(int id, string name, DateTime date)
    {
        Id = id;
        Name = name;
        Date = date;
    }

    public abstract void ShowDetails();
}
