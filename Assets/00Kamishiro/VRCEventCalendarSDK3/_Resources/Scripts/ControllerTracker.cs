/*
* Copyright (c) 2021 AoiKamishiro
* 
* This code is provided under the MIT license.
* 
*/

#if VRC_SDK_VRCSDK3

using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace Kamishiro.VRChatUDON.VRChatEventCalendar.SDK3
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class ControllerTracker : UdonSharpBehaviour
    {
        private VRCPlayerApi _lp;
        public VRCPlayerApi.TrackingDataType _trackingData = VRCPlayerApi.TrackingDataType.Head;
        public VRC_Pickup.PickupHand _hapticHand = VRC_Pickup.PickupHand.None;

        private void OnEnable()
        {
            _lp = Networking.LocalPlayer;
        }
        private void Update()
        {
            transform.position = _lp.GetTrackingData(_trackingData).position;
        }
        public void _PlayHaptic()
        {
            _lp.PlayHapticEventInHand(_hapticHand, 1.0f, 0.5f, 0.5f);
        }
    }
}
#endif