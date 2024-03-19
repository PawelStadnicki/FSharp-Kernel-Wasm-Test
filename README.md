# FSharp-Kernel-Wasm-Test

This is for .NET 9 Preview-2 (SDK, ASP runtime, and VS 17.10.0 Preview 2.0 are needed), where real multithreading is planned for wasm (tentative).
The work just started and probably will not be ready until later previews (if at all), but I need this feature and want to catch problems as soon as possible.

Speaking shortly, real multithreading should work in .NET wasm as the proper native code that supports it is already there. The work for the .NET team is to enable it via some configuration, make it backward compatible, and make it work with JS interop, which currently is single-threaded. Many challenges appeared that moved it to tentative in .NET 9 but sooner or later, it will be available ( I hope with .NET 9). 

## About the sample app

It is a Blazor app created from the regular template but slightly adjusted to support real multithreading in WASM.
I noticed several GitHub issues with discussions of how it will be enabled at some point in time, so this is my pure guessing, and I may be wrong about the setup.
I added:
```<WasmEnableThreads>true</WasmEnableThreads>```
to the project file and

```
app.Use(async (context, next) => {
    context.Response.Headers.Add("Cross-Origin-Opener-Policy", "same-origin");
    context.Response.Headers.Add("Cross-Origin-Embedder-Policy", "require-corp");
    await next();
});
```
to the Program.cs file.

It already does a lot by trying to get the interactive command responses, while in .NET 8 it hangs without any message.
Note that it still even hangs/fails for C# Kernel in .NET 9 preview-2 but at this time I'm only interested in F# Kernel.

The F# code is in dedicated project, the remaining is Blazor C# server/client:
![image](https://github.com/PawelStadnicki/FSharp-Kernel-Wasm-Test/assets/56049414/140803e8-4acb-4330-95de-4ee634682307)


The logic of the app is just a counter that can be incremented with a button and then multiplied by 6 with F# Kernel from .NET Interactive:
![image](https://github.com/PawelStadnicki/FSharp-Kernel-Wasm-Test/assets/56049414/7488ae48-6639-4ec1-84c2-53bc79463c6c)

The rest of interactive code is here: https://github.com/PawelStadnicki/FSharp-Kernel-Wasm-Test/blob/4317e1cf0d08a4587f81a6154a27401ed3c22187/BlazorApp9/Interactive/Library.fs#L28

This is to demonstrate that in server mode, it works, but in a web assembly, it fails with not supported operation exception.

Server Mode:

![image](https://github.com/PawelStadnicki/FSharp-Kernel-Wasm-Test/assets/56049414/686ada19-6773-41fb-836e-2f69575f1ede)

Web Assembly:

![image](https://github.com/PawelStadnicki/FSharp-Kernel-Wasm-Test/assets/56049414/e072f9aa-7468-4eb0-aaef-e3321e7d1295)


The goal is to find a root cause and act to make it work.

Note: for server app logs are in VS Debug Console, for wasm there are in a browser console.


