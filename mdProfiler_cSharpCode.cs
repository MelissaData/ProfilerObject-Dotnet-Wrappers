using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Security;

namespace MelissaData {
	public class mdProfiler : IDisposable {
		private IntPtr i;

		public enum ProgramStatus {
			ErrorNone = 0,
			ErrorConfigFile = 1,
			ErrorDatabaseExpired = 2,
			ErrorLicenseExpired = 3,
			ErrorProfileFile = 4,
			ErrorUnknown = 5
		}
		public enum AppendMode {
			Append = 0,
			Report = 1,
			Overwrite = 2,
			MustNotExist = 3
		}
		public enum ProfilerColumnType {
			ColumnTypeInt1 = 1,
			ColumnTypeInt2 = 2,
			ColumnTypeInt4 = 3,
			ColumnTypeInt8 = 4,
			ColumnTypeUInt1 = 5,
			ColumnTypeUInt2 = 6,
			ColumnTypeUInt4 = 7,
			ColumnTypeUInt8 = 8,
			ColumnTypeReal4 = 9,
			ColumnTypeReal8 = 10,
			ColumnTypeNumeric = 11,
			ColumnTypeDecimal = 12,
			ColumnTypeCurrency = 13,
			ColumnTypeFixedMBCSString = 14,
			ColumnTypeVariableMBCSString = 15,
			ColumnTypeFixedUnicodeString = 16,
			ColumnTypeVariableUnicodeString = 17,
			ColumnTypeDate = 18,
			ColumnTypeDBDate = 19,
			ColumnTypeDBTime = 20,
			ColumnTypeDBTime2 = 21,
			ColumnTypeDBTimeStamp = 22,
			ColumnTypeDBTimeStamp2 = 23,
			ColumnTypeDBTimeStampOffset = 24,
			ColumnTypeFileTime = 25,
			ColumnTypeBoolean = 26,
			ColumnTypeGUID = 27,
			ColumnTypeBytes = 28,
			ColumnTypeImage = 29
		}
		public enum ProfilerDataType {
			DataTypeFullName = 1,
			DataTypeInverseName = 2,
			DataTypeNamePrefix = 3,
			DataTypeFirstName = 4,
			DataTypeMiddleName = 5,
			DataTypeLastName = 6,
			DataTypeNameSuffix = 7,
			DataTypeTitle = 8,
			DataTypeCompany = 9,
			DataTypeAddress = 10,
			DataTypeCity = 11,
			DataTypeStateOrProvince = 12,
			DataTypeZipOrPostalCode = 13,
			DataTypeCityStateZip = 14,
			DataTypeCountry = 15,
			DataTypePhone = 16,
			DataTypeEmail = 17,
			DataTypeString = 18,
			DataTypeNumeric = 19,
			DataTypeDateMDY = 20,
			DataTypeDateYMD = 21,
			DataTypeDateDMY = 22,
			DataTypeBoolean = 23
		}
		public enum Sortation {
			SortUnknown = 0,
			SortStringAscending = 1,
			SortStringDescending = 2,
			SortNumericAscending = 3,
			SortNumericDescending = 4,
			SortDateAscending = 5,
			SortDateDescending = 6
		}
		public enum Order {
			OrderNone = 0,
			OrderValueAscending = 1,
			OrderValueDescending = 2,
			OrderCountAscending = 3,
			OrderCountDescending = 4
		}
		public enum DateSpan {
			DateSpanDate = 1,
			DateSpanTime = 2,
			DateSpanHour = 3,
			DateSpanMinute = 4,
			DateSpanSecond = 5,
			DateSpanMillisecond = 6,
			DateSpanDayOfWeek = 7,
			DateSpanDay = 8,
			DateSpanWeek = 9,
			DateSpanMonth = 10,
			DateSpanQuarter = 11,
			DateSpanYear = 12,
			DateSpanDecade = 13,
			DateSpanCentury = 14
		}

