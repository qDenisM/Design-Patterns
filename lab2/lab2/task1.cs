
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

public class University
{
    protected List<Faculty> faculties = new List<Faculty>();
    protected List<JobVacancy> jobVacancies = new List<JobVacancy>();
    protected List<JobTitle> jobTitles = new List<JobTitle>();
    protected List<Employee> employees = new List<Employee>();

    public University()
    {

    }

    public University(University other)
    {
        this.faculties = other.faculties;
    }

    public University(string name, string shortName, string address)
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
        Console.WriteLine($"Университет '{faculties.Count} факультетов");
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
        return new Employee(person.name, "", jobVacancy.title);
    }

    public bool dismiss(int jobId, Reason reason)
    {
        Console.WriteLine($"{jobId} удалена по причине {reason.description}");
        return true;
    }
}

public class Faculty
{
    protected List<Department> departments = new List<Department>();
    protected List<JobVacancy> jobVacancies = new List<JobVacancy>();
    protected List<JobTitle> jobTitles = new List<JobTitle>();
    protected List<Employee> employees = new List<Employee>();

    public Faculty() : base()
    {

    }

    public Faculty(Faculty other)
    {
        this.departments = other.departments;
    }

    public Faculty(string name, string shortName, string address)
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
        Console.WriteLine($"Факультет '{departments.Count} департаментов");
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
        return new Employee(person.name, "", jobVacancy.title);
    }

    public bool dismiss(int jobId, Reason reason)
    {
        Console.WriteLine($"{jobId} удалено по причине {reason.description}");
        return true;
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

public class Program
{
    static void Main(string[] args)
    {
        Organization org = new Organization("Белорусский государственный технологический университет", "БГТУ", "Свердлова 13а");
        org.printInfo();

        University university = new University();
        Console.WriteLine("Университет создан.");

        Faculty faculty1 = new Faculty();
        Faculty faculty2 = new Faculty();
        university.addFaculty(faculty1);
        university.addFaculty(faculty2);

        Console.WriteLine($"В университете {university.getFaculties().Count} факультетов.");

        JobTitle professor = new JobTitle("Профессор");
        JobTitle assistantProfessor = new JobTitle("Ассистент профессор");
        university.addJobTitle(professor);
        university.addJobTitle(assistantProfessor);

        Console.WriteLine($"Количество вакансий: {university.getJobTitles().Count}");

        JobVacancy jobVacancy1 = new JobVacancy("Профессор по физике");
        JobVacancy jobVacancy2 = new JobVacancy("Ассистент по химии");

        Person person = new Person("Иван Иванов");
        Employee employee = university.recruit(jobVacancy1, person);

        Console.WriteLine($"Новый сотрудник: {employee.name}, {employee.job}");

        Reason reason = new Reason("Контракт завершился");
        university.dismiss(0, reason);
    }
}