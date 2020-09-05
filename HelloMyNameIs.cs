using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Player = Exiled.Events.Handlers.Player;

namespace HelloMyNameIs
{
    public class Plugin : Plugin<Config>
    {
        private static readonly Lazy<Plugin> LazyInstance = new Lazy<Plugin>(() => new Plugin());
        public static Plugin Instance => LazyInstance.Value;

        private Plugin() { }

        public override PluginPriority Priority { get; } = PluginPriority.Medium;
        public override string Name { get; } = "HelloMyNameIs";
        public override string Author { get; } = "Steven4547466";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 2);
        public override string Prefix { get; } = "HelloMyNameIs";


        public Handlers.Player player { get; set; }

        public override void OnEnabled()
        {
            if (Plugin.Instance.Config.IsEnabled == false) return;
            base.OnEnabled();
            Log.Info("HelloMyNameIs enabled.");
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Log.Info("HelloMyNameIs disabled.");
            UnregisterEvents();
        }

        public override void OnReloaded()
        {
            base.OnReloaded();
            Log.Info("HelloMyNameIs reloading.");
        }

        public void RegisterEvents()
        {
            player = new Handlers.Player();
            Player.Left += player.OnLeft;
            Player.Spawning += player.OnSpawning;
            Player.ChangingRole += player.OnChangingRole;
            Player.Died += player.OnDied;
        }

        public void UnregisterEvents()
        {
            Log.Info("Events unregistered");
            Player.Left -= player.OnLeft;
            Player.Spawning -= player.OnSpawning;
            Player.ChangingRole -= player.OnChangingRole;
            Player.Died -= player.OnDied;

            player = null;
        }
    }
}
