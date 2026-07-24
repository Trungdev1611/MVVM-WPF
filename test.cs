namespace Reserveroom;

class Programe
{
    private string message = "HelloWorld";
    public string Message
    {
        get { return message; }
        set
        {
            if (value == "message updated")
            {
                message = "notset";
            }
            else
            {
                message = "seted";
            }

        }

    }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string GetFullName()
    {
        return FirstName + LastName;
    }



}

class Test
{
    static void Main(string[] args)
    {
        Programe programe = new Programe();

        Console.WriteLine(programe.Message);

        programe.Message = "message updated";
        Console.WriteLine(programe.Message);

        programe.FirstName = "Trung";
        programe.LastName = "Pham";

        Console.WriteLine(programe.GetFullName());
    }

}