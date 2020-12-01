using System;

namespace PsxNet
{
	public class PsxException : Exception
	{	
		private readonly PsxError error;
		
		public PsxException(PsxError err) : base(PsxErrorToString(err))
		{
			this.error = err;
		}
		
		public PsxError Error {
			get { return this.error; }
		}		

		public static bool IsError(PsxError err)
		{
			return (err >= PsxError.Fail);
		}

		private static string PsxErrorToString(PsxError err)
		{
			switch (err) {
				case PsxError.Success:
					return "Success";

				case PsxError.SuccessDontSynchronize:
					return "Success but not synchronized";

				case PsxError.ValueIdentical:
					return "Value identical";

				case PsxError.AlreadyInitialized:
					return "Already initialized";

				case PsxError.Fail:
					return "General failure";

				case PsxError.DisplayEngineApi:
					return "Display engine API call failed";

				case PsxError.InvalidParam:
					return "Invalid parameter";

				case PsxError.NotSupported:
					return "Operation not supported";

				case PsxError.ReceiptSourceNotFound:
					return "Receipt data source not found";

				case PsxError.ReceiptItemNoParent:
					return "Parent receipt item not found";

				case PsxError.ReceiptParentIsSubItem:
					return "Parent receipt item of new item cannot be a subitem";

				case PsxError.ReceiptItemNotFound:
					return "Receipt item not found";

				case PsxError.ReceiptItemExists:
					return "Receipt item already exists";

				case PsxError.ReceiptItemVarNotFound:
					return "Receipt variable not found";

				case PsxError.StartServerFail:
					return "Failed to start Psx server";

				case PsxError.ConnectionInvalid:
					return "Remote connection does not exist";

				case PsxError.ConnectionExists:
					return "Remote connection name already exists";

				case PsxError.InvalidHandle:
					return "Invalid handle";

				case PsxError.InvalidControl:
					return "Invalid control";

				case PsxError.NotInitialized:
					return "Not initialized";

				case PsxError.TimeOut:
					return "Operation timed out";
			}
			return "Unknown error";
		}
	}
}