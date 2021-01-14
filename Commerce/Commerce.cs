using System;
using PatchZone.Hatch;
using PatchZone.Hatch.Utils;
using Commerce.Services;

using ECS;
using Service.Achievement;
using Service.Building;
using Service.Localization;
using Service.Street;
using Service.UserWorldTasks;

namespace Commerce
{
    public class Commerce : Singleton<Commerce>, IPatchZoneMod
    {
        public IPatchZoneContext Context { get; private set; }

        public void Init(IPatchZoneContext context)
        {
            this.Context = context;
        }

        public void OnBeforeGameStart()
        {
            this.Context.RegisterProxyService<ILocalizationService, LocalizationService>();
        }
    }
}
