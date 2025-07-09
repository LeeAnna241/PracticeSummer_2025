using Plugin;
using System.Reflection;
namespace task10_PluginLoader;

public class PluginLoader
{
    public static void LoadAndExcute(string pluginsPath)
    {
        if (!Directory.Exists(pluginsPath))
        {
            Console.WriteLine("Папка с плагинами не найдена");
            return;
        }

        var loadedPlugins = new HashSet<string>();

        foreach (var dllPath in Directory.GetFiles(pluginsPath, "*.dll"))
        {
            var assembly = Assembly.LoadFrom(dllPath);

            var pluginTypes = assembly.GetTypes()
                .Where(a => typeof(IPlugin).IsAssignableFrom(a))
                .Where(b => !b.IsInterface)
                .Where(c => c.GetCustomAttribute<PluginLoad>() != null).ToList();

            var plugins = pluginTypes
           .Select(type => new
           {
               Type = type,
               Name = type.Name,
               Dependenc = type.GetCustomAttribute<PluginLoad>()?.Dependence
           }).ToList();

            while (loadedPlugins.Count < plugins.Count)
            {
                foreach (var plugin in plugins)
                {
                    if (!loadedPlugins.Contains(plugin.Name) && plugin.Dependenc != null && plugin.Dependenc.All(loadedPlugins.Contains) && Activator.CreateInstance(plugin.Type) is IPlugin pluginInstance)
                    {                     
                        pluginInstance.Execute();
                        loadedPlugins.Add(plugin.Name);                      
                    }
                }
            }
        }
    }
}

