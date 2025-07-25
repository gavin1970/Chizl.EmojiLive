using Chizl.EmojiLive;
using System.Reflection;
using System.Text;

namespace ConsoleDemo
{
    internal class Program
    {
        const string _emojiNamespace = "Chizl.EmojiLive";
        const string _emojiBuildClass = "Emoji";
        static readonly string _groupSeps = (new string('*', 50));

        static List<Emoji> _animateTime = new() {
                EmojiTravelPlaces.TwelveOclock, EmojiTravelPlaces.TwelveThirty, EmojiTravelPlaces.OneOclock, EmojiTravelPlaces.OneThirty,
                EmojiTravelPlaces.TwoOclock, EmojiTravelPlaces.TwoThirty, EmojiTravelPlaces.ThreeOclock, EmojiTravelPlaces.ThreeThirty,
                EmojiTravelPlaces.FourOclock, EmojiTravelPlaces.FourThirty, EmojiTravelPlaces.FiveOclock, EmojiTravelPlaces.FiveThirty,
                EmojiTravelPlaces.SixOclock, EmojiTravelPlaces.SixThirty, EmojiTravelPlaces.SevenOclock, EmojiTravelPlaces.SevenThirty,
                EmojiTravelPlaces.EightOclock, EmojiTravelPlaces.EightThirty, EmojiTravelPlaces.NineOclock, EmojiTravelPlaces.NineThirty,
                EmojiTravelPlaces.TenOclock, EmojiTravelPlaces.TenThirty, EmojiTravelPlaces.ElevenOclock, EmojiTravelPlaces.ElevenThirty,
                EmojiTravelPlaces.TwelveOclock
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var emoJackOLantern = EmojiActivities.JackOLantern;
            var emoFilePath = $".\\";
            var emoFileName = $"{emoJackOLantern.Name}.png";

            DisplayEmoji(emoJackOLantern, false);
            if (emoJackOLantern.SaveEmoji(emoFilePath, emoFileName, EmojiImageFormat.Png, true))
            {
                var fgClr = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"'{emoFilePath}{emoFileName}' has been created.");
                Console.ForegroundColor = fgClr;
            }

