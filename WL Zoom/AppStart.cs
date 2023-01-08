using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WorldLoader.Attributes;
using WorldLoader.Mods;

namespace Zoom
{
    [Mod("Zoom", "1.0", "Cyconi")]
    public class AppStart : UnityMod
    {
        public static UnityMod classInst { get; private set; }
        public static Harmony harmInst { get; private set; }

        public static GameObject quickMenu;
        internal float zoomFov = 20;        
        public override void OnInject()
        {
            classInst = this;
            harmInst = harmonyInstance;
            Console.WriteLine("");
            Con.Log("[=========================-  Zoom  -==========================]");
            Con.Log("[========================= KeyBinds ==========================]");
            Con.Log("[                                                             ]");
            Con.Log("[               Zoom Camera   =   Mouse5 (Side Mouse)         ]");
            Con.Log("[                Reset Zoom   =   Middle Mouse                ]");
            Con.Log("[             Zoom In / Out   =   Scroll Wheel                ]");
            Con.Log("[                                                             ]");
            Con.Log("[========================= KeyBinds ==========================]");
            Con.Log("[=========================-  Zoom  -==========================]");
            Console.WriteLine("");
        }

        public override void OnUpdate()
        {
            //Log("FOV = " + Camera.main.fieldOfView.ToString());

            if (zoomFov < 5f)
                zoomFov = 5f;
            if (Camera.main.fieldOfView < 5f)
                Camera.main.fieldOfView = 5f;
            if (zoomFov > 140f)
                zoomFov = 140f;
            if (Camera.main.fieldOfView > 140f)
                Camera.main.fieldOfView = 140f;

            if (Input.GetKey(KeyCode.Mouse2))
                zoomFov = 20;
            //if (Input.GetKey(KeyCode.Mouse3))
                //Camera.main.fieldOfView = 60;

            try
            {
                if (Input.GetKey(KeyCode.Mouse4))
                {
                    float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
                    if (mouseWheel > 0.1)
                        zoomFov -= 5f;
                    else if (mouseWheel < -0.1)
                        zoomFov += 5f;

                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomFov, Time.deltaTime * 10f);
                    VRCPlayer.field_Internal_Static_VRCPlayer_0.GetComponent<LocomotionInputController>().field_Protected_MonoBehaviourPublicObSiBoSiVeBoQuVeBoSiUnique_0.field_Public_Single_1 = 0.05f; // NeckMouseRotator
                    return;
                }

                if (!Input.GetKey(KeyCode.Mouse4))
                {
                    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60f, Time.deltaTime * 10f);
                    VRCPlayer.field_Internal_Static_VRCPlayer_0.GetComponent<LocomotionInputController>().field_Protected_MonoBehaviourPublicObSiBoSiVeBoQuVeBoSiUnique_0.field_Public_Single_1 = 0.05f; // NeckMouseRotator
                }
            } catch { }
        }
    }
}
