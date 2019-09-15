namespace UmtData.Data
{
    /// <summary>
    /// generic Singleton<T> (потокобезопасный с использованием generic-класса и с отложенной инициализацией)
    /// </summary>
    /// <typeparam name="T">Singleton class</typeparam>
    public class Singleton<T> where T : class, new()
    {
        /// Защищённый конструктор необходим для того, чтобы предотвратить создание экземпляра класса Singleton. 
        /// Он будет вызван из закрытого конструктора наследственного класса.
        protected Singleton() { }

        /// Фабрика используется для отложенной инициализации экземпляра класса
        private sealed class SingletonCreator<S> where S : class, new()
        {
            //Используется Reflection для создания экземпляра класса без публичного конструктора

            public static S CreatorInstance { get; } = new S();
        }

        public static T Instance => SingletonCreator<T>.CreatorInstance;
    }
}