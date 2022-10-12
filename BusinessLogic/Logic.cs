using Model2;
using DataAccessLayer;
using System.Data.Entity.Core.Common;

namespace BusinessLogic;

public class Logic
{
    EntityRepository<Student> repository = new();
    //DapperRepository<Student> repository = new();

    /// <summary>
    /// Добавить нового студента.
    /// </summary>
    public void AddStudent(string name, string speciality, string group)
    {
        repository.Create(new Student { Name = name, Speciality = speciality, Group = group });
        repository.Save();
    }

    /// <summary>
    /// Удалить студента по индексу.
    /// </summary>
    public void DeleteStudent(int index)
    {
        repository.Delete(index);
        repository.Save();
    }

    public void DeleteStudent()
    {
        repository.DeleteAll();
        repository.Save();
    }

    /// <summary>
    /// Вывести весь список студентов.
    /// </summary>
    public List<Student> GetAll()
    {
        return repository.GetAll().ToList();
    }

    public Dictionary<string, int> DistributionOfSpecialties()
    {
        Dictionary<string, int> specialtiesDistribution = new();

        foreach (Student student in (List<Student>)repository.GetAll())
        {
            if (specialtiesDistribution.ContainsKey(student.Speciality))
                specialtiesDistribution[student.Speciality] += 1;

            else
                specialtiesDistribution[student.Speciality] = 1;
        }
        return specialtiesDistribution;
    }
}