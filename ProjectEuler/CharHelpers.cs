namespace ProjectEuler
{
    public static class CharHelpers
    {
        public static void Swap(ref char a, ref char b)
        {
            if (a == b) return;
            var temp = a;
            a = b;
            b = temp;
        }

        public static void Reverse(this char[] value, int startIndex = 0)
        {
            value.Reverse(startIndex, value.Length - 1);
        }

        public static void Reverse(this char[] value, int startIndex, int endIndex)
        {
            for (var i = 0; i < (endIndex - startIndex + 1) / 2; ++i)
            {
                Swap(ref value[startIndex + i], ref value[endIndex - i]);
            }
        }
    }
}
