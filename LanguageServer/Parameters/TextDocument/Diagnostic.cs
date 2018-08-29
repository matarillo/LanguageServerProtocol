using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
	/// <summary>
	/// For <c>textDocument/codeAction</c> and <c>textDocument/publishDiagnostics</c>
	/// </summary>
	/// <seealso>Spec 3.7.0</seealso>
	public class Diagnostic
	{
		/// <summary>
		/// The range at which the message applies.
		/// </summary>
		public Range range { get; set; }

		/// <summary>
		/// The diagnostic's severity. Can be omitted.
		/// </summary>
		/// <remarks>
		/// If omitted it is up to the client to interpret diagnostics as error, warning, info or hint.
		/// </remarks>
		public DiagnosticSeverity? severity { get; set; }

		/// <summary>
		/// The diagnostic's code. Can be omitted.
		/// </summary>
		public NumberOrString code { get; set; }

		/// <summary>
		/// A human-readable string describing the source of this diagnostic,
		/// e.g. <c>'typescript'</c> or <c>'super lint'</c>.
		/// </summary>
		public string source { get; set; }

		/// <summary>
		/// The diagnostic's message.
		/// </summary>
		public string message { get; set; }

		/// <summary>
		/// An array of related diagnostic information.
		/// </summary>
		/// <remarks>
		/// e.g. when symbol-names within a scope collide
		/// all definitions can be marked via this property.
		/// </remarks>
		/// <seealso>Spec 3.7.0</seealso>
		public DiagnosticRelatedInformation[] relatedInformation { get; set; }
	}
}
