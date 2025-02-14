using Domain.Abstractions;

namespace Domain.Services
{
    public class VetClinic : IVetClinic
    {
        /// <summary>
        ///  This method examines possibility of adding animal to the zoo.
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public bool CheckHealth(IAlive animal)
        {
            return animal.State;
        }
    }
}