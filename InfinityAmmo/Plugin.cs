using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace InfinityAmmo
{
    public sealed class Plugin : Plugin<Config>
    {
        public override string Author => "D3ltA_O5";
        public override string Name => "InfinityAmmo";
        public override Version RequiredExiledVersion { get; } = new(9, 1, 1);
        public override Version Version { get; } = new(2, 1, 0);

        public static Plugin Instance { get; private set; }
        private EventHandlers _handlers;

        public Plugin()
        {
            Instance = this;
        }

        public override void OnEnabled()
        {
            base.OnEnabled();

            if (!Config.IsEnabled)
            {
                Log.Info("[InfinityAmmo] Plugin is disabled via configuration.");
                return;
            }

            if (Config.Debug)
                Log.Debug("[InfinityAmmo] Debug mode is enabled.");

            _handlers = new EventHandlers();

            // Регистрация всех обработчиков событий
            Player.ReloadingWeapon += _handlers.OnReloadingWeapon;
            Player.Shot += _handlers.OnShot;
            Player.ChangingItem += _handlers.OnChangingItem;
            Player.Dying += _handlers.OnDying;
            Player.PickingUpItem += _handlers.OnPickingUpItem; // Поднятие предметов
            Player.DroppingAmmo += _handlers.OnDroppingAmmo; // Выбрасывание боеприпасов
            Server.RoundStarted += _handlers.OnRoundStarted;

            Log.Info("[InfinityAmmo] Plugin enabled.");
        }

        public override void OnDisabled()
        {
            base.OnDisabled();

            // Отмена регистрации всех обработчиков событий
            Player.ReloadingWeapon -= _handlers.OnReloadingWeapon;
            Player.Shot -= _handlers.OnShot;
            Player.ChangingItem -= _handlers.OnChangingItem;
            Player.Dying -= _handlers.OnDying;
            Player.PickingUpItem -= _handlers.OnPickingUpItem; // Поднятие предметов
            Player.DroppingAmmo -= _handlers.OnDroppingAmmo; // Выбрасывание боеприпасов
            Server.RoundStarted -= _handlers.OnRoundStarted;

            _handlers = null;

            Log.Info("[InfinityAmmo] Plugin disabled.");
        }
    }
}
