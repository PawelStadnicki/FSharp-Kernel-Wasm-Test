# FSharp-Kernel-Wasm-Test

This is for .NET 9 Preview-2 (SDK, ASP runtime, and VS 17.10.0 Preview 2.0 are needed)

Blazor, minimum app that takes a counter and multiplies it by 6 with F# Kernel from .NET Interactive:
![image](https://github.com/PawelStadnicki/FSharp-Kernel-Wasm-Test/assets/56049414/7488ae48-6639-4ec1-84c2-53bc79463c6c)

The whole interactive code is here:

This is just to demonstrate that in server mode, it works, but in a web assembly, it fails:
![image](https://github.com/PawelStadnicki/FSharp-Kernel-Wasm-Test/assets/56049414/686ada19-6773-41fb-836e-2f69575f1ede)

The goal is to find a root cause and act to make it work.

Note: Real multithreading for Blazor is a (tentative) goal for .NET 9.
It is just a preview-2 with almost no info on how to run it with a huge possibility for breaking changes,
but I think it is worth to catch up early problems.

