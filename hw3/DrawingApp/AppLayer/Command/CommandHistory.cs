using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    public class CommandHistory : List<Command>
    {
        private static CommandHistory instance;

        private CommandHistory(){ }

        public static CommandHistory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new CommandHistory();
                }
                return instance;
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach(Command c in instance)
            {
                s += c.ToString();
            }
            return s;
        }

        public void UndoLast()
        {
            Command c = Instance[Instance.Count - 1];
            Instance.RemoveAt(Instance.Count - 1);
            c.Undo();
        }
    }
}
