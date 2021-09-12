namespace FlatMango.ProjectGlass
{
    public abstract class Module<T> where T : Module<T>
    {
        protected readonly static T instance;

        internal static T Instance => instance;

        static Module()
        {
            instance = System.Activator.CreateInstance(typeof(T), true) as T;
        }


        public bool IsEnabled { get; private set; }


        public void Enable()
        {
            if (IsEnabled)
                return;

            IsEnabled = true;
            OnEnable();

            Update();
        }

        public void Disable()
        {
            if (!IsEnabled)
                return;

            IsEnabled = false;
            OnDisable();
        }

        internal void Update()
        {
            if (!IsEnabled)
                return;

            OnUpdate();
        }

        protected abstract void OnEnable();
        protected abstract void OnDisable();
        protected abstract void OnUpdate();
    }
}
