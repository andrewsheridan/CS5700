﻿using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    /// <summary>
    /// CommandFactory
    /// 
    /// Creates standard commands, but can be specialized to create custom commands.  This class is the base
    /// class in a factory method pattern.
    /// </summary>
    public class CommandFactory
    {
        public Drawing TargetDrawing { get; set; }

        public CommandHistory History = CommandHistory.Instance;

        /// <summary>
        /// Create -- a factory method for standard commands 
        /// 
        /// This method can be overridden to generate different or custom commands.
        /// </summary>
        /// <param name="commandType">type of command to Create:
        ///             New
        ///             Add
        ///             Remove
        ///             Select
        ///             Deselect
        ///             Load
        ///             Save</param>
        /// <param name="commandParameters">An array of optional parametesr whose sementics depedent on the command type
        ///     For new, no additional parameters needed
        ///     For add, 
        ///         [0]: Type       reference type for assembly containing the image type resource
        ///         [1]: string     image type -- a fully qualified resource name
        ///         [2]: int        x-coordinate for center location for the image, default = left side
        ///         [3]: int        y-coordinate for center location for the image, default = top
        ///         [4]: float      scale factor</param>
        ///     For remove, no additional parameters needed
        ///     For select,
        ///         [0]: int       x-Location at which a image could be selected
        ///         [1]: int       y-location at which a image could be selected 
        ///     For deselect, no additional parameters needed
        ///     For load,
        ///         [0]: string     filename of file to load from  
        ///     For save,
        ///         [0]: string     filename of file to save to  
        /// <returns></returns>
        public virtual Command Create(string commandType, params object[] commandParameters)
        {
            if (string.IsNullOrWhiteSpace(commandType)) return null;

            Command command=null;
            switch (commandType.Trim().ToUpper())
            {
                case "NEW":
                    command = new NewCommand();
                    break;
                case "ADD":
                    command = new AddCommand(commandParameters);
                    break;
                case "REMOVE":
                    command = new RemoveSelectedCommand();
                    break;
                case "SELECT":
                    command = new SelectCommand(commandParameters);
                    break;
                case "DESELECT":
                    command = new DeselectAllCommand();
                    break;
                case "LOAD":
                    command = new LoadCommand(commandParameters);
                    break;
                case "SAVE":
                    command = new SaveCommand(commandParameters);
                    break;
                case "SCALE":
                    command = new ScaleCommand(commandParameters);
                    break;
                case "MOVE":
                    command = new MoveSelectedCommand(commandParameters);
                    break;
                case "COPY":
                    command = new CopyCommand();
                    break;
            }

            if (command != null)
            {
                command.TargetDrawing = TargetDrawing;
                History.Add(command);
            }
                

            return command;
        }
    }
}

