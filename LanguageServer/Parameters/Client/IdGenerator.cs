using LanguageServer.Json;

namespace LanguageServer.Parameters.Client
{
    /// <summary>
    /// The id generator class for request messages from the server to the client.
    /// </summary>
    public class IdGenerator
    {
        /// <summary>
        /// The globally shared instance of <see cref="IdGenerator"/>.
        /// </summary>
        public static IdGenerator Instance = new IdGenerator();

        private long _id;

        /// <summary>
        /// Initializes a new instance of <see cref="IdGenerator"/>.
        /// </summary>
        public IdGenerator()
        {
            _id = 0L;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IdGenerator"/> with the specified initial value.
        /// </summary>
        public IdGenerator(long initialValue)
        {
            _id = initialValue;
        }

        /// <summary>
        /// Returns an id and increments the internal value.
        /// </summary>
        /// <returns></returns>
        public NumberOrString Next()
        {
            var ns = new NumberOrString(_id);
            _id = (_id == long.MaxValue) ? 0L : _id + 1;
            return ns;
        }
    }
}
