using AnnouncementWebApi.Entities;

namespace AnnouncementWebApi.Helpers
{
    public static class TextHelper
    {
        public static readonly HashSet<string> StopWords = new HashSet<string>
        {
            "the", "a", "an", "for", "in", "on", "at", "of", "and", "but", "or", "as", "with", "by", "is", "it", "this", "that"
        };

        public static HashSet<string> GetWords(string text)
        {
            return new HashSet<string>(
                text.Split(new[] { ' ', ',', '.', ';', ':', '-', '_', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(word => !StopWords.Contains(word, StringComparer.OrdinalIgnoreCase)),
                StringComparer.OrdinalIgnoreCase);
        }
    }

    public static class AnnouncementComparer
    {
        public static (int TitleMatchCount, int DescriptionMatchCount) GetMatchingWordCount(Announcement main, Announcement compareTo)
        {
            var mainTitleWords = TextHelper.GetWords(main.Title);
            var compareToTitleWords = TextHelper.GetWords(compareTo.Title);
            var titleMatchCount = mainTitleWords.Intersect(compareToTitleWords).Count();

            var mainDescriptionWords = TextHelper.GetWords(main.Description);
            var compareToDescriptionWords = TextHelper.GetWords(compareTo.Description);
            var descriptionMatchCount = mainDescriptionWords.Intersect(compareToDescriptionWords).Count();

            return (titleMatchCount, descriptionMatchCount);
        }
    }
}
