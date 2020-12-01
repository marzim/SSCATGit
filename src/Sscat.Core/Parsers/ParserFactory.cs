//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="ac185120@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Util;
using Sscat.Core.Config;
using Sscat.Core.Util;

namespace Sscat.Core.Parsers
{
	[Obsolete("Please refrain from using weird factory classes.")]
	public class ParserFactory
	{
		LaneConfiguration config;
		
		public ParserFactory() // TODO: Remove this!
		{
		}
		
		public ParserFactory(LaneConfiguration config)
		{
			this.config = config;
		}
		
		public IParser CreatePsxParser()
		{
			return CreatePsxParser(null);
		}
		
		public IParser CreatePsxParser(IExtendedTextReader reader)
		{
//			return new EventParser(
//				"PSX Log",
//				reader,
//				new ParserPattern(ParserPattern.Psx, new PsxEventAdder())
//			);
			return config.Parsers.GetParser("Psx").Instantiate(reader);
		}
		
		public IParser CreateLaunchPadPsxParser()
		{
			return CreatePsxParser(null);
		}
		
		public IParser CreateLaunchPadPsxParser(IExtendedTextReader reader)
		{
//			return new EventParser(
//				"Launch Pad PSX Log",
//				reader,
//				new ParserPattern(ParserPattern.Psx, new PsxEventAdder())
//			);
			return config.Parsers.GetParser("LaunchPadPsx").Instantiate(reader);
		}
		
		public IParser CreateTraceParser()
		{
			return CreateTraceParser(null);
		}
		
		public IParser CreateTraceParser(IExtendedTextReader reader)
		{
//			return new EventParser(
//				"Trace Log",
//				reader,
//				new ParserPattern(ParserPattern.Scale, new DeviceEventAdder(Constants.DeviceType.Scale)),
//				new ParserPattern(ParserPattern.Scanner, new ScannerDeviceEventAdder()),
//				new ParserPattern(ParserPattern.Scanner3207, new Scanner3207DeviceEventAdder()),
//				new ParserPattern(ParserPattern.DeviceError, new DeviceEventAdder(Constants.DeviceType.DeviceError)),
//				new ParserPattern(ParserPattern.ReceiptItem, new ReceiptItemDeviceEventAdder()),
//				new ParserPattern(ParserPattern.ReceiptItemBase, new ReceiptItemDeviceEventAdder()),
//				new ParserPattern(ParserPattern.Msr, new MsrDeviceEventAdder()),
//				new ParserPattern("Parse DM evt 0, dev 15", new CashOrCoinDeviceEventAdder(Constants.DeviceType.CashAcceptor)),
//				new ParserPattern("Parse DM evt 0, dev 16", new CashOrCoinDeviceEventAdder(Constants.DeviceType.CoinAcceptor)),
//				new ParserPattern(ParserPattern.SignatureCapture, new DeviceEventAdder(Constants.DeviceType.SignatureCapture)),
//				new ParserPattern(ParserPattern.PinPad, new PinPadDeviceEventAdder()),
//				new ParserPattern(ParserPattern.PinPadCancel, new PinPadCancelDeviceEventAdder()),
//				new ParserPattern(ParserPattern.CouponSlip, new CouponSlipDeviceEventAdder()),
//				new ParserPattern(ParserPattern.AmountAndTaxDue, new AmountAndTaxDueDeviceEventAdder())
//			);
			return config.Parsers.GetParser("Trace").Instantiate(reader);
		}
		
		public IParser CreateSMParser()
		{
			return CreateSMParser(null);
		}
		
		public IParser CreateSMParser(IExtendedTextReader reader)
		{
//			return new EventParser(
//				"SM Log",
//				reader,
//				new ParserPattern(ParserPattern.BagScale, new DeviceEventAdder(Constants.DeviceType.BagScale))
//			);
			return config.Parsers.GetParser("SM").Instantiate(reader);
		}
		
		public IParser CreateFLMParser()
		{
			return CreateFLMParser(null);
		}
		
		public IParser CreateFLMParser(IExtendedTextReader reader)
		{
//			return new EventParser(
//				"FLM Bak Log",
//				reader,
//				new ParserPattern(ParserPattern.WalmartMCXMSR, new WalmartMCXMSRAdder()),
//				new ParserPattern(ParserPattern.WalmartMCXShoppingCard, new WalmartMCXShoppingCardAdder()),
//				new ParserPattern(ParserPattern.WalmartMCXMoneyTransfer, new WalmartMCXMoneyTransferAdder()),
//				new ParserPattern(ParserPattern.WalmartMCXDebitCard, new WalmartMCXDebitCardAdder())
//			);
			return config.Parsers.GetParser("FLM").Instantiate(reader);
		}
	}
}
