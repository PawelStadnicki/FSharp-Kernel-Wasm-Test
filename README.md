# FSharp-Kernel-Wasm-Test

This is for .NET 9 Preview-2 (SDK, ASP runtime and VS 17.10.0 Preview 2.0 are needed)

Blazor app that takes a counter and multiple it by 6 with F# Kernel from .NET Interactive.

This is just to demonstrate that in server mode it works but in a webassembly (client it fails):
![image](https://github.com/PawelStadnicki/FSharp-Kernel-Wasm-Test/assets/56049414/686ada19-6773-41fb-836e-2f69575f1ede)

The goal is to find a root cause and act to make it work.

Note: Real multithreading for Blazor is a (tentiative) goal for .NET 9.

