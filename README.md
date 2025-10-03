🏛️ Class - C# Class Examples & OOP Principles
کتابخانه جامع مثال‌ها و الگوهای کلاس در زبان C# - آموزش کامل مفاهیم شیءگرایی و طراحی کلاس

https://img.shields.io/badge/C%2523-239120?style=for-the-badge&logo=c-sharp&logoColor=white
https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white
https://img.shields.io/badge/OOP-Object%2520Oriented%2520Programming-blue?style=for-the-badge
https://img.shields.io/badge/GitHub-Open%2520Source-181717?style=for-the-badge&logo=github

https://img.shields.io/github/stars/programmerdrn/Class
https://img.shields.io/github/forks/programmerdrn/Class
https://img.shields.io/github/issues/programmerdrn/Class

✨ ویژگی‌ها
✅ اصول شیءگرایی: کپسوله‌سازی، وراثت، چندریختی، انتزاع

✅ انواع کلاس: معمولی، static، abstract، sealed، partial

✅ اعضای کلاس: فیلدها، پراپرتی‌ها، متدها، constructorها

✅ الگوهای طراحی: Repository, Service, DTO, Factory

✅ مفاهیم پیشرفته: Generic classes, Interfaces, Inheritance

🏗️ ساختار پروژه
text
Class/
├── Program.cs                     # فایل اصلی برنامه
├── BasicClasses/                  # کلاس‌های پایه
│   ├── Person.cs                 # کلاس ساده با پراپرتی
│   ├── BankAccount.cs            # کلاس با business logic
│   └── Product.cs                # کلاس با validation
├── AdvancedClasses/              # کلاس‌های پیشرفته
│   ├── AbstractClasses/          # کلاس‌های abstract
│   ├── StaticClasses/            # کلاس‌های static
│   ├── GenericClasses/           # کلاس‌های جنریک
│   └── PartialClasses/           # کلاس‌های partial
├── OOPPrinciples/               # اصول شیءگرایی
│   ├── Inheritance/             # وراثت
│   ├── Polymorphism/            # چندریختی
│   ├── Encapsulation/           # کپسوله‌سازی
│   └── Abstraction/             # انتزاع
├── DesignPatterns/              # الگوهای طراحی
│   ├── RepositoryPattern/       # الگوی Repository
│   ├── ServicePattern/          # الگوی Service
│   └── FactoryPattern/          # الگوی Factory
└── README.md
🚀 نحوه اجرا
پیش‌نیازها
.NET 6.0 یا بالاتر

اجرای پروژه
bash
# کلون کردن ریپوزیتوری
git clone https://github.com/programmerdrn/Class.git
cd Class

# اجرای پروژه
dotnet run
💡 مثال‌های کلاس‌های مختلف
۱. کلاس پایه با کپسوله‌سازی
کلاس Person
csharp
public class Person
{
    // فیلدهای private (کپسوله‌سازی)
    private string _firstName;
    private string _lastName;
    private int _age;

    // Constructor
    public Person(string firstName, string lastName, int age)
    {
        _firstName = firstName;
        _lastName = lastName;
        _age = age;
    }

    // Properties با validation
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("نام نمی‌تواند خالی باشد");
            _firstName = value;
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("نام خانوادگی نمی‌تواند خالی باشد");
            _lastName = value;
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value < 0 || value > 150)
                throw new ArgumentException("سن باید بین ۰ تا ۱۵۰ باشد");
            _age = value;
        }
    }

    // متدهای instance
    public string GetFullName()
    {
        return $"{_firstName} {_lastName}";
    }

    public bool IsAdult()
    {
        return _age >= 18;
    }

    // Override ToString
    public override string ToString()
    {
        return $"{GetFullName()} - {_age} سال";
    }
}

// استفاده
var person = new Person("محمد", "رضایی", 25);
Console.WriteLine(person.GetFullName());  // "محمد رضایی"
Console.WriteLine(person.IsAdult());      // true
۲. کلاس BankAccount با business logic
csharp
public class BankAccount
{
    private decimal _balance;
    public string AccountNumber { get; }
    public string Owner { get; }

    public BankAccount(string accountNumber, string owner, decimal initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        _balance = initialBalance;
    }

    public decimal Balance => _balance;

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("مبلغ واریز باید مثبت باشد");

        _balance += amount;
        Console.WriteLine($"{amount} تومان واریز شد. موجودی: {_balance}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("مبلغ برداشت باید مثبت باشد");

        if (amount > _balance)
            throw new InvalidOperationException("موجودی کافی نیست");

        _balance -= amount;
        Console.WriteLine($"{amount} تومان برداشت شد. موجودی: {_balance}");
    }

    public void Transfer(BankAccount targetAccount, decimal amount)
    {
        if (targetAccount == null)
            throw new ArgumentNullException(nameof(targetAccount));

        Withdraw(amount);
        targetAccount.Deposit(amount);
        Console.WriteLine($"{amount} تومان به {targetAccount.Owner} انتقال یافت");
    }
}
۳. کلاس static برای utility functions
csharp
public static class MathUtility
{
    public static double CalculateCircleArea(double radius)
    {
        return Math.PI * radius * radius;
    }

