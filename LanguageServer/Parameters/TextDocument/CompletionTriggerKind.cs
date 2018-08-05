using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// How a completion was triggered
    /// </summary>
    /// <seealso>Spec 3.3.0</seealso>
    public enum CompletionTriggerKind
    {
        /// <summary>
        /// Completion was triggered by typing an identifier (24x7 code
        /// complete), manual invocation (e.g Ctrl+Space) or via API.
        /// </summary>
        Invoked = 1,
        /// <summary>
        /// Completion was triggered by a trigger character specified by
        /// the <c>triggerCharacters</c> properties of the <c>CompletionRegistrationOptions</c>.
        /// </summary>
        TriggerCharacter = 2,
        /// <summary>
        /// Completion was re-triggered as the current completion list is incomplete.
        /// </summary>
        TriggerForIncompleteCompletions = 3,
    }
}
