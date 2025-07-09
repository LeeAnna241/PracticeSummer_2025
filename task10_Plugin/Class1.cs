namespace Plugin;

public interface IPlugin
{
    void Execute();
}

public class PluginLoad : Attribute
{
    public string[] Dependence { get; }

        public PluginLoad(params string[] depends_on)
        {
            Dependence = depends_on;
        }
}

