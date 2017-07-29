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
    public sealed class _Template : MyGridProgram // interface
    {
        //=======================================================================
        //////////////////////////BEGIN//////////////////////////////////////////
        //=======================================================================

        /* Constructor
        public Program()
        {
            // The constructor, called only once every session and
            // always before any other method is called. Use it to
            // initialize your script.
        }
        */

        public void Main(string args)
        {
            IMyTextPanel panel;
            
            // The main entry point of the script, invoked every time
            // one of the programmable block's Run actions are invoked.

            // The method itself is required, but the argument above
            // can be removed if not needed.
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