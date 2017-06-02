using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.General
{
    public class TextDocumentSyncOptions
    {
        public bool? openClose { get; set; }
        public TextDocumentSyncKind? change { get; set; }
        public bool? willSave { get; set; }
        public bool? willSaveWaitUntil { get; set; }
        public SaveOptions save { get; set; }
    }

    public class SaveOptions
    {
        public bool? includeText { get; set; }
    }

    public class CompletionOptions
    {
        public bool? resolveProvider { get; set; }

        public string[] triggerCharacters { get; set; }
    }

    public class SignatureHelpOptions
    {
        public string[] triggerCharacters { get; set; }
    }

    public class CodeLensOptions
    {
        public bool? resolveProvider { get; set; }
    }

    public class DocumentOnTypeFormattingOptions
    {
        public string firstTriggerCharacter { get; set; }

        public string[] moreTriggerCharacter { get; set; }
    }

    public class DocumentLinkOptions
    {
        public bool? resolveProvider { get; set; }
    }

    public class ExecuteCommandOptions
    {
        public string[] commands { get; set; }
    }
}
