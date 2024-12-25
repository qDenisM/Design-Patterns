using System;

class C3
{
    private string privateField = "C3: Приватное поле";
    
    protected string protectedField = "C3: Защищенное поле";
    
    public string publicField = "C3: Публичное поле";
    
    private string PrivateProperty { get; set; } = "С3: Приватное свойства";
    
    protected string ProtectedProperty { get; set; } = "С3: Защищенное свойство";
    
    public string PublicProperty { get; set; } = "C3: Публичное свойство";
    
    private void PrivateMethod()
    {
        Console.WriteLine("C3: Приватный метод");
    }
    
    protected void ProtectedMethod()
    {
        Console.WriteLine("C3: Защищенный метод");
    }
    
    public void PublicMethod()
    {
        Console.WriteLine("C3: Публичный метод");
    }
    
    public C3()
    {
        Console.WriteLine("C3: Конструктор");
    }
}

class C4 : C3
{
    public string ownField = "C4: Публичное поле";
    
    public string OwnProperty { get; set; } = "C4: Публичное свойство";
    
    public void OwnMethod()
    {
        Console.WriteLine("C4: Публичный метод");
    }
    
    public C4()
    {
        Console.WriteLine("C4: Конструктор");
    }
    
    public void DisplayFieldsAndMethods()
    {
        Console.WriteLine(protectedField);  
        Console.WriteLine(publicField);     
    
        Console.WriteLine(ownField);        
    
        ProtectedMethod();  
        PublicMethod();     
    
        OwnMethod();
    }
}

class Program
{
    static void Main()
    {
        C4 obj = new C4();
        
        obj.DisplayFieldsAndMethods();
    
        Console.WriteLine(obj.PublicProperty);  
        obj.PublicMethod();                     
    
        Console.WriteLine(obj.OwnProperty);     
        obj.OwnMethod();                        
    }
}