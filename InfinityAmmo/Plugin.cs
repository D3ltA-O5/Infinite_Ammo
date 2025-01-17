using System;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;
using player = Exiled.Events.Handlers.Player;
using scp914 = Exiled.Events.Handlers.Scp914;

namespace InfinityAmmo
{
    public sealed class Plugin : Plugin<Config>
    {
        public override string Author => "DrBright";
        public override string Name => "InfinityAmmo";
        public override Version RequiredExiledVersion { get; } = new(9, 1, 1);
        public override Version Version { get; } = new(2, 1, 1);

        public static Plugin Instance { get; private set; }
        private EventHandlers _handlers;

        public Plugin()
        {
            Instance = this;
        }

        public override void OnEnabled()
        {
            Instance = this;

            RegisterEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            Instance = null;

            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _handlers = new EventHandlers();

            Player.Dying += _handlers.OnDying;
            Player.ReloadingWeapon += _handlers.OnReloadingWeapon;
            Player.ChangingItem += _handlers.OnChangingItem;
            Player.Shot += _handlers.OnShot;
            Player.PickingUpItem += _handlers.OnPickingUpItem;
            Player.DroppingAmmo += _handlers.OnDroppingAmmo;
            Server.RoundStarted += _handlers.OnRoundStarted;
            scp914.UpgradingPlayer += _handlers.OnUpgradingPlayer;
            scp914.UpgradingPickup += _handlers.OnUpgradingItem;



        }

        private void UnregisterEvents()
        {
            Player.Dying -= _handlers.OnDying;
            Player.ReloadingWeapon -= _handlers.OnReloadingWeapon;
            Player.ChangingItem -= _handlers.OnChangingItem;
            Player.Shot -= _handlers.OnShot;
            Player.PickingUpItem -= _handlers.OnPickingUpItem;
            Player.DroppingAmmo -= _handlers.OnDroppingAmmo;
            Server.RoundStarted -= _handlers.OnRoundStarted;
            scp914.UpgradingPlayer -= _handlers.OnUpgradingPlayer;
            scp914.UpgradingPickup -= _handlers.OnUpgradingItem;


            _handlers = null;
        }
    }
}