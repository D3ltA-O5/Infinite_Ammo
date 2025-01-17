using Exiled.API.Interfaces;
using System.ComponentModel;

namespace InfinityAmmo
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public bool InfParticleDisruptor { get; set; } = true;
        public bool DestroyAmmoPickups { get; set; } = true;
    }
}
