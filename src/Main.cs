using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;

namespace Server
{
    public class Main : BaseScript
    {
        public Main()
        {
            EventHandlers["Server:SoundToClient"] += new Action<int, string, float>(ServerSoundToClient);
            EventHandlers["Server:SoundToAll"] += new Action<string, float>(ServerSoundToAll);
            EventHandlers["Server:SoundToRadius"] += new Action<int, float, string, float>(ServerSoundToRadius);
            EventHandlers["Server:SoundToCoords"] += new Action<float, float, float, float, string, float>(ServerSoundToCoords);
        }

        private void ServerSoundToClient(int netId, string soundFile, float soundVolume)
        {
            Player plyr = new PlayerList()[netId];
            plyr.TriggerEvent("Client:SoundToClient", soundFile, soundVolume);
        }

        private void ServerSoundToAll (string soundFile, float soundVolume)
        {
            TriggerClientEvent("Client:SoundToAll", soundFile, soundVolume);
        }

        private void ServerSoundToRadius(int netid, float soundRadius, string soundFile, float soundVolume)
        {
            TriggerClientEvent("Client:SoundToRadius", netid, soundRadius, soundFile, soundVolume);
        }

        private void ServerSoundToCoords(float positionX, float positionY, float positionZ, float soundRadius, string soundFile, float soundVolume)
        {
            TriggerClientEvent("Client:SoundToCoords", positionX, positionY, positionZ, soundRadius, soundFile, soundVolume);
        }

        /*  © 2020 - London Studios - Do not modify/change source code obtained permission. 
            This may be used on public/private FiveM servers and used in videos published to websites, 
            This is for non-commercial use. */
    }
}
