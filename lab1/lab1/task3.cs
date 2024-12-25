using System;

interface I1
{
    string MyProperty { get; set; }

    void MyMethod(string message);

    event EventHandler MyEvent;

    string this[int index] { get; set; }
}

class C1 : I1
{
    private string privateField;

    public string MyProperty { get; set; }

    public void MyMethod(string message)
    {
        Console.WriteLine("C1: Метод вызван: " + message);
    }

    public void DisplayFields()
    {
        Console.WriteLine($"Приватное поле: {privateField}");
    }
}

class C2
{
    private string[] data = new string[10];
    public string this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }

    public event EventHandler MyEvent;

    public new void MyMethod(string message)
    {
        Console.WriteLine("C2: Метод вызван: " + message);
    }

    public void TriggerEvent()
    {
        MyEvent?.Invoke(this, EventArgs.Empty);
    }

    public C2()
    {
        Console.WriteLine("C2: Конструктор вызван.");
    }

    public C2(string param)
    {
        Console.WriteLine($"C2: Конструктор вызван с параметром: {param}");
    }
}

class Program
{
    static void Main()
    {
        C2 obj1 = new C2();
        obj1.MyProperty = "Свойство";
        Console.WriteLine(obj1.MyProperty);

        obj1.MyMethod("Метод");

        obj1.MyEvent += (sender, e) => Console.WriteLine("C2: Событие");
        obj1.TriggerEvent();

        obj1[0] = "Индекс 0";
        Console.WriteLine(obj1[0]);

        C2 obj2 = new C2("Параметр");
    }
}
