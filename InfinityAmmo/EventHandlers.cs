using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.CustomItems.API.EventArgs;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp914;
using MEC;
using System;
using System.Linq;
using UnityEngine;
using Firearm = Exiled.API.Features.Items.Firearm;

namespace InfinityAmmo
{
    public class EventHandlers
    {
        public void OnReloadingWeapon(ReloadingWeaponEventArgs ev)
        {
            if (ev.Firearm.Type != ItemType.GunShotgun)
            {
                Log.Debug("Reloading!");
                ev.Player.SetAmmo(ev.Firearm.AmmoType, (ushort)(ev.Firearm.TotalMaxAmmo + 1));
            } 
        }

        public void OnShot(ShotEventArgs ev)
        {
            if (ev.Firearm.Type != ItemType.ParticleDisruptor)
            {
                ev.Player.SetAmmo(ev.Firearm.AmmoType, 1);
                return;
            }

            Log.Debug("Disruptor Shot!");

            if (!Plugin.Instance.Config.InfParticleDisruptor)
                return;

            Log.Debug("Reloading Disruptor!");
            ev.Firearm.AmmoDrain = 5;
            ev.Firearm.BarrelAmmo = 5;
            ev.Firearm.MagazineAmmo = 5;
        }

        public void OnChangingItem(ChangingItemEventArgs ev)
        {
            Log.Debug("Changing!");
            if (ev.Item is not Firearm firearm)
                return;

            Log.Debug("Firearm!");

            if (firearm.Type == ItemType.ParticleDisruptor)
            {
                Log.Debug("Disruptor!");
                firearm.AmmoDrain = 5;
                firearm.BarrelAmmo = 5;
                firearm.MagazineAmmo = 5;
            }

            Log.Debug("Setting ammo!");
            ev.Player.SetAmmo(firearm.AmmoType, 1);
        }

        public void OnPickingUpItem(Exiled.Events.EventArgs.Player.PickingUpItemEventArgs ev)
        {
            if (ev.Pickup.Type is ItemType.Ammo12gauge or ItemType.Ammo44cal or ItemType.Ammo556x45 or ItemType.Ammo762x39 or ItemType.Ammo9x19)
            {
                ev.IsAllowed = false;

                if (Plugin.Instance.Config.Debug)
                    Log.Debug($"[InfinityAmmo] Player {ev.Player.Nickname} attempted to pick up ammo ({ev.Pickup.Type}) and was blocked.");
            }
        }


        public void OnDroppingAmmo(Exiled.Events.EventArgs.Player.DroppingAmmoEventArgs ev)
        {
            ev.IsAllowed = false;

            if (Plugin.Instance.Config.Debug)
                Log.Debug($"[InfinityAmmo] Player {ev.Player.Nickname} attempted to drop ammo ({ev.AmmoType}) and was blocked.");
        }

        public void OnDying(DyingEventArgs ev)
        {
            Log.Debug("Dying!");
            ev.Player.SetAmmo(AmmoType.Nato9, 0);
            ev.Player.SetAmmo(AmmoType.Ammo44Cal, 0);
            ev.Player.SetAmmo(AmmoType.Ammo12Gauge, 0);
            ev.Player.SetAmmo(AmmoType.Nato556, 0);
            ev.Player.SetAmmo(AmmoType.Nato762, 0);
            ev.Player.SetAmmo(AmmoType.None, 0);
        }

        public void OnRoundStarted()
        {
            if (!Plugin.Instance.Config.DestroyAmmoPickups)
                return;

            foreach (var pickup in Exiled.API.Features.Pickups.Pickup.List)
            {
                if (pickup is Exiled.API.Features.Pickups.AmmoPickup)
                    pickup.Destroy();
            }

            if (Plugin.Instance.Config.Debug)
                Log.Debug("[InfinityAmmo] All ammo pickups destroyed at the start of the round.");
        }
        public void OnUpgradingPlayer(UpgradingPlayerEventArgs ev)
        {
            // Очищаем карту от всех патронов, если это включено в конфигурации
            if (Plugin.Instance.Config.DestroyAmmoPickups)
            {
                foreach (var pickup in Exiled.API.Features.Pickups.Pickup.List)
                {
                    if (pickup is Exiled.API.Features.Pickups.AmmoPickup)
                        pickup.Destroy();
                }

                if (Plugin.Instance.Config.Debug)
                    Log.Debug("[InfinityAmmo] All ammo pickups destroyed during player upgrade.");
            }

        }

        public void OnUpgradingItem(UpgradingPickupEventArgs ev)
        {
            // Очищаем карту от всех патронов, если это включено в конфигурации
            if (Plugin.Instance.Config.DestroyAmmoPickups)
            {
                foreach (var pickup in Exiled.API.Features.Pickups.Pickup.List)
                {
                    if (pickup is Exiled.API.Features.Pickups.AmmoPickup)
                        pickup.Destroy();
                }

                if (Plugin.Instance.Config.Debug)
                    Log.Debug("[InfinityAmmo] All ammo pickups destroyed during player upgrade.");
            }
        }

    }
}