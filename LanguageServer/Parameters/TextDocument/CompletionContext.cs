using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/completion</c>
    /// </summary>
    /// <remarks>
    /// Contains additional information about the context in which a completion request is triggered.
    /// </remarks>
    /// <seealso>Spec 3.3.0</seealso>
    public class CompletionContext
    {
        /// <summary>
        /// How the completion was triggered.
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public CompletionTriggerKind triggerKind { get; set; }

        /// <summary>
        /// The trigger character (a single character) that has trigger code complete.
        /// Is undefined if <c>triggerKind !== CompletionTriggerKind.TriggerCharacter</c>
        /// </summary>
        /// <seealso>Spec 3.3.0</seealso>
        public string triggerCharacter { get; set; }
    }
}
