namespace Samples.NancyFx
{
    public interface ISimpleDependency
    {
        int ConstructorCounter { get; }
    }

    public class SimpleDependency: ISimpleDependency
    {
        private static int _constructorCounter;

        public SimpleDependency()
        {
            _constructorCounter++;
        }

        public int ConstructorCounter => _constructorCounter;
    }
}