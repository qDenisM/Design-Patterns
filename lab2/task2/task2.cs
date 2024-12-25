using System;

public class Organization
{

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
}

public class University : Organization
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

public class Faculty : Organization
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
        Console.WriteLine($"Факультет '{name}' ({shortName}); {address}; {timeStamp}; {departments.Count} департаментов");
    }
}

public class Department
{

}

public class task2
{
    public static void Main()
    {
        Department csDepartment = new Department();
        Department mathDepartment = new Department();

        Faculty engineeringFaculty = new Faculty("Информационные технологии", "ИТ", "101-4 каб.");
        engineeringFaculty.addDepartment(csDepartment);
        engineeringFaculty.addDepartment(mathDepartment);

        Faculty scienceFaculty = new Faculty("Технологии органических веществ", "ТОВ", "307-1 каб.");

        University university = new University("Белорусский государственный технологический университет", "БГТУ", "Свердлова 13а");
        university.addFaculty(engineeringFaculty);
        university.addFaculty(scienceFaculty);

        university.printInfo();

        foreach (var faculty in university.getFaculties())
        {
            faculty.printInfo();
        }
    }
}