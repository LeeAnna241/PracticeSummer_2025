namespace task04
{
    public interface ISpaceship
    {
        void MoveForward();      // Движение вперед
        void Rotate(int angle);  // Поворот на угол (градусы)
        void Fire();             // Выстрел ракетой
        int Speed { get; }       // Скорость корабля
        int FirePower { get; }   // Мощность выстрела
    }
    public class Fighter : ISpaceship
    {
        public void MoveForward() {}
        public void Rotate(int angle) {}
        public void Fire() {}
        public int Speed
        {
            get { return 100; }
        }
        public int FirePower
        {
            get { return 50; }
        }
    }
    public class Cruiser : ISpaceship
    {
        public void MoveForward() {}
        public void Rotate(int angle) {}
        public void Fire() {}
        public int Speed
        {
            get { return 50; }
        }
        public int FirePower
        {
            get { return 100; }
        }
    }
}