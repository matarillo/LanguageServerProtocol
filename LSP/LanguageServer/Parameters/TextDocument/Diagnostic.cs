using LanguageServer.Json;

namespace LanguageServer.Parameters.TextDocument
{
    public class Diagnostic
    {
        public Range range { get; set; }

	    public DiagnosticSeverity? severity { get; set; }

	    public NumberOrString code { get; set; }

        public string source { get; set; }

    	public string message { get; set; }
    }
}