		[SuppressUnmanagedCodeSecurity]
		private class mdProfilerUnmanaged {
			[DllImport("mdProfiler", EntryPoint = "mdProfilerCreate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerCreate();
			[DllImport("mdProfiler", EntryPoint = "mdProfilerDestroy", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerDestroy(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetLicenseString", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerSetLicenseString(IntPtr i, IntPtr license);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetPathToProfilerDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetPathToProfilerDataFiles(IntPtr i, IntPtr path);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetFileName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetFileName(IntPtr i, IntPtr fileName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetAppendMode", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetAppendMode(IntPtr i, Int32 appendMode);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetUserName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetUserName(IntPtr i, IntPtr userName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetUserName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetUserName(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetTableName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetTableName(IntPtr i, IntPtr tableName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetTableName(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetJobName", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetJobName(IntPtr i, IntPtr jobName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetJobName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetJobName(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetJobDescription", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetJobDescription(IntPtr i, IntPtr jobDescription);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetJobDescription", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetJobDescription(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetSortAnalysis", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetSortAnalysis(IntPtr i, Int32 sortAnalysis);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetMatchUpAnalysis", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetMatchUpAnalysis(IntPtr i, Int32 matchUpAnalysis);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetRightFielderAnalysis", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetRightFielderAnalysis(IntPtr i, Int32 rightFielderAnalysis);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetDataAggregation", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetDataAggregation(IntPtr i, Int32 dataAggregation);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerInitializeDataFiles", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerInitializeDataFiles(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetInitializeErrorString", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetInitializeErrorString(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetBuildNumber", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetBuildNumber(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetDatabaseDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetDatabaseDate(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetLicenseExpirationDate", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetLicenseExpirationDate(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetProfileStartDateTime", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetProfileStartDateTime(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetProfileEndDateTime", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetProfileEndDateTime(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnTypeEnum", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnTypeEnum(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnTypeDescription", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnTypeDescription(IntPtr i, Int32 columnType);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerParseColumnTypeDescription", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerParseColumnTypeDescription(IntPtr i, IntPtr columnTypeStr);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetDataTypeEnum", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetDataTypeEnum(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetDataTypeDescription", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetDataTypeDescription(IntPtr i, Int32 dataType);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerParseDataTypeDescription", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerParseDataTypeDescription(IntPtr i, IntPtr dataTypeStr);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetResultCodeEnum", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetResultCodeEnum(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetResultCodeDescription", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetResultCodeDescription(IntPtr i, IntPtr resultStr);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerAddColumn", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerAddColumn(IntPtr i, IntPtr columnName, Int32 columnType, Int32 dataType);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetColumnCustomPattern", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerSetColumnCustomPattern(IntPtr i, IntPtr columnName, IntPtr regEx);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetColumnValueRange", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerSetColumnValueRange(IntPtr i, IntPtr columnName, IntPtr fromStr, IntPtr toStr);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetColumnDefaultValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerSetColumnDefaultValue(IntPtr i, IntPtr columnName, IntPtr value);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetColumnSize", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetColumnSize(IntPtr i, IntPtr columnName, Int32 size);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetColumnPrecision", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetColumnPrecision(IntPtr i, IntPtr columnName, Int32 precision);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetColumnScale", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetColumnScale(IntPtr i, IntPtr columnName, Int32 scale);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetColumnIgnoreOnError", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetColumnIgnoreOnError(IntPtr i, IntPtr columnName, Int32 ignore);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerStartProfiling", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerStartProfiling(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetColumn", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetColumn(IntPtr i, IntPtr columnName, IntPtr content);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetColumnNull", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetColumnNull(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerAddRecord", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerAddRecord(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetResults", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetResults(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetTextQualifier", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetTextQualifier(IntPtr i, IntPtr qualifier);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetColumnDelimiter", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetColumnDelimiter(IntPtr i, IntPtr delimiter);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetRowDelimiter", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetRowDelimiter(IntPtr i, IntPtr delimiter);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerAddDelimitedRecord", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerAddDelimitedRecord(IntPtr i, IntPtr record);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerProfileData", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerProfileData(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableRecordCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableRecordCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableRecordEmptyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableRecordEmptyCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableRecordNullCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableRecordNullCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableEmbeddedRowDelimiterCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableEmbeddedRowDelimiterCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableNotAllFieldsPresentCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableNotAllFieldsPresentCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableExtraFieldsPresentCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableExtraFieldsPresentCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableUnbalancedTextQualifiersCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableUnbalancedTextQualifiersCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableUnescapedEmbeddedTextQualifiersCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableUnescapedEmbeddedTextQualifiersCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableExactMatchDistinctCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableExactMatchDistinctCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableExactMatchDupesCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableExactMatchDupesCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableExactMatchLargestGroup", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableExactMatchLargestGroup(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableContactMatchDistinctCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableContactMatchDistinctCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableContactMatchDupesCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableContactMatchDupesCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableContactMatchLargestGroup", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableContactMatchLargestGroup(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableHouseholdMatchDistinctCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableHouseholdMatchDistinctCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableHouseholdMatchDupesCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableHouseholdMatchDupesCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableHouseholdMatchLargestGroup", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableHouseholdMatchLargestGroup(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableAddressMatchDistinctCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableAddressMatchDistinctCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableAddressMatchDupesCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableAddressMatchDupesCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetTableAddressMatchLargestGroup", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetTableAddressMatchLargestGroup(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnCount(IntPtr i);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnName", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnName(IntPtr i, Int32 index);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnColumnType", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnColumnType(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnDataType", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnDataType(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnSize", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnSize(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnPrecision", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnPrecision(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnScale", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnScale(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnValueRangeFrom", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnValueRangeFrom(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnValueRangeTo", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnValueRangeTo(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnDefaultValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnDefaultValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnCustomPatterns", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnCustomPatterns(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnInferredDataType", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnInferredDataType(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnInferredColumnType", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnInferredColumnType(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnSortation", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnSortation(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnSortationPercent", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnSortationPercent(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnMostPopularCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnMostPopularCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnDistinctCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnDistinctCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnUniqueCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnUniqueCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnDefaultValueCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnDefaultValueCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnBelowRangeCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnBelowRangeCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnAboveRangeCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnAboveRangeCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnAboveSizeCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnAboveSizeCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnAbovePrecisionCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnAbovePrecisionCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnAboveScaleCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnAboveScaleCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnInvalidRegExCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnInvalidRegExCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnEmptyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnEmptyCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNullCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnNullCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnInvalidDataCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnInvalidDataCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnInvalidUTF8Count", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnInvalidUTF8Count(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNonPrintingCharCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnNonPrintingCharCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnDiacriticCharCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnDiacriticCharCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnForeignCharCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnForeignCharCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnAlphaOnlyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnAlphaOnlyCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNumericOnlyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnNumericOnlyCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnAlphaNumericCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnAlphaNumericCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnUpperCaseOnlyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnUpperCaseOnlyCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnLowerCaseOnlyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnLowerCaseOnlyCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnMixedCaseCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnMixedCaseCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnSingleSpaceCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnSingleSpaceCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnMultiSpaceCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnMultiSpaceCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnLeadingSpaceCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnLeadingSpaceCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnTrailingSpaceCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnTrailingSpaceCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnMaxSpaces", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnMaxSpaces(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnMinSpaces", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnMinSpaces(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnTotalSpaces", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnTotalSpaces(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnTotalWordBreaks", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnTotalWordBreaks(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnAvgSpaces", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnAvgSpaces(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnDecorationCharCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnDecorationCharCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnProfanityCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnProfanityCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnInconsistentDataCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnInconsistentDataCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStringMaxValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnStringMaxValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStringMinValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnStringMinValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStringQ1Value", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnStringQ1Value(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStringMedValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnStringMedValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStringQ3Value", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnStringQ3Value(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStringMaxLength", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnStringMaxLength(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStringMinLength", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnStringMinLength(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStringAvgLength", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnStringAvgLength(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStringQ1Length", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnStringQ1Length(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStringMedLength", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnStringMedLength(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStringQ3Length", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnStringQ3Length(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnWordMaxValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnWordMaxValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnWordMinValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnWordMinValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnWordQ1Value", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnWordQ1Value(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnWordMedValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnWordMedValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnWordQ3Value", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnWordQ3Value(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnWordMaxLength", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnWordMaxLength(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnWordMinLength", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnWordMinLength(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnWordAvgLength", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnWordAvgLength(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnWordQ1Length", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnWordQ1Length(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnWordMedLength", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnWordMedLength(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnWordQ3Length", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnWordQ3Length(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnMaxWords", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnMaxWords(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnMinWords", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnMinWords(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnAvgWords", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnAvgWords(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNumericMaxValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnNumericMaxValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNumericMinValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnNumericMinValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNumericAvgValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnNumericAvgValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNumericQ1Value", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnNumericQ1Value(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNumericQ1IntValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnNumericQ1IntValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNumericMedValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnNumericMedValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNumericMedIntValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnNumericMedIntValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNumericQ3Value", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnNumericQ3Value(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNumericQ3IntValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnNumericQ3IntValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNumericStdDevValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern double mdProfilerGetColumnNumericStdDevValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnDateMaxValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnDateMaxValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnDateMinValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnDateMinValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnDateAvgValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnDateAvgValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnDateQ1Value", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnDateQ1Value(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnDateMedValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnDateMedValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnDateQ3Value", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnDateQ3Value(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnTimeMaxValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnTimeMaxValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnTimeMinValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnTimeMinValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnTimeAvgValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnTimeAvgValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnTimeQ1Value", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnTimeQ1Value(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnTimeMedValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnTimeMedValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnTimeQ3Value", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetColumnTimeQ3Value(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnDateNoCenturyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnDateNoCenturyCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNameInconsistentOrderCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnNameInconsistentOrderCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNameMultipleNameCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnNameMultipleNameCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnNameSuspiciousNameCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnNameSuspiciousNameCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStateCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnStateCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnProvinceCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnProvinceCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStateProvinceNonStandardCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnStateProvinceNonStandardCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStateProvinceInvalidCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnStateProvinceInvalidCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnZipCodeCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnZipCodeCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnPlus4Count", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnPlus4Count(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnZipCodeInvalidCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnZipCodeInvalidCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnPostalCodeCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnPostalCodeCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnPostalCodeInvalidCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnPostalCodeInvalidCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnZipCodePostalCodeInvalidCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnZipCodePostalCodeInvalidCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnStateZipCodeMismatchCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnStateZipCodeMismatchCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnProvincePostalCodeMismatchCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnProvincePostalCodeMismatchCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnCountryNonStandardCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnCountryNonStandardCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnCountryInvalidCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnCountryInvalidCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnEmailSyntaxCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnEmailSyntaxCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnEmailMobileDomainCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnEmailMobileDomainCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnEmailMisspelledDomainCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnEmailMisspelledDomainCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnEmailSpamtrapDomainCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnEmailSpamtrapDomainCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnEmailDisposableDomainCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnEmailDisposableDomainCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetColumnPhoneInvalidCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetColumnPhoneInvalidCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerStartDataFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerStartDataFrequency(IntPtr i, IntPtr columnName, Int32 order);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetDataFrequencyValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetDataFrequencyValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetDataFrequencyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetDataFrequencyCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetNextDataFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetNextDataFrequency(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerStartLengthFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerStartLengthFrequency(IntPtr i, IntPtr columnName, Int32 order);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetLengthFrequencyValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetLengthFrequencyValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetLengthFrequencyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetLengthFrequencyCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetNextLengthFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetNextLengthFrequency(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerStartPatternFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerStartPatternFrequency(IntPtr i, IntPtr columnName, Int32 order);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetPatternFrequencyValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetPatternFrequencyValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetPatternFrequencyRegEx", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetPatternFrequencyRegEx(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetPatternFrequencyExample", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetPatternFrequencyExample(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetPatternFrequencyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetPatternFrequencyCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetNextPatternFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetNextPatternFrequency(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerStartDateFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerStartDateFrequency(IntPtr i, IntPtr columnName, Int32 order, Int32 dateSpan);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetDateFrequencyValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetDateFrequencyValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetDateFrequencyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetDateFrequencyCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetNextDateFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetNextDateFrequency(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerStartSoundExFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerStartSoundExFrequency(IntPtr i, IntPtr columnName, Int32 order);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetSoundExFrequencyValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetSoundExFrequencyValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetSoundExFrequencyExample", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetSoundExFrequencyExample(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetSoundExFrequencyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetSoundExFrequencyCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetNextSoundExFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetNextSoundExFrequency(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerStartWordFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerStartWordFrequency(IntPtr i, IntPtr columnName, Int32 order);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetWordFrequencyValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetWordFrequencyValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetWordFrequencyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetWordFrequencyCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetNextWordFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetNextWordFrequency(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerStartWordLengthFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerStartWordLengthFrequency(IntPtr i, IntPtr columnName, Int32 order);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetWordLengthFrequencyValue", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetWordLengthFrequencyValue(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetWordLengthFrequencyCount", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetWordLengthFrequencyCount(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetNextWordLengthFrequency", CallingConvention = CallingConvention.Cdecl)]
			public static extern Int32 mdProfilerGetNextWordLengthFrequency(IntPtr i, IntPtr columnName);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerSetReserved", CallingConvention = CallingConvention.Cdecl)]
			public static extern void mdProfilerSetReserved(IntPtr i, IntPtr key, IntPtr value);
			[DllImport("mdProfiler", EntryPoint = "mdProfilerGetReserved", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr mdProfilerGetReserved(IntPtr i, IntPtr key);
		}

		public mdProfiler() {
			i = mdProfilerUnmanaged.mdProfilerCreate();
		}

		~mdProfiler() {
			Dispose();
		}

		public virtual void Dispose() {
			lock (this) {
				mdProfilerUnmanaged.mdProfilerDestroy(i);
				GC.SuppressFinalize(this);
			}
		}

		public int SetLicenseString(string license) {
			Utf8String u_license = new Utf8String(license);
			return mdProfilerUnmanaged.mdProfilerSetLicenseString(i, u_license.GetUtf8Ptr());
		}

		public void SetPathToProfilerDataFiles(string path) {
			Utf8String u_path = new Utf8String(path);
			mdProfilerUnmanaged.mdProfilerSetPathToProfilerDataFiles(i, u_path.GetUtf8Ptr());
		}

		public void SetFileName(string fileName) {
			Utf8String u_fileName = new Utf8String(fileName);
			mdProfilerUnmanaged.mdProfilerSetFileName(i, u_fileName.GetUtf8Ptr());
		}

		public void SetAppendMode(AppendMode appendMode) {
			mdProfilerUnmanaged.mdProfilerSetAppendMode(i, (int)appendMode);
		}

		public void SetUserName(string userName) {
			Utf8String u_userName = new Utf8String(userName);
			mdProfilerUnmanaged.mdProfilerSetUserName(i, u_userName.GetUtf8Ptr());
		}

		public string GetUserName() {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetUserName(i));
		}

		public void SetTableName(string tableName) {
			Utf8String u_tableName = new Utf8String(tableName);
			mdProfilerUnmanaged.mdProfilerSetTableName(i, u_tableName.GetUtf8Ptr());
		}

		public string GetTableName() {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetTableName(i));
		}

		public void SetJobName(string jobName) {
			Utf8String u_jobName = new Utf8String(jobName);
			mdProfilerUnmanaged.mdProfilerSetJobName(i, u_jobName.GetUtf8Ptr());
		}

		public string GetJobName() {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetJobName(i));
		}

		public void SetJobDescription(string jobDescription) {
			Utf8String u_jobDescription = new Utf8String(jobDescription);
			mdProfilerUnmanaged.mdProfilerSetJobDescription(i, u_jobDescription.GetUtf8Ptr());
		}

		public string GetJobDescription() {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetJobDescription(i));
		}

		public void SetSortAnalysis(int sortAnalysis) {
			mdProfilerUnmanaged.mdProfilerSetSortAnalysis(i, sortAnalysis);
		}

		public void SetMatchUpAnalysis(int matchUpAnalysis) {
			mdProfilerUnmanaged.mdProfilerSetMatchUpAnalysis(i, matchUpAnalysis);
		}

		public void SetRightFielderAnalysis(int rightFielderAnalysis) {
			mdProfilerUnmanaged.mdProfilerSetRightFielderAnalysis(i, rightFielderAnalysis);
		}

		public void SetDataAggregation(int dataAggregation) {
			mdProfilerUnmanaged.mdProfilerSetDataAggregation(i, dataAggregation);
		}

		public ProgramStatus InitializeDataFiles() {
			return (ProgramStatus)mdProfilerUnmanaged.mdProfilerInitializeDataFiles(i);
		}

		public string GetInitializeErrorString() {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetInitializeErrorString(i));
		}

		public string GetBuildNumber() {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetBuildNumber(i));
		}

		public string GetDatabaseDate() {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetDatabaseDate(i));
		}

		public string GetLicenseExpirationDate() {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetLicenseExpirationDate(i));
		}

		public string GetProfileStartDateTime() {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetProfileStartDateTime(i));
		}

		public string GetProfileEndDateTime() {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetProfileEndDateTime(i));
		}

		public string GetColumnTypeEnum() {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnTypeEnum(i));
		}

		public string GetColumnTypeDescription(ProfilerColumnType columnType) {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnTypeDescription(i, (int)columnType));
		}

		public ProfilerColumnType ParseColumnTypeDescription(string columnTypeStr) {
			Utf8String u_columnTypeStr = new Utf8String(columnTypeStr);
			return (ProfilerColumnType)mdProfilerUnmanaged.mdProfilerParseColumnTypeDescription(i, u_columnTypeStr.GetUtf8Ptr());
		}

		public string GetDataTypeEnum() {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetDataTypeEnum(i));
		}

		public string GetDataTypeDescription(ProfilerDataType dataType) {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetDataTypeDescription(i, (int)dataType));
		}

		public ProfilerDataType ParseDataTypeDescription(string dataTypeStr) {
			Utf8String u_dataTypeStr = new Utf8String(dataTypeStr);
			return (ProfilerDataType)mdProfilerUnmanaged.mdProfilerParseDataTypeDescription(i, u_dataTypeStr.GetUtf8Ptr());
		}

		public string GetResultCodeEnum() {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetResultCodeEnum(i));
		}

		public string GetResultCodeDescription(string resultStr) {
			Utf8String u_resultStr = new Utf8String(resultStr);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetResultCodeDescription(i, u_resultStr.GetUtf8Ptr()));
		}

		public void AddColumn(string columnName, ProfilerColumnType columnType, ProfilerDataType dataType) {
			Utf8String u_columnName = new Utf8String(columnName);
			mdProfilerUnmanaged.mdProfilerAddColumn(i, u_columnName.GetUtf8Ptr(), (int)columnType, (int)dataType);
		}

		public int SetColumnCustomPattern(string columnName, string regEx) {
			Utf8String u_columnName = new Utf8String(columnName);
			Utf8String u_regEx = new Utf8String(regEx);
			return mdProfilerUnmanaged.mdProfilerSetColumnCustomPattern(i, u_columnName.GetUtf8Ptr(), u_regEx.GetUtf8Ptr());
		}

		public int SetColumnValueRange(string columnName, string fromStr, string toStr) {
			Utf8String u_columnName = new Utf8String(columnName);
			Utf8String u_fromStr = new Utf8String(fromStr);
			Utf8String u_toStr = new Utf8String(toStr);
			return mdProfilerUnmanaged.mdProfilerSetColumnValueRange(i, u_columnName.GetUtf8Ptr(), u_fromStr.GetUtf8Ptr(), u_toStr.GetUtf8Ptr());
		}

		public int SetColumnDefaultValue(string columnName, string value) {
			Utf8String u_columnName = new Utf8String(columnName);
			Utf8String u_value = new Utf8String(value);
			return mdProfilerUnmanaged.mdProfilerSetColumnDefaultValue(i, u_columnName.GetUtf8Ptr(), u_value.GetUtf8Ptr());
		}

		public void SetColumnSize(string columnName, int size) {
			Utf8String u_columnName = new Utf8String(columnName);
			mdProfilerUnmanaged.mdProfilerSetColumnSize(i, u_columnName.GetUtf8Ptr(), size);
		}

		public void SetColumnPrecision(string columnName, int precision) {
			Utf8String u_columnName = new Utf8String(columnName);
			mdProfilerUnmanaged.mdProfilerSetColumnPrecision(i, u_columnName.GetUtf8Ptr(), precision);
		}

		public void SetColumnScale(string columnName, int scale) {
			Utf8String u_columnName = new Utf8String(columnName);
			mdProfilerUnmanaged.mdProfilerSetColumnScale(i, u_columnName.GetUtf8Ptr(), scale);
		}

		public void SetColumnIgnoreOnError(string columnName, int ignore) {
			Utf8String u_columnName = new Utf8String(columnName);
			mdProfilerUnmanaged.mdProfilerSetColumnIgnoreOnError(i, u_columnName.GetUtf8Ptr(), ignore);
		}

		public void StartProfiling() {
			mdProfilerUnmanaged.mdProfilerStartProfiling(i);
		}

		public void SetColumn(string columnName, string content) {
			Utf8String u_columnName = new Utf8String(columnName);
			Utf8String u_content = new Utf8String(content);
			mdProfilerUnmanaged.mdProfilerSetColumn(i, u_columnName.GetUtf8Ptr(), u_content.GetUtf8Ptr());
		}

		public void SetColumnNull(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			mdProfilerUnmanaged.mdProfilerSetColumnNull(i, u_columnName.GetUtf8Ptr());
		}

		public string GetColumnValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnValue(i, u_columnName.GetUtf8Ptr()));
		}

		public void AddRecord() {
			mdProfilerUnmanaged.mdProfilerAddRecord(i);
		}

		public string GetResults(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetResults(i, u_columnName.GetUtf8Ptr()));
		}

		public void SetTextQualifier(string qualifier) {
			Utf8String u_qualifier = new Utf8String(qualifier);
			mdProfilerUnmanaged.mdProfilerSetTextQualifier(i, u_qualifier.GetUtf8Ptr());
		}

		public void SetColumnDelimiter(string delimiter) {
			Utf8String u_delimiter = new Utf8String(delimiter);
			mdProfilerUnmanaged.mdProfilerSetColumnDelimiter(i, u_delimiter.GetUtf8Ptr());
		}

		public void SetRowDelimiter(string delimiter) {
			Utf8String u_delimiter = new Utf8String(delimiter);
			mdProfilerUnmanaged.mdProfilerSetRowDelimiter(i, u_delimiter.GetUtf8Ptr());
		}

		public string AddDelimitedRecord(string record) {
			Utf8String u_record = new Utf8String(record);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerAddDelimitedRecord(i, u_record.GetUtf8Ptr()));
		}

		public void ProfileData() {
			mdProfilerUnmanaged.mdProfilerProfileData(i);
		}

		public int GetTableRecordCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableRecordCount(i);
		}

		public int GetTableRecordEmptyCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableRecordEmptyCount(i);
		}

		public int GetTableRecordNullCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableRecordNullCount(i);
		}

		public int GetTableEmbeddedRowDelimiterCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableEmbeddedRowDelimiterCount(i);
		}

		public int GetTableNotAllFieldsPresentCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableNotAllFieldsPresentCount(i);
		}

		public int GetTableExtraFieldsPresentCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableExtraFieldsPresentCount(i);
		}

		public int GetTableUnbalancedTextQualifiersCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableUnbalancedTextQualifiersCount(i);
		}

		public int GetTableUnescapedEmbeddedTextQualifiersCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableUnescapedEmbeddedTextQualifiersCount(i);
		}

		public int GetTableExactMatchDistinctCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableExactMatchDistinctCount(i);
		}

		public int GetTableExactMatchDupesCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableExactMatchDupesCount(i);
		}

		public int GetTableExactMatchLargestGroup() {
			return mdProfilerUnmanaged.mdProfilerGetTableExactMatchLargestGroup(i);
		}

		public int GetTableContactMatchDistinctCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableContactMatchDistinctCount(i);
		}

		public int GetTableContactMatchDupesCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableContactMatchDupesCount(i);
		}

		public int GetTableContactMatchLargestGroup() {
			return mdProfilerUnmanaged.mdProfilerGetTableContactMatchLargestGroup(i);
		}

		public int GetTableHouseholdMatchDistinctCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableHouseholdMatchDistinctCount(i);
		}

		public int GetTableHouseholdMatchDupesCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableHouseholdMatchDupesCount(i);
		}

		public int GetTableHouseholdMatchLargestGroup() {
			return mdProfilerUnmanaged.mdProfilerGetTableHouseholdMatchLargestGroup(i);
		}

		public int GetTableAddressMatchDistinctCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableAddressMatchDistinctCount(i);
		}

		public int GetTableAddressMatchDupesCount() {
			return mdProfilerUnmanaged.mdProfilerGetTableAddressMatchDupesCount(i);
		}

		public int GetTableAddressMatchLargestGroup() {
			return mdProfilerUnmanaged.mdProfilerGetTableAddressMatchLargestGroup(i);
		}

		public int GetColumnCount() {
			return mdProfilerUnmanaged.mdProfilerGetColumnCount(i);
		}

		public string GetColumnName(int index) {
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnName(i, index));
		}

		public ProfilerColumnType GetColumnColumnType(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return (ProfilerColumnType)mdProfilerUnmanaged.mdProfilerGetColumnColumnType(i, u_columnName.GetUtf8Ptr());
		}

		public ProfilerDataType GetColumnDataType(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return (ProfilerDataType)mdProfilerUnmanaged.mdProfilerGetColumnDataType(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnSize(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnSize(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnPrecision(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnPrecision(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnScale(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnScale(i, u_columnName.GetUtf8Ptr());
		}

		public string GetColumnValueRangeFrom(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnValueRangeFrom(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnValueRangeTo(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnValueRangeTo(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnDefaultValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnDefaultValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnCustomPatterns(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnCustomPatterns(i, u_columnName.GetUtf8Ptr()));
		}

		public ProfilerDataType GetColumnInferredDataType(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return (ProfilerDataType)mdProfilerUnmanaged.mdProfilerGetColumnInferredDataType(i, u_columnName.GetUtf8Ptr());
		}

		public ProfilerColumnType GetColumnInferredColumnType(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return (ProfilerColumnType)mdProfilerUnmanaged.mdProfilerGetColumnInferredColumnType(i, u_columnName.GetUtf8Ptr());
		}

		public Sortation GetColumnSortation(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return (Sortation)mdProfilerUnmanaged.mdProfilerGetColumnSortation(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnSortationPercent(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnSortationPercent(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnMostPopularCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnMostPopularCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnDistinctCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnDistinctCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnUniqueCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnUniqueCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnDefaultValueCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnDefaultValueCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnBelowRangeCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnBelowRangeCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnAboveRangeCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnAboveRangeCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnAboveSizeCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnAboveSizeCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnAbovePrecisionCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnAbovePrecisionCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnAboveScaleCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnAboveScaleCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnInvalidRegExCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnInvalidRegExCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnEmptyCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnEmptyCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnNullCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNullCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnInvalidDataCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnInvalidDataCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnInvalidUTF8Count(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnInvalidUTF8Count(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnNonPrintingCharCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNonPrintingCharCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnDiacriticCharCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnDiacriticCharCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnForeignCharCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnForeignCharCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnAlphaOnlyCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnAlphaOnlyCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnNumericOnlyCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNumericOnlyCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnAlphaNumericCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnAlphaNumericCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnUpperCaseOnlyCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnUpperCaseOnlyCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnLowerCaseOnlyCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnLowerCaseOnlyCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnMixedCaseCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnMixedCaseCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnSingleSpaceCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnSingleSpaceCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnMultiSpaceCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnMultiSpaceCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnLeadingSpaceCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnLeadingSpaceCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnTrailingSpaceCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnTrailingSpaceCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnMaxSpaces(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnMaxSpaces(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnMinSpaces(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnMinSpaces(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnTotalSpaces(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnTotalSpaces(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnTotalWordBreaks(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnTotalWordBreaks(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnAvgSpaces(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnAvgSpaces(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnDecorationCharCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnDecorationCharCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnProfanityCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnProfanityCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnInconsistentDataCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnInconsistentDataCount(i, u_columnName.GetUtf8Ptr());
		}

		public string GetColumnStringMaxValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnStringMaxValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnStringMinValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnStringMinValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnStringQ1Value(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnStringQ1Value(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnStringMedValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnStringMedValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnStringQ3Value(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnStringQ3Value(i, u_columnName.GetUtf8Ptr()));
		}

		public int GetColumnStringMaxLength(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnStringMaxLength(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnStringMinLength(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnStringMinLength(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnStringAvgLength(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnStringAvgLength(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnStringQ1Length(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnStringQ1Length(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnStringMedLength(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnStringMedLength(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnStringQ3Length(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnStringQ3Length(i, u_columnName.GetUtf8Ptr());
		}

		public string GetColumnWordMaxValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnWordMaxValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnWordMinValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnWordMinValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnWordQ1Value(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnWordQ1Value(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnWordMedValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnWordMedValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnWordQ3Value(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnWordQ3Value(i, u_columnName.GetUtf8Ptr()));
		}

		public int GetColumnWordMaxLength(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnWordMaxLength(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnWordMinLength(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnWordMinLength(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnWordAvgLength(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnWordAvgLength(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnWordQ1Length(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnWordQ1Length(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnWordMedLength(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnWordMedLength(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnWordQ3Length(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnWordQ3Length(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnMaxWords(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnMaxWords(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnMinWords(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnMinWords(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnAvgWords(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnAvgWords(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnNumericMaxValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNumericMaxValue(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnNumericMinValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNumericMinValue(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnNumericAvgValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNumericAvgValue(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnNumericQ1Value(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNumericQ1Value(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnNumericQ1IntValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNumericQ1IntValue(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnNumericMedValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNumericMedValue(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnNumericMedIntValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNumericMedIntValue(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnNumericQ3Value(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNumericQ3Value(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnNumericQ3IntValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNumericQ3IntValue(i, u_columnName.GetUtf8Ptr());
		}

		public double GetColumnNumericStdDevValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNumericStdDevValue(i, u_columnName.GetUtf8Ptr());
		}

		public string GetColumnDateMaxValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnDateMaxValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnDateMinValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnDateMinValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnDateAvgValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnDateAvgValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnDateQ1Value(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnDateQ1Value(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnDateMedValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnDateMedValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnDateQ3Value(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnDateQ3Value(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnTimeMaxValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnTimeMaxValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnTimeMinValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnTimeMinValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnTimeAvgValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnTimeAvgValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnTimeQ1Value(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnTimeQ1Value(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnTimeMedValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnTimeMedValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetColumnTimeQ3Value(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetColumnTimeQ3Value(i, u_columnName.GetUtf8Ptr()));
		}

		public int GetColumnDateNoCenturyCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnDateNoCenturyCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnNameInconsistentOrderCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNameInconsistentOrderCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnNameMultipleNameCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNameMultipleNameCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnNameSuspiciousNameCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnNameSuspiciousNameCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnStateCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnStateCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnProvinceCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnProvinceCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnStateProvinceNonStandardCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnStateProvinceNonStandardCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnStateProvinceInvalidCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnStateProvinceInvalidCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnZipCodeCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnZipCodeCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnPlus4Count(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnPlus4Count(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnZipCodeInvalidCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnZipCodeInvalidCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnPostalCodeCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnPostalCodeCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnPostalCodeInvalidCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnPostalCodeInvalidCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnZipCodePostalCodeInvalidCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnZipCodePostalCodeInvalidCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnStateZipCodeMismatchCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnStateZipCodeMismatchCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnProvincePostalCodeMismatchCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnProvincePostalCodeMismatchCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnCountryNonStandardCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnCountryNonStandardCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnCountryInvalidCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnCountryInvalidCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnEmailSyntaxCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnEmailSyntaxCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnEmailMobileDomainCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnEmailMobileDomainCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnEmailMisspelledDomainCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnEmailMisspelledDomainCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnEmailSpamtrapDomainCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnEmailSpamtrapDomainCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnEmailDisposableDomainCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnEmailDisposableDomainCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetColumnPhoneInvalidCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetColumnPhoneInvalidCount(i, u_columnName.GetUtf8Ptr());
		}

		public int StartDataFrequency(string columnName, Order order) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerStartDataFrequency(i, u_columnName.GetUtf8Ptr(), (int)order);
		}

		public string GetDataFrequencyValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetDataFrequencyValue(i, u_columnName.GetUtf8Ptr()));
		}

		public int GetDataFrequencyCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetDataFrequencyCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetNextDataFrequency(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetNextDataFrequency(i, u_columnName.GetUtf8Ptr());
		}

		public int StartLengthFrequency(string columnName, Order order) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerStartLengthFrequency(i, u_columnName.GetUtf8Ptr(), (int)order);
		}

		public int GetLengthFrequencyValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetLengthFrequencyValue(i, u_columnName.GetUtf8Ptr());
		}

		public int GetLengthFrequencyCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetLengthFrequencyCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetNextLengthFrequency(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetNextLengthFrequency(i, u_columnName.GetUtf8Ptr());
		}

		public int StartPatternFrequency(string columnName, Order order) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerStartPatternFrequency(i, u_columnName.GetUtf8Ptr(), (int)order);
		}

		public string GetPatternFrequencyValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetPatternFrequencyValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetPatternFrequencyRegEx(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetPatternFrequencyRegEx(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetPatternFrequencyExample(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetPatternFrequencyExample(i, u_columnName.GetUtf8Ptr()));
		}

		public int GetPatternFrequencyCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetPatternFrequencyCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetNextPatternFrequency(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetNextPatternFrequency(i, u_columnName.GetUtf8Ptr());
		}

		public int StartDateFrequency(string columnName, Order order, DateSpan dateSpan) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerStartDateFrequency(i, u_columnName.GetUtf8Ptr(), (int)order, (int)dateSpan);
		}

		public string GetDateFrequencyValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetDateFrequencyValue(i, u_columnName.GetUtf8Ptr()));
		}

		public int GetDateFrequencyCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetDateFrequencyCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetNextDateFrequency(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetNextDateFrequency(i, u_columnName.GetUtf8Ptr());
		}

		public int StartSoundExFrequency(string columnName, Order order) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerStartSoundExFrequency(i, u_columnName.GetUtf8Ptr(), (int)order);
		}

		public string GetSoundExFrequencyValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetSoundExFrequencyValue(i, u_columnName.GetUtf8Ptr()));
		}

		public string GetSoundExFrequencyExample(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetSoundExFrequencyExample(i, u_columnName.GetUtf8Ptr()));
		}

		public int GetSoundExFrequencyCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetSoundExFrequencyCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetNextSoundExFrequency(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetNextSoundExFrequency(i, u_columnName.GetUtf8Ptr());
		}

		public int StartWordFrequency(string columnName, Order order) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerStartWordFrequency(i, u_columnName.GetUtf8Ptr(), (int)order);
		}

		public string GetWordFrequencyValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetWordFrequencyValue(i, u_columnName.GetUtf8Ptr()));
		}

		public int GetWordFrequencyCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetWordFrequencyCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetNextWordFrequency(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetNextWordFrequency(i, u_columnName.GetUtf8Ptr());
		}

		public int StartWordLengthFrequency(string columnName, Order order) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerStartWordLengthFrequency(i, u_columnName.GetUtf8Ptr(), (int)order);
		}

		public int GetWordLengthFrequencyValue(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetWordLengthFrequencyValue(i, u_columnName.GetUtf8Ptr());
		}

		public int GetWordLengthFrequencyCount(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetWordLengthFrequencyCount(i, u_columnName.GetUtf8Ptr());
		}

		public int GetNextWordLengthFrequency(string columnName) {
			Utf8String u_columnName = new Utf8String(columnName);
			return mdProfilerUnmanaged.mdProfilerGetNextWordLengthFrequency(i, u_columnName.GetUtf8Ptr());
		}

		public void SetReserved(string key, string value) {
			Utf8String u_key = new Utf8String(key);
			Utf8String u_value = new Utf8String(value);
			mdProfilerUnmanaged.mdProfilerSetReserved(i, u_key.GetUtf8Ptr(), u_value.GetUtf8Ptr());
		}

		public string GetReserved(string key) {
			Utf8String u_key = new Utf8String(key);
			return Utf8String.GetUnicodeString(mdProfilerUnmanaged.mdProfilerGetReserved(i, u_key.GetUtf8Ptr()));
		}

		private class Utf8String : IDisposable {
			private IntPtr utf8String = IntPtr.Zero;

			public Utf8String(string str) {
				if (str == null)
					str = "";
				byte[] buffer = Encoding.UTF8.GetBytes(str);
				Array.Resize(ref buffer, buffer.Length + 1);
				buffer[buffer.Length - 1] = 0;
				utf8String = Marshal.AllocHGlobal(buffer.Length);
				Marshal.Copy(buffer, 0, utf8String, buffer.Length);
			}

			~Utf8String() {
				Dispose();
			}

			public virtual void Dispose() {
				lock (this) {
					Marshal.FreeHGlobal(utf8String);
					GC.SuppressFinalize(this);
				}
			}

			public IntPtr GetUtf8Ptr() {
				return utf8String;
			}

			public static string GetUnicodeString(IntPtr ptr) {
				if (ptr == IntPtr.Zero)
					return "";
				int len = 0;
				while (Marshal.ReadByte(ptr, len) != 0)
					len++;
				if (len == 0)
					return "";
				byte[] buffer = new byte[len];
				Marshal.Copy(ptr, buffer, 0, len);
				return Encoding.UTF8.GetString(buffer);
			}
		}
	}
}
