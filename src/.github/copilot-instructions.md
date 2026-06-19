* When using HarmonyPatch, use the nameof operator instead of a string literal.
Example:  `HarmonyPatch(typeof(MyClass), nameof(MyClass.MyMethod))` instead of `HarmonyPatch(typeof(MyClass), "MyMethod")`

