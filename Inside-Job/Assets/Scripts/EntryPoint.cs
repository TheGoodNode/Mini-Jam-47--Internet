using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace EntryPointscs
{
    public class EntryPoint : MonoBehaviour
    {

        [System.Serializable]
        public enum EntryPointType { request, response }

        public EntryPointType entryPointType;

        PlayerControlcs.PlayerControls player;

        void Start()
        {

        }

        void HandleEntryPoint()
        {
            switch (entryPointType)
            {
                case EntryPointType.request:
                    //should give player a request
                    Debug.Log("give player a request");
                    break;

                case EntryPointType.response:
                    //should give a player a request
                    Debug.Log("give plauer response");
                    break;

                default:
                    break;
            }
        }
    }
}



