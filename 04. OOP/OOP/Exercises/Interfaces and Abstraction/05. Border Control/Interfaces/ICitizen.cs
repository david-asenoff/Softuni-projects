namespace P05BorderControl.Interfaces
{
    public interface ICitizen:IIdentifiable
    {
        int Age { get; }
        string Name { get; }
    }
}
