

namespace StaffTrackApp.SAL.Helpers
{
    public static class ObjectExtensions
    {
        public static List<string> ToFormattedString<T>(this List<T> objects)
        {
            if (objects == null || !objects.Any())
            {
                throw new ArgumentException("Список объектов не может быть пустым");
            }

            var formattedStrings = objects.Select(obj =>
            {
                var type = obj.GetType();
                var properties = type.GetProperties();

                var values = properties.Select(prop =>
                {
                    var value = prop.GetValue(obj);
                    return $"{prop.Name}: {value}";
                });

                return string.Join(", ", values);
            }).ToList();

            return formattedStrings;
        }
    }
}
