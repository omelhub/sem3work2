﻿using BusinessLogic;
using Model2;
using System.Collections.Generic;

Logic logic = new();

//тестовый список студентов
logic.AddStudent("Иванов", "Информатика", "КИ21-18Б");
logic.AddStudent("Петров", "Информатика", "КИ21-21Б");
logic.AddStudent("Сидоров", "Информатика", "КИ21-21Б");
logic.AddStudent("Лагойда", "Информатика", "КИ21-21Б");
logic.AddStudent("Машкова", "Биология", "КИ21-01А");
logic.AddStudent("Викторова", "Биология", "КИ21-02А");

static void Commands()
{
    Console.WriteLine("Список команд:");
    Console.WriteLine(" 1  - добавить студента,");
    Console.WriteLine(" 2  - удалить студента по идентификатору,");
    Console.WriteLine(" 3  - вывести список студентов,");
    Console.WriteLine("Esc - выйти.");
}

bool x = true;
while (x)
{
    Commands();
    ConsoleKeyInfo key = Console.ReadKey();

    switch (key.Key)
    {
        case ConsoleKey.D1:
            AddStudentCommand();
            break;
        case ConsoleKey.D2:
            DeleteStudentCommand();
            break;
        case ConsoleKey.D3:
            ShowStudentsCommand();
            break;
        case ConsoleKey.Escape:
            x = false;
            break;


        case ConsoleKey.D5:
            logic.DeleteStudent(); //удаление всех студентов
            break;
    }
    Console.WriteLine();
}

void AddStudentCommand()
{
    Console.WriteLine("\nВведите Имя Специальность Группу студента через пробел:");
    string[] NewStudent = Console.ReadLine().Split();
    if (NewStudent.Length == 3)
        logic.AddStudent(NewStudent[0], NewStudent[1], NewStudent[2]);
}

void DeleteStudentCommand()
{
    Console.WriteLine("\nВведите индекс студента:");
    if ((Int32.TryParse(Console.ReadLine(), out int result)) && result > 0 && (logic.GetAll().ToList().Exists(x => x.Id == result)))
        logic.DeleteStudent(result);
    else
        Console.WriteLine("Индекс введен неправильно.");
}

void ShowStudentsCommand()
{
    Console.WriteLine($"\n\n{"Имя",-30} {"| Специальность",-30} {"| Группа",-20} {"| Id",-20}");
    Console.WriteLine(new string('-', 100));
    List<Student> allStudents = logic.GetAll().ToList();
    foreach (Student student in allStudents)
    {
        Console.WriteLine($"{student.Name,-30} {student.Speciality,-30} {student.Group,-20} {student.Id,-20}");
    }
}