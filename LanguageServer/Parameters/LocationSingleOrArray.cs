using LanguageServer.Json;

namespace LanguageServer.Parameters
{
    public class LocationSingleOrArray : Either
    {
        public static implicit operator LocationSingleOrArray(Location value)
            => new LocationSingleOrArray(value);

        public static implicit operator LocationSingleOrArray(Location[] value)
            => new LocationSingleOrArray(value);

        public LocationSingleOrArray(Location value)
        {
            Type = typeof(Location);
            Value = value;
        }

        public LocationSingleOrArray(Location[] value)
        {
            Type = typeof(Location[]);
            Value = value;
        }

        public bool IsSingle => Type == typeof(Location);

        public bool IsArray => Type == typeof(Location[]);

        public Location Single => GetValue<Location>();

        public Location[] Array => GetValue<Location[]>();
    }
}
