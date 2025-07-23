using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;

namespace Framework48FormsDemo
{
    // --- Add this static class to your DLL for image generation (used by your auto-gen tool) ---
    // You can put this in a separate file (e.g., EmojiImageGenerator.cs) within your Chizl.EmojiLive project.
    internal static class EmojiImageGenerator
    {
        /// <summary>
        /// Renders text (like an emoji character string) into an Image.
        /// This method is intended for your auto-generation tool to create the embedded images.
        /// </summary>
        public static Image BuildImage(string text)
        {
            Color fgColor = Color.Empty;
            Color bgColor = Color.Empty;

            // Create a dummy bitmap to measure the string size
            using (Bitmap dummyImage = new Bitmap(1, 1))
            using (Graphics dummyGraphics = Graphics.FromImage(dummyImage))
            using (Font font = new Font("Segoe UI Emoji", 80, FontStyle.Regular))
            {
                // Set high quality text rendering for accurate measurement
                dummyGraphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit; // Or AntiAlias

                SizeF sizeF = dummyGraphics.MeasureString(text, font);

                // Create the actual image with the calculated size
                // Add a small buffer to width/height to ensure no clipping, especially for complex emojis
                int width = (int)Math.Ceiling(sizeF.Width) + 2;
                int height = (int)Math.Ceiling(sizeF.Height) + 2;

                using (Bitmap image = new Bitmap(width, height))
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.Clear(bgColor); // Fill background
                    graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit; // Ensure smooth text rendering

                    using (Brush brush = new SolidBrush(fgColor))
                    {
                        // Draw the string. You might need to adjust the position slightly (e.g., 1f, 1f)
                        // if you added padding to the width/height
                        graphics.DrawString(text, font, brush, 1f, 1f);
                    }

                    // Return a clone to ensure the original Bitmap is not disposed prematurely
                    // when the 'using' block exits. The caller is responsible for disposing the returned Image.
                    return (Image)image.Clone();
                }
            }
        }
    }
}
