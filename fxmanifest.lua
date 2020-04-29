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
    -- List sound files:
    -- Files must be in html/sounds/
    -- Files must be in .ogg format
    -- Remember to add a comma after,
    'html/sounds/example.ogg'
}
