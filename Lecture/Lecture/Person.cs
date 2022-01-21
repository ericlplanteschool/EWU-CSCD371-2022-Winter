﻿namespace Lecture;


public class Person : Thing, ISavable
{

    public Person(string firstName, string lastName) : 
        this($"{firstName} {lastName}") {}

    public Person(string name) 
    {
        Initialize(name);
    }

    // Initializer... for explanation only.
    internal void Initialize(string name)
    {
        Name = name;
    }

    public string ToText() => $"{nameof(Name)}: {Name}; {nameof(DateOfBirth)}: {DateOfBirth}";

    //public int Age
    //{
    //    get
    //    {
    //        return (DateOfBirth - DateTime.Now).TotalDays/365;
    //    }
    //}

    public DateOnly DateOfBirth { get; set; }


    public string? MiddelName { get; set; }


    private string? _Name;
    public override string Name
    {
        get => _Name!;

        set { 
            if(value is null) { throw new ArgumentNullException(nameof(value)); }
            if(string.IsNullOrWhiteSpace(value)) { throw new ArgumentException(
                $"{nameof(Name)} cannot be an empty or whitespace.", nameof(value)); }
            _Name = value; 
        }
    }

    (string, string)[] Passwords = new[] { 
        ("Inigo Montoya", "YouKilledMyF@ther!")
    }; 

    public bool Login(string userName, string password)
    {
        return password == "YouKilledMyF@ther!";
    }
}