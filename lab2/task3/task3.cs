using System;

public class Organization : IStaff
{
    protected List<JobVacancy> jobVacancies = new List<JobVacancy>();
    protected List<JobTitle> jobTitles = new List<JobTitle>();
    protected List<Employee> employees = new List<Employee>();

    public int id
    {
        get;
        private set;
    }

    public string name
    {
        get;
        protected set;
    }

    public string shortName
    {
        get;
        protected set;
    }

    public string address
    {
        get;
        protected set;
    }

    public DateTime timeStamp
    {
        get;
        protected set;
    }

    public Organization()
    {
        name = string.Empty;
        shortName = string.Empty;
        address = string.Empty;
        timeStamp = DateTime.Now;
    }

    public Organization(Organization other)
    {
        this.jobVacancies = other.jobVacancies;
        this.jobTitles = other.jobTitles;
        this.employees = other.employees;
        this.id = other.id;
        this.name = other.name;
        this.shortName = other.shortName;
        this.address = other.address;
        this.timeStamp = other.timeStamp;
    }

    public Organization(string name, string shortName, string address)
    {
        this.name = name;
        this.shortName = shortName;
        this.address = address;
        timeStamp = DateTime.Now;
    }

    public void printInfo()
    {
        Console.WriteLine($"Организация '{name}' ({shortName}); {address}; {timeStamp}");
    }

    public List<JobVacancy> getJobVacancies()
    {
        return jobVacancies;
    }

    public List<JobTitle> getJobTitles()
    {
        return jobTitles;
    }

    public List<Employee> getEmployees()
    {
        return employees;
    }

    public int addJobTitle(JobTitle jobTitle)
    {
        try
        {
            jobTitles.Add(jobTitle);
            return jobTitles.Count;
        }
        catch
        {
            return -1;
        }
    }

    public string printJobVacancies()
    {
        return string.Join('\n', jobVacancies.Select(jv => $"{jv.title} [{jv.isOpened}]"));
    }

