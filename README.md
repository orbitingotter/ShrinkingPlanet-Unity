# ShrinkingPlanet - Unity
A game inspired from [Brackeys LD38 submission](https://www.youtube.com/watch?v=XldCg9sQYx0) in Unity Engine. It is currently supported on x64 Windows and Android.

## What is the game?

You are stuck in an alternative universe where the planet is shrinking and you have to survive as long as possible, avoiding the meteors and crater in the process.

## Gameplay

![SP-windows-gif](https://user-images.githubusercontent.com/112700146/235308070-572f8230-e6c8-4546-bab7-983a6f73fc0e.gif)

Youtube Link (with audio)-

[![Shrinking Planet Gameplay](https://img.youtube.com/vi/1JAc29utN0A/0.jpg)](https://www.youtube.com/watch?v=1JAc29utN0A)

## How can i play?

1. **Windows** - Download the Windows x64 version in the Releases page, unzip it and play .
2. **Android** - Download the apk in the Releases page. Allow your browser to install apps. If you get Play Protect warning, click on more details and "Install anyway", after lauching the app, if a prompt appears click "Don't Send".

**Latest Version Download** -

Release Page - [v1.0.2](https://github.com/orbitingotter/ShrinkingPlanet-Unity/releases/tag/v1.0.2)

Windows - [v1.0.2](https://github.com/orbitingotter/ShrinkingPlanet-Unity/releases/download/v1.0.2/windows-x64-SP-1.0.2.zip)

Android - [v1.0.2](https://github.com/orbitingotter/ShrinkingPlanet-Unity/releases/download/v1.0.2/android-SP-v1.0.2.apk)

Note - For android, change settings to low if fps is too low.

For other platforms, like iOS and Linux, i cannot play test or compile it, feel free to clone and compile.

## Bug Report & Features
If you have found any bugs or have suggestions, open up a issue on the repo with info - platform, optional video, reproduction steps.

Some features i have planned for future -
* Improved optimisation for android
* Save-Load System for high score and saving settings states
* Better looking craters - for some reason, currently they look like pancakes

## Programming - devlog
Here's what the scripts do (general overview) -
1. GravityBody.cs & GravityAttractor.cs - Disables normal gravity and implements spherical gravity around the planet.
2. CraterSpawner.cs & MeteorSpawner.cs - Runs on a coroutine that spawns meteors (with particles and smoke)
3. FollowPlayer.cs - Controls the camera movement on player using quaternions and smooths out jittery motion 
4. PlayerController.cs - Controls player movement for touch and keyboard controls
5. MeteorHit.cs - Destroys meteor, spawns crater
6. CarCollide.cs - Detects when car collides with crater, spawns destroyed car and ends game
7. CarHeadlights.cs - Turns on car headlights in dark(only on PC as realtime lighting is slow on android)
 8. GameManager.cs - Handles core game states in a unified script
 9. AudioManger.cs - Singleton class that handles audio clips across game scenes
 10. RestartMenu.cs & SettingsMenu.cs - Manages restart state and UI and settings (music, sound fx, quality) respectively

Car and planet models were imported as free assets 

 ## Music - devlog
 Most of the arcade games of this type have fast paced music, i wanted to go the opposite direction and make the music more laid back and soothing. End result transformed into a weird combination of  jazzy-neosoul-r&b-lofi genre.

Some music theory if anyone interested -

 **Chord Progression** - ii V I vi in the E♭ major key - extremely common progression in jazz which looks like - Fmin7, B♭7, E♭maj7, Cmin7

 This sounds boring, so after adding extensions, it becomes - Fmin9, B♭11sus2 - B♭13, E♭maj9, Cmin7. I learned this on guitar and then converted the notes to midi for piano and other instruments. Here's a [video](https://www.youtube.com/watch?v=57HErJ8H3_k) of what the first iteration sounded like on guitar.

 Added percussions, foley sounds & atmosphere, synth pads, bass etc.

 Tried to mix to best of my ability with eq, compression, reverb etc, but i suck at mixing & mastering, it could sound a lot better still.

 **Software Used** - Ableton Live 11 & Audacity

Heres a playthrough of the song in ableton-

[![Shrinking Planet](https://img.youtube.com/vi/AnQGixURMfU/0.jpg)](https://www.youtube.com/watch?v=AnQGixURMfU)

## Credits

Chandan Priyadarshi

Divyanshu Poddar

Rahul Stephen 


**Special thanks to Brackeys**