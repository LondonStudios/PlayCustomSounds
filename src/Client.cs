using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;

namespace Client
{
    public class Main : BaseScript
    {
        public Main()
        {
            EventHandlers["Client:SoundToClient"] += new Action<string, float>(SoundToClient);
            EventHandlers["Client:SoundToAll"] += new Action<string, float>(SoundToAll);
            EventHandlers["Client:SoundToRadius"] += new Action<int, float, string, float>(SoundToRadius);
            EventHandlers["Client:SoundToCoords"] += new Action<float, float, float, float, string, float>(SoundToCoords);
        }

        private void SoundToClient(string soundFile, float soundVolume)
        {
            SendNuiMessage(string.Format("{{\"submissionType\":\"sendSound\", \"submissionVolume\":{0}, \"submissionFile\":\"{1}\"}}", (object)soundVolume, (object)soundFile));
        }

        private void SoundToAll(string soundFile, float soundVolume)
        {
            SendNuiMessage(string.Format("{{\"submissionType\":\"sendSound\", \"submissionVolume\":{0}, \"submissionFile\":\"{1}\"}}", (object)soundVolume, (object)soundFile));
        }

        private void SoundToRadius(int networkId, float soundRadius, string soundFile, float soundVolume)
        {
            Vector3 playerCoords = Game.Player.Character.Position;
            Vector3 targetCoords = GetEntityCoords(NetworkGetEntityFromNetworkId(networkId), true);
            var distance = Vdist(playerCoords.X, playerCoords.Y, playerCoords.Z, targetCoords.X, targetCoords.Y, targetCoords.Z);
            float distanceVolumeMultiplier = (soundVolume / soundRadius);
            float distanceVolume = soundVolume - (distance * distanceVolumeMultiplier);
            if (distance <= soundRadius)
            {
                SendNuiMessage(string.Format("{{\"submissionType\":\"sendSound\", \"submissionVolume\":{0}, \"submissionFile\":\"{1}\"}}", (object)distanceVolume, (object)soundFile));
            }

        }

        private void SoundToCoords(float positionX, float positionY, float positionZ, float soundRadius, string soundFile, float soundVolume)
        {
            Vector3 playerCoords = Game.Player.Character.Position;
            var compare = Vdist(playerCoords.X, playerCoords.Y, playerCoords.Z, positionX, positionY, positionZ);
            float distanceVolumeMultiplier = (soundVolume / soundRadius);
            float distanceVolume = soundVolume - (compare * distanceVolumeMultiplier);
            if (compare <= soundRadius)
            {
                SendNuiMessage(string.Format("{{\"submissionType\":\"sendSound\", \"submissionVolume\":{0}, \"submissionFile\":\"{1}\"}}", (object)distanceVolume, (object)soundFile));
            }
        }

        /*  © 2020 - London Studios - Do not modify/change source code obtained permission. 
            This may be used on public/private FiveM servers and used in videos published to websites, 
            This is for non-commercial use. */
    }
}
