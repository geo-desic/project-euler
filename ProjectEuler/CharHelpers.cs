namespace ProjectEuler
{
    public static class CharHelpers
    {
        /// <summary>
        /// Swaps the two characters provided.
        /// </summary>
        public static void Swap(ref char a, ref char b)
        {
            if (a == b) return;
            (b, a) = (a, b);
        }

        /// <summary>
        /// Reverses the character array starting at the index provided.
        /// </summary>
        /// <param name="value">Array of characters to (partially) reverse.</param>
        /// <param name="startIndex">Starting index (inclusive) after which all characters will be reversed.</param>
        public static void Reverse(this char[] value, int startIndex = 0)
        {
            value.Reverse(startIndex, value.Length - 1);
        }

        /// <summary>
        /// Reverses the character array between the indexes provided (inclusive).
        /// </summary>
        /// <param name="value">Array of characters to (partially) reverse.</param>
        /// <param name="startIndex">Starting index (inclusive) for character reversal.</param>
        /// <param name="endIndex">Ending index (inclusive) for character reversal.</param>
        public static void Reverse(this char[] value, int startIndex, int endIndex)
        {
            for (var i = 0; i < (endIndex - startIndex + 1) / 2; ++i)
            {
                Swap(ref value[startIndex + i], ref value[endIndex - i]);
            }
        }
    }
}
