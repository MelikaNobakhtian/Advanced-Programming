using E1.Enums;

namespace E1.Interfaces
{
    public interface IAnimal
    {
        string Name { get; set; }
        int Age { get; set; }
        double Health { get; set; }
        string EatFood();
        string Reproduction(IAnimal animal);
        string Move(Environment environment);
    }
}