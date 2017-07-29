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
    class GravityDrive : MyGridProgram
    {

        //=======================================================================
        //////////////////////////BEGIN//////////////////////////////////////////
        //=======================================================================

        /*
         * 
         * Moving forward: Use direction=forward argument 
         * Moving backward: Use direction=backward argument
         * Stop gravity drive: Use default (empty) argument. (This WON'T stop the ship)
         */

        //Tag in gravity generators name
        const string gravityDriveGeneratorTag = "[Gravity Drive]";
        //forward gravity force. Depends on the orientation of the gravity generator
        const float forwardGravity = 9.8f;
        //forward gravity force. Depends on the orientation of the gravity generator
        const float backwardGravity = -9.8f;

        List<IMyGravityGenerator> driveGravityGeneratorList;
        List<IMyGravityGenerator> normalGravityGeneratorList;
        List<IMyArtificialMassBlock> artificialMassList;
        IMyCockpit mainCockpit;

        //Constructor !!!!! Rename to public Program() in-game !!!!!
        public GravityDrive()
        {
            List<IMyCockpit> cockpitList = new List<IMyCockpit>();
            GridTerminalSystem.GetBlocksOfType<IMyCockpit>(cockpitList);

            foreach (IMyCockpit cockpit in cockpitList)
            {
                if (cockpit.IsMainCockpit)
                {
                    mainCockpit = cockpit;
                    break;
                }
            }

            List<IMyGravityGenerator> allGravityGeneratorList = new List<IMyGravityGenerator>();
            GridTerminalSystem.GetBlocksOfType<IMyGravityGenerator>(allGravityGeneratorList);

            artificialMassList = new List<IMyArtificialMassBlock>();
            GridTerminalSystem.GetBlocksOfType<IMyArtificialMassBlock>(artificialMassList);

            driveGravityGeneratorList = new List<IMyGravityGenerator>();
            normalGravityGeneratorList = new List<IMyGravityGenerator>();
            foreach (IMyGravityGenerator generator in allGravityGeneratorList)
            {
                if (generator.CustomName.Contains(gravityDriveGeneratorTag))
                {
                    driveGravityGeneratorList.Add(generator);
                } else
                {
                    normalGravityGeneratorList.Add(generator);
                }
            }

            try
            {
                foreach (IMyGravityGenerator generator in driveGravityGeneratorList)
                {
                    generator.ApplyAction("OnOff_Off");
                }
            } catch
            {
                Echo("Cannot find gravity generator with tag " + gravityDriveGeneratorTag);
            }

            turnOffArtificialMass();

            Echo("Compiled Successfuly. \nGravity Drive Components:\nGravity generators: " + driveGravityGeneratorList.Count + ", Masses: " + artificialMassList.Count);
        }
        

        public void Main(string args)
        {
            switch (args)
            {
                case "direction=forward":
                    forward();
                    break;
                case "direction=backward":
                    backward();
                    break;
                default:
                    stopGravityDrive();
                    break;
            }
        }

        private void forward()
        {
            turnOffInertiaDampener();
            turnOffNormalGravity();
            turnOnDriveGravity(forwardGravity);
            turnOnArtificialMass();
        }

        private void backward()
        {
            turnOffInertiaDampener();
            turnOffNormalGravity();
            turnOnDriveGravity(backwardGravity);
            turnOnArtificialMass();
        }

        private void stopGravityDrive()
        {
            turnOffArtificialMass();
            turnOffDriveGravity();
            turnOnInertiaDampener();
            turnOnNormalGravity();
        }

        private void turnOffInertiaDampener()
        {
            mainCockpit.DampenersOverride = false;
        }

        private void turnOnInertiaDampener()
        {
            mainCockpit.DampenersOverride = true;
        }

        private void turnOnDriveGravity(float acceleration)
        {
            foreach (IMyGravityGenerator generator in driveGravityGeneratorList)
            {
                generator.GravityAcceleration = acceleration;
                generator.ApplyAction("OnOff_On");
            }
        }

        private void turnOffDriveGravity()
        {
            foreach (IMyGravityGenerator generator in driveGravityGeneratorList)
            {
                generator.GravityAcceleration = 0.0f;
                generator.ApplyAction("OnOff_Off");
            }
        }

        private void turnOffArtificialMass()
        {
            foreach (IMyArtificialMassBlock mass in artificialMassList)
            {
                mass.ApplyAction("OnOff_Off");
            }
        }

        private void turnOnArtificialMass()
        {
            foreach (IMyArtificialMassBlock mass in artificialMassList)
            {
                mass.ApplyAction("OnOff_On");
            }
        }

        private void turnOffNormalGravity()
        {
            foreach (IMyGravityGenerator generator in normalGravityGeneratorList)
            {
                generator.ApplyAction("OnOff_Off");
            }
        }

        private void turnOnNormalGravity()
        {
            foreach (IMyGravityGenerator generator in normalGravityGeneratorList)
            {
                generator.ApplyAction("OnOff_On");
            }
        }
        public void Save()
        {
            // Called when the program needs to save its state. Use
            // this method to save your state to the Storage field
            // or some other means.

            // This method is optional and can be removed if not
            // needed.
        }

        //=======================================================================
        //////////////////////////END////////////////////////////////////////////
        //=======================================================================

    }
}
