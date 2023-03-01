#!/bin/bash
wine ./bin/Release/net7.0/Telegram.exe &
wine ./bin/Release/net7.0/Discord.exe &
wait
