using System;
	
namespace PsxNet
{
	public enum PsxError
	{
		Success,
		SuccessDontSynchronize,
		ValueIdentical,
		AlreadyInitialized,
		Fail,
		DisplayEngineApi,
		InvalidParam,
		NotSupported,
		ReceiptSourceNotFound,
		ReceiptItemNoParent,
		ReceiptParentIsSubItem,
		ReceiptItemNotFound,
		ReceiptItemExists,
		ReceiptItemVarNotFound,
		StartServerFail,
		ConnectionInvalid,
		ConnectionExists,
		InvalidHandle,
		InvalidControl,
		NotInitialized,
		TimeOut
	}
}