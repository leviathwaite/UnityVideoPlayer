# UnityVideoPlayer
A training video player prototype built in Unity

## Overview
Building a learning app using Unity3D to be used on students tablet.

**Challenges**
* Video player that can pause video to show learning prompts or insert learning prompts between videos and play thru a playlist containing both.
* Creating learning promts for quizs/tests
* Evaluating answers with feed back
* Score/Test result tracking and summary
* Navigating content
* A learning track creator scene or app that a non programmer can use to create learning tracks.
* Inject learning tracks into build or app

## Video Player and Learning Prompts

### Video Player
![Video Player](/Images/VideoPlayer.PNG)

**Navigation**
* Play/Pause, Stop, Next Buttons
* Scrubber to move thru video frames

**Volume Control**
* Slider to set volume level using Audio Component and Audio Mixer
* Saves and loads volume level from Player Prefs

### Learning Prompts

**Test Types**
* Drag and Drop for matching questions

![Video Player](/Images/MatchingTest1.PNG)

![Video Player](/Images/MatchingTest2.PNG)

* Multiple choice?
* Check all that apply

#### Known Issues
######Learning Prompts
* Can't return to videos

**Matching Test**
* Can't replace answer when dropping on top of another

######VideoPlayer
* Show first frame or blank screen on start of video or after pressing stop.
* Change pause to play when video ends.
* Change volume mute/unmute buttons when slider is clicked

**Not Implemented**
* Connection lines on matching tests
* Show logo or splash on start
* Multiple choice tests
* Check all that apply
* Answer evaluation
* Content navigation
* Sound clips on tests
* Loading text for learning prompts



