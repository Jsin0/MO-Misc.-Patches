using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace MO_MiscPatches
{
    public class MO_MiscPatchSettings : ModSettings
    {
        ///<summary>
        ///Settings
        /// </summary>
        public bool NoRefueling;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref NoRefueling, "NoRefueling");
            base.ExposeData();
        }
    }
    public class MO_MiscPatch : Mod
    {
        ///<summary>
        ///A refernce to the settings
        /// </summary>
        MO_MiscPatchSettings settings;

        public MO_MiscPatch(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<MO_MiscPatchSettings>();
        }
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled("Toggle fuel-less lamps", ref settings.NoRefueling, "ToolTip");
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }
        public override string SettingsCategory()
        {
            return "MO Misc. Patch".Translate();
        }
    }
}
