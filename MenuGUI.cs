using BepInEx;
using GorillaNetworking;
using Photon.Pun;
using StupidTemplate.Classes;
using StupidTemplate.Menu;
using StupidTemplate.Patches;
using System;
using static StupidTemplate.Menu.Main;
using UnityEngine;
using StupidTemplate.Mods;
using Facebook.WitAi.Utilities;

namespace yourname.UI
{
    [BepInPlugin("org.urname.gui", "put whatever u want here", "1.0.0")] // this is customizable
    public class Main : BaseUnityPlugin
    {
        private string inputText = "input something here";

        private string r = "0";

        private string g = "128";

        private string b = "142";

        public static bool isOpen = false;

        public static bool lastCondition = false;

        public static bool modbox;

        public static bool wasdcool;

        public static float aaaaaa = 0f;

        public static string togglebuttontext = "+";

        private Color guicolor = Color.red;

        private Rect rectstuff = new Rect(60, 20, 500, 500);
        private int numpage;
        private Color color1;
        private Color color2;

        void Update() // for RGB
        {
            float r = Mathf.Abs(Mathf.Sin(aaaaaa * 0.4f));
            float g = Mathf.Abs(Mathf.Sin(aaaaaa * 0.5f));
            float b = Mathf.Abs(Mathf.Sin(aaaaaa * 0.6f));
            guicolor = new Color(r, g, b);
            aaaaaa += Time.deltaTime;
        }
        public void Start() // helps the rgb idk
        {
            ColorUtility.TryParseHtmlString("ffc1cc", out color1); 
            ColorUtility.TryParseHtmlString("98FF98", out color2);
        }
        private void OnGUI() // the toggle button for the gui, dont rlly mess with this unless you know what ur doing
        {
            if (GUI.Button(new Rect(20, 0, 20, 20), togglebuttontext))
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
                }
            }
            if (isOpen)
            {
                rectstuff = GUI.Window(10000, rectstuff, MainGUI, "Bludclient GUI");
            }
        }
        /*
         collumn 1 x: 20
         collumn 2 x: 200
         change y by 30 every new button <- USE THESE! THESE ARE FOR MAKING YOUR BUTTONS
        */
        void MainGUI(int windowID)
        {
            GUI.color = guicolor;
            GUI.backgroundColor = guicolor;
            GUI.contentColor = guicolor;
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
                    break;
            }
        }
    }
}
