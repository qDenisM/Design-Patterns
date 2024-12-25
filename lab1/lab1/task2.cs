using System;

interface I1
{
    string MyProperty { get; set; }

    void MyMethod(string message);

    event EventHandler MyEvent;

    string this[int index] { get; set; }
}

class Implementation : I1
{
    public string MyProperty { get; set; }

    public void MyMethod(string message)
    {
        Console.WriteLine("Метод вызван: " + message);
    }

    public event EventHandler MyEvent;

    public void TriggerEvent()
    {
        if (MyEvent != null)
        {
            MyEvent(this, EventArgs.Empty);
        }
    }

    private string[] data = new string[10];
    public string this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }
}

class Program
{
    static void Main()
    {
        Implementation obj = new Implementation();

        obj.MyProperty = "Свойство";
        Console.WriteLine(obj.MyProperty);

        obj.MyMethod("Метод");

        obj.MyEvent += (sender, e) => Console.WriteLine("Событие");
        obj.TriggerEvent();

        obj[0] = "Индекс 0";
        Console.WriteLine(obj[0]);
    }
}
