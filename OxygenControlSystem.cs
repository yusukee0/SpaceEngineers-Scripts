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

namespace SpaceEngineers
{
    public sealed class OxygenControlSystem : MyGridProgram
    {
        //=======================================================================
        //////////////////////////BEGIN//////////////////////////////////////////
        //=======================================================================
        const int iTankOxygen = 1;
        const int iTankHydro = 2;
        List<IMyGasTank> tankList;
        List<IMyGasGenerator> generatorList;
        List<IMyAirVent> airVentList;

        //Constructor !!!!! Rename to public Program() in-game !!!!!
        public OxygenControlSystem()
        {
            // Get the list of gas tanks
            tankList = new List<IMyGasTank>();
            GridTerminalSystem.GetBlocksOfType<IMyGasTank>(tankList);

            // Get the list of Oxygen generators
            generatorList = new List<IMyGasGenerator>();
            GridTerminalSystem.GetBlocksOfType<IMyGasGenerator>(generatorList);

            // Get the list of Air vents
            airVentList = new List<IMyAirVent>();
            GridTerminalSystem.GetBlocksOfType<IMyAirVent>(airVentList);

            Echo("Compiled Successculy!");
        }

        public void Main(string argument)
        {
            // Oxygen generator ON / OFF at 99% / 90%
            double gasRate = getTankFillPercentage();
            ControlOxygenGenerators(gasRate);

            ControlAirVents();
        }

        private void ControlAirVents()
        {
            for (int i = 0; i < airVentList.Count; i++)
            {
                if (airVentList[i].GetOxygenLevel() < 0.8)
                {
                    airVentList[i].ApplyAction("OnOff_On");
                } else if (airVentList[i].GetOxygenLevel() > 0.99)
                {
                    airVentList[i].ApplyAction("OnOff_Off");
                }
            }
        }

        private void ControlOxygenGenerators(double gasRate)
        {
            if (gasRate < 90.0)
            {
                for (int i = 0; i < generatorList.Count; i++)
                {
                    generatorList[i].ApplyAction("OnOff_On");
                }
            }
            else if (gasRate > 99.0)
            {
                for (int i = 0; i < generatorList.Count; i++)
                {
                    generatorList[i].ApplyAction("OnOff_Off");
                }
            }
        }

        private double getTankFillPercentage()
        {
            double totalLevel = 0;
            int iTankCount = 0;

            for (int i = 0; i < tankList.Count; ++i)
            {
                IMyGasTank tank = tankList[i];
                float tankLevel = tank.FilledRatio;
                totalLevel += tankLevel;
                iTankCount++;
            }

            if (iTankCount > 0)
            {
                return (totalLevel / iTankCount) * 100;
            }
            else
            {
                return -1;
            }
        }

        //=======================================================================
        //////////////////////////END////////////////////////////////////////////
        //=======================================================================
    }
}