    public bool delJobTitle(int jobTitleId)
    {
        try
        {
            jobTitles.RemoveAt(jobTitleId);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public int openJobVacancy(JobVacancy jobVacancy)
    {
        try
        {
            int index = jobVacancies.FindIndex(jb => jb.title == jobVacancy.title);
            jobVacancies[index].Open();
            return index;
        }
        catch
        {
            return -1;
        }
    }

    public bool closeJobVacancy(int jobId)
    {
        try
        {
            jobVacancies[jobId].Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Employee recruit(JobVacancy jobVacancy, Person person)
    {
        return new Employee(person.name, name, jobVacancy.title);
    }

    public bool dismiss(int jobId, Reason reason)
    {
        Console.WriteLine($"{jobId} удалена по причине {reason.description}");
        return true;
    }
}

public class University : Organization, IStaff
{
    protected List<Faculty> faculties = new List<Faculty>();

    public University() : base()
    {

    }

    public University(University other) : base(other)
    {
        this.faculties = other.faculties;
    }

    public University(string name, string shortName, string address) : base(name, shortName, address)
    {

    }

    public int addFaculty(Faculty faculty)
    {
        try
        {
            faculties.Add(faculty);
            return faculties.Count;
        }
        catch
        {
            return -1;
        }
    }

    public bool delFaculty(int facultyId)
    {
        try
        {
            faculties.RemoveAt(facultyId);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool updDepartment(Faculty faculty)
    {
        return false;
    }

    private bool verFaculty(int facultyId)
    {
        return faculties.Count > facultyId;
    }

    public List<Faculty> getFaculties()
    {
        return faculties;
    }

    public new void printInfo()
    {
        Console.WriteLine($"Университет '{name}' ({shortName}); {address}; {timeStamp}; {faculties.Count} факультета");
    }
}

public class Faculty : Organization, IStaff
{
    protected List<Department> departments = new List<Department>();

    public Faculty() : base()
    {

    }

    public Faculty(Faculty other) : base(other)
    {
        this.departments = other.departments;
    }

    public Faculty(string name, string shortName, string address) : base(name, shortName, address)
    {

    }

    public int addDepartment(Department department)
    {
        try
        {
            departments.Add(department);
            return departments.Count;
        }
        catch
        {
            return -1;
        }
    }

    public bool delDepartment(int departmentId)
    {
        try
        {
            departments.RemoveAt(departmentId);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool updDepartment(Department department)
    {
        return false;
    }

    private bool verDepartment(int departmentId)
    {
        return departments.Count > departmentId;
    }

    public List<Department> getDepartments()
    {
        return departments;
    }

    public new void printInfo()
    {
        Console.WriteLine($"Факультет '{name}' ({shortName}); {address}; {timeStamp}; {departments.Count} департамента");
    }
}

public interface IStaff
{
    List<JobVacancy> getJobVacancies();
    List<Employee> getEmployees();
    List<JobTitle> getJobTitles();
    int addJobTitle(JobTitle jobTitle);
    string printJobVacancies();
    bool delJobTitle(int jobTitleId);
    int openJobVacancy(JobVacancy jobVacancy);
    bool closeJobVacancy(int jobVacancyId);
    Employee recruit(JobVacancy jobVacancy, Person person);
    bool dismiss(int jobVacancyId, Reason reason);
}

public class JobVacancy
{
    public string title
    {
        get;
        private set;
    }

    public bool isOpened
    {
        get;
        private set;
    }

    public JobVacancy(string title)
    {
        this.title = title;
        isOpened = false;
    }

    public void Open()
    {
        isOpened = true;
    }

    public void Close()
    {
        isOpened = false;
    }
}

public class Employee : Person
{
    public string department
    {
        get;
        private set;
    }

    public string job
    {
        get;
        private set;
    }

    public Employee(string name, string department, string job) : base(name)
    {
        this.department = department;
        this.job = job;
    }
}

public class Person
{
    public string name
    {
        get;
        private set;
    }

    public Person(string name)
    {
        this.name = name;
    }
}

public class JobTitle
{
    public string title
    {
        get;
        private set;
    }

    public JobTitle(string title)
    {
        this.title = title;
    }
}

public class Department
{

}

public class Reason
{
    public string description
    {
        get;
        private set;
    }

    public Reason(string description)
    {
        this.description = description;
    }
}

class task3
{
    static void Main()
    {
        Organization org = new Organization("Министерство образования", "МО", "123 Main Street");
        org.printInfo();

        University uni = new University("Белорусский государственный технологический университет", "БГТУ", "Свердлова 13а");
        uni.printInfo();

        Faculty faculty1 = new Faculty("Информационные технологии", "ИТ", "101-4 каб.");
        Faculty faculty2 = new Faculty("Технологии органических веществ", "ТОВ", "307-1 каб.");
        uni.addFaculty(faculty1);
        uni.addFaculty(faculty2);
        uni.printInfo();

        Department dep1 = new Department();
        Department dep2 = new Department();
        faculty1.addDepartment(dep1);
        faculty1.addDepartment(dep2);
        faculty1.printInfo();

        JobVacancy jobVacancy1 = new JobVacancy("Профессор по физике");
        JobVacancy jobVacancy2 = new JobVacancy("Ассистент по физике");
        org.addJobTitle(new JobTitle("Профессор"));
        org.addJobTitle(new JobTitle("Ассистент"));
        org.getJobVacancies().Add(jobVacancy1);
        org.getJobVacancies().Add(jobVacancy2);

        Console.WriteLine(org.printJobVacancies());

        org.openJobVacancy(jobVacancy1);
        Console.WriteLine(org.printJobVacancies());

        Person person1 = new Person("Иван Иванов");
        Employee employee1 = org.recruit(jobVacancy1, person1);
        org.getEmployees().Add(employee1);
        Console.WriteLine($"Сотрудник: {employee1.name}, Департамент: {employee1.department}, Работа: {employee1.job}");

        Reason reason = new Reason("Контракт завершен");
        org.dismiss(0, reason);
    }
}