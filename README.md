# Harae
[![Build status](https://github.com/HTWK-18INB-1/harae/actions/workflows/unity_ci.yml/badge.svg)](https://github.com/HTWK-18INB-1/harae/actions/workflows/unity_ci.yml)
[![Chat](https://discordapp.com/api/guilds/774798139982348309/widget.png?style=shield)](https://discord.gg/h4wJmKYkMZ)
[![Project refactoring](https://img.shields.io/badge/Project-Refactoring-blue.svg)](https://github.com/HTWK-18INB-1/harae/issues)

## About
This is an simple virtual reality exorcism game.
![Screenshot](screenshot.png)

## Requirements
 * [Unity](https://unity.com) 2020.1.17f1 or higher

## Contribution
 1. Install [Git](https://git-scm.com) and [Git LFS](https://git-lfs.github.com).
 2. Run `git lfs install`.
 3. Clone the repository.
 4. Configure the repository properly by issuing the following Git commands (please use your own name, email and UnityYAMLMerge path instead):
 ```bash
 git config user.name "Your Name"
 git config user.email "you@example.org"
 git config credential.helper 'cache --timeout=3600'
 git config mergetool.unityyamlmerge.trustExitCode false
 git config mergetool.unityyamlmerge.keepBackup false
 git config mergetool.unityyamlmerge.cmd '"/path/to/UnityYAMLMerge" merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"'
 ```

## Assets
 * [Unity Assetstore](https://assetstore.unity.com):
    * [Oculus Integration](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022) (10.02.2021)
    * [Free Night Sky](https://assetstore.unity.com/packages/2d/textures-materials/sky/free-night-sky-79066) (06.02.2021)
    * [Survival old House](https://assetstore.unity.com/packages/3d/environments/urban/survival-old-house-55315) (10.02.2021)
    * [Unnerving Ambient Sounds - Horror Game Sound Effect Pack (30 Sounds)](https://assetstore.unity.com/packages/audio/ambient/unnerving-ambient-sounds-horror-game-sound-effect-pack-30-sounds-170590) (11.02.2021)
       * Paranormal Phenomena 1
    * [Terrain Textures Pack Free](https://assetstore.unity.com/packages/2d/textures-materials/terrain-textures-pack-free-139542) (11.02.2021)
    * [Dream Forest Tree](https://assetstore.unity.com/packages/3d/vegetation/trees/dream-forest-tree-105297) (11.02.2021)
    * [Low Poly Tree Pack](https://assetstore.unity.com/packages/3d/vegetation/trees/low-poly-tree-pack-57866) (07.02.2021)
    * [18 High Resolution Wall Textures](https://assetstore.unity.com/packages/2d/textures-materials/brick/18-high-resolution-wall-textures-12567) (07.02.2021)
    * [Terrain Textures Pack Free](https://assetstore.unity.com/packages/2d/textures-materials/terrain-textures-pack-free-139542) (07.02.2021)
    * [Outdoor Ground Textures](https://assetstore.unity.com/packages/2d/textures-materials/floors/outdoor-ground-textures-12555) (07.02.2021)
    * [Particle Ribbon](https://assetstore.unity.com/packages/vfx/particles/spells/particle-ribbon-42866)(07.02.2021)
    * [Unity Particle Pack](https://assetstore.unity.com/packages/essentials/tutorial-projects/unity-particle-pack-127325)(07.02.2021)
    * [FREE Witchcraft and Wizardry Asset Pack](https://assetstore.unity.com/packages/3d/props/free-witchcraft-and-wizardry-asset-pack-141428)(01.03.2021)
    * [Essential Horror Music Collection (v1) [FREE]](https://assetstore.unity.com/packages/audio/ambient/fantasy/essential-horror-music-collection-v1-free-187099)(01.03.2021)
    * [Wind01](https://www.freesoundeffects.com/free-track/wind01-428702/)(12.03.2021)
    * [Oculus Integration](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022) (10.02.2021)
 * [Sketchfab](https://sketchfab.com)
    * [Skull downloadable](https://sketchfab.com/3d-models/skull-downloadable-1a9db900738d44298b0bc59f68123393) (11.02.2021)
 * [Charakter's and Animation](https://www.mixamo.com/):
    * [Warrok W Kurniawan]
    * [Yaku J Ignite]
    * [Scary Zombie Pack]
    * [Creature NPC Pack]
 * [Music]
    * [Boss Baatle Music](https://opengameart.org/content/boss-battle-music)

## Unity Packages
 * [XR Plugin Management](https://docs.unity3d.com/Packages/com.unity.xr.management@3.2/manual/index.html) (10.02.2021)
 * [Oculus XR Plugin](https://docs.unity3d.com/Packages/com.unity.xr.oculus@1.6/manual/index.html) (10.02.2021)
 * [Visual Effect Graph](https://docs.unity3d.com/Packages/com.unity.visualeffectgraph@10.3/manual/index.html) (11.02.2021)
 * [VR Controller Unity Package](https://uc9917c7ab5321a72540b0a96c90.dl.dropboxusercontent.com/cd/0/get/BKbMVB9jka6c0M3u_SIJfnQNyNB5LjX5vX23k-hEMH_g3cNelRWZ4vX0NQwktR6xkUUan29Ltep5qq1fpbdOsOv9vGt3fCN5wgA1Qw6F_WGM5LPHJ2WSxTSGcyqcM6MUqx3ona12D1V9Yd9M5Mv3r5x0/file?dl=1#)
 * [Oculus Hands Unity Package](https://uc596a07805e2999e64e3c2f02f4.dl.dropboxusercontent.com/cd/0/get/BKb9QUVKPba89H5G5_kL4Ralj852zBWyEC8EVMDw3fk69DYMRF5cCkuwB9QKTjV5oUpLlyhGCb5ZwuVg2Lg3497f804Oj0KSLtsyMHWMyxm1pEJuveIku8iRRP8xPpvUIPzt3Yevsxf6vG54fZhlf-Bu/file?dl=1#)

## Project status meanings
 * **Refactoring:** Structural and technical changes have currently priority.
 * **Active:** Default status.
 * **Fixes only:** The project is maintained at the minimum level to apply at least fixes.
 * **Takeover:** The project is currently being taked over by another team and will possibly move.
 * **Not maintained:** The project is not maintained any more (ready to take over).

*Feature requests are welcomed all the time, of course! ;-)*

## License
This project is free software under the terms of the CC BY 4.0 license.
For more details please see the LICENSE file or: [Creative Commons](http://creativecommons.org/licenses/by/4.0)

## Credits
 * 2020/2021 by Vivien Richter, Bao So Nguyen, Leon Gottschild and Jan Wegmann
 * Git repository: [GitHub](https://github.com/HTWK-18INB-1/harae.git)
