namespace Tk.Extensions.Search
{
    public static class StringExtensions
    {
        public static int LevenshteinDistance(this string value, string comparand, StringComparer comparer)
            => value.NaiveLevenshteinDistance(comparand, comparer);

        public static int LevenshteinDistance(this string value, string comparand)
            => value.NaiveLevenshteinDistance(comparand, StringComparer.InvariantCulture);

        private static int NaiveLevenshteinDistance(this string value, string comparand, StringComparer comparer)
        {
            if (value.Length == 0) return comparand.Length;
            if (comparand.Length == 0) return value.Length;

            var distance = new int[value.Length + 1, comparand.Length + 1];

            for(var i = 1; i <= value.Length; i++) distance[i, 0] = i;
            for(var j = 1; j <= comparand.Length; j++) distance[0, j] = j;

            for (var j = 1; j <= comparand.Length; j++)
            {
                for (var i = 1; i <= value.Length; i++)
                {                    
                    var equal = comparer.Equals(value[i - 1], comparand[j - 1]);
                    
                    var cost = equal ? 0 : 1;

                    distance[i, j] = Math.Min(distance[i - 1, j] + 1, 
                                                Math.Min(distance[i, j - 1] + 1,
                                                         distance[i - 1, j - 1] + cost));
                }
            }

            return distance[value.Length, comparand.Length];
        }
    }
}
