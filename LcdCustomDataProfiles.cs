using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
//=======================================================================
//////////////////////////Space Engineers Imports////////////////////////
//=======================================================================
using VRageMath;
using VRage.Game;
using VRage.Collections;
using Sandbox.ModAPI.Ingame;
using VRage.Game.Components;
using VRage.Game.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using Sandbox.Game.EntityComponents;
using SpaceEngineers.Game.ModAPI.Ingame;
using VRage.Game.ObjectBuilders.Definitions;

namespace SpaceEngineers_Visual_Studio_17
{
    class LcdCustomDataProfiles : MyGridProgram
    {
        /* =======================================================================
            * =======================================================================
            * Új profil hozzáadása: public void Profile_1() másolása, adatok módosítása
            * Ezután a public void Main(string args) -ban a switch-ben hozzáadni
            * egy új case-ban az új profilt
            * =======================================================================
            * =======================================================================
            */

        // Névben lévő TAG eleje:
        const string prefix = "[Yusukee_LCD";
        // Névben lévő TAG vége:
        const string postfix = "]";
        List<IMyTextPanel> taggedTextPanelList;

        //Constructor !!!!! Rename to public Program() in-game !!!!!
        public LcdCustomDataProfiles()
        {
            List<IMyTextPanel> allTextPanel = new List<IMyTextPanel>();
            GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(allTextPanel);
            
            taggedTextPanelList = getTaggedTextPanels(allTextPanel);
            Echo("Compiled Successfuly");
        }

        public void Main(string args)
        {
            switch (args)
            {
                //STATUS tag
                //Automatic LCDs 2
                case "GAS":
                    Gas();
                    break;
                //STATUS tag
                //Automatic LCDs 2
                case "POWER":
                    Power();
                    break;
                //STATUS tag
                //Automatic LCDs 2
                case "POWER_CONSUMPTION":
                    PowerConsumption();
                    break;
                //INVENTORY tag
                //TIM Inventory manager
                case "INVENTORY_ORE":
                    InventoryOre();
                    break;
                //INVENTORY tag
                //TIM Inventory manager
                case "INVENTORY_INGOT":
                    InventoryIngot();
                    break;
                //INVENTORY tag
                //TIM Inventory manager
                case "INVENTORY_COMPONENT":
                    InventoryComponent();
                    break;
                //INVENTORY tag
                //TIM Inventory manager
                case "INVENTORY_QUOTA":
                    InventoryQuota();
                    break;
                default:
                    break;
            }
        }

        public void Gas()
        {
            // Profil neve 
            string partialTag = "STATUS";
            // LCD nevében lévő teljes tag (itt pl: [Yusukee_LCD STATUS] ) 
            string tag = prefix + " " + partialTag + postfix;
            // új custom data 
            string customData = "Center --- Gas Tanks ---;Tanks * Oxygen;Tanks * Hydrogen;Center --- Cargo Summary ---;Cargo;Center --- Oxygen Generators (Many more) ---;Working {Oxygen Generator 2};";
            // public Text (profil váltáskor felenik meg, amíg nem frissül a LCD mod)
            string publicText = "Profile: Gas";
            // betűméret 0 - 1-ig a végén F fontos! 
            float fontSize = 1.0F;
            // betű színe (Red,Green,Blue) mind a 3 érték 0-255 
            Color fontColor = new Color(255, 200, 0);
            // háttér színe 
            Color backgroundColor = new Color(0, 0, 0);

            //======================================================================= 
            foreach (IMyTextPanel textPanel in taggedTextPanelList)
            {
                if (textPanel.CustomName.Contains(tag))
                {
                    textPanel.CustomData = customData;
                    textPanel.SetValue("FontSize", fontSize);
                    textPanel.SetValue("FontColor", fontColor);
                    textPanel.SetValue("BackgroundColor", backgroundColor);
                    textPanel.WritePublicText(publicText);
                    textPanel.ShowPublicTextOnScreen();
                }
            }
        }

        public void Power()
        {
            string partialTag = "STATUS";
            string tag = prefix + " " + partialTag + postfix;
            string customData = "Center --- Power Summary ---;Power;";
            string publicText = "Profile: Power";
            float fontSize = 1.0F;
            Color fontColor = new Color(255, 200, 0);
            Color backgroundColor = new Color(0, 0, 0);

            //=======================================================================
            foreach (IMyTextPanel textPanel in taggedTextPanelList)
            {
                if (textPanel.CustomName.Contains(tag))
                {
                    textPanel.CustomData = customData;
                    textPanel.SetValue("FontSize", fontSize);
                    textPanel.SetValue("FontColor", fontColor);
                    textPanel.SetValue("BackgroundColor", backgroundColor);
                    textPanel.WritePublicText(publicText);
                    textPanel.ShowPublicTextOnScreen();
                }
            }
        }

