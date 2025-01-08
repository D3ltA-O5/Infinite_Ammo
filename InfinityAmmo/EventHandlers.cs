using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Firearm = Exiled.API.Features.Items.Firearm;

namespace InfinityAmmo
{
    public class EventHandlers
    {
        public void OnReloadingWeapon(ReloadingWeaponEventArgs ev)
        {
            if (Plugin.Instance.Config.Debug)
                Log.Debug($"[InfinityAmmo] Player {ev.Player.Nickname} is reloading.");

            // Устанавливаем фиксированное количество боеприпасов
            ev.Player.SetAmmo(ev.Firearm.AmmoType, (ushort)Plugin.Instance.Config.FixedAmmoAmount);
        }

        public void OnPickingUpItem(Exiled.Events.EventArgs.Player.PickingUpItemEventArgs ev)
        {
            // Проверяем, является ли подбираемый предмет боеприпасами
            if (ev.Pickup.Type is ItemType.Ammo12gauge or ItemType.Ammo44cal or ItemType.Ammo556x45 or ItemType.Ammo762x39 or ItemType.Ammo9x19)
            {
                ev.IsAllowed = false; // Блокируем возможность поднять боеприпасы

                if (Plugin.Instance.Config.Debug)
                    Log.Debug($"[InfinityAmmo] Player {ev.Player.Nickname} attempted to pick up ammo ({ev.Pickup.Type}) and was blocked.");
            }
        }

        public void OnDroppingAmmo(Exiled.Events.EventArgs.Player.DroppingAmmoEventArgs ev)
        {
            ev.IsAllowed = false; // Блокируем возможность выбросить боеприпасы

            if (Plugin.Instance.Config.Debug)
                Log.Debug($"[InfinityAmmo] Player {ev.Player.Nickname} attempted to drop ammo ({ev.AmmoType}) and was blocked.");
        }


        public void OnShot(ShotEventArgs ev)
        {
            if (ev.Firearm.Type != ItemType.ParticleDisruptor)
            {
                ev.Player.SetAmmo(ev.Firearm.AmmoType, (ushort)Plugin.Instance.Config.FixedAmmoAmount);
                return;
            }

            if (Plugin.Instance.Config.Debug)
                Log.Debug($"[InfinityAmmo] Player {ev.Player.Nickname} fired a Particle Disruptor.");

            if (!Plugin.Instance.Config.InfParticleDisruptor)
                return;

            ev.Firearm.AmmoDrain = 5;
            ev.Firearm.BarrelAmmo = 5;
            ev.Firearm.MagazineAmmo = 5;
        }

        public void OnChangingItem(ChangingItemEventArgs ev)
        {
            if (Plugin.Instance.Config.Debug)
                Log.Debug($"[InfinityAmmo] Player {ev.Player.Nickname} is changing items.");

            if (ev.Item is not Firearm firearm)
                return;

            if (firearm.Type == ItemType.ParticleDisruptor)
            {
                firearm.AmmoDrain = 5;
                firearm.BarrelAmmo = 5;
                firearm.MagazineAmmo = 5;
            }

            ev.Player.SetAmmo(firearm.AmmoType, (ushort)Plugin.Instance.Config.FixedAmmoAmount);
        }

        public void OnDying(DyingEventArgs ev)
        {
            if (Plugin.Instance.Config.Debug)
                Log.Debug($"[InfinityAmmo] Player {ev.Player.Nickname} has died. Clearing ammo.");

            ev.Player.Ammo.Clear();
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
    }
}
