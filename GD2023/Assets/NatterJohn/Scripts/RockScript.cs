using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

internal class RockScript : MonoBehaviour
{
    CharacterMovementScript harvesterJammo;

    internal void ImHarvestingYou(MoveJammo harvesterJammo)
    {
        print("Yikes I'm being harvested");
    }

    private void print(string v)
    {
        throw new NotImplementedException();
    }
}