        public void PowerConsumption()
        {
            string partialTag = "STATUS";
            string tag = prefix + " " + partialTag + postfix;
            string customData = "Center --- Power Consumption ---;PowerUsedTop {T:*} 8;";
            string publicText = "Profile: Power Consumption";
            float fontSize = 1.0F;
            Color fontColor = new Color(255, 200, 0);
            Color backgroundColor = new Color(0, 0, 0);

            //=======================================================================
            foreach (IMyTextPanel textPanel in taggedTextPanelList)
            {
                if (textPanel.CustomName.Contains(tag))
                {
                    textPanel.CustomData = customData;
                    textPanel.SetValue("FontSize", fontSize);
                    textPanel.SetValue("FontColor", fontColor);
                    textPanel.SetValue("BackgroundColor", backgroundColor);
                    textPanel.WritePublicText(publicText);
                    textPanel.ShowPublicTextOnScreen();
                }
            }
        }

        public void InventoryOre()
        {
            string partialTag = "INVENTORY";
            string tag = prefix + " " + partialTag + postfix;
            string publicText = "Profile: Ore Inventory";
            string name = "LCD Inventory [TIM INVEN:Ore] [Yusukee_LCD INVENTORY]";
            float fontSize = 1.0F;
            Color fontColor = new Color(255, 255, 255);
            Color backgroundColor = new Color(0, 0, 0);

            //=======================================================================
            foreach (IMyTextPanel textPanel in taggedTextPanelList)
            {
                if (textPanel.CustomName.Contains(tag))
                {
                    textPanel.CustomName = name;
                    textPanel.SetValue("FontSize", fontSize);
                    textPanel.SetValue("FontColor", fontColor);
                    textPanel.SetValue("BackgroundColor", backgroundColor);
                    textPanel.WritePublicText(publicText);
                    textPanel.ShowPublicTextOnScreen();
                }
            }
        }

        public void InventoryIngot()
        {
            string partialTag = "INVENTORY";
            string tag = prefix + " " + partialTag + postfix;
            string publicText = "Profile: Ingot Inventory";
            string name = "LCD Inventory [TIM INVEN:Ingot] [Yusukee_LCD INVENTORY]";
            float fontSize = 1.0F;
            Color fontColor = new Color(255, 255, 255);
            Color backgroundColor = new Color(0, 0, 0);

            //=======================================================================
            foreach (IMyTextPanel textPanel in taggedTextPanelList)
            {
                if (textPanel.CustomName.Contains(tag))
                {
                    textPanel.CustomName = name;
                    textPanel.SetValue("FontSize", fontSize);
                    textPanel.SetValue("FontColor", fontColor);
                    textPanel.SetValue("BackgroundColor", backgroundColor);
                    textPanel.WritePublicText(publicText);
                    textPanel.ShowPublicTextOnScreen();
                }
            }
        }

        public void InventoryComponent()
        {
            string partialTag = "INVENTORY";
            string tag = prefix + " " + partialTag + postfix;
            string publicText = "Profile: Component Inventory";
            string name = "LCD Inventory [TIM INVEN:Component] [Yusukee_LCD INVENTORY]";
            float fontSize = 1.0F;
            Color fontColor = new Color(255, 255, 255);
            Color backgroundColor = new Color(0, 0, 0);

            //=======================================================================
            foreach (IMyTextPanel textPanel in taggedTextPanelList)
            {
                if (textPanel.CustomName.Contains(tag))
                {
                    textPanel.CustomName = name;
                    textPanel.SetValue("FontSize", fontSize);
                    textPanel.SetValue("FontColor", fontColor);
                    textPanel.SetValue("BackgroundColor", backgroundColor);
                    textPanel.WritePublicText(publicText);
                    textPanel.ShowPublicTextOnScreen();
                }
            }
        }

        public void InventoryQuota()
        {
            string partialTag = "INVENTORY";
            string tag = prefix + " " + partialTag + postfix;
            string publicText = "Profile: TIM QUOTA";
            string name = "LCD Inventory [TIM QUOTA] [Yusukee_LCD INVENTORY]";
            float fontSize = 1.0F;
            Color fontColor = new Color(255, 255, 255);
            Color backgroundColor = new Color(0, 0, 0);

            //=======================================================================
            foreach (IMyTextPanel textPanel in taggedTextPanelList)
            {
                if (textPanel.CustomName.Contains(tag))
                {
                    textPanel.CustomName = name;
                    textPanel.SetValue("FontSize", fontSize);
                    textPanel.SetValue("FontColor", fontColor);
                    textPanel.SetValue("BackgroundColor", backgroundColor);
                    textPanel.WritePublicText(publicText);
                    textPanel.ShowPublicTextOnScreen();
                }
            }
        }

        public List<IMyTextPanel> getTaggedTextPanels(List<IMyTextPanel> allTextPanel)
        {
            List<IMyTextPanel> result = new List<IMyTextPanel>();
            foreach (IMyTextPanel textPanel in allTextPanel)
            {
                if (textPanel.CustomName.Contains(prefix)) 
                {
                    result.Add(textPanel);
                }   
            }

            return result;
        }
    }
}