    public static double CalculateTriangleArea(double baseLength, double height)
    {
        return 0.5 * baseLength * height;
    }

    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
            if (number % i == 0)
                return false;

        return true;
    }
}

// استفاده
double area = MathUtility.CalculateCircleArea(5);  // 78.54
bool isPrime = MathUtility.IsPrime(17);            // true
۴. کلاس abstract و inheritance
csharp
// کلاس پایه abstract
public abstract class Shape
{
    public string Name { get; set; }
    
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
    
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"شکل: {Name}");
        Console.WriteLine($"مساحت: {CalculateArea()}");
        Console.WriteLine($"محیط: {CalculatePerimeter()}");
    }
}

// کلاس مشتق شده
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public Rectangle(double width, double height)
    {
        Name = "مستطیل";
        Width = width;
        Height = height;
    }
    
    public override double CalculateArea()
    {
        return Width * Height;
    }
    
    public override double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }
    
    public Circle(double radius)
    {
        Name = "دایره";
        Radius = radius;
    }
    
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
    
    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

// استفاده
Shape rectangle = new Rectangle(5, 3);
Shape circle = new Circle(4);

rectangle.DisplayInfo();
circle.DisplayInfo();
۵. کلاس generic
csharp
public class Repository<T> where T : class
{
    private readonly List<T> _items = new List<T>();
    
    public void Add(T item)
    {
        _items.Add(item);
    }
    
    public T GetById(int id)
    {
        // در واقعیت از reflection یا خاصیت ID استفاده می‌شود
        return _items.ElementAtOrDefault(id);
    }
    
    public List<T> GetAll()
    {
        return new List<T>(_items);
    }
    
    public void Remove(T item)
    {
        _items.Remove(item);
    }
}

// استفاده
var personRepo = new Repository<Person>();
var productRepo = new Repository<Product>();
۶. Interface و چندریختی
csharp
public interface INotification
{
    void Send(string message);
    bool CanSend();
}

public class EmailNotification : INotification
{
    public string Email { get; set; }
    
    public bool CanSend() => !string.IsNullOrEmpty(Email);
    
    public void Send(string message)
    {
        Console.WriteLine($"ایمیل به {Email}: {message}");
    }
}

public class SmsNotification : INotification
{
    public string PhoneNumber { get; set; }
    
    public bool CanSend() => !string.IsNullOrEmpty(PhoneNumber);
    
    public void Send(string message)
    {
        Console.WriteLine($"SMS به {PhoneNumber}: {message}");
    }
}

public class NotificationService
{
    private readonly List<INotification> _notifications;
    
    public NotificationService(params INotification[] notifications)
    {
        _notifications = notifications.ToList();
    }
    
    public void Broadcast(string message)
    {
        foreach (var notification in _notifications.Where(n => n.CanSend()))
        {
            notification.Send(message);
        }
    }
}
🎯 اصول شیءگرایی در عمل
کپسوله‌سازی (Encapsulation)
فیلدهای private

پراپرتی‌های public با validation

متدهای controlled access

وراثت (Inheritance)
کلاس‌های پایه و مشتق شده

override متدها

base constructor

چندریختی (Polymorphism)
interface implementation

method overriding

generic constraints

انتزاع (Abstraction)
abstract classes

interfaces

virtual methods

🧪 تست کلاس‌ها
csharp
[Test]
public void Person_ShouldCreateWithValidData()
{
    // Arrange & Act
    var person = new Person("علی", "محمدی", 30);
    
    // Assert
    Assert.AreEqual("علی", person.FirstName);
    Assert.AreEqual("محمدی", person.LastName);
    Assert.AreEqual(30, person.Age);
    Assert.IsTrue(person.IsAdult());
}
🎓 سطوح یادگیری
✅ مبتدی: کلاس‌های ساده، constructor، پراپرتی

✅ متوسط: وراثت، interface، static classes

✅ پیشرفته: generic classes، design patterns، SOLID principles

🤝 مشارکت در توسعه
ریپو را Fork کنید

Branch جدید ایجاد کنید (git checkout -b feature/class-enhancement)

تغییرات را Commit کنید (git commit -m 'Add new class patterns')

Branch را Push کنید (git push origin feature/class-enhancement)

Pull Request ایجاد کنید

📄 لایسنس
این پروژه تحت لایسنس MIT منتشر شده است.

👨‍💻 توسعه‌دهنده
[programmerdrn - GitHub Profile
](https://github.com/programmerdrn)
⭐ اگر این پروژه آموزشی برایتان مفید بود، حتما به آن Star بدهید!

💬 پشتیبانی
📧 ایجاد Issue در گیتهاب برای گزارش باگ یا پیشنهاد

🔄 پیشنهاد الگوهای کلاس جدید
