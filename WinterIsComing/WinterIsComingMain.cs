﻿namespace WinterIsComing
{
    using Contracts;
    using Core;
    using Models;

    public class WinterIsComingMain
    {
        private const int MatrixRows = 5;
        private const int MatrixCols = 5;

        static void Main()
        {
            IInputReader consoleReader = new ConsoleReader();
            var consoleWriter = new ConsoleWriter
            {
                AutoFlush = true
            };

            IUnitContainer unitMatrix = new MatrixContainer(MatrixRows, MatrixCols);
            //ICommandDispatcher commandDispatcher = new CommandDispatcher();
            ICommandDispatcher commandDispatcher = new NewCommandDispatcher();
            //IUnitEffector unitEffector = new EmptyUnitEffector();
            IUnitEffector unitEffector = new ExtendUnitEffect();

            var engine = new Engine(unitMatrix,
                consoleReader, 
                consoleWriter, 
                commandDispatcher, 
                unitEffector);

            engine.Start();
        }
    }
}
