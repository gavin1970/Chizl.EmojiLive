# Chizl.EmojiLive

[![NuGet Version](https://img.shields.io/nuget/v/Chizl.EmojiLive.svg)](https://www.nuget.org/packages/Chizl.EmojiLive/)
[![License: MIT](https://img.shields.io/badge/license-MIT-orange.svg)](https://github.com/gavin1970/Chizl.EmojiLive/blob/master/LICENSE.md)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Chizl.EmojiLive)](https://www.nuget.org/packages/Chizl.EmojiLive/)<br/>
[![Target Frameworks](https://img.shields.io/badge/target%20frameworks-netstandard2.0%20%7C%20netstandard2.1%20%7C%20net471%20%7C%20net472%20%7C%20net48%20%7C%20net481%20%7C%20net8.0%20%7C%20net9.0%20%7C%20net10.0-purple)](https://dotnet.microsoft.com/)


A comprehensive .NET emoji library providing **4,098 fully-qualified emojis** organized into 10 major groups with detailed metadata and save as image support.
## 👩‍❤️‍💋‍👨 Resulting PNG (Kiss: Woman, Man)

[[64x64]](https://github.com/gavin1970/Chizl.EmojiLive/blob/master/examples/KissWomanMan_64x64.png) | [[128x128]](https://github.com/gavin1970/Chizl.EmojiLive/blob/master/examples/KissWomanMan_128x128.png) | [[512x512]](https://github.com/gavin1970/Chizl.EmojiLive/blob/master/examples/KissWomanMan_512x512.png)

## 🎯 Key Features

- ✅ **4,098 Fully-Qualified Emojis** - Complete Unicode emoji set
- 📦 **10 Major Groups** - Organized into logical categories (Smileys, People, Animals, Food, Travel, Activities, Objects, Symbols, Flags, Basic Latin)
- 🖼️ **Built-in PNG Images** - 16x16 to 512x512 color PNG images for each emoji
- 📊 **Rich Metadata** - Name, group, subgroup, version, code points, and more
- 🎨 **Cross-Platform** - Works with Console, WinForms, WPF, and more
- 💾 **Save to Disk** - Export emojis as PNG files using SkiaSharp
- 🌈 **Skin Tone Support** - Full support for skin tone variations
- ⚡ **Multi-Targeting** - Supports .NET Standard 2.0/2.1, .NET Framework 4.7.1-4.8.1, and .NET 8-10

---

## 📦 Installation

### NuGet Package Manager

### .NET CLI

> dotnet add package Chizl.EmojiLive

### Package Reference

> <PackageReference Include="Chizl.EmojiLive" Version="*" />

---

## 🚀 Quick Start

### Basic Usage

```csharp
using Chizl.EmojiLive;

// Access an emoji 
Emoji emoji = EmojiActivities.JackOLantern;

// Display in console 
Console.WriteLine($"[{emoji}] {emoji.Name}"); 
// Output: [🎃] Jack-O-Lantern

// Get detailed information 
Console.WriteLine($"Group: {emoji.Group}"); 
Console.WriteLine($"Subgroup: {emoji.SubGroup}"); 
Console.WriteLine($"Version: {emoji.Version}"); 
Console.WriteLine($"Code Points: {emoji.CodePoints}");
```

### Converting to Emoji Binary Images

```csharp
// Get the emoji as a byte array (PNG format) 
byte[] pngBytes = emoji.EmojiPngImage;

// Save emoji to disk 
emoji.SaveEmoji( 
	fullPath: @"C:\MyEmojis", 
	fileName: "pumpkin",					// Optional - defaults to emoji name 
	imageFormat: SKEncodedImageFormat.Png, 
	overWrite: true );
```

### Display Defining Properties

```csharp
Emoji emoji = EmojiSmileys.GrinningFace;
Console.WriteLine($"Character: {emoji.EmojiCharacter}"); 
Console.WriteLine($"Display Width: {emoji.EmojiDisplayWidth}"); 
Console.WriteLine($"String Length: {emoji.Length}"); 
Console.WriteLine($"Fully Qualified: {emoji.FullyQualified}"); 
Console.WriteLine($"Uses ZWJ: {emoji.UsesZWJ}"); 
Console.WriteLine($"Uses Variation Selector: {emoji.UsesVariationSelector}");
```

---

## 📋 Available Properties

| Property | Type | Description |
|----------|------|-------------|
| `Group` | `string` | Emoji group (e.g., "Smileys & Emotion") |
| `SubGroup` | `string` | Emoji subgroup (e.g., "face-smiling") |
| `Name` | `string` | Clean emoji name (used as resource name) |
| `FullName` | `string` | Official Unicode name |
| `Version` | `string` | Unicode version (e.g., "E0.6") |
| `CodePoints` | `string` | All emoji code points |
| `UnqualifiedCodePoints` | `string` | Shortest unqualified code points |
| `EmojiPngImage` | `byte[]` | 16x16->512x512 PNG image as byte array |
| `EmojiDisplayWidth` | `int` | Actual width on screen |
| `EmojiCharacter` | `string` | Unicode character representation |
| `UnqualifiedEmojiCharacter` | `string` | Shortest unqualified character |
| `UTF32Codes` | `int[]` | Array of decimal values for each byte |
| `Length` | `int` | String length |
| `ByteFlags` | `ByteFlag[]` | Flags for each byte |
| `FullyQualified` | `bool` | Unicode qualification status |
| `HasError` | `bool` | Error flag status |
| `HasUnqualifiedCharacter` | `bool` | Conversion failure indicator |
| `UsesZWJ` | `bool` | Uses Zero Width Joiner (U+200D) |
| `UsesVariationSelector` | `bool` | Uses Variation Selector-16 (U+FE0F) |
| `UsesKeycapCombiner` | `bool` | Uses Keycap Combining (U+20E3) |
| `IsSingleCodepoint` | `bool` | Single Unicode code point |
| `CanRendersAsImage` | `bool` | Platform image rendering support |

---

## 🎨 Emoji Categories

### Available Static Classes

| Class | Emoji Count | Description |
|-------|-------------|-------------|
| `EmojiBasicLatin` | 317 | Basic Latin characters and symbols |
| `EmojiSmileys` | 169 | Smileys and emotions |
| `EmojiPeopleBody` | 2,261 | People, body parts, and gestures |
| `EmojiAnimalsNature` | 159 | Animals and nature |
| `EmojiFoodDrink` | 131 | Food and beverages |
| `EmojiTravelPlaces` | 218 | Travel and places |
| `EmojiActivities` | 85 | Activities and events |
| `EmojiObjects` | 264 | Objects and tools |
| `EmojiSymbols` | 224 | Symbols and signs |
| `EmojiFlags` | 270 | Country and subdivision flags |

### Example: Browsing by Category

```csharp
// Access food emojis 
Emoji pizza = EmojiFoodDrink.Pizza; 
Emoji burger = EmojiFoodDrink.Hamburger; 
Emoji taco = EmojiFoodDrink.Taco;

// Access people emojis with skin tones 
Emoji wave = EmojiPeopleBody.WavingHand; 
Emoji waveDark = EmojiPeopleBody.WavingHandDarkSkinTone;

// Access flags 
Emoji usFlag = EmojiFlags.FlagUnitedStates; 
Emoji japanFlag = EmojiFlags.FlagJapan;
```

---

## 💾 SaveEmoji Method

Save emojis to disk with flexible options:

```csharp
emoji.SaveEmoji( 
	fullPath: @"C:\MyImages", 
	fileName: "custom-name",					// Optional - defaults to emoji name 
	imageFormat: SKEncodedImageFormat.Png,		// PNG, JPEG, WEBP, etc. 
	overWrite: true);							// Default: true
```

**Supported Image Formats:**
- PNG (default)
- JPEG
- WEBP
- BMP
- GIF
- ICO
- WBMP

---

## ⚠️ Known Limitations

### PNG Image Rendering
Not all emoji features are perfectly represented based on your OS, icu.dll, icuuc.dll, or icuin.dll versions.  If any image is not rendering correctly, please create an issue with details about your environment and the specific emoji(s) affected and we will investigate.

- **Skin Tone Variations**: Some skin tone combinations may not render correctly in PNG
- **Complex Emojis**: Family emojis (e.g., 👩‍👩‍👧‍👧) may only show partial characters in PNG
- **Recommendation**: Use `EmojiCharacter` property for console output or label display with emoji fonts for best results

### Platform-Specific Rendering
- Console applications show full unicode characters including tones
- WinForms labels support emoji fonts with correct foreground color
- Some emojis may appear differently across operating systems

---

## 🎯 Use Cases

### Console Applications

```csharp
Emoji rocket = EmojiTravelPlaces.Rocket; 
Console.WriteLine($"Launching {rocket.EmojiCharacter} {rocket.Name}!");
```

### WinForms Applications

```csharp
// Display emoji in a label with emoji font 
label.Text = emoji.EmojiCharacter; 
label.Font = new Font("Segoe UI Emoji", 48);
```


### Save Emoji Collection

```csharp
var foodEmojis = new[] { EmojiFoodDrink.Pizza, EmojiFoodDrink.Hamburger, EmojiFoodDrink.Taco, EmojiFoodDrink.Sushi };
foreach (var emoji in foodEmojis) 
	emoji.SaveEmoji(@"C:\FoodEmojis", imageFormat: SKEncodedImageFormat.Png); 
```

---

## 📊 Technical Details

### Target Frameworks
- .NET Standard 2.0
- .NET Standard 2.1
- .NET Framework 4.7.1
- .NET Framework 4.7.2
- .NET Framework 4.8
- .NET Framework 4.8.1
- .NET 8.0
- .NET 9.0
- .NET 10.0

### Dependencies
- **SkiaSharp** - Cross-platform 2D graphics library for image rendering and saving.
- **SkiaSharp.HarfBuzz** - Text shaping library for advanced text rendering complex emojis.

### Data Source
All emoji data is auto-generated from official Unicode specifications and maintained by Chizl's internal tooling.

---

## 📁 Demo Projects

Explore the included demo projects in the `/demos/` folder:

- **Console Demo** (.NET 8.0): `.\demos\ConsoleDemo\`
- **WinForms Demo** (.NET Framework 4.8.1): `.\demos\Framework48FormsDemo\`

---

## 🔗 Links

- [NuGet Package](https://www.nuget.org/packages/Chizl.EmojiLive/)
- [GitHub Repository](https://github.com/gavin1970/Chizl.EmojiLive)
- [Chizl Home Page](http://www.chizl.com/)
- [License](https://github.com/gavin1970/Chizl.EmojiLive/blob/master/LICENSE.md)
- [Third-Party Notices](https://github.com/gavin1970/Chizl.EmojiLive/blob/master/THIRD-PARTY-NOTICES.txt)

---

## 📜 License

This project is licensed under the terms specified in the [LICENSE.md](https://github.com/gavin1970/Chizl.EmojiLive/blob/master/LICENSE.md) file.

---

## 📝 Third-Party Notices

This project includes data derived from Unicode® Emoji data files.
See [`THIRD-PARTY-NOTICES.txt`](https://github.com/gavin1970/Chizl.EmojiLive/blob/master/THIRD-PARTY-NOTICES.txt) for full attribution and license details.

---

## 🤝 Contributing

Contributions are welcome! Please feel free to submit issues or pull requests.

---

## 📧 Support

For questions or support, please visit [www.chizl.com](http://www.chizl.com/)

---

**Note**: Emoji rendering may vary based on operating system version, Unicode library version, and installed fonts. The library was developed and tested on Windows 11 using Visual Studio 2022 Professional.

