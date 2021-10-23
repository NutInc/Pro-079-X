using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using UnityEngine;

namespace Pro079XGenerators
{
    public class MapUtils
    {
        public static void LockAllDoors()
        {
            foreach (Door door in Map.Doors)
            {
                door.IsOpen = false;
                door.ChangeLock(DoorLockType.Regular079);
            }
        }

        public static void TurnOffAllLights(float duration)
        {
            foreach (FlickerableLightController controller in FlickerableLightController.Instances)
            {
                Room room = controller.GetComponentInParent<Room>();
                controller.ServerFlickerLights(duration);
            }
        }
        
        public static void UnlockAllDoors()
        {
            foreach (Door door in Map.Doors)
                door.ChangeLock(DoorLockType.None);
        }
    }
}