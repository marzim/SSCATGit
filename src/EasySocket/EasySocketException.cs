using System;

namespace JadBenAutho.EasySocket
{
	/// <summary>
	/// <c>EasySocketException</c> exception type for the <c>EasySocket</c> namespace.
	/// Handles exception on <c>EasyClient</c> and <c>EasyServer</c> objects.
	/// </summary>
	public class EasySocketException : ApplicationException
	{
		/// <summary>Generate empty exception.</summary>
		public EasySocketException()
			: base()
		{ }

		/// <summary>
		/// Generate exception with a error message.
		/// </summary>
		/// <param name="ErrorMessage">Error message.</param>
		public EasySocketException(string ErrorMessage)
			: base(ErrorMessage)
		{ }

		/// <summary>
		/// Generate exception with error message and InnerException.
		/// </summary>
		/// <param name="ErrorMessage">Error message.</param>
		/// <param name="InnerException">Exception that causes current exception.</param>
		public EasySocketException(string ErrorMessage, Exception InnerException)
			: base(ErrorMessage, InnerException)
		{ }

		//--------------------------------------------------------------------------
	}
}
