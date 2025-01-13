Made on basis of this plugin [InfinityAmmo](https://github.com/alexomur/InfinityAmmo) i made little upgrades for them for ammo clearence and ban on throwing away cartridges from inventory
# 🔫 Infinite_Ammo Plugin for SCP: Secret Laboratory

The **Infinite_Ammo Plugin** provides advanced ammo management for SCP: Secret Laboratory. This plugin ensures a balanced and controlled gameplay experience by managing ammo capacities, reloading behavior, and restricting certain actions like dropping or picking up ammo.

## ✨ Features

- **Infinite Ammo for All Firearms**: Automatically sets a fixed ammo count for all firearm types, ensuring players never run out of bullets.
- **Pickup & Drop Restrictions**: Prevent players from picking up or dropping ammo during the game.
- **Automatic Ammo Clearance**: Removes all ammo pickups from the map at the start of each round.
- **Dynamic Reloading Logic**: Automatically resets a player's firearm to a fixed ammo count upon reloading.

## 📋 Requirements

- **SCP: Secret Laboratory** game server
- **Exiled API** version 9.1.1 or higher

## 📥 Installation

1. **Download the InfinityAmmo.dll file** from the [Releases](https://github.com/D3ltA-O5/Infinite_Ammo/releases) page.
2. **Place the InfinityAmmo.dll file** in your server's `EXILED/Plugins` directory.
3. **Create or modify the configuration file** in your server's `EXILED/Configs` directory to customize the plugin settings.

## ⚙️ Configuration

Once installed, the plugin generates a configuration file in your server's `EXILED/Configs` directory. You can customize the following settings:

- **IsEnabled**: Enables or disables the plugin (default: `true`).
- **Debug**: Enables or disables debug mode (default: `false`).
- **FixedAmmoAmount**: Sets the fixed amount of ammo players will have for each ammo type (default: `150`).
- **InfParticleDisruptor**: Enables infinite ammo functionality for the Particle Disruptor (default: `true`).
- **DestroyAmmoPickups**: Automatically removes all ammo pickups at the start of each round (default: `true`).

Edit the configuration file to adjust these settings according to your server's preferences.

## 🕹️ Usage

After installing and configuring the plugin, it will:
- Automatically manage ammo capacities for all players.
- Prevent ammo pickups and drops.
- Reset firearm ammo to a fixed amount upon reloading.
- Optionally, clear all ammo pickups from the map at the start of each round.

## 🤝 Contributing

We welcome contributions from the community! If you have suggestions or improvements, feel free to fork the repository and submit a pull request.

## 🛠️ Support

For support, questions, or to report bugs, please visit the [GitHub Issues page](https://github.com/D3ltA-O5/Infinite_Ammo/issues) or contact me on Discord (cyberco).

---

Enjoy precise control over ammo management and enhance your SCP: SL server with this powerful plugin!