            while (true)
            {
                Console.WriteLine("Press 'A' if you want to dump all emoji to screen.");
                Console.WriteLine("Press 'S' if you want to see some Emoji used in a string.");
                Console.WriteLine("Press 'Esc' to quit.");

                ConsoleKey ck = ConsoleKey.End;
                while (ck != ConsoleKey.A && ck != ConsoleKey.S && ck != ConsoleKey.Escape)
                    ck = Console.ReadKey(true).Key;

                Console.OutputEncoding = Encoding.UTF8;
                ClearScreen();

                if (ck.Equals(ConsoleKey.Escape))
                    break;
                if (ck.Equals(ConsoleKey.A))
                    ShowAllEmoji();
                else
                    ShowEmojiStings();

                Console.WriteLine("\nPress any key to clear.");
                Console.ReadKey(true);
                ClearScreen();
            }
        }
        /// <summary>
        /// Showing Emoji within a string.
        /// </summary>
        static void ShowEmojiStings()
        {
            var cnt = _animateTime.Count;
            Console.CursorVisible = false;

            Console.WriteLine($"There once was a {EmojiTravelPlaces.Snowman} who {EmojiSmileysEmotion.GrowingHeart} " +
                                $"to ride {EmojiTravelPlaces.Skateboard}s.  One day, while heading down a " +
                                $"steep {EmojiTravelPlaces.SnowCappedMountain}, the front right {EmojiTravelPlaces.Wheel} " +
                                $"came off. This caused the {EmojiTravelPlaces.Snowman} to fall into a " +
                                $"{EmojiTravelPlaces.Fire} and {EmojiSmileysEmotion.MeltingFace}.\n");

            DisplayEmoji(EmojiTravelPlaces.Snowman, false);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Check out the animation -> ");

            foreach (var emo in _animateTime)
            {
                var hr = (int)Math.Floor((cnt--) * .5);
                var emoShow = $"[{emo}] ({hr}) ";
                Console.Write(emoShow);

                Thread.Sleep(500);
                Console.CursorLeft -= emoShow.Length;
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.CursorVisible = true;
        }
        /// <summary>
        /// Using reflection to pull back all public emoji structs
        /// </summary>
        static void ShowAllEmoji()
        {
            var prevSubGroup = string.Empty;
            ConsoleKey ck = ConsoleKey.End;
            Assembly myAssembly = typeof(Emoji).GetTypeInfo().Assembly;
            Type[] typelist = GetStructTypesByNS(myAssembly, _emojiNamespace);

            Console.WriteLine("\nDo you want to see:\nF.  Fully Qualified\nN.  Not Fully Qualified\nB.  Both");

            while (ck != ConsoleKey.F && ck != ConsoleKey.N && ck != ConsoleKey.B)
                ck = Console.ReadKey(true).Key;

            var fq = ck.Equals(ConsoleKey.B) ? true : ck.Equals(ConsoleKey.F);
            var nq = ck.Equals(ConsoleKey.B) ? true : ck.Equals(ConsoleKey.N);

            ClearScreen();

            var totalEmojies = 0;
            for (int i = 0; i < typelist.Length; i++)
            {
                totalEmojies += typelist[i].GetProperties().Length;
                foreach (var p in typelist[i].GetProperties())
                {
                    var emojiObj = p.GetValue(0);
                    if (emojiObj == null)
                        continue;

                    Emoji emoji = (Emoji)emojiObj;

                    if (!fq && !emoji.HasUnqualifiedCharacter)
                        continue;

                    if (string.IsNullOrWhiteSpace(prevSubGroup) || !prevSubGroup.Equals(emoji.SubGroup))
                    {
                        //Console.WriteLine($"\nGroup: {emoji.Group}, Subgroup: {emoji.SubGroup}");
                        Console.WriteLine($"{_groupSeps}\n" +
                                          $"Group: {emoji.Group}, Subgroup: {emoji.SubGroup}\n" +
                                          $"{_groupSeps}");
                        prevSubGroup = emoji.SubGroup;
                    }

                    if (fq)
                        DisplayEmoji(emoji, true);

                    if (emoji.HasUnqualifiedCharacter && nq)
                    {
                        var addSpace = new string(' ', emoji.Length - emoji.UnqualifiedEmojiCharacter.Length);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"- [{emoji.UnqualifiedEmojiCharacter}]> {addSpace}{emoji.Name} - ({emoji.UnqualifiedCodePoints}), Length: {emoji.UnqualifiedEmojiCharacter.Length}");
                        Console.ResetColor();
                    }
                }
            }

            Console.WriteLine($"\nTotal ({typelist.Length}) Groups w/ ({totalEmojies}) Emojis captured.");
        }
        /// <summary>
        /// Retrieves all types for a specific namespaces within an assembly.
        /// </summary>
        /// <param name="asm">Assembly object to search</param>
        /// <param name="ns">Namespace to find within assembly</param>
        /// <returns>Array of types found</returns>
        static Type[] GetStructTypesByNS(Assembly asm, string ns)
        {
            var types = asm.GetTypes()
                    .Where(t => string.Equals(
                        t.Namespace,
                        ns,
                        StringComparison.CurrentCultureIgnoreCase))
                    .ToArray();

            return types
                    .Where(w => w.Name.StartsWith(_emojiBuildClass) &&
                        w.BaseType != null &&
                        w.BaseType.Equals(typeof(ValueType)))
                    .ToArray();
        }
        /// <summary>
        /// Display some info on the structured class.
        /// </summary>
        static void DisplayEmoji(Emoji emoji, bool simple)
        {
            if(simple)
                Console.WriteLine($"[{emoji}] {emoji.Name}  -  \"{emoji.FullName}\"");
            else
                Console.WriteLine($"[{emoji}] Usage: {emoji.Group}.{emoji.Name} \n" +
                                        $"Name: {emoji.Name}, Display Name: \"{emoji.FullName}\"\n" +
                                        $"String Length: {emoji.Length}, Display Width: {emoji.EmojiDisplayWidth}, Version: {emoji.Version}\n" +
                                        $"Group: {emoji.Group}, Subgroup: {emoji.SubGroup}\n" +
                                        $"CodePoints: {emoji.CodePoints}, Codes: {string.Join(", ", emoji.UTF32Codes)}\n" +
                                        $"Flags: ({String.Join(", ", emoji.ByteFlags)})\n");
        }
        /// <summary>
        /// \u001b itself is the Escape character (ASCII code 27).<br/>
        /// The following 'c' is a literal character within the sequence and in this case means: clean or clear.<br/>
        /// <br/>
        /// This follow might not be required in some cases.  The above can clear the buffer, but if a deeper dive is required, continue with the following.<br/>
        /// <br/>
        /// \x1b or \u001b: is the Escape character.<br/>
        /// [3J: This is an ANSI escape sequence that clears the entire terminal screen.<br/>
        /// - [ : Introduces the control sequence.<br/>
        /// - 3 : Specifies the type of screen clearing.<br/>
        /// - J : Indicates the action(clear screen).<br/>
        /// </summary>
        static void ClearScreen() => Console.Write("\u001bc\x1b[3J"); //cursor will be sitting at X: 0, Y: 0
    }
}
