namespace Domain.Entities.Animals
{
    public class Herbo : Animal
    {
        public int Kindness { get; } = 0;

        public Herbo(string name, int food, bool state, int kindness) : base(name, food, state)
        {
            if (kindness > 10 || kindness < 0)
            {
                Kindness = 10;
            }
            else
            {
                Kindness = kindness;
            }
        }

    }
}