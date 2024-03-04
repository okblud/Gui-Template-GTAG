using BepInEx;
using GorillaNetworking;
using Photon.Pun;
using StupidTemplate.Classes;
using StupidTemplate.Menu;
using StupidTemplate.Patches;
using System;
using static StupidTemplate.Menu.Main;
using UnityEngine;
using StupidTemplate.Mods; // i used ii's temp, but change these references as needed.

namespace yourmenuname.UI
{
    [BepInPlugin("org.yourname.gui", "Your Name's GUI", "1.0.0")] // feel free to change this to whatever you desire
    public class Main : BaseUnityPlugin
    {
        private string inputText = "input something here";

        private string r = "0";

        private string g = "128";

        private string b = "142";

        public static bool isOpen = false;

        public static bool lastCondition = false;

        public static bool modbox;

        public static string togglebuttontext = "+";

        private Rect rectstuff = new Rect(60, 20, 500, 500);
        
        private int numpage;

        private void OnGUI() // dont mess with this too much unless you know what your doing
        {
            if (GUI.Button(new Rect(20, 0, 50, 20), togglebuttontext)) // toggle button for the gui
            {
                if (isOpen == false)
                {
                    togglebuttontext = "-";
                    isOpen = true;
                }
                else
                {
                    togglebuttontext = "+";
                    isOpen = false;
                } // button text
            }
            if (isOpen)
            {
                rectstuff = GUI.Window(10000, rectstuff, MainGUI, "Bludclient GUI");
            }
        }
        /*
         collumn 1 x: 20
         collumn 2 x: 200
         change y by 30 every new button
         USE THIS!! this will help organize your buttons for your gui.
        */
        void MainGUI(int windowID)
        {
            GUI.contentColor = Color.white;
            GUI.backgroundColor = Color.blue;
            inputText = GUI.TextArea(new Rect(20, 50, 100, 20), inputText);
            int page = numpage + 1; 
            GUI.Label(new Rect(230, 20, 200, 20), "Page: " + page);
            switch (numpage)
            {
                case 0: // page 1

                    if (GUI.Button(new Rect(20, 80, 100, 20), "Join Room"))
                    {
                        PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(inputText);
                    }
                    // add other buttons here
                    if (GUI.Button(new Rect(0, 450, 500, 20), ">>>>>>>>>")) //forward 
                    {
                        numpage++;
                    }

                    break;

                case 1: // page 2

                    if (GUI.Button(new Rect(20, 80, 100, 20), "Placeholder"))
                    {

                    }
                    if (GUI.Button(new Rect(0, 450, 500, 20), ">>>>>>>>>")) //forward 
                    {
                        numpage++;
                    }

                    if (GUI.Button(new Rect(0, 470, 500, 20), "<<<<<<<<<")) //backward 
                    {
                        numpage--;
                    }
                    break; // keep adding cases and breaks for different pages
            }
        }
    }
}
