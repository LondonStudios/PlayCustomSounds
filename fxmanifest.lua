fx_version 'bodacious'
game 'gta5'

author 'London Studios'
description 'PlayCustomSounds'
version '1.0.0'

client_script 'Client.net.dll'
server_script 'Server.net.dll'

ui_page 'html/index.html'

files {
    'html/index.html',
    
    -- Sound files must be in html/sounds/
    -- Sound files must be in .ogg format
    'html/sounds/*.ogg'
}
