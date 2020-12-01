//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Tests.Config;

namespace Sscat.Tests.Parsers
{
	[TestFixture]
	public class XmodeParserTests
	{
		IExtendedTextReader log;
		IParser parser;
		
		[SetUp]
		public void Setup()
		{
			log = new ExtendedStringReader(@"XM: 11/06 22:24:46   180242655 8A0> * COUNTS AFTER CHANGES: ndisp: [1:15,5:3,25:2,100:1;100:6,200:0,500:2,1000:1,2000:0,5000:0,10000:0]; disp: [1:110,5:100,10:100,25:100;100:3000,500:1500,1000:750] *
XM: 11/06 22:22:51   180127439 8A0> +XMCashManagementBase::PrintReceipt
XM: 11/06 22:22:51   180127439 8A0> +XMCashManagementBase::BuildCashManagementPrintData
XM: 11/06 22:22:51   180127439 8A0> +XMCashManagementBase::BuildCashmanagementHeader
XM: 11/06 22:22:51   180127439 8A0> +TBWrapperBase::GetTerminalNumber
XM: 11/06 22:22:51   180127439 8A0> -TBWrapperBase::GetTerminalNumber
XM: 11/06 22:22:51   180127439 8A0> +XMRegWrapper::XMRegWrapper
XM: 11/06 22:22:51   180127439 8A0> -XMRegWrapper::XMRegWrapper
XM: 11/06 22:22:51   180127439 8A0> +XMRegWrapper::Open
XM: 11/06 22:22:51   180127439 8A0> -XMRegWrapper::Open
XM: 11/06 22:22:51   180127439 8A0> +XMRegWrapper::ReadDWORD
XM: 11/06 22:22:51   180127439 8A0> Read [sequence = 11]
XM: 11/06 22:22:51   180127439 8A0> -XMRegWrapper::ReadDWORD
XM: 11/06 22:22:51   180127439 8A0> Sequence number is incremented
XM: 11/06 22:22:51   180127439 8A0> +XMRegWrapper::WriteDWORD
XM: 11/06 22:22:51   180127449 8A0> Write [sequence = 12]
XM: 11/06 22:22:51   180127449 8A0> -XMRegWrapper::WriteDWORD
XM: 11/06 22:22:51   180127449 8A0> +XMRegWrapper::~XMRegWrapper
XM: 11/06 22:22:51   180127449 8A0> +XMRegWrapper::Close
XM: 11/06 22:22:51   180127449 8A0> -XMRegWrapper::Close
XM: 11/06 22:22:51   180127449 8A0> -XMRegWrapper::~XMRegWrapper
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::JustifyData
XM: 11/06 22:22:51   180127449 8A0> Justified Data: [             Sequence Number 12]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::JustifyData
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::JustifyData
XM: 11/06 22:22:51   180127449 8A0> Justified Data: [                  10:22 PM]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::JustifyData
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::JustifyData
XM: 11/06 22:22:51   180127449 8A0> Justified Data: [             Terminal Number 1]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::JustifyData
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::JustifyData
XM: 11/06 22:22:51   180127449 8A0> Justified Data: [        Wednesday, November 06, 2013]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::JustifyData
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::JustifyData
XM: 11/06 22:22:51   180127449 8A0> Justified Data: [           Cash Management Report]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::JustifyData
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::JustifyData
XM: 11/06 22:22:51   180127449 8A0> Justified Data: [        NCR SelfServ Checkout Report]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::JustifyData
XM: 11/06 22:22:51   180127449 8A0> Header: [        NCR SelfServ Checkout Report
----------------------------------------
           Cash Management Report
        Wednesday, November 06, 2013
             Terminal Number 1
                  10:22 PM
             Sequence Number 12

]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::BuildCashmanagementHeader
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::BuildCashmanagementDataByDevice
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Bins], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [29], Last Field: [Change in Count]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Bins                  Count  Change in Count]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.01], Count: [15], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.05], Count: [3], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.25], Count: [2], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$1.00], Count: [1], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$1.00], Count: [6], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$1.00], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$1.00                     6                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$2.00], Count: [0], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$2.00], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$2.00                     0                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$5.00], Count: [2], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$5.00], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$5.00                     2                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$10.00], Count: [1], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$10.00], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$10.00                    1                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$20.00], Count: [0], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$20.00], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$20.00                    0                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$50.00], Count: [0], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$50.00], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$50.00                    0                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$100.00], Count: [0], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$100.00], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$100.00                   0                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> TotalCount: [9], Total ChangeInCount: [0], TotalValue: [$26.00], Total ChangeInValue: [$0.00]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Total Count:], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Total Count:              9                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Total Value:], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [39], Last Field: [$0.00]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Total Value:         $26.00            $0.00]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::BuildCashmanagementDataByDevice
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::BuildCashmanagementDataByDevice
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Bins], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [29], Last Field: [Change in Count]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Bins                  Count  Change in Count]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.01], Count: [15], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$0.01], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$0.01                    15                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.05], Count: [3], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$0.05], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$0.05                     3                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.25], Count: [2], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$0.25], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$0.25                     2                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$1.00], Count: [1], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$1.00], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$1.00                     1                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$1.00], Count: [6], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$2.00], Count: [0], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$5.00], Count: [2], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$10.00], Count: [1], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$20.00], Count: [0], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$50.00], Count: [0], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$100.00], Count: [0], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> TotalCount: [21], Total ChangeInCount: [0], TotalValue: [$1.80], Total ChangeInValue: [$0.00]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Total Count:], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Total Count:             21                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Total Value:], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [39], Last Field: [$0.00]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Total Value:          $1.80            $0.00]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::BuildCashmanagementDataByDevice
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::BuildCashmanagementDataByDevice
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Bins], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [29], Last Field: [Change in Count]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Bins                  Count  Change in Count]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.01], Count: [110], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.05], Count: [100], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.10], Count: [100], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.25], Count: [90], ChangeInCount: [-10]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$1.00], Count: [3000], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$1.00], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$1.00                  3000                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$5.00], Count: [1500], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$5.00], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$5.00                  1500                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$10.00], Count: [750], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$10.00], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$10.00                  750                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> TotalCount: [5250], Total ChangeInCount: [0], TotalValue: [$18,000.00], Total ChangeInValue: [$0.00]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Total Count:], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Total Count:           5250                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Total Value:], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [39], Last Field: [$0.00]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Total Value:     $18,000.00            $0.00]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [29], Last Field: [Change in Count]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [                      Count  Change in Count]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Purge Operations:], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Purge Operations:         0                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::BuildCashmanagementDataByDevice
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::BuildCashmanagementDataByDevice
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Bins], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [29], Last Field: [Change in Count]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Bins                  Count  Change in Count]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.01], Count: [110], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$0.01], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$0.01                   110                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.05], Count: [100], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$0.05], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$0.05                   100                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.10], Count: [100], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$0.10], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [43], Last Field: [0]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$0.10                   100                0]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$0.25], Count: [90], ChangeInCount: [-10]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [$0.25], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [41], Last Field: [-10]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [$0.25                    90              -10]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$1.00], Count: [3000], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$5.00], Count: [1500], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> Denomination: [$10.00], Count: [750], ChangeInCount: [0]
XM: 11/06 22:22:51   180127449 8A0> TotalCount: [400], Total ChangeInCount: [-10], TotalValue: [$38.60], Total ChangeInValue: [($2.50)]
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Total Count:], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [41], Last Field: [-10]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Total Count:            400              -10]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Total Value:], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [37], Last Field: [($2.50)]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Total Value:         $38.60          ($2.50)]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::BuildCashmanagementDataByDevice
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Coins Subtotal:], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [37], Last Field: [($2.50)]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Coins Subtotal:      $40.40          ($2.50)]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Bills Subtotal:], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [39], Last Field: [$0.00]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Bills Subtotal:  $18,026.00            $0.00]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> +XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> First Field: [Grand Total:], Position: [27]
XM: 11/06 22:22:51   180127449 8A0> Position: [37], Last Field: [($2.50)]
XM: 11/06 22:22:51   180127449 8A0> PositionData: [Grand Total:     $18,066.40          ($2.50)]
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PositionData
XM: 11/06 22:22:51   180127449 8A0> Default Character Set is 437
XM: 11/06 22:22:51   180127449 8A0> Attempting conversion to code page 437
XM: 11/06 22:22:51   180127449 8A0> Conversion needs 1900 bytes: 0
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::BuildCashManagementPrintData
XM: 11/06 22:22:51   180127449 8A0> -XMCashManagementBase::PrintReceipt
XM: 11/06 22:24:42   180238799 8A0> +XMCashReplenishBase::AlertMessage");
			
			LaneConfiguration config = new LaneConfigurationRepositoryStub().Read("");
			parser = config.Parsers.GetParser("Xmode").Instantiate();
			
			parser.Parse += new EventHandler<ProgressEventArgs>(ParserParse);
		}
		
		[TearDown]
		public void Teardown()
		{
			parser.Parse -= new EventHandler<ProgressEventArgs>(ParserParse);
		}
		
		[Test]
		public void TestParse()
		{
			List<IScriptEvent> events = parser.PerformParse(log);
			Assert.AreEqual(3, events.Count);
			
			FingerScriptEvent evnt = events[0] as FingerScriptEvent;
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(new FingerXmEvent().GetType(), evnt.Item);
			FingerXmEvent item = evnt.Item as FingerXmEvent;
			Assert.AreEqual("Checking XmCountChanges", item.ToString());
			Assert.AreEqual("XmEventData", item.Type);
			Assert.AreEqual("XmCountChanges", item.Id);
			Assert.AreEqual(2, item.ValueCount);
			Assert.AreEqual("1:15,5:3,25:2,100:1;100:6,200:0,500:2,1000:1,2000:0,5000:0,10000:0", item.Values[0]);
			Assert.AreEqual("1:110,5:100,10:100,25:100;100:3000,500:1500,1000:750", item.Values[1]);
		}
		
		void ParserParse(object sender, ProgressEventArgs e)
		{
		}
	}
}
