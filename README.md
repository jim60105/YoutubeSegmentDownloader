# Youtube Segment Downloader

## What's this?

A lifesaver for anyone who is doing video clipping/translating or any need to download segments from Youtube.

[![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/jim60105/YoutubeSegmentDownloader?style=for-the-badge)](https://github.com/jim60105/YoutubeSegmentDownloader/releases/latest)
![GitHub Release Date](https://img.shields.io/github/release-date/jim60105/YoutubeSegmentDownloader?style=for-the-badge)
![GitHub all releases](https://img.shields.io/github/downloads/jim60105/YoutubeSegmentDownloader/total?style=for-the-badge)

![Preview](assets/preview.png)

![Windows](https://img.shields.io/static/v1?style=for-the-badge&message=WinForm&color=0078D6&logo=Windows&logoColor=FFFFFF&label=)
![.NET 8.0](https://img.shields.io/static/v1?style=for-the-badge&message=.NET+8.0&color=512BD4&logo=.NET&logoColor=FFFFFF&label=)
![GitHub](https://img.shields.io/github/license/jim60105/YoutubeSegmentDownloader?style=for-the-badge)
> The software can only be run on Windows x64 platforms.

## Feature

**Download Youtube video in segment**\
In detail, you can download only one segment in the middle of the video instead of downloading the whole video.

**This software is built on yt-dlp and FFmpeg.**\
If you don't have them installed, this software will download them automatically at startup.

**Can accept Youtube clips too!**\
Try to put this in the Youtube Link textbox: [https://youtube.com/clip/UgkxdTb9o6I2pTr87wKgpO0kLEaZbYrkMDFv](https://youtube.com/clip/UgkxdTb9o6I2pTr87wKgpO0kLEaZbYrkMDFv)\
It will be converted to id, start, and end time immediately.

**Use the Youtube login status in your browser.**\
Select your login browser and download the membership video/your private video.

**The output video format conforms to the Youtube recommendation for uploading!**\
[Recommended upload encoding settings - YouTube Help](https://support.google.com/youtube/answer/1722171/)

**The download format can be specified.**\
Input [the format](https://github.com/yt-dlp/yt-dlp#format-selection) such as `303+251`
> Note: The video will be downloaded in this format and will ALWAYS be re-encoded to mp4 format.\
> Re-encoded is needed after cutting the video. Please read the details below.

**I18n 多國語系**\
我做了中文介面\
I only speak Chinese. Give me PR if you make more languages!

**It can accept any yt-dlp supported site.**\
I only support Youtube, but this application can theoretically be used on [any site supported by yt-dlp](https://github.com/yt-dlp/yt-dlp/blob/master/supportedsites.md).\
The actual situation depends on the video format and whether ffmpeg can index it correctly, but it's still worth a try.\
For reference, I have had success with Youtube, Twitch, and niconico.

## Install

Get the latest release
[![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/jim60105/YoutubeSegmentDownloader?style=for-the-badge)](https://github.com/jim60105/YoutubeSegmentDownloader/releases/latest)

Please download and install with the *setup.exe*

- Automatically check for upgrades when launching this software
  ![update](assets/update.png)
- Setup installer will install **.NET 8.0** Runtime for you
- Setting shortcuts on the Desktop and Start Up Menu

Or you can just download *YoutubeSegmentDownloader.exe*, if you don't care about the above.

## Why not just use yt-dlp with ffmpeg `-ss -to`?

Nope, not enough.

According to [FFmpeg docs](https://ffmpeg.org/ffmpeg.html#toc-Main-options) about `-ss`:
> Note that in most formats it is not possible to seek exactly, so ffmpeg will seek to the closest seek point *before* position. When transcoding and `-accurate_seek` is enabled (the default), this extra segment between the seek point and position will be decoded and discarded. When doing stream copy or when `-noaccurate_seek` is used, it will be preserved.

Then the download is actually a streaming copy, so you won't get an accurate cut of it.

For example, downloading [this video](https://youtu.be/89kXyUCenD0) from 230s ~ 250s

```bash
yt-dlp --downloader ffmpeg --downloader-args "ffmpeg_i:-ss 230 -to 250" 89kXyUCenD0 
```

> yt-dlp `--download-sections "*230-250"` is actually equivalent to `--downloader ffmpeg --downloader-args "ffmpeg_i:-ss 230 -t 20"` [*ref](https://github.com/yt-dlp/yt-dlp/commit/5ec1b6b71689d2f0cbdcd2b6c4dd861fb2fcf911#diff-045340cd706a52a49d1614a44d092c244144486fdd4101f4b56ae644ac9fdd04R452-R455)

would result in a video duration of 29.98 seconds, with the first 7 seconds being corrupted. This is *inaccurate* by, well, about 10 seconds. This is because the last seek point is around 220s, so it cuts off 220s ~ 250s.

To solve this, use ffmpeg to seek it again *with transcoding*.

```bash
ffmpeg -sseof -20 -i just_downloaded.webm good.webm
```

> `-sseof` likes the `-ss` option but relative to the "end of file".

So, you have to do two steps, plus a simple math calculation. It's not that much of a hassle, but it's enough to get a lazy programmer move.

## LICENSE

> [!NOTE]  
> This software uses **FFmpeg** licensed under the **GPLv3**.  
> FFmpeg binary distributions will be downloaded from [here](https://github.com/yt-dlp/FFmpeg-Builds/releases/latest).  
> FFmpeg source code can be found [here](https://github.com/FFmpeg/FFmpeg/commit/390d6853d0).
>
> This software uses **yt-dlp** licensed under the **Unlicense License**.  
> yt-dlp binary distribution will be downloaded from [here](https://github.com/yt-dlp/yt-dlp/releases/latest).
> 
> This software uses **Xabe.FFmpeg** licensed under the [License Agreement](https://ffmpeg.xabe.net/license.html) with **Non-commercial use** - Attribution-NonCommercial-ShareAlike 3.0 Unported (CC BY-NC-SA 3.0).
> 
> This software uses **Beautiful Flat Icons** licensed under the **GPLv2**.  
> Icon source can be found [here](https://www.elegantthemes.com/blog/freebie-of-the-week/beautiful-flat-icons-for-free).

<img src="https://github.com/jim60105/YoutubeSegmentDownloader/assets/16995691/05e722a2-c531-452d-b7df-295139431195" alt="gpl" width="300" />

[GNU GENERAL PUBLIC LICENSE Version 3](LICENSE)

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program. If not, see <https://www.gnu.org/licenses/>.

---

> A winform project written in .NET ~~6~~ ~~7~~ 8 and CI/CD the ClickOnce installer on the github workflow.\
> I think I'll stop it at .NET 8 since it's LTS.\
> Anyone want to turn it into MAUI? ¯\\\_(ツ)_/¯
