using System;

class C1
{
    private const int privateConst = 100;

    private string privateField;

    private string PrivateProperty
    {
        get { return privateField; }
        set { privateField = value; }
    }

    private void PrivateMethod()
    {
        Console.WriteLine("Приватный метод вызван.");
    }

    protected const int protectedConst = 200;

    protected string protectedField;

    protected string ProtectedProperty
    {
        get { return protectedField; }
        set { protectedField = value; }
    }

    protected void ProtectedMethod()
    {
        Console.WriteLine("Защищенный метод вызван.");
    }

    public const int publicConst = 300;

    public string publicField;

    public string PublicProperty
    {
        get { return publicField; }
        set { publicField = value; }
    }

    public C1()
    {
        privateField = "Приватный";
        protectedField = "Защищенный";
        publicField = "Публичное";
    }

    public C1(C1 other)
    {
        privateField = other.privateField;
        protectedField = other.protectedField;
        publicField = other.publicField;
    }

    public C1(string priv, string prot, string publ)
    {
        privateField = priv;
        protectedField = prot;
        publicField = publ;
    }

    public void PublicMethod()
    {
        Console.WriteLine("Публичный метод вызван.");
    }

    public void DisplayFields()
    {
        Console.WriteLine($"Приватное поле: {privateField}");
        Console.WriteLine($"Защищенное поле: {protectedField}");
        Console.WriteLine($"Публичное поле: {publicField}");
    }

    public void AccessProtectedMethod()
    {
        ProtectedMethod();
    }
}

class Program
{
    static void Main()
    {
        C1 obj1 = new C1();
        obj1.DisplayFields();

        C1 obj2 = new C1("Приватный параметр", "Защищенный параметр", "Публичный параметр");
        obj2.DisplayFields();

        C1 obj3 = new C1(obj2);
        obj3.DisplayFields();

        obj1.PublicMethod();
        obj1.AccessProtectedMethod();

        obj1.publicField = "Публичное значение";
        Console.WriteLine($"Публичное свойство: {obj1.PublicProperty}");
    }
}
