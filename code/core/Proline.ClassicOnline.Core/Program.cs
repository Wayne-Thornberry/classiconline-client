using CitizenFX.Core;
using Newtonsoft.Json;
using Proline.ClassicOnline.CCoreSystem;
using Proline.ClassicOnline.Engine.Component; 
using Proline.Resource.Configuration;
using Proline.Resource.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Console = Proline.Resource.Console;

namespace Proline.ClassicOnline.Engine
{
    public class Program
    {
        private static Dictionary<string, ComponentContainer> _components;

        private static void Main(string[] args)
        {
            Console.WriteLine($"Started ClassicOnline");
            _components = new Dictionary<string, ComponentContainer>();

            try
            {
                // Data system

                // Event Systems

                // Load the components
                var componentJson = ResourceFile.Load("components.json");
                var components = JsonConvert.DeserializeObject<string[]>(componentJson.Load()); 

                foreach (var item in components)
                {
                    Console.WriteLine($"Loading {item}");
                    var container = ComponentContainer.Load(item);
                    Console.WriteLine($"Succesfully Loaded {container.Name}");
                    container.RegisterCommands();
                    _components.Add(container.Name, container);
                }

                 // Init_Core
                 // - Finds all scripts that are marked InitializeCore
                 // - Execute Core Initializations
                foreach (var container in _components.Values)
                {  
                    Console.WriteLine(string.Format("Invoking {0} {1}", container.Name, ComponentContainer.INITCORESCRIPTNAME)); 
                    try
                    {
                        container.ExecuteScript(ComponentContainer.INITCORESCRIPTNAME);
                    }
                    catch (ScriptDoesNotExistException e)
                    {

                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }

                // Init_Session
                // - Find all scripts that are marked InitializeSession
                // - Execute Session Intializations
                foreach (var container in _components.Values)
                {
                    try
                    { 
                        Console.WriteLine(string.Format("Invoking {0} {1}", container.Name, ComponentContainer.INITSESSIONSCRIPTNAME));
                        try
                        {
                            container.ExecuteScript(ComponentContainer.INITSESSIONSCRIPTNAME);
                        }
                        catch (ScriptDoesNotExistException e)
                        {

                        }
                        catch (Exception e)
                        {
                            throw;
                        } 
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

                //CCoreSystemAPI.StartNewScript("Main");
                // Level Scripts
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
         

    }
}
