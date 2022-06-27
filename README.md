# VRC Fury - All in one VRChat Prop / Inventory Manager

## Beta Notice

VRC Fury is new. Things may be broken. Beware. If you find any issues, please report them in our issue tracker, or to @SenkyDragon on twitter.

## Features
* **Easy to use**
  * Define props, puppets, item modes and more using a simple GUI in Unity
* **No more layers, no more menu editing**
  * The animation controller, VRC Menu, and synced parameters are all generated automatically by VRC Fury.
* **Great for asset artists**
  * Prefabs can contain their own VRC Fury definitions
  * Distribute your avatar addons with everything needed for the user to add your animations / props to their menu.
  * No more complicated "copy my layers into your fx"! If their project has VRC Fury, they can just drop your prefab into their project, and upload!
* **No more absolute paths for animations**
  * VRC Fury props defined in prefabs will automatically have their clips rewritten to work properly, no matter where in the hierarchy they are ultimately placed.
  * Write your animation clips from the root of the prefab, and VRCFury will handle rewriting it when it winds up on an avatar.
* **No clips? No problem!**
  * Just want to toggle a game object or a blend shape? No worries!
  * VRC Fury can create these toggles for you, without you needing to touch animation clips whatsoever.
* **Gestures, Idle Animation Support, and more!**
  * Fury isn't just about props. It also has logic to build every single animation layer that I personally use myself for my avatars. If it can't build a layer the way you want, let us know and maybe we can support it!
* **Already got your avatar perfect?**
  * VRC Fury still works perfectly with avatars that already have animations.
  * Your existing layers, parameters, and menus will be untouched, and VRC Fury will keep its work totally separate from yours.
  * This also means VRC Fury will not clobber the work of TPS, VRCLens, etc.
  * Note: VRC Fury is only compatible with existing layers that use Write Defaults **OFF** (the vrchat recommendation).
* **No more write defaults pain**
  * Every layer generated by VRC Fury will automatically have its default states calculated and maintained, based on the resting state of your avatar in the editor. This includes animation clips you give VRC Fury, so now you only have to make "on" animations, no more "off"!

## How to install and use

* Delete the VRCFury directory from your project (if upgrading).
* Click [here](https://gitlab.com/VRCFury/VRCFury/-/archive/main/VRCFury-main.zip) to download the latest release.
* Extract the zip somewhere into your avatar project (this is not a unity package file, so you can't just drag it in).
* If you are using just VRCFury because an artist said you needed if for their prefab:
  * You're done! Just follow their directions to add their prefab to your avatar, and VRC Fury will handle the rest.
  * Otherwise, read on to add your own behaviors and props.
* On your main avatar object, click `Add Component` -> `VRC Fury`.
* All fields are optional. If you only want props, only fill out props! However, VRCFury also handles common gesture patterns and blinking animations.
* You're done! There's no "building" to do. VRC Fury will update your FX layer, VRC menus and params automatically before each upload.

## Advanced features

### Blinking

If you include a single-frame animation of your avatar with its eyes closed (or click the plus and give it the blend shape name), VRC Fury will drive your avatar's blink cycle. If you do this, be sure to disable blinking AND look up / look down support in your VRC Avatar Descriptor.

Benefits:
* Blinking will stop automatically when your avatar performs vrcfury gestures affecting its eyes. This means no more 'double-blinking'.
* Unlike vrc's built-in eye tracking disable feature, your eyes will not freeze closed, partially closed, unfreeze unexpectedly due to combo-gestures.
* Your eye blink will be synchronized with all other clients (I'm unsure if the default vrc eye blink is synced or not).

### Visemes using Animation Clips

This feature is in very very early alpha testing. Fill a folder with animation clips named `Viseme-??` (where ?? is the oculus viseme code), then drop one of those animations into the VRCFury `Advanced Visemes` field. VRC Fury will build a layer to use these animations as visemes.

Benefits:

* You can use bone transforms in your visemes, meaning you can open your jaw rather than using an A blend shape.
* This can enhance some features, such as tongue movement, while your mouth is open during speech.

### Prefab artists

Distributing your own prefab with animations? 
* Add the VRC Fury component to the root object of your prefab, and add the props like normal. 
* Instruct your clients to install VRCFury in their own project.
* Ship the prefab to them, and instruct them to drag the prefab onto whatever bone on their avatar.
* When they upload their avatar, your prefab's props will be imported to their menu automatically! Any animation clip paths will be adjusted automatically to work properly, no matter where they've placed it in their avatar.

### Physbone Reset

Got an animation that changes parameters on a physbone?

Click the advanced `*` button on the VRC Fury prop for the animation, then click `Add PhysBone to Reset`. Drag the object for the physbone into the box (it should be on an empty by itself). VRC Fury will automatically flip the bone off and on any time your animation is run or reset, causing the physbone to reload your changed settings.

### Idle Animations

Want to add an idle animation to your avatar? Create a new prop, click the `*` and select `Default On`. Your idle animation will now play all the time (but you can also trigger it back off in game!)

### Sliders

Select `Slider` from the `*` menu, and VRC Fury will make the prop into a slider rather than a toggle. 0 will be the avatar default state, and 100% will be your "enabled" state.

### Saved Parameters

Not everything in VRC Fury has to be a prop. Want to save your clothes (or anything else?) across worlds? Select `Saved between worlds` in the `*` menu.

### Fully-Managed Controller

Your avatar doesn't even need to have a FX layer, menu, or params! If these are unset, VRCFury will create them automatically, and manage them fully (meaning it will be deleted and recreated from scratch before each upload).
Beware of this! If you want to make your own changes to your controller, menu, or params, then you should create one yourself outside of the vrcf temp directory.