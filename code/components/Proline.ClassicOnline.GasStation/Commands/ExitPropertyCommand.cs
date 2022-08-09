using Proline.Resource.Framework;

namespace Proline.ClassicOnline.CWorldObjects.Commands
{
    public class ExitProperty : ResourceCommand
    {
        public ExitProperty() : base("ExitProperty")
        {
        }

        protected override void OnCommandExecute(params object[] args)
        {
            if (args.Length == 3)
            {
                WorldAPI.ExitProperty(args[0].ToString(), args[1].ToString(), args[2].ToString());
            }
        }
    }
}
