using System;
using SkiaSharp;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Chizl.EmojiLive
{
    [Flags]
    public enum ByteFlag
    {
        /// <summary>
        /// No ByteFlag Set
        /// Value: 0
        /// </summary>
        None = 0,
        /// <summary>
        /// Control ByteFlag
        /// Value: 1
        /// </summary>
        Control = 1,
        /// <summary>
        /// HighSurrogate ByteFlag
        /// Value: 2
        /// </summary>
        HighSurrogate = 2,
        /// <summary>
        /// LowSurrogate ByteFlag
        /// Value: 4
        /// </summary>
        LowSurrogate = 4,
        /// <summary>
        /// Separator ByteFlag
        /// Value: 8
        /// </summary>
        Separator = 8,
        /// <summary>
        /// Surrogate ByteFlag
        /// Value: 16
        /// </summary>
        Surrogate = 16,
        /// <summary>
        /// SurrogatePair ByteFlag
        /// Value: 32
        /// </summary>
        SurrogatePair = 32,
        /// <summary>
        /// Symbol ByteFlag
        /// Value: 64
        /// </summary>
        Symbol = 64,
        /// <summary>
        /// WhiteSpace ByteFlag
        /// Value: 128
        /// </summary>
        WhiteSpace = 128,
        /// <summary>
        /// Letter ByteFlag
        /// Value: 256
        /// </summary>
        Letter = 256,
        /// <summary>
        /// Digit ByteFlag
        /// Value: 512
        /// </summary>
        Digit = 512,
        /// <summary>
        /// Punctuation ByteFlag
        /// Value: 1024
        /// </summary>
        Punctuation = 1024,
    }


    /// <summary>
    /// Emoji object provides Name, Group, Subgroup, Code, Unicode version, Qualified and Unqualified unicode character to be used within a console or form.
    /// </summary>
    public sealed class Emoji
    {
        // Private fields (existing and new for image)
        private string _name = string.Empty;
        private string _fullName = string.Empty;
        private string _version = string.Empty;
        private string _group = string.Empty;
        private string _subGroup = string.Empty;
        private string _codePoints = string.Empty;
        private string _emojiCharacter = string.Empty; // Populated by ConvertToEmojiCharacter
        private string _errorMessage = string.Empty;
        private string _unQualifiedcodePoints = string.Empty;
        private string _unQualifiedEmojiCharacter = string.Empty; // Populated by ConvertToEmojiCharacter

        private int _displayWidth;
        private int _length = 0;
        private int[] _utf32Codes = new int[1] { 0 };
        private bool _fullyQualified = true;

        private ByteFlag[] _byteFlags = { ByteFlag.None };

        private Emoji() { IsEmpty = true; }
        // Default constructor overloads (keep existing)
        public Emoji(string group, string subGroup, string name, string fullName, string version, string codePoints, string unQualifiedcodePoints)
           : this(group, subGroup, name, fullName, version, true, codePoints, unQualifiedcodePoints) { }
        // Primary constructor
        public Emoji(string group, string subGroup, string name, string fullName, string version, bool fullyQualified, string codePoints, string unQualifiedcodePoints)
        {
            _group = group;
            _subGroup = subGroup;
            _name = name;
            _fullName = fullName;
            _version = version;
            _fullyQualified = fullyQualified;
            _codePoints = codePoints;
            _unQualifiedcodePoints = unQualifiedcodePoints;

            // Call the helper methods to populate _emojiCharacter, _unQualifiedEmojiCharacter, etc.
            this.ConvertToEmojiCharacter(codePoints, true);
            this.ConvertToEmojiCharacter(unQualifiedcodePoints, false);
            _displayWidth = ConsoleDisplayHelper.GetConsoleDisplayWidth(_emojiCharacter);
        }

        #region Public Properties (including the new Image property)
        /// <summary>
        /// Creates Empty Class object with only the IsEmpty property set to true. All other values are ignored.<br/>
        /// Easier to valid with _emoji.IsEmpty property than _emoji==null
        /// <code>
        /// var _emoji = Emoji.Empty;
        /// ...
        /// LoadEmoji(EmojiActivities.FlowerPlayingCards)
        /// ...
        /// private void LoadEmoji(Emoji emoji)
        /// {
        ///     if (emoji.IsEmpty)
        ///         return;
        /// 
        ///     _emoji = emoji;
        ///     _fileName = $"./{_emoji.Name}.png";
        /// }
        /// </code>
        /// </summary>
        public static Emoji Empty { get { return new Emoji(); } }
        /// <summary>
        /// True if Emoji was created using the static property Emoji.Empty.  False if true values exists.<br/>
        /// <code>
        /// var _emoji = Emoji.Empty;
        /// ...
        /// LoadEmoji(EmojiActivities.FlowerPlayingCards)
        /// ...
        /// private void LoadEmoji(Emoji emoji)
        /// {
        ///     if (emoji.IsEmpty)
        ///         return;
        /// 
        ///     _emoji = emoji;
        ///     _fileName = $"./{_emoji.Name}.png";
        /// }
        /// </code>
        /// </summary>
        public bool IsEmpty { get; }
        /// <summary>
        /// Emoji group name, set by unicode.org
        /// </summary>
        public string Group => _group;
        /// <summary>
        /// Emoji subgroup name, set by unicode.org
        /// </summary>
        public string SubGroup => _subGroup;
        /// <summary>
        /// Emoji name, cleaned up, based on unicode.org. This is also used as the resource name.
        /// </summary>
        public string Name => _name;
        /// <summary>
        /// Emoji full name, set by unicode.org
        /// </summary>
        public string FullName => _fullName;
        /// <summary>
        /// Emoji version, set by unicode.org
        /// </summary>
        public string Version => _version;
        /// <summary>
        /// All Emoji code points, set by unicode.org
        /// </summary>
        public string CodePoints => _codePoints;
        /// <summary>
        /// Shortest Unqualifed Emoji code points, set by unicode.org
        /// </summary>
        public string UnqualifiedCodePoints => _unQualifiedcodePoints;
        /// <summary>
        /// Emoji Image byte array in PNG format.<br/>
        /// For cross platform purposes, this images was created using Nuget Package (SkiaSharp)<br/>
        /// Gets the pre-rendered Image representation of the Emoji in a byte array.<br/>
        /// This as done because of the compatibility issues of the Image library from net-standard to<br/>
        /// other libraries like framework 4.x. The best way is to return it in a byte array, then convert 
        /// it to an image on the client.<br/>
        /// <code>
        /// using (MemoryStream ms = new MemoryStream(imageBytes))
        ///     PictureBox.Image = Image.FromStream(ms);
        /// </code>
        /// The image is loaded by its <see cref="Name"/> property (e.g., "GrinningFace").
        /// Returns null if the image resource is not found.
        /// </summary>
        public byte[] EmojiPngImage => UnicodeImageRenderer.RenderToPng(_emojiCharacter);
        /// <summary>
        /// Display width is the actual width on screen of this Emoji.  Where length could be 12, display width might be only 1.
        /// </summary>
        public int EmojiDisplayWidth => _displayWidth;
        /// <summary>
        /// Emoji unicode character as combined code points
        /// </summary>
        public string EmojiCharacter => _emojiCharacter;
        /// <summary>
        /// Shortest unqualified Emoji unicode character as combined code points
        /// </summary>
        public string UnqualifiedEmojiCharacter => _unQualifiedEmojiCharacter;
        /// <summary>
        /// If HasError is true, then the errormessage will show here.
        /// </summary>
        public string ErrorMessage => _errorMessage;
        /// <summary>
        /// Qualified Emoji array of decimal values for each unicode byte for the EmojiCharacter.
        /// </summary>
        public int[] UTF32Codes => _utf32Codes;
        /// <summary>
        /// Emoji string length
        /// </summary>
        public int Length => _length;
        /// <summary>
        /// Each ByteFlag represents 1 byte either single char or multi-byte Char if exists.<br/>
        /// If multi-byte char, the single byte will have combind all the ByteFlags for that byte.
        /// </summary>
        public ByteFlag[] ByteFlags => _byteFlags;
        /// <summary>
        /// Emoji status, set by unicode.org.<br/>
        /// This project only tracks fully-qualified and the shortest unicode characters by the same name.  
        /// Default ToString() will always show qualified characters.<br/>
        /// All half-size unicode characters that need variation selectors will have them added as part of 
        /// EmojiCharacter response, but not the UnqualifiedEmojiCharacter response.
        /// </summary>
        public bool FullyQualified => _fullyQualified;
        /// <summary>
        /// By passing one or multiple flag into HasFlag, a full scan or the emoji will return true if 'all' flags passed are found.<br/>
        /// <code>
        /// Example:<br/>
        ///     var allSurrogates = EmojiPeopleBody.WomanMediumLightSkinToneBeard.HasFlag(ByteFlag.HighSurrogate | ByteFlag.LowSurrogate);<br/>
        /// </code>
        /// </summary>
        /// <param name="flag">One or Multiple ByteFlags</param>
        /// <returns>
        /// True if all passed flags are found within the emoji.<br/>
        /// False if one or more flags passed in aren't found.
        /// </returns>
        public bool HasFlag(ByteFlag flags)
        {
            ByteFlag found = ByteFlag.None;

            //since multiple flags could be passed in, those need to be broken down.
            foreach (ByteFlag ef in Enum.GetValues(typeof(ByteFlag)))
            {
                //skip none..
                if (ef.Equals(ByteFlag.None))
                    continue;

                //flags could have multiple flags.
                if ((flags & ef) == ef)
                {
                    //loop through each byte, reading flags if any have passed in flag.
                    foreach (var b in _byteFlags)
                    {
                        //b could have multiple flags.
                        if ((b & ef) == ef)
                        {
                            //tracking each that are found, to compare at the end.
                            found |= ef;
                            break;
                        }
                    }
                }
                //if all found, break
                //if passed flag is none
                if (!flags.Equals(ByteFlag.None) && found.Equals(flags))
                    break;
            }

            //if all found, then true.
            return found.Equals(flags);
        }
        /// <summary>
        /// True, if any byte failed to convert. Enumerating through ByteStatus, this will state which byte failed.
        /// </summary>
        public bool HasError => !string.IsNullOrWhiteSpace(_errorMessage);
        /// <summary>
        /// True if Unqualified or Minimal-Qualified character exists.
        /// </summary>
        public bool HasUnqualifiedCharacter => !string.IsNullOrWhiteSpace(_unQualifiedcodePoints);
        #endregion

        #region Private Helper (Existing methods)
        private ByteFlag GetByteFlags(string unicodeChar, int ndx = 0)
        {
            var byteFlags = ByteFlag.None;
            if (char.IsControl(unicodeChar, ndx))
                byteFlags |= ByteFlag.Control;
            if (char.IsHighSurrogate(unicodeChar, ndx))
                byteFlags |= ByteFlag.HighSurrogate;
            if (char.IsLowSurrogate(unicodeChar, ndx))
                byteFlags |= ByteFlag.LowSurrogate;
            if (char.IsSeparator(unicodeChar, ndx))
                byteFlags |= ByteFlag.Separator;
            if (char.IsSurrogate(unicodeChar, ndx))
                byteFlags |= ByteFlag.Surrogate;
            if (char.IsSurrogatePair(unicodeChar, ndx))
                byteFlags |= ByteFlag.SurrogatePair;
            if (char.IsSymbol(unicodeChar, ndx))
                byteFlags |= ByteFlag.Symbol;
            if (char.IsWhiteSpace(unicodeChar, ndx))
                byteFlags |= ByteFlag.WhiteSpace;
            if (char.IsLetter(unicodeChar, ndx))
                byteFlags |= ByteFlag.Letter;
            if (char.IsDigit(unicodeChar, ndx))
                byteFlags |= ByteFlag.Digit;
            if (char.IsPunctuation(unicodeChar, ndx))
                byteFlags |= ByteFlag.Punctuation;

            // This recursive call should only apply to the *first* char of the string if it's a surrogate pair,
            // not recursively check subsequent chars in a multi-char emoji string.
            // If unicodeChar itself is already a multi-char string (e.g., a ZWJ sequence),
            // then `unicodeChar[ndx]` correctly refers to each individual char.
            // However, `IsSurrogatePair` only checks `unicodeChar[ndx]` and `unicodeChar[ndx + 1]`.
            // The current recursive logic might be trying to combine flags from separate Unicode characters
            // which are part of a ZWJ sequence. This might be fine depending on your exact definition of ByteFlag for a "single byte".
            // If you want flags for *each* constituent Unicode character (UTF-32 code point), then `_byteFlags`
            // should probably hold flags per `_utf32Codes` entry, not just per .NET `char`.
            // Given your _byteFlags array size is codePointsList.Length, it seems you intend one ByteFlag per Unicode code point.
            // So, `unicodeChar` passed to `GetByteFlags` should ideally be a single converted character string,
            // not the entire combined emoji string.
            // Your current `ConvertToEmojiCharacter` calls `GetByteFlags(unicodeChar)` where `unicodeChar` is already
            // `char.ConvertFromUtf32(code)`, which means it's usually 1 or 2 `char`s representing a single UTF-32 codepoint.
            // So the recursion for `unicodeChar.Length > ndx + 1` here *is* for surrogate pairs within that single codepoint.
            if (unicodeChar.Length > ndx + 1)
                byteFlags |= GetByteFlags(unicodeChar, ndx + 1);

            return byteFlags;
        }

        /// <summary>
        /// Convert's multiple code points into an array of ints, "codes", to
        /// handle multiple code points for a single emoji.
        /// </summary>
        /// <param name="codePoints">Hex string of codepoints, each byte seperated by a space.</param>
        private void ConvertToEmojiCharacter(string codePoints, bool qualified)
        {
            if (string.IsNullOrWhiteSpace(codePoints))
                return;

            var vLoc = 0;
            var codePointsList = codePoints.Split(new[] { ' ', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            if (qualified)
            {
                _utf32Codes = new int[codePointsList.Length];
                _byteFlags = new ByteFlag[codePointsList.Length];
            }

            foreach (var codePoint in codePointsList)
            {
                try
                {
                    var strippedCP = codePoint.ToUpper().TrimStart('U').TrimStart('0');
                    // Corrected max length from 5 to 6 for full Unicode range (U+10FFFF is 6 hex digits)
                    if (strippedCP.Length > 6)
                        throw new Exception($"[{strippedCP}] (Str Len: {strippedCP.Length}) - Invalid single \"HEX\" code points.");

                    int code = int.Parse(strippedCP, NumberStyles.HexNumber);
                    var unicodeChar = char.ConvertFromUtf32(code);
                    sb.Append(unicodeChar);

                    if (qualified)
                    {
                        _utf32Codes[vLoc] = code;
                        // Get byte flags for the *single* Unicode character (which might be a surrogate pair)
                        _byteFlags[vLoc] = GetByteFlags(unicodeChar);
                    }
                }
                catch (Exception ex)
                {
                    if (qualified)
                    {
                        _utf32Codes[vLoc] = 0;
                        _errorMessage = ex.Message;
                    }
                    // Optionally, log this warning or throw a more specific exception
                    Debug.WriteLine($"Warning: Failed to process code point '{codePoint}'. Error: {ex.Message}");
                }
                finally
                {
                    vLoc++;
                }
            }

            if (qualified)
            {
                _emojiCharacter = sb.ToString();
                _length = _emojiCharacter.Length;
            }
            else
                _unQualifiedEmojiCharacter = sb.ToString();
        }
        #endregion

        #region Validate (Existing methods)
        public bool Equals(Emoji other) => this.CodePoints.Equals(other.CodePoints);
        #endregion

        #region Public Overrides (Existing methods)
        public override int GetHashCode() => this.CodePoints.GetHashCode();
        public override bool Equals(object obj) => obj is Emoji other && Equals(other);
        public override string ToString() => this.EmojiCharacter;
        #endregion

        private static class UnicodeImageRenderer
        {
            /// <summary>
            /// Renders a Unicode string (e.g., emoji) to a PNG image and returns the image as a byte array.
            /// </summary>
            public static byte[] RenderToPng(string text, int fontSize = 64)
            {
                if (string.IsNullOrEmpty(text))
                    throw new ArgumentNullException(nameof(text));

                string fontFamily = GetPlatformEmojiFont();

                using (var typeface = SKTypeface.FromFamilyName(fontFamily))
                using (var font = new SKFont(typeface, fontSize))
                using (var paint = new SKPaint { IsAntialias = true })
                {
                    SKRect bounds;
                    font.MeasureText(text, out bounds, paint);

                    int width = (int)Math.Ceiling(bounds.Width) + 4;
                    int height = (int)Math.Ceiling(bounds.Height) + 4;

                    using (var bitmap = new SKBitmap(width, height))
                    using (var canvas = new SKCanvas(bitmap))
                    {
                        canvas.Clear(SKColors.Transparent);

                        float x = -bounds.Left + 2;
                        float y = -bounds.Top + 2;

                        canvas.DrawText(text, x, y, font, paint);
                        canvas.Flush();

                        using (var image = SKImage.FromBitmap(bitmap))
                        using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                        {
                            return data.ToArray(); // Returns in-memory PNG
                        }
                    }
                }
            }
            /// <summary>
            /// Get Font name by OS
            /// </summary>
            /// <returns></returns>
            private static string GetPlatformEmojiFont()
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return "Segoe UI Emoji";
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    return "Apple Color Emoji";
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    return "Noto Color Emoji";          // Often available with emoji-supporting distros
                else
                    return "Segoe UI Emoji";
            }
        }

        private static class ConsoleDisplayHelper
        {
            /// <summary>
            /// Estimates the display width of a Unicode string in the console.
            /// </summary>
            public static int GetConsoleDisplayWidth(string input)
            {
                var enumerator = StringInfo.GetTextElementEnumerator(input);
                int totalWidth = 0;

                while (enumerator.MoveNext())
                {
                    string element = enumerator.GetTextElement();

                    totalWidth += GetCharacterDisplayWidth(element);
                }

                return totalWidth;
            }
            /// <summary>
            /// Returns the width of a single Unicode grapheme cluster.
            /// </summary>
            private static int GetCharacterDisplayWidth(string grapheme)
            {
                if (string.IsNullOrEmpty(grapheme)) return 0;

                var codePoint = Char.ConvertToUtf32(grapheme, 0);

                // Handle common emoji and wide character ranges
                if (IsWideUnicode(codePoint))
                    return 2;

                // Zero width joiners or modifiers
                if (IsZeroWidth(codePoint))
                    return 0;

                return 1;
            }
            private static bool IsZeroWidth(int codePoint)
            {
                return codePoint == 0x200D ||  // Zero-width joiner
                       (codePoint >= 0xFE00 && codePoint <= 0xFE0F); // Variation selectors
            }
            private static bool IsWideUnicode(int codePoint)
            {
                return
                    // CJK Unified Ideographs
                    (codePoint >= 0x1100 && codePoint <= 0x115F) || // Hangul Jamo init.
                    (codePoint >= 0x2329 && codePoint <= 0x232A) ||
                    (codePoint >= 0x2E80 && codePoint <= 0xA4CF) ||
                    (codePoint >= 0xAC00 && codePoint <= 0xD7A3) || // Hangul Syllables
                    (codePoint >= 0xF900 && codePoint <= 0xFAFF) ||
                    (codePoint >= 0xFE10 && codePoint <= 0xFE19) ||
                    (codePoint >= 0xFE30 && codePoint <= 0xFE6F) ||
                    (codePoint >= 0xFF00 && codePoint <= 0xFF60) ||
                    (codePoint >= 0x1F300 && codePoint <= 0x1F64F) || // Emoji
                    (codePoint >= 0x1F900 && codePoint <= 0x1F9FF);   // Supplemental emoji
            }
        }
    }
}