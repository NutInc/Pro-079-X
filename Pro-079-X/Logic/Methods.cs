namespace Pro079X.Logic
{
    using Interfaces;
    using System;
    using System.Linq;
    using System.Text;
    using CommandSystem;
    using Exiled.API.Features;
    using NorthwoodLib.Pools;
    public static class Methods
    {
        private static string _helpMessage;

        public static string GetHelp()
        {
            if (!string.IsNullOrEmpty(_helpMessage))
                return _helpMessage;

            StringBuilder stringBuilder = StringBuilderPool.Shared.Rent();
            stringBuilder.Append(FormatCommands());
            stringBuilder.Append(FormatUltimates());
            _helpMessage = stringBuilder.ToString();
            StringBuilderPool.Shared.Return(stringBuilder);
            return _helpMessage;
        }

        internal static string FormatCommands()
        {
            Log.Debug("Running Command Formatter");
            if (!Pro079X.Singleton.Config.EnableModules)
                return string.Empty;

            var builder = new StringBuilder();
            builder.Append("\n<b><color=green>-- Commands --</color></b>\n");
            foreach (var command in Manager.Commands)
            {
                builder.Append(".079" + " " + command?.ExtraArguments + " - " + command?.Description);
                if (command != null) builder.Append(FormatEnergyLevel(command.Cost, command.MinLevel));
            }

            string str = builder.ToString();
            StringBuilderPool.Shared.Return(builder);
            return str;
        }

        internal static string FormatUltimates()
        {
            Log.Debug("Running Ultimate Formatter");
            if (!Pro079X.Singleton.Config.EnableUltimates)
                return string.Empty;

            var builder = new StringBuilder();

            builder.Append("\n<color=red><b>-- Ultimates --</b></color>\n");
            foreach (var ult in Manager.Ultimates)
            {
                builder.Append("<color=yellow>"+".079" + " " + Pro079X.Singleton.Translation.UltCmd + " " + ult.Command + "</color>");
                builder.Append(" - ");
                builder.Append(ult.Description + " " + Pro079X.Singleton?.Translation.UltData.ReplaceAfterToken('$', new[]
                {
                    new Tuple<string, object>("cost", ult.Cost),
                    new Tuple<string, object>("cd", ult.Cooldown)
                }));
            }
            
            string str = builder.ToString();
            Log.Debug("Produced Ultimate String: " + str);
            return str;
        }

        public static string FormatEnergyLevel(int energy, int level)
        {
            var stringBuilder = new StringBuilder();
            if (energy > 0)
                stringBuilder.Append(Pro079X.Singleton?.Translation.Energy);
            if (level > 1)
                stringBuilder.Append(Pro079X.Singleton?.Translation.Level);

            string str = stringBuilder.ToString();
            StringBuilderPool.Shared.Return(stringBuilder);
            str.ReplaceAfterToken('$', new[]
            {
                new Tuple<string, object>("ap", energy),
                new Tuple<string, object>("lvl", level),
            });

            if (str.Length == 0)
                return string.Empty;

            stringBuilder = StringBuilderPool.Shared.Rent();
            stringBuilder.Append("(");
            stringBuilder.Append(str);
            stringBuilder.Append(")");
            StringBuilderPool.Shared.Return(stringBuilder);
            return stringBuilder.ToString();
        }

        public static ICommand079 GetCommand(string command)
        {
            return Manager.Commands.Where(c => c.Command == command).ToList()[0];
        }

        public static IUltimate079 GetUltimate(string command)
        {
            return Manager.Ultimates.Where(ultimate => ultimate.Command == command).ToList()[0];
        }

        public static bool UltimateExists(string command)
        {
            Log.Debug($"Method UltimateExists() invoked with ultimate:{command}");
            Manager.Ultimates.ForEach(action=>Log.Debug($"Ultimate:{action.Command}"));
            return Manager.Ultimates.Count(c => c.Command == command) > 0;
        }
        
        public static bool CommandExists(string command)
        {
            Log.Debug($"Method CommandExists() invoked with command:{command}");
            Manager.Commands.ForEach(action=>Log.Debug($"Command:{action.Command}"));
            return Manager.Commands.Count(c => c.Command == command) > 0;
        }
        public static string LevelString(int level, bool uppercase = true)
        {
            if (uppercase || char.IsDigit(Pro079X.Singleton.Translation.Level[0]))
            {
                return char.ToUpper(Pro079X.Singleton.Translation.Level[0])
                       + Pro079X.Singleton?.Translation.Level.Substring(1).Replace("$lvl", level.ToString());
            }

            return Pro079X.Singleton?.Translation.Level.Replace("$lvl", level.ToString());
        }
    }
}