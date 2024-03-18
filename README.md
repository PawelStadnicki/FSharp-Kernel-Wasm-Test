# FSharp-Kernel-Wasm-Test

This is for .NET 9 Preview-2 (SDK, ASP runtime, and VS 17.10.0 Preview 2.0 are needed)

Blazor, minimum app that takes a counter and multiplies it by 6 with F# Kernel from .NET Interactive:
![image](https://github.com/PawelStadnicki/FSharp-Kernel-Wasm-Test/assets/56049414/7488ae48-6639-4ec1-84c2-53bc79463c6c)

The rest of interactive code is here: https://github.com/PawelStadnicki/FSharp-Kernel-Wasm-Test/blob/4317e1cf0d08a4587f81a6154a27401ed3c22187/BlazorApp9/Interactive/Library.fs#L28

This is to demonstrate that in server mode, it works, but in a web assembly, it fails with not supported operation exception.

Server Mode:

![image](https://github.com/PawelStadnicki/FSharp-Kernel-Wasm-Test/assets/56049414/686ada19-6773-41fb-836e-2f69575f1ede)

Web Assembly:

![image](https://github.com/PawelStadnicki/FSharp-Kernel-Wasm-Test/assets/56049414/e072f9aa-7468-4eb0-aaef-e3321e7d1295)


The goal is to find a root cause and act to make it work.

Note: Real multithreading for Blazor is a (tentative) goal for .NET 9.
It is just a preview-2 with almost no info on how to run it, with a huge possibility for breaking changes.
The problem may be with a setup, not the used libraries.


