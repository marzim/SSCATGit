// <copyright file="PsxContexts.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.PsxDisplay
{
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the PsxContexts class
    /// </summary>
    public class PsxContexts
    {
        /// <summary>
        /// List of PSX contexts
        /// </summary>
        private PsxContext[] _contexts;

        /// <summary>
        /// Gets or sets the PSX contexts
        /// </summary>
        [XmlElement("Context")]
        public PsxContext[] Contexts
        {
            get { return _contexts; }
            set { _contexts = value; }
        }

        /// <summary>
        /// Gets a context by name
        /// </summary>
        /// <param name="contextName">context name</param>
        /// <returns>Returns the context if found, null otherwise</returns>
        public PsxContext GetContext(string contextName)
        {
            foreach (PsxContext context in Contexts)
            {
                if (context.Name.Equals(contextName))
                {
                    return context;
                }
            }

            return null;
        }
    }
}
