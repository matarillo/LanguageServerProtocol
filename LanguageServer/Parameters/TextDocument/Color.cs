namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// Represents a color in RGBA space.
    /// For <c>textDocument/documentColor</c> and <c>textDocument/colorPresentation</c>
    /// </summary>
    /// <remarks>
    /// Underlying values should be in the range <c>0.0</c> to <c>1.0</c>.
    /// Any values outside the range will be clamped to this range.
    /// <c>NaN</c> will be converted to <c>0.0</c>.
    /// </remarks>
    /// <seealso>Spec 3.6.0</seealso>
    public struct Color
    {
        /// <summary>
        /// The red component of this color in the range [0-1].
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public readonly double red;

        /// <summary>
        /// The green component of this color in the range [0-1].
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public readonly double green;

        /// <summary>
        /// The blue component of this color in the range [0-1].
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public readonly double blue;

        /// <summary>
        /// The alpha component of this color in the range [0-1].
        /// </summary>
        /// <seealso>Spec 3.6.0</seealso>
        public readonly double alpha;

        private const double MaxByte = (double)byte.MaxValue;

        /// <summary>
        /// Initializes a new instance of the <c>Color</c> struct with the specified color components.
        /// </summary>
        /// <param name="red"></param>
        /// <param name="green"></param>
        /// <param name="blue"></param>
        /// <param name="alpha"></param>
        public Color(double red, double green, double blue, double alpha)
        {
            this.red = Clamp(red);
            this.green = Clamp(green);
            this.blue = Clamp(blue);
            this.alpha = Clamp(alpha);
        }

        private static double Clamp(double value)
        {
            if (double.IsNaN(value))
                return 0.0;
            if (value > 1.0)
                return 1.0;
            if (value < 0.0)
                return 0.0;
            return value;
        }

        /// <summary>
        /// Gets the red component value of this <c>Color</c> structure as a byte value.
        /// </summary>
        public byte RedByte => (byte)(MaxByte * red);

        /// <summary>
        /// Gets the green component value of this <c>Color</c> structure as a byte value.
        /// </summary>
        public byte GreenByte => (byte)(MaxByte * green);

        /// <summary>
        /// Gets the blue component value of this <c>Color</c> structure as a byte value.
        /// </summary>
        public byte BlueByte => (byte)(MaxByte * blue);

        /// <summary>
        /// Gets the alpha component value of this <c>Color</c> structure as a byte value.
        /// </summary>
        public byte AlphaByte => (byte)(MaxByte * alpha);

        private double DiscreteAlpha => (double)AlphaByte / MaxByte;

        /// <summary>
        /// Gets the RGB value of this <c>Color</c> structure as a numeric triplet
        /// in the functional notation like <c>rgb(255, 255, 255)</c>.
        /// </summary>
        public string RGB => $"rgb({RedByte}, {GreenByte}, {BlueByte})";

        /// <summary>
        /// Gets the RGBA value of this <c>Color</c> structure as a numeric quadruplet
        /// in the functional notation like <c>rgba(255, 255, 255, 1)</c>.
        /// </summary>
        public string RGBA => $"rgba({RedByte}, {GreenByte}, {BlueByte}, {DiscreteAlpha})";

        /// <summary>
        /// Gets the RGB value of this <c>Color</c> structure as a six digit hex value
        /// with a leading hash character like <c>#ffffff</c>.
        /// </summary>
        public string HexRGB => $"#{RedByte:x2}{GreenByte:x2}{BlueByte:x2}";

        /// <summary>
        /// Gets the RGBA value of this <c>Color</c> structure as a eight digit hex value
        /// with a leading hash character like <c>#ffffffff</c>.
        /// </summary>
        public string HexRGBA => $"#{RedByte:x2}{GreenByte:x2}{BlueByte:x2}{AlphaByte:x2}";

        /// <summary>
        /// Converts this <c>Color</c> structure to a human-readable string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => RGBA;
    }
}
