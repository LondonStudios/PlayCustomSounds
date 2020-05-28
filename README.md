![PlayCustomSounds Banner](https://i.ibb.co/wCVs2YR/Play-Custom-Sounds-Banner-jpg-3267.png)

# Play Custom Sounds - London Studios

**PlayCustomSounds** is a standalone C# FiveM Resource allowing you to play **external sounds** in your FiveM server from other resources and scripts. Four main functions:

**1.**  Play sounds to all players
    
**2.**  Play sounds to a specified player
    
**3.**  Play sounds to a specified player and all players in a certain radius, including a reduction in volume the further away you are.
    
**4.**  Play sounds to a set 3D coordinate, and all players in a radius, including a volume reduction the further away you are.

This resource works by the triggering of **ServerEvents** from external scripts, the possibilities are endless, you may choose to play a sound upon a player entering a vehicle, or even play sounds in a certain area of the map such as a custom fire alarm or sound. This is similar to a Lua plugin for external sounds, however this version has more functionality.

  

Please use the documentation below on how to install and use this in your resources. You may call these external ServerEvents from any FiveM supported language. Any bugs or feedback is greatly appreciated in the thread and we will support any queries with installations or those requiring assistance.

  

# 1. Installation

    

Any external resources triggering **ServerEvents** handled by this resource (**playCustomSounds**) will require the server to have this installed. The installation comes with a FiveM-Ready “fxmanifest.lua” file. This should be placed in the server resources file, and ensure you start “playcustomsounds” in server.cfg.

**IMPORTANT:** The resource name must remain lowercase, this is due to an interaction with the FiveM NUI function requiring this for DNS purposes.

  
  

## 2. Installing custom sounds

    

All custom sounds must be in the **“.ogg”** format. Online converters can be used to format files this way. Place all custom sounds in the **“html/sounds/”** folder in the **"playcustomsounds"** resource folder.


## 3. Triggering Custom Sounds


After the **PlayCustomSounds** resource is on the server, you will have the ability to **TriggerServerEvents** from any other resource, including ones you create.

These are all Server Events, and triggered from a Client resource file.

(examples, client.lua or Client.net.dll)

  

**NOTES:**

- The specified volume must be at a maximum of 1.0 and must be as a float value.

- The specified sound file to play must not include .ogg, this is automatically added!

- The dynamic volume (further away you are), is automatic but requires a base volume.

- The distance (or radius) is a float value, it is worth testing this out in-game

  

## Play sound to all players - “Server:SoundToAll”

Play a sound to all players on the server

**Format:**

    TriggerServerEvent(“Server:SoundToAll”, soundFile, soundVolume);

soundFile = String, soundVolume = Float

  

**Example:**

    TriggerServerEvent(“Server:SoundToAll”, “example”, 1.0f);

This would play the “example.ogg” sound at Volume 1.0 to all players.

(Note: The f after 1.0 is used in C# programming to declare a float.)


## Play sound to client - “Server:SoundToClient”

Play a sound to a specified client based on NetworkID. (Not other players nearby)

**Format:**

    TriggerServerEvent(“Server:SoundToClient”, networkId, soundFile, soundVolume);

networkId = Specified Player, soundFile = String, soundVolume = Float

**Example:**

    TriggerServerEvent(“Server:SoundToClient”, networkId, “example”, 1.0f);

This would play the “example.ogg” sound at Volume 1.0 to the player with “networkId”.

(Note: The f after 1.0 is used in C# programming to declare a float.)
 

## Play sound to player and radius - “Server:SoundToRadius”

Play a sound to the specified player based on NetworkID and all players in a specified radius to the player, reducing the volume based on distance from the player.

**Format:**

    TriggerServerEvent(“Server:SoundToRadius”, networkId, soundRadius, soundFile, soundVolume”);

networkId = Specified Player, soundRadius = Float, soundFile = String, soundVolume = Float

**Example:**

    TriggerServerEvent(“Server:SoundToRadius”, networkId, 20.0f, “example”, 1.0f);

(Note: The f after 1.0 is used in C# programming to declare a float.)

This would play the “example.ogg” sound at Volume 1.0 to the player with “networkId” and all players in a 20.0 float radius, reducing the volume based on distance.

## Play sound to coords and radius - “Server:SoundToCoords”

Play a sound to the specified coordinates (3D) and all players in a specified radius, reducing the volume based on distance from the coordinates.

**Format:**

    TriggerServerEvent(“Server:SoundToCoords”, positionX, positionY, positionZ, soundRadius, soundFile, soundVolume);

positionX, positionY, positionZ = Floats, soundRadius = Float, soundFile = String, soundVolume = Float.

**Example:**

    TriggerServerEvent(“Server:SoundToCoords”, positionX, positionY, positionZ, 20.0f, “example”, 1.0f);

(Note: The f after 1.0 is used in C# programming to declare a float.)

This would play the “example.ogg” sound at the specified coordinates at volume 1.0 and all players in a 20.0 float radius, reducing the volume based on distance.

  

One way these coordinates can be declared prior is through the use of Vector3, a FiveM Native Function, you can then enter positionX, positionY and positionZ as parameters.

## Licence Information

  

© 2020 - London Studios

This plugin may be freely distributed however the source code should not be modified or changed without obtained permission from London Studios.

Credit must be given when redistributing or using as part of external resources.
