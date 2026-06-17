# Deadly Days Mod Pack

A quality-of-life BepInEx mod for the game [Deadly Days](https://store.steampowered.com/app/740080/Deadly_Days/) that bundles several independent improvements into a single configurable package.
Requires BepInEx, a popular modding framework for Unity games.

The install instructions can be found in the [Installation](#installing-the-mod) section below.

---

## Features

Each feature can be individually enabled or disabled in the config file.  All settings and hotkeys can be changed in the config file.  
See the [Configuration](#configuration) section below for details.

### Character Hotkeys
Press **F1–F6** during a mission to instantly zoom the camera to that character's location.  This is identical to clicking on the character's portrait. 
Supports up to 6 characters and all hotkeys are configurable.

### DPS Display
Adds an estimated total **DPS value** to the weapon inspection popup, 
factoring in damage per hit, bullet count, and fire rate.  

### Damage Display Scale
Adjusts the minimum and maximum size of the **floating damage numbers** that appear when hitting enemies. 
Useful for reducing visual clutter or making numbers more prominent.

| Config Key     | Default | Description                            |
|----------------|---------|----------------------------------------|
| DamageMinScale | `0.4`   | Minimum scale multiplier for numbers.  The game's default is `0.9` |
| DamageMaxScale | `0.4`   | Maximum scale multiplier for numbers. The game's default is `1.2` |

### Daily Summary - Show Mission Resource Gain
Changes the daily summary for food, parts, and tools to show the amount gained from the mission, not the total amount at the end of the day.
This allows the user to easily see the rewards from each mission without having to manually calculate the difference from the previous day's total.
Note that any daily summaries before this mod was installed will still show the total amount.

### Instant Sell
**Middle-click** (Mouse2) a weapon in the base's invetory to instantly sell it - no confirmation dialog required. The hotkey is configurable.

| Config Key     | Default     | Description              |
|----------------|-------------|--------------------------|
| InstantSellKey | `Mouse2`    | Hotkey to instantly sell.|

### Inventory Sort

When opening the weapon inventory panel, weapons are automatically sorted by:
1. Repaired status (repaired weapons first)
2. Level (highest first)
3. Name (alphabetical)

### Return to Bus Key
Adds a hotkey to the "Return to Bus" button when in the mission.  This function is available on the controller, 
but not on the keyboard by default. 

The hotkey is configurable.

Note that this is part of the [Key Binds](#key-binds) feature, and will only be enabled if the Key Binds functionality is enabled.


### Key Binds
Allows remapping of all in-game keyboard shortcuts through the config file. Changes take effect immediately when the config is saved.
The config uses the game's defaults.

**Default bindings:**

| Action          | Default Key  |
|-----------------|--------------|
| ReturnToBus     | Q            |
| UISubmit        | Return       |
| UICancel        | Escape       |
| PageRight       | E            |
| PageLeft        | Q            |
| Menu            | Escape       |
| UseAirStrike    | 1            |
| UseHeal         | 2            |
| UseSpecialPower1| 3            |
| UseSpecialPower2| 4            |
| UseSpecialPower3| 5            |
| AttackPosition  | Left Control |
| TempPause       | Space        |
| CameraLeft      | A            |
| CameraRight     | D            |
| CameraUp        | W            |
| CameraDown      | S            |

---

## Requirements

- [BepInEx 5](https://github.com/BepInEx/BepInEx/releases)
- **Important**: Only use BepInEx 5. BepInEx 6 is not compatible and will cause the game to crash on launch.

## Installing BepInEx

1. **Download** the latest stable BepInEx 5 release from the [BepInEx releases page](https://github.com/BepInEx/BepInEx/releases).
   - Choose the `BepInEx_win_x64_*.zip` file for a 64-bit Windows install of Deadly Days.

2. **Extract** the contents of the zip directly into the Deadly Days game folder (the same folder that contains `Deadly Days.exe`). 
1. After extraction the folder should contain a `BepInEx` directory alongside the game executable.

3. **Launch the game once** and then close it. BepInEx will perform its first-run setup and create the `BepInEx/plugins` and `BepInEx/config` directories.

4. Confirm BepInEx is working by checking that `BepInEx/LogOutput.log` was created.

---

## Installing the Mod

1. Download the latest `DeadlyDaysModPack.dll` from the [Releases](../../releases) page.

2. Extract the `DeadlyDaysModPack.zip` into:
   ```
   <Deadly Days game folder>\BepInEx\plugins\
   ```

   The zip file already includes the mod's folder.  If the zip was extracted correctly, there will be a `DeadlyDaysModPack/DeadlyDaysModPack.dll` directory and file.

3. Launch the game. The mod will load automatically.

---

## Configuration

The config file is generated on first launch at:

```
<Deadly Days game folder>\BepInEx\config\com.nbk_redspy.deadlydaysmodpack.cfg
```

Each feature has an `Enable` key that can be set to `true` or `false` to turn it on or off individually. All other settings (hotkeys, scale values) 
are also found in this file.

If a feature is disabled, the mod code for that feature will not run at all, so there is no performance 
impact from disabled features. 

Other than the Enable settings, changes to the config file are applied **immediately** — you do not need to restart the game.

## Support
If you enjoy my mods and want to buy me a coffee, check out my [Ko-Fi](https://ko-fi.com/nbkredspy71915) page.
Thanks!

## Source Code
The mod's source can be found at https://github.com/NBKRedSpy/DeadlyDaysModPack.
