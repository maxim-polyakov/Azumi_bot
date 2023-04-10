#!/bin/bash
./Front_layer/Discord_bot/bin/Release/net7.0/ubuntu.22.10-x64/Discord_bot &
./Front_layer/Telegram_bot/bin/Release/net7.0/ubuntu.22.10-x64/Telegram_bot &
wait
