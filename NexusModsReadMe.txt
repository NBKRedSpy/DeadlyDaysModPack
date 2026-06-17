[b][size=5]Deadly Days Mod Pack[/size][/b] 
 
A quality-of-life BepInEx mod for the game [url=https://store.steampowered.com/app/740080/Deadly_Days/]Deadly Days[/url] that bundles several independent improvements into a single configurable package.
Requires BepInEx, a popular modding framework for Unity games.
 
The install instructions can be found in the [font=Courier New]Installation[/font] section below.
 
[b][size=4]Features[/size][/b] 
 
Each feature can be individually enabled or disabled in the config file.  All settings and hotkeys can be changed in the config file.
See the [font=Courier New]Configuration[/font] section below for details.
 
[b][size=3]Character Hotkeys[/size][/b] 
 
Press [b]F1–F6[/b] during a mission to instantly zoom the camera to that character's location.  This is identical to clicking on the character's portrait.
Supports up to 6 characters and all hotkeys are configurable.
 
[b][size=3]DPS Display[/size][/b] 
 
Adds an estimated total [b]DPS value[/b] to the weapon inspection popup,
factoring in damage per hit, bullet count, and fire rate.
 
[b][size=3]Damage Display Scale[/size][/b] 
 
Adjusts the minimum and maximum size of the [b]floating damage numbers[/b] that appear when hitting enemies.
Useful for reducing visual clutter or making numbers more prominent.
[font=Courier New]+----------------+---------+---------------------------------------------------------------+
| Config Key     | Default | Description                                                   |
|================+=========+===============================================================|
| DamageMinScale |         | Minimum scale multiplier for numbers.  The game's default is  |
|----------------+---------+---------------------------------------------------------------|
| DamageMaxScale |         | Maximum scale multiplier for numbers. The game's default is   |
+----------------+---------+---------------------------------------------------------------+
[/font]
 
[b][size=3]Daily Summary - Show Mission Resource Gain[/size][/b] 
 
Changes the daily summary for food, parts, and tools to show the amount gained from the mission, not the total amount at the end of the day.
This allows the user to easily see the rewards from each mission without having to manually calculate the difference from the previous day's total.
Note that any daily summaries before this mod was installed will still show the total amount.
 
[b][size=3]Instant Sell[/size][/b] 
 
[b]Middle-click[/b] (Mouse2) a weapon in the base's invetory to instantly sell it - no confirmation dialog required. The hotkey is configurable.
[font=Courier New]+----------------+---------+---------------------------+
| Config Key     | Default | Description               |
|================+=========+===========================|
| InstantSellKey |         | Hotkey to instantly sell. |
+----------------+---------+---------------------------+
[/font]
 
[b][size=3]Inventory Sort[/size][/b] 
 
When opening the weapon inventory panel, weapons are automatically sorted by:
[list=1]
[*]Repaired status (repaired weapons first)
[*]Level (highest first)
[*]Name (alphabetical)
[/list]
 
[b][size=3]Return to Bus Key[/size][/b] 
 
Adds a hotkey to the "Return to Bus" button when in the mission.  This function is available on the controller,
but not on the keyboard by default.
 
The hotkey is configurable.
 
Note that this is part of the [font=Courier New]Key Binds[/font] feature, and will only be enabled if the Key Binds functionality is enabled.
 
[b][size=3]Key Binds[/size][/b] 
 
Allows remapping of all in-game keyboard shortcuts through the config file. Changes take effect immediately when the config is saved.
The config uses the game's defaults.
 
[b]Default bindings:[/b]
[font=Courier New]+------------------+--------------+
| Action           | Default Key  |
|==================+==============|
| ReturnToBus      | Q            |
|------------------+--------------|
| UISubmit         | Return       |
|------------------+--------------|
| UICancel         | Escape       |
|------------------+--------------|
| PageRight        | E            |
|------------------+--------------|
| PageLeft         | Q            |
|------------------+--------------|
| Menu             | Escape       |
|------------------+--------------|
| UseAirStrike     | 1            |
|------------------+--------------|
| UseHeal          | 2            |
|------------------+--------------|
| UseSpecialPower1 | 3            |
|------------------+--------------|
| UseSpecialPower2 | 4            |
|------------------+--------------|
| UseSpecialPower3 | 5            |
|------------------+--------------|
| AttackPosition   | Left Control |
|------------------+--------------|
| TempPause        | Space        |
|------------------+--------------|
| CameraLeft       | A            |
|------------------+--------------|
| CameraRight      | D            |
|------------------+--------------|
| CameraUp         | W            |
|------------------+--------------|
| CameraDown       | S            |
+------------------+--------------+
[/font]
 
[b][size=4]Requirements[/size][/b] 
[list]
[*][url=https://github.com/BepInEx/BepInEx/releases]BepInEx 5[/url]
[*][b]Important[/b]: Only use BepInEx 5. BepInEx 6 is not compatible and will cause the game to crash on launch.
[/list]
 
[b][size=4]Installing BepInEx[/size][/b] 
[list=1]
[*]
[b]Download[/b] the latest stable BepInEx 5 release from the [url=https://github.com/BepInEx/BepInEx/releases]BepInEx releases page[/url].
[list]
[*]Choose the [font=Courier New]BepInEx_win_x64_*.zip[/font] file for a 64-bit Windows install of Deadly Days.
[/list]
[*]
[b]Extract[/b] the contents of the zip directly into the Deadly Days game folder (the same folder that contains [font=Courier New]Deadly Days.exe[/font]).
[*]
After extraction the folder should contain a [font=Courier New]BepInEx[/font] directory alongside the game executable.
[*]
[b]Launch the game once[/b] and then close it. BepInEx will perform its first-run setup and create the [font=Courier New]BepInEx/plugins[/font] and [font=Courier New]BepInEx/config[/font] directories.
[*]
Confirm BepInEx is working by checking that [font=Courier New]BepInEx/LogOutput.log[/font] was created.
[/list]
 
[b][size=4]Installing the Mod[/size][/b] 
[list=1]
[*]
Download the latest [font=Courier New]DeadlyDaysModPack.zip[/font] Files tab.
[*]
Extract the [font=Courier New]DeadlyDaysModPack.zip[/font] into:
[code]
<Deadly Days game folder>\BepInEx\plugins\
[/code]
 
The zip file already includes the mod's folder.  If the zip was extracted correctly, there will be a [font=Courier New]DeadlyDaysModPack/DeadlyDaysModPack.dll[/font] directory and file.
[*]
Launch the game. The mod will load automatically.
[/list]
 
[b][size=4]Configuration[/size][/b] 
 
The config file is generated on first launch at:
[code]
<Deadly Days game folder>\BepInEx\config\com.nbk_redspy.deadlydaysmodpack.cfg
[/code]
 
Each feature has an [font=Courier New]Enable[/font] key that can be set to [font=Courier New]true[/font] or [font=Courier New]false[/font] to turn it on or off individually. All other settings (hotkeys, scale values)
are also found in this file.
 
If a feature is disabled, the mod code for that feature will not run at all, so there is no performance
impact from disabled features.
 
Other than the Enable settings, changes to the config file are applied [b]immediately[/b] — you do not need to restart the game.
 
[b][size=4]Support[/size][/b] 
 
If you enjoy my mods and want to buy me a coffee, check out my [url=https://ko-fi.com/nbkredspy71915]Ko-Fi[/url] page.
Thanks!
 
[b][size=4]Source Code[/size][/b] 
 
The mod's source can be found at [url=https://github.com/NBKRedSpy/DeadlyDaysModPack]https://github.com/NBKRedSpy/DeadlyDaysModPack[/url].
