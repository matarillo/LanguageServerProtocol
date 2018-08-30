using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageServer.Parameters.TextDocument
{
    /// <summary>
    /// For <c>textDocument/signatureHelp</c>
    /// </summary>
    public class SignatureHelp
    {
        /// <summary>
        /// One or more signatures.
        /// </summary>
        public SignatureInformation[] signatures { get; set; }

        /// <summary>
        /// The active signature.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If omitted or the value lies outside the
        /// range of <c>signatures</c> the value defaults to zero or is ignored if
        /// <c>signatures.length === 0</c>. Whenever possible implementors should
        /// make an active decision about the active signature and shouldn't
        /// rely on a default value.
        /// </para>
        /// <para>
        /// In future version of the protocol this property might become
        /// mandatory to better express this.
        /// </para>
        /// </remarks>
        public int? activeSignature { get; set; }

        /// <summary>
        /// The active parameter of the active signature.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If omitted or the value
        /// lies outside the range of <c>signatures[activeSignature].parameters</c>
        /// defaults to 0 if the active signature has parameters. If
        /// the active signature has no parameters it is ignored.
        /// </para>
        /// <para>
        /// In future version of the protocol this property might become
        /// mandatory to better express the active parameter if the
        /// active signature does have any.
        /// </para>
        /// </remarks>
        public int? activeParameter { get; set; }
    }
}
