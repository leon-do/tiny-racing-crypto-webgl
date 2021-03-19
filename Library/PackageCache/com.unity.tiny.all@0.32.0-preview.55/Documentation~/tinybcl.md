# Project Tiny Base Class Library

Project Tiny includes a custom .NET base class library. This includes a reference profile (Tiny Standard) used for C# compilation and an implementation profile.

The reference profile is a proper subset of .NET Standard 2.0, so any code compiled against the Tiny Standard profile is binary compatible with any runtime that supports .NET Standard 2.0.

The Tiny Standard profile exposes APIs in the following namespaces:
* [System](#system)
* [System.Collections](#systemcollections)
* [System.Collections.Generic](#systemcollectionsgeneric)
* [System.ComponentModel](#systemcomponentmodel)
* [System.Diagnostics](#systemdiagnostics)
* [System.Globalization](#systemglobalization)
* [System.IO](#systemio)
* [System.Reflection](#systemreflection)
* [System.Runtime.CompilerServices](#systemruntimecompilerservices)
* [System.Runtime.ConstrainedExecution](#systemruntimeconstrainedexecution)
* [System.Runtime.InteropServices](#systemruntimeinteropservices)
* [System.Security](#systemsecurity)
* [System.Security.Permissions](#systemsecuritypermissions)
* [System.Text](#systemtext)
* [System.Threading](#systemthreading)

# System
## AttributeTargets enum
### Values
`All`

`Assembly`

`Class`

`Constructor`

`Delegate`

`Enum`

`Event`

`Field`

`GenericParameter`

`Interface`

`Method`

`Module`

`Parameter`

`Property`

`ReturnValue`

`Struct`

## DateTimeKind enum
### Values
`Local`

`Unspecified`

`Utc`

## DayOfWeek enum
### Values
`Friday`

`Monday`

`Saturday`

`Sunday`

`Thursday`

`Tuesday`

`Wednesday`

## MidpointRounding enum
### Values
`AwayFromZero`

`ToEven`

## TypeCode enum
### Values
`Boolean`

`Byte`

`Char`

`DateTime`

`DBNull`

`Decimal`

`Double`

`Empty`

`Int16`

`Int32`

`Int64`

`Object`

`SByte`

`Single`

`String`

`UInt16`

`UInt32`

`UInt64`

## ICloneable interface
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.icloneable.clone?view=netcore-3.1">`object Clone()`</a>

## IComparable&lt;T&gt; interface
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.icomparable`1.compareto?view=netcore-3.1">`int CompareTo(T other)`</a>

## IDisposable interface
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.idisposable.dispose?view=netcore-3.1">`void Dispose()`</a>

## IEquatable&lt;T&gt; interface
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.iequatable`1.equals?view=netcore-3.1">`bool Equals(T other)`</a>

## IFormatProvider interface
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.iformatprovider.getformat?view=netcore-3.1">`object GetFormat(Type formatType)`</a>

## IFormattable interface
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.iformattable.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider formatProvider)`</a>

## Boolean struct
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.boolean.compareto?view=netcore-3.1">`int CompareTo(bool value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.boolean.equals?view=netcore-3.1">`bool Equals(bool obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.boolean.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

## Byte struct
### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.byte.maxvalue?view=netcore-3.1">`static byte MaxValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.byte.minvalue?view=netcore-3.1">`static byte MinValue`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.byte.compareto?view=netcore-3.1">`int CompareTo(byte value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.byte.equals?view=netcore-3.1">`bool Equals(byte obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.byte.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.byte.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

## Char struct
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.char.compareto?view=netcore-3.1">`int CompareTo(char value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.char.equals?view=netcore-3.1">`bool Equals(char obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.char.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

## DateTime struct
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.-ctor?view=netcore-3.1">`DateTime(int year, int month, int day)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.-ctor?view=netcore-3.1">`DateTime(int year, int month, int day, int hour, int minute, int second)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.-ctor?view=netcore-3.1">`DateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.-ctor?view=netcore-3.1">`DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.-ctor?view=netcore-3.1">`DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.-ctor?view=netcore-3.1">`DateTime(long ticks)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.-ctor?view=netcore-3.1">`DateTime(long ticks, DateTimeKind kind)`</a>

### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.maxvalue?view=netcore-3.1">`readonly static DateTime MaxValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.minvalue?view=netcore-3.1">`readonly static DateTime MinValue`</a>

### Static Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.now?view=netcore-3.1">`DateTime Now { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.today?view=netcore-3.1">`DateTime Today { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.utcnow?view=netcore-3.1">`DateTime UtcNow { get; }`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.compare?view=netcore-3.1">`static int Compare(DateTime t1, DateTime t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.daysinmonth?view=netcore-3.1">`static int DaysInMonth(int year, int month)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.equals?view=netcore-3.1">`static bool Equals(DateTime t1, DateTime t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.isleapyear?view=netcore-3.1">`static bool IsLeapYear(int year)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_addition?view=netcore-3.1">`static DateTime op_Addition(DateTime d, TimeSpan t)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_equality?view=netcore-3.1">`static bool op_Equality(DateTime d1, DateTime d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_greaterthan?view=netcore-3.1">`static bool op_GreaterThan(DateTime t1, DateTime t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_greaterthanorequal?view=netcore-3.1">`static bool op_GreaterThanOrEqual(DateTime t1, DateTime t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_inequality?view=netcore-3.1">`static bool op_Inequality(DateTime d1, DateTime d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_lessthan?view=netcore-3.1">`static bool op_LessThan(DateTime t1, DateTime t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_lessthanorequal?view=netcore-3.1">`static bool op_LessThanOrEqual(DateTime t1, DateTime t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_subtraction?view=netcore-3.1">`static TimeSpan op_Subtraction(DateTime d1, DateTime d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_subtraction?view=netcore-3.1">`static DateTime op_Subtraction(DateTime d, TimeSpan t)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.specifykind?view=netcore-3.1">`static DateTime SpecifyKind(DateTime value, DateTimeKind kind)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.date?view=netcore-3.1">`DateTime Date { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.day?view=netcore-3.1">`int Day { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.dayofweek?view=netcore-3.1">`DayOfWeek DayOfWeek { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.dayofyear?view=netcore-3.1">`int DayOfYear { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.hour?view=netcore-3.1">`int Hour { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.kind?view=netcore-3.1">`DateTimeKind Kind { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.millisecond?view=netcore-3.1">`int Millisecond { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.minute?view=netcore-3.1">`int Minute { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.month?view=netcore-3.1">`int Month { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.second?view=netcore-3.1">`int Second { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.ticks?view=netcore-3.1">`long Ticks { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.timeofday?view=netcore-3.1">`TimeSpan TimeOfDay { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.year?view=netcore-3.1">`int Year { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.add?view=netcore-3.1">`DateTime Add(TimeSpan value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.adddays?view=netcore-3.1">`DateTime AddDays(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.addhours?view=netcore-3.1">`DateTime AddHours(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.addmilliseconds?view=netcore-3.1">`DateTime AddMilliseconds(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.addminutes?view=netcore-3.1">`DateTime AddMinutes(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.addmonths?view=netcore-3.1">`DateTime AddMonths(int months)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.addseconds?view=netcore-3.1">`DateTime AddSeconds(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.addticks?view=netcore-3.1">`DateTime AddTicks(long value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.addyears?view=netcore-3.1">`DateTime AddYears(int value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.compareto?view=netcore-3.1">`int CompareTo(DateTime value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.compareto?view=netcore-3.1">`int CompareTo(object value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.equals?view=netcore-3.1">`bool Equals(DateTime value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.equals?view=netcore-3.1">`bool Equals(object value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.isdaylightsavingtime?view=netcore-3.1">`bool IsDaylightSavingTime()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.subtract?view=netcore-3.1">`TimeSpan Subtract(DateTime value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.subtract?view=netcore-3.1">`DateTime Subtract(TimeSpan value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.tofiletime?view=netcore-3.1">`long ToFileTime()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.tofiletimeutc?view=netcore-3.1">`long ToFileTimeUtc()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.tolocaltime?view=netcore-3.1">`DateTime ToLocalTime()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.datetime.touniversaltime?view=netcore-3.1">`DateTime ToUniversalTime()`</a>

## Decimal struct
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.-ctor?view=netcore-3.1">`Decimal(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.-ctor?view=netcore-3.1">`Decimal(int value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.-ctor?view=netcore-3.1">`Decimal(int lo, int mid, int hi, bool isNegative, byte scale)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.-ctor?view=netcore-3.1">`Decimal(Int32[] bits)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.-ctor?view=netcore-3.1">`Decimal(long value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.-ctor?view=netcore-3.1">`Decimal(float value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.-ctor?view=netcore-3.1">`Decimal(uint value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.-ctor?view=netcore-3.1">`Decimal(ulong value)`</a>

### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.maxvalue?view=netcore-3.1">`readonly static Decimal MaxValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.minusone?view=netcore-3.1">`readonly static Decimal MinusOne`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.minvalue?view=netcore-3.1">`readonly static Decimal MinValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.one?view=netcore-3.1">`readonly static Decimal One`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.zero?view=netcore-3.1">`readonly static Decimal Zero`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.add?view=netcore-3.1">`static Decimal Add(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.ceiling?view=netcore-3.1">`static Decimal Ceiling(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.compare?view=netcore-3.1">`static int Compare(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.divide?view=netcore-3.1">`static Decimal Divide(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.equals?view=netcore-3.1">`static bool Equals(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.floor?view=netcore-3.1">`static Decimal Floor(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.getbits?view=netcore-3.1">`static Int32[] GetBits(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.multiply?view=netcore-3.1">`static Decimal Multiply(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.negate?view=netcore-3.1">`static Decimal Negate(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_addition?view=netcore-3.1">`static Decimal op_Addition(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_decrement?view=netcore-3.1">`static Decimal op_Decrement(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_division?view=netcore-3.1">`static Decimal op_Division(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_equality?view=netcore-3.1">`static bool op_Equality(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_explicit?view=netcore-3.1">`static byte op_Explicit(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_explicit?view=netcore-3.1">`static char op_Explicit(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_explicit?view=netcore-3.1">`static double op_Explicit(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_explicit?view=netcore-3.1">`static short op_Explicit(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_explicit?view=netcore-3.1">`static int op_Explicit(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_explicit?view=netcore-3.1">`static long op_Explicit(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_explicit?view=netcore-3.1">`static sbyte op_Explicit(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_explicit?view=netcore-3.1">`static float op_Explicit(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_explicit?view=netcore-3.1">`static ushort op_Explicit(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_explicit?view=netcore-3.1">`static uint op_Explicit(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_explicit?view=netcore-3.1">`static ulong op_Explicit(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_explicit?view=netcore-3.1">`static Decimal op_Explicit(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_explicit?view=netcore-3.1">`static Decimal op_Explicit(float value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_greaterthan?view=netcore-3.1">`static bool op_GreaterThan(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_greaterthanorequal?view=netcore-3.1">`static bool op_GreaterThanOrEqual(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_implicit?view=netcore-3.1">`static Decimal op_Implicit(byte value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_implicit?view=netcore-3.1">`static Decimal op_Implicit(char value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_implicit?view=netcore-3.1">`static Decimal op_Implicit(short value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_implicit?view=netcore-3.1">`static Decimal op_Implicit(int value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_implicit?view=netcore-3.1">`static Decimal op_Implicit(long value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_implicit?view=netcore-3.1">`static Decimal op_Implicit(sbyte value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_implicit?view=netcore-3.1">`static Decimal op_Implicit(ushort value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_implicit?view=netcore-3.1">`static Decimal op_Implicit(uint value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_implicit?view=netcore-3.1">`static Decimal op_Implicit(ulong value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_increment?view=netcore-3.1">`static Decimal op_Increment(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_inequality?view=netcore-3.1">`static bool op_Inequality(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_lessthan?view=netcore-3.1">`static bool op_LessThan(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_lessthanorequal?view=netcore-3.1">`static bool op_LessThanOrEqual(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_modulus?view=netcore-3.1">`static Decimal op_Modulus(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_multiply?view=netcore-3.1">`static Decimal op_Multiply(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_subtraction?view=netcore-3.1">`static Decimal op_Subtraction(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_unarynegation?view=netcore-3.1">`static Decimal op_UnaryNegation(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.op_unaryplus?view=netcore-3.1">`static Decimal op_UnaryPlus(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.remainder?view=netcore-3.1">`static Decimal Remainder(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.round?view=netcore-3.1">`static Decimal Round(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.round?view=netcore-3.1">`static Decimal Round(Decimal d, int decimals)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.round?view=netcore-3.1">`static Decimal Round(Decimal d, int decimals, MidpointRounding mode)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.round?view=netcore-3.1">`static Decimal Round(Decimal d, MidpointRounding mode)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.subtract?view=netcore-3.1">`static Decimal Subtract(Decimal d1, Decimal d2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.tobyte?view=netcore-3.1">`static byte ToByte(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.todouble?view=netcore-3.1">`static double ToDouble(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.toint16?view=netcore-3.1">`static short ToInt16(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.toint32?view=netcore-3.1">`static int ToInt32(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.toint64?view=netcore-3.1">`static long ToInt64(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.tosbyte?view=netcore-3.1">`static sbyte ToSByte(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.tosingle?view=netcore-3.1">`static float ToSingle(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.touint16?view=netcore-3.1">`static ushort ToUInt16(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.touint32?view=netcore-3.1">`static uint ToUInt32(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.touint64?view=netcore-3.1">`static ulong ToUInt64(Decimal d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.truncate?view=netcore-3.1">`static Decimal Truncate(Decimal d)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.compareto?view=netcore-3.1">`int CompareTo(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.compareto?view=netcore-3.1">`int CompareTo(object value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.equals?view=netcore-3.1">`bool Equals(Decimal value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.equals?view=netcore-3.1">`bool Equals(object value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.decimal.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

## Double struct
### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.double.epsilon?view=netcore-3.1">`static double Epsilon`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.double.maxvalue?view=netcore-3.1">`static double MaxValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.double.minvalue?view=netcore-3.1">`static double MinValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.double.nan?view=netcore-3.1">`static double NaN`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.double.negativeinfinity?view=netcore-3.1">`static double NegativeInfinity`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.double.positiveinfinity?view=netcore-3.1">`static double PositiveInfinity`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.double.isnan?view=netcore-3.1">`static bool IsNaN(double d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.double.isnegativeinfinity?view=netcore-3.1">`static bool IsNegativeInfinity(double d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.double.ispositiveinfinity?view=netcore-3.1">`static bool IsPositiveInfinity(double d)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.double.compareto?view=netcore-3.1">`int CompareTo(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.double.equals?view=netcore-3.1">`bool Equals(double obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.double.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.double.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

## Guid struct
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.-ctor?view=netcore-3.1">`Guid(Byte[] b)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.-ctor?view=netcore-3.1">`Guid(int a, short b, short c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.-ctor?view=netcore-3.1">`Guid(int a, short b, short c, Byte[] d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.-ctor?view=netcore-3.1">`Guid(string g)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.-ctor?view=netcore-3.1">`Guid(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k)`</a>

### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.empty?view=netcore-3.1">`readonly static Guid Empty`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.newguid?view=netcore-3.1">`static Guid NewGuid()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.op_equality?view=netcore-3.1">`static bool op_Equality(Guid a, Guid b)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.op_inequality?view=netcore-3.1">`static bool op_Inequality(Guid a, Guid b)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.parse?view=netcore-3.1">`static Guid Parse(string input)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.parseexact?view=netcore-3.1">`static Guid ParseExact(string input, string format)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.tryparse?view=netcore-3.1">`static bool TryParse(string input, out Guid result)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.tryparseexact?view=netcore-3.1">`static bool TryParseExact(string input, string format, out Guid result)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.compareto?view=netcore-3.1">`int CompareTo(Guid value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.equals?view=netcore-3.1">`bool Equals(Guid g)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.equals?view=netcore-3.1">`bool Equals(object o)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.tobytearray?view=netcore-3.1">`Byte[] ToByteArray()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.tostring?view=netcore-3.1">`string ToString(string format)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.guid.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

## Int16 struct
### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int16.maxvalue?view=netcore-3.1">`static short MaxValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int16.minvalue?view=netcore-3.1">`static short MinValue`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int16.compareto?view=netcore-3.1">`int CompareTo(short value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int16.equals?view=netcore-3.1">`bool Equals(short obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int16.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int16.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

## Int32 struct
### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32.maxvalue?view=netcore-3.1">`static int MaxValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32.minvalue?view=netcore-3.1">`static int MinValue`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32.compareto?view=netcore-3.1">`int CompareTo(int value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32.equals?view=netcore-3.1">`bool Equals(int obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int32.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

## Int64 struct
### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int64.maxvalue?view=netcore-3.1">`static long MaxValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int64.minvalue?view=netcore-3.1">`static long MinValue`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int64.compareto?view=netcore-3.1">`int CompareTo(long value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int64.equals?view=netcore-3.1">`bool Equals(long obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int64.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.int64.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

## IntPtr struct
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.-ctor?view=netcore-3.1">`IntPtr(int value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.-ctor?view=netcore-3.1">`IntPtr(long value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.-ctor?view=netcore-3.1">`IntPtr(Void* value)`</a>

### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.zero?view=netcore-3.1">`readonly static IntPtr Zero`</a>

### Static Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.size?view=netcore-3.1">`int Size { get; }`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.add?view=netcore-3.1">`static IntPtr Add(IntPtr pointer, int offset)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.op_addition?view=netcore-3.1">`static IntPtr op_Addition(IntPtr pointer, int offset)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.op_equality?view=netcore-3.1">`static bool op_Equality(IntPtr value1, IntPtr value2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.op_explicit?view=netcore-3.1">`static IntPtr op_Explicit(int value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.op_explicit?view=netcore-3.1">`static IntPtr op_Explicit(long value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.op_explicit?view=netcore-3.1">`static int op_Explicit(IntPtr value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.op_explicit?view=netcore-3.1">`static long op_Explicit(IntPtr value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.op_explicit?view=netcore-3.1">`static Void* op_Explicit(IntPtr value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.op_explicit?view=netcore-3.1">`static IntPtr op_Explicit(Void* value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.op_inequality?view=netcore-3.1">`static bool op_Inequality(IntPtr value1, IntPtr value2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.op_subtraction?view=netcore-3.1">`static IntPtr op_Subtraction(IntPtr pointer, int offset)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.subtract?view=netcore-3.1">`static IntPtr Subtract(IntPtr pointer, int offset)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.toint32?view=netcore-3.1">`int ToInt32()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.toint64?view=netcore-3.1">`long ToInt64()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.topointer?view=netcore-3.1">`Void* ToPointer()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.intptr.tostring?view=netcore-3.1">`string ToString(string format)`</a>

## Nullable&lt;T&gt; struct
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.nullable`1.-ctor?view=netcore-3.1">`Nullable<T>(T value)`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.nullable`1.op_explicit?view=netcore-3.1">`static T op_Explicit(Nullable value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.nullable`1.op_implicit?view=netcore-3.1">`static Nullable op_Implicit(T value)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.nullable`1.hasvalue?view=netcore-3.1">`bool HasValue { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.nullable`1.value?view=netcore-3.1">`T Value { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.nullable`1.equals?view=netcore-3.1">`bool Equals(object other)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.nullable`1.getvalueordefault?view=netcore-3.1">`T GetValueOrDefault()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.nullable`1.getvalueordefault?view=netcore-3.1">`T GetValueOrDefault(T defaultValue)`</a>

## RuntimeTypeHandle struct
### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtimetypehandle.value?view=netcore-3.1">`IntPtr Value { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtimetypehandle.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

## SByte struct
### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.sbyte.maxvalue?view=netcore-3.1">`static sbyte MaxValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.sbyte.minvalue?view=netcore-3.1">`static sbyte MinValue`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.sbyte.compareto?view=netcore-3.1">`int CompareTo(sbyte value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.sbyte.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.sbyte.equals?view=netcore-3.1">`bool Equals(sbyte obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.sbyte.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

## Single struct
### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.epsilon?view=netcore-3.1">`static float Epsilon`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.maxvalue?view=netcore-3.1">`static float MaxValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.minvalue?view=netcore-3.1">`static float MinValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.nan?view=netcore-3.1">`static float NaN`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.negativeinfinity?view=netcore-3.1">`static float NegativeInfinity`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.positiveinfinity?view=netcore-3.1">`static float PositiveInfinity`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.isinfinity?view=netcore-3.1">`static bool IsInfinity(float f)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.isnan?view=netcore-3.1">`static bool IsNaN(float f)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.isnegativeinfinity?view=netcore-3.1">`static bool IsNegativeInfinity(float f)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.ispositiveinfinity?view=netcore-3.1">`static bool IsPositiveInfinity(float f)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.compareto?view=netcore-3.1">`int CompareTo(float value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.equals?view=netcore-3.1">`bool Equals(float obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.single.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

## TimeSpan struct
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.-ctor?view=netcore-3.1">`TimeSpan(int hours, int minutes, int seconds)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.-ctor?view=netcore-3.1">`TimeSpan(int days, int hours, int minutes, int seconds)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.-ctor?view=netcore-3.1">`TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.-ctor?view=netcore-3.1">`TimeSpan(long ticks)`</a>

### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.maxvalue?view=netcore-3.1">`readonly static TimeSpan MaxValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.minvalue?view=netcore-3.1">`readonly static TimeSpan MinValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.ticksperday?view=netcore-3.1">`static long TicksPerDay`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.ticksperhour?view=netcore-3.1">`static long TicksPerHour`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.tickspermillisecond?view=netcore-3.1">`static long TicksPerMillisecond`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.ticksperminute?view=netcore-3.1">`static long TicksPerMinute`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.tickspersecond?view=netcore-3.1">`static long TicksPerSecond`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.zero?view=netcore-3.1">`readonly static TimeSpan Zero`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.compare?view=netcore-3.1">`static int Compare(TimeSpan t1, TimeSpan t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.equals?view=netcore-3.1">`static bool Equals(TimeSpan t1, TimeSpan t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.fromdays?view=netcore-3.1">`static TimeSpan FromDays(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.fromhours?view=netcore-3.1">`static TimeSpan FromHours(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.frommilliseconds?view=netcore-3.1">`static TimeSpan FromMilliseconds(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.fromminutes?view=netcore-3.1">`static TimeSpan FromMinutes(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.fromseconds?view=netcore-3.1">`static TimeSpan FromSeconds(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.fromticks?view=netcore-3.1">`static TimeSpan FromTicks(long value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.op_addition?view=netcore-3.1">`static TimeSpan op_Addition(TimeSpan t1, TimeSpan t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.op_equality?view=netcore-3.1">`static bool op_Equality(TimeSpan t1, TimeSpan t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.op_greaterthan?view=netcore-3.1">`static bool op_GreaterThan(TimeSpan t1, TimeSpan t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.op_greaterthanorequal?view=netcore-3.1">`static bool op_GreaterThanOrEqual(TimeSpan t1, TimeSpan t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.op_inequality?view=netcore-3.1">`static bool op_Inequality(TimeSpan t1, TimeSpan t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.op_lessthan?view=netcore-3.1">`static bool op_LessThan(TimeSpan t1, TimeSpan t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.op_lessthanorequal?view=netcore-3.1">`static bool op_LessThanOrEqual(TimeSpan t1, TimeSpan t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.op_subtraction?view=netcore-3.1">`static TimeSpan op_Subtraction(TimeSpan t1, TimeSpan t2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.op_unarynegation?view=netcore-3.1">`static TimeSpan op_UnaryNegation(TimeSpan t)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.op_unaryplus?view=netcore-3.1">`static TimeSpan op_UnaryPlus(TimeSpan t)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.days?view=netcore-3.1">`int Days { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.hours?view=netcore-3.1">`int Hours { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.milliseconds?view=netcore-3.1">`int Milliseconds { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.minutes?view=netcore-3.1">`int Minutes { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.seconds?view=netcore-3.1">`int Seconds { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.ticks?view=netcore-3.1">`long Ticks { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.totaldays?view=netcore-3.1">`double TotalDays { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.totalhours?view=netcore-3.1">`double TotalHours { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.totalmilliseconds?view=netcore-3.1">`double TotalMilliseconds { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.totalminutes?view=netcore-3.1">`double TotalMinutes { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.totalseconds?view=netcore-3.1">`double TotalSeconds { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.add?view=netcore-3.1">`TimeSpan Add(TimeSpan ts)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.compareto?view=netcore-3.1">`int CompareTo(object value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.compareto?view=netcore-3.1">`int CompareTo(TimeSpan value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.duration?view=netcore-3.1">`TimeSpan Duration()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.equals?view=netcore-3.1">`bool Equals(object value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.equals?view=netcore-3.1">`bool Equals(TimeSpan obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.negate?view=netcore-3.1">`TimeSpan Negate()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.subtract?view=netcore-3.1">`TimeSpan Subtract(TimeSpan ts)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.timespan.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider formatProvider)`</a>

## TypedReference struct
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.typedreference.equals?view=netcore-3.1">`bool Equals(object o)`</a>

## UInt16 struct
### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint16.maxvalue?view=netcore-3.1">`static ushort MaxValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint16.minvalue?view=netcore-3.1">`static ushort MinValue`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint16.compareto?view=netcore-3.1">`int CompareTo(ushort value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint16.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint16.equals?view=netcore-3.1">`bool Equals(ushort obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint16.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

## UInt32 struct
### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint32.maxvalue?view=netcore-3.1">`static uint MaxValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint32.minvalue?view=netcore-3.1">`static uint MinValue`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint32.compareto?view=netcore-3.1">`int CompareTo(uint value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint32.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint32.equals?view=netcore-3.1">`bool Equals(uint obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint32.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

## UInt64 struct
### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint64.maxvalue?view=netcore-3.1">`static ulong MaxValue`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint64.minvalue?view=netcore-3.1">`static ulong MinValue`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint64.compareto?view=netcore-3.1">`int CompareTo(ulong value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint64.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint64.equals?view=netcore-3.1">`bool Equals(ulong obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uint64.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

## UIntPtr struct
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.-ctor?view=netcore-3.1">`UIntPtr(uint value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.-ctor?view=netcore-3.1">`UIntPtr(ulong value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.-ctor?view=netcore-3.1">`UIntPtr(Void* value)`</a>

### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.zero?view=netcore-3.1">`readonly static UIntPtr Zero`</a>

### Static Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.size?view=netcore-3.1">`int Size { get; }`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.add?view=netcore-3.1">`static UIntPtr Add(UIntPtr pointer, int offset)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.op_addition?view=netcore-3.1">`static UIntPtr op_Addition(UIntPtr pointer, int offset)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.op_equality?view=netcore-3.1">`static bool op_Equality(UIntPtr value1, UIntPtr value2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.op_explicit?view=netcore-3.1">`static UIntPtr op_Explicit(uint value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.op_explicit?view=netcore-3.1">`static UIntPtr op_Explicit(ulong value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.op_explicit?view=netcore-3.1">`static uint op_Explicit(UIntPtr value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.op_explicit?view=netcore-3.1">`static ulong op_Explicit(UIntPtr value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.op_explicit?view=netcore-3.1">`static Void* op_Explicit(UIntPtr value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.op_explicit?view=netcore-3.1">`static UIntPtr op_Explicit(Void* value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.op_inequality?view=netcore-3.1">`static bool op_Inequality(UIntPtr value1, UIntPtr value2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.op_subtraction?view=netcore-3.1">`static UIntPtr op_Subtraction(UIntPtr pointer, int offset)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.subtract?view=netcore-3.1">`static UIntPtr Subtract(UIntPtr pointer, int offset)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.topointer?view=netcore-3.1">`Void* ToPointer()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.touint32?view=netcore-3.1">`uint ToUInt32()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.uintptr.touint64?view=netcore-3.1">`ulong ToUInt64()`</a>

## Void struct
## Action class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action.-ctor?view=netcore-3.1">`Action(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action.invoke?view=netcore-3.1">`void Invoke()`</a>

## Action&lt;T&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`1.-ctor?view=netcore-3.1">`Action<T>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`1.invoke?view=netcore-3.1">`void Invoke(T obj)`</a>

## Action&lt;T1, T2&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`2.-ctor?view=netcore-3.1">`Action<T1, T2>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`2.invoke?view=netcore-3.1">`void Invoke(T1 arg1, T2 arg2)`</a>

## Action&lt;T1, T2, T3&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`3.-ctor?view=netcore-3.1">`Action<T1, T2, T3>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`3.invoke?view=netcore-3.1">`void Invoke(T1 arg1, T2 arg2, T3 arg3)`</a>

## Action&lt;T1, T2, T3, T4&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`4.-ctor?view=netcore-3.1">`Action<T1, T2, T3, T4>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`4.invoke?view=netcore-3.1">`void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)`</a>

## Action&lt;T1, T2, T3, T4, T5&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`5.-ctor?view=netcore-3.1">`Action<T1, T2, T3, T4, T5>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`5.invoke?view=netcore-3.1">`void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)`</a>

## Action&lt;T1, T2, T3, T4, T5, T6&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`6.-ctor?view=netcore-3.1">`Action<T1, T2, T3, T4, T5, T6>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`6.invoke?view=netcore-3.1">`void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)`</a>

## Action&lt;T1, T2, T3, T4, T5, T6, T7&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`7.-ctor?view=netcore-3.1">`Action<T1, T2, T3, T4, T5, T6, T7>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`7.invoke?view=netcore-3.1">`void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)`</a>

## Action&lt;T1, T2, T3, T4, T5, T6, T7, T8&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`8.-ctor?view=netcore-3.1">`Action<T1, T2, T3, T4, T5, T6, T7, T8>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.action`8.invoke?view=netcore-3.1">`void Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)`</a>

## Activator class
### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.activator.createinstance?view=netcore-3.1">`static T CreateInstance<T>()`</a>

## ArgumentException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception.-ctor?view=netcore-3.1">`ArgumentException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception.-ctor?view=netcore-3.1">`ArgumentException(string message)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception.-ctor?view=netcore-3.1">`ArgumentException(string message, string paramName)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception.message?view=netcore-3.1">`string Message { get; }`</a>

## ArgumentNullException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception.-ctor?view=netcore-3.1">`ArgumentNullException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception.-ctor?view=netcore-3.1">`ArgumentNullException(string paramName)`</a>

## ArgumentOutOfRangeException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception.-ctor?view=netcore-3.1">`ArgumentOutOfRangeException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception.-ctor?view=netcore-3.1">`ArgumentOutOfRangeException(string paramName)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception.-ctor?view=netcore-3.1">`ArgumentOutOfRangeException(string paramName, string message)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception.message?view=netcore-3.1">`string Message { get; }`</a>

## ArithmeticException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.arithmeticexception.-ctor?view=netcore-3.1">`ArithmeticException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.arithmeticexception.-ctor?view=netcore-3.1">`ArithmeticException(string message)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.arithmeticexception.-ctor?view=netcore-3.1">`ArithmeticException(string message, Exception innerException)`</a>

## Array class
### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.array.empty?view=netcore-3.1">`static T[] Empty<T>()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.array.indexof?view=netcore-3.1">`static int IndexOf<T>(T[] array, T value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.array.indexof?view=netcore-3.1">`static int IndexOf<T>(T[] array, T value, int startIndex, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.array.resize?view=netcore-3.1">`static void Resize<T>(T array, int newSize)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.array.length?view=netcore-3.1">`int Length { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.array.clone?view=netcore-3.1">`object Clone()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.array.getenumerator?view=netcore-3.1">`System.Collections.IEnumerator GetEnumerator()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.array.getlength?view=netcore-3.1">`int GetLength(int dimension)`</a>

## Attribute class
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.attribute.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

## AttributeUsageAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.attributeusageattribute.-ctor?view=netcore-3.1">`AttributeUsageAttribute(AttributeTargets validOn)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.attributeusageattribute.allowmultiple?view=netcore-3.1">`bool AllowMultiple { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.attributeusageattribute.inherited?view=netcore-3.1">`bool Inherited { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.attributeusageattribute.validon?view=netcore-3.1">`AttributeTargets ValidOn { get; }`</a>

## CLSCompliantAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.clscompliantattribute.-ctor?view=netcore-3.1">`CLSCompliantAttribute(bool isCompliant)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.clscompliantattribute.iscompliant?view=netcore-3.1">`bool IsCompliant { get; }`</a>

## Console class
### Static Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.console.outputencoding?view=netcore-3.1">`System.Text.Encoding OutputEncoding { get; set; }`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.console.write?view=netcore-3.1">`static void Write(string value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.console.writeline?view=netcore-3.1">`static void WriteLine(string value)`</a>

## Delegate class
### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.delegate.combine?view=netcore-3.1">`static Delegate Combine(Delegate a, Delegate b)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.delegate.remove?view=netcore-3.1">`static Delegate Remove(Delegate source, Delegate value)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.delegate.clone?view=netcore-3.1">`object Clone()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.delegate.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

## DivideByZeroException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception.-ctor?view=netcore-3.1">`DivideByZeroException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception.-ctor?view=netcore-3.1">`DivideByZeroException(string message)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.dividebyzeroexception.-ctor?view=netcore-3.1">`DivideByZeroException(string message, Exception innerException)`</a>

## Enum class
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.enum.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.enum.tostring?view=netcore-3.1">`string ToString(string format, IFormatProvider provider)`</a>

## Environment class
### Static Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.environment.processorcount?view=netcore-3.1">`int ProcessorCount { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.environment.stacktrace?view=netcore-3.1">`string StackTrace { get; }`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.environment.failfast?view=netcore-3.1">`static void FailFast(string message)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.environment.getcommandlineargs?view=netcore-3.1">`static String[] GetCommandLineArgs()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.environment.getenvironmentvariable?view=netcore-3.1">`static string GetEnvironmentVariable(string variable)`</a>

## Exception class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.exception.-ctor?view=netcore-3.1">`Exception()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.exception.-ctor?view=netcore-3.1">`Exception(string message)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.exception.-ctor?view=netcore-3.1">`Exception(string message, Exception innerException)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.exception.message?view=netcore-3.1">`string Message { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.exception.stacktrace?view=netcore-3.1">`string StackTrace { get; }`</a>

## FlagsAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.flagsattribute.-ctor?view=netcore-3.1">`FlagsAttribute()`</a>

## FormatException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.formatexception.-ctor?view=netcore-3.1">`FormatException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.formatexception.-ctor?view=netcore-3.1">`FormatException(string message)`</a>

## Func&lt;TResult&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`1.-ctor?view=netcore-3.1">`Func<TResult>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`1.invoke?view=netcore-3.1">`TResult Invoke()`</a>

## Func&lt;T, TResult&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`2.-ctor?view=netcore-3.1">`Func<T, TResult>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`2.invoke?view=netcore-3.1">`TResult Invoke(T arg)`</a>

## Func&lt;T1, T2, TResult&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`3.-ctor?view=netcore-3.1">`Func<T1, T2, TResult>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`3.invoke?view=netcore-3.1">`TResult Invoke(T1 arg1, T2 arg2)`</a>

## Func&lt;T1, T2, T3, TResult&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`4.-ctor?view=netcore-3.1">`Func<T1, T2, T3, TResult>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`4.invoke?view=netcore-3.1">`TResult Invoke(T1 arg1, T2 arg2, T3 arg3)`</a>

## Func&lt;T1, T2, T3, T4, TResult&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`5.-ctor?view=netcore-3.1">`Func<T1, T2, T3, T4, TResult>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`5.invoke?view=netcore-3.1">`TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4)`</a>

## Func&lt;T1, T2, T3, T4, T5, TResult&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`6.-ctor?view=netcore-3.1">`Func<T1, T2, T3, T4, T5, TResult>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`6.invoke?view=netcore-3.1">`TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)`</a>

## Func&lt;T1, T2, T3, T4, T5, T6, TResult&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`7.-ctor?view=netcore-3.1">`Func<T1, T2, T3, T4, T5, T6, TResult>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`7.invoke?view=netcore-3.1">`TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)`</a>

## Func&lt;T1, T2, T3, T4, T5, T6, T7, TResult&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`8.-ctor?view=netcore-3.1">`Func<T1, T2, T3, T4, T5, T6, T7, TResult>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`8.invoke?view=netcore-3.1">`TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)`</a>

## Func&lt;T1, T2, T3, T4, T5, T6, T7, T8, TResult&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`9.-ctor?view=netcore-3.1">`Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.func`9.invoke?view=netcore-3.1">`TResult Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)`</a>

## GC class
### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.gc.collect?view=netcore-3.1">`static void Collect()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.gc.keepalive?view=netcore-3.1">`static void KeepAlive(object obj)`</a>

## IndexOutOfRangeException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.indexoutofrangeexception.-ctor?view=netcore-3.1">`IndexOutOfRangeException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.indexoutofrangeexception.-ctor?view=netcore-3.1">`IndexOutOfRangeException(string message)`</a>

## InvalidOperationException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception.-ctor?view=netcore-3.1">`InvalidOperationException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception.-ctor?view=netcore-3.1">`InvalidOperationException(string message)`</a>

## MarshalByRefObject class
## Math class
### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.e?view=netcore-3.1">`static double E`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.pi?view=netcore-3.1">`static double PI`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.abs?view=netcore-3.1">`static double Abs(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.acos?view=netcore-3.1">`static double Acos(double d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.asin?view=netcore-3.1">`static double Asin(double d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.atan?view=netcore-3.1">`static double Atan(double d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.atan2?view=netcore-3.1">`static double Atan2(double y, double x)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.bigmul?view=netcore-3.1">`static long BigMul(int a, int b)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.ceiling?view=netcore-3.1">`static double Ceiling(double a)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.cos?view=netcore-3.1">`static double Cos(double d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.cosh?view=netcore-3.1">`static double Cosh(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.divrem?view=netcore-3.1">`static int DivRem(int a, int b, out ref int result)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.divrem?view=netcore-3.1">`static long DivRem(long a, long b, out ref long result)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.exp?view=netcore-3.1">`static double Exp(double d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.floor?view=netcore-3.1">`static double Floor(double d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.log?view=netcore-3.1">`static double Log(double d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.log?view=netcore-3.1">`static double Log(double a, double newBase)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.log10?view=netcore-3.1">`static double Log10(double d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.max?view=netcore-3.1">`static byte Max(byte val1, byte val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.max?view=netcore-3.1">`static double Max(double val1, double val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.max?view=netcore-3.1">`static short Max(short val1, short val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.max?view=netcore-3.1">`static int Max(int val1, int val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.max?view=netcore-3.1">`static long Max(long val1, long val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.max?view=netcore-3.1">`static sbyte Max(sbyte val1, sbyte val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.max?view=netcore-3.1">`static float Max(float val1, float val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.max?view=netcore-3.1">`static ushort Max(ushort val1, ushort val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.max?view=netcore-3.1">`static uint Max(uint val1, uint val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.max?view=netcore-3.1">`static ulong Max(ulong val1, ulong val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.min?view=netcore-3.1">`static byte Min(byte val1, byte val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.min?view=netcore-3.1">`static double Min(double val1, double val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.min?view=netcore-3.1">`static short Min(short val1, short val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.min?view=netcore-3.1">`static int Min(int val1, int val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.min?view=netcore-3.1">`static long Min(long val1, long val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.min?view=netcore-3.1">`static sbyte Min(sbyte val1, sbyte val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.min?view=netcore-3.1">`static float Min(float val1, float val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.min?view=netcore-3.1">`static ushort Min(ushort val1, ushort val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.min?view=netcore-3.1">`static uint Min(uint val1, uint val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.min?view=netcore-3.1">`static ulong Min(ulong val1, ulong val2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.pow?view=netcore-3.1">`static double Pow(double x, double y)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round?view=netcore-3.1">`static double Round(double a)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round?view=netcore-3.1">`static double Round(double value, int digits)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.round?view=netcore-3.1">`static double Round(double value, int digits, MidpointRounding mode)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign?view=netcore-3.1">`static int Sign(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign?view=netcore-3.1">`static int Sign(short value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign?view=netcore-3.1">`static int Sign(int value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign?view=netcore-3.1">`static int Sign(long value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign?view=netcore-3.1">`static int Sign(sbyte value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sign?view=netcore-3.1">`static int Sign(float value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sin?view=netcore-3.1">`static double Sin(double a)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sinh?view=netcore-3.1">`static double Sinh(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.sqrt?view=netcore-3.1">`static double Sqrt(double d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.tan?view=netcore-3.1">`static double Tan(double a)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.tanh?view=netcore-3.1">`static double Tanh(double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.math.truncate?view=netcore-3.1">`static double Truncate(double d)`</a>

## MulticastDelegate class
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.multicastdelegate.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

## NotImplementedException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.notimplementedexception.-ctor?view=netcore-3.1">`NotImplementedException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.notimplementedexception.-ctor?view=netcore-3.1">`NotImplementedException(string message)`</a>

## NotSupportedException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.notsupportedexception.-ctor?view=netcore-3.1">`NotSupportedException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.notsupportedexception.-ctor?view=netcore-3.1">`NotSupportedException(string message)`</a>

## NullReferenceException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.nullreferenceexception.-ctor?view=netcore-3.1">`NullReferenceException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.nullreferenceexception.-ctor?view=netcore-3.1">`NullReferenceException(string message)`</a>

## Nullable class
### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.nullable.equals?view=netcore-3.1">`static bool Equals<T>(Nullable n1, Nullable n2)`</a>

## Object class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.object.-ctor?view=netcore-3.1">`Object()`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.object.referenceequals?view=netcore-3.1">`static bool ReferenceEquals(object objA, object objB)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.object.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.object.gettype?view=netcore-3.1">`Type GetType()`</a>

## ObjectDisposedException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.objectdisposedexception.-ctor?view=netcore-3.1">`ObjectDisposedException(string objectName)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.objectdisposedexception.message?view=netcore-3.1">`string Message { get; }`</a>

## ObsoleteAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.obsoleteattribute.-ctor?view=netcore-3.1">`ObsoleteAttribute()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.obsoleteattribute.-ctor?view=netcore-3.1">`ObsoleteAttribute(string message)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.obsoleteattribute.-ctor?view=netcore-3.1">`ObsoleteAttribute(string message, bool error)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.obsoleteattribute.iserror?view=netcore-3.1">`bool IsError { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.obsoleteattribute.message?view=netcore-3.1">`string Message { get; }`</a>

## OverflowException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.overflowexception.-ctor?view=netcore-3.1">`OverflowException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.overflowexception.-ctor?view=netcore-3.1">`OverflowException(string message)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.overflowexception.-ctor?view=netcore-3.1">`OverflowException(string message, Exception innerException)`</a>

## ParamArrayAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.paramarrayattribute.-ctor?view=netcore-3.1">`ParamArrayAttribute()`</a>

## Predicate&lt;T&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.predicate`1.-ctor?view=netcore-3.1">`Predicate<T>(object object, IntPtr method)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.predicate`1.invoke?view=netcore-3.1">`bool Invoke(T obj)`</a>

## SerializableAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.serializableattribute.-ctor?view=netcore-3.1">`SerializableAttribute()`</a>

## String class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.-ctor?view=netcore-3.1">`String(Char* value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.-ctor?view=netcore-3.1">`String(Char* value, int startIndex, int length)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.-ctor?view=netcore-3.1">`String(Char[] value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.-ctor?view=netcore-3.1">`String(Char[] value, int startIndex, int length)`</a>

### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.empty?view=netcore-3.1">`readonly static string Empty`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.concat?view=netcore-3.1">`static string Concat(object arg0, object arg1)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.concat?view=netcore-3.1">`static string Concat(object arg0, object arg1, object arg2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.concat?view=netcore-3.1">`static string Concat(Object[] args)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.concat?view=netcore-3.1">`static string Concat(string str0, string str1)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.concat?view=netcore-3.1">`static string Concat(string str0, string str1, string str2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.concat?view=netcore-3.1">`static string Concat(string str0, string str1, string str2, string str3)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.concat?view=netcore-3.1">`static string Concat(String[] values)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=netcore-3.1">`static string Format(string format, object arg0)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=netcore-3.1">`static string Format(string format, object arg0, object arg1)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=netcore-3.1">`static string Format(string format, object arg0, object arg1, object arg2)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=netcore-3.1">`static string Format(string format, Object[] args)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.isnullorempty?view=netcore-3.1">`static bool IsNullOrEmpty(string value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.op_equality?view=netcore-3.1">`static bool op_Equality(string a, string b)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.op_inequality?view=netcore-3.1">`static bool op_Inequality(string a, string b)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.chars?view=netcore-3.1">`char Chars { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.length?view=netcore-3.1">`int Length { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.clone?view=netcore-3.1">`object Clone()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.compareto?view=netcore-3.1">`int CompareTo(string strB)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.equals?view=netcore-3.1">`bool Equals(string value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof?view=netcore-3.1">`int IndexOf(char value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof?view=netcore-3.1">`int IndexOf(char value, int startIndex)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.substring?view=netcore-3.1">`string Substring(int startIndex)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.substring?view=netcore-3.1">`string Substring(int startIndex, int length)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.string.trim?view=netcore-3.1">`string Trim()`</a>

## SystemException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.systemexception.-ctor?view=netcore-3.1">`SystemException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.systemexception.-ctor?view=netcore-3.1">`SystemException(string message)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.systemexception.-ctor?view=netcore-3.1">`SystemException(string message, Exception innerException)`</a>

## Type class
### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.gettypecode?view=netcore-3.1">`static TypeCode GetTypeCode(Type type)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.gettypefromhandle?view=netcore-3.1">`static Type GetTypeFromHandle(RuntimeTypeHandle handle)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.assemblyqualifiedname?view=netcore-3.1">`string AssemblyQualifiedName { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.basetype?view=netcore-3.1">`Type BaseType { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.isabstract?view=netcore-3.1">`bool IsAbstract { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.isarray?view=netcore-3.1">`bool IsArray { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.isclass?view=netcore-3.1">`bool IsClass { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.isenum?view=netcore-3.1">`bool IsEnum { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.isinterface?view=netcore-3.1">`bool IsInterface { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.ispointer?view=netcore-3.1">`bool IsPointer { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.isprimitive?view=netcore-3.1">`bool IsPrimitive { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.isvaluetype?view=netcore-3.1">`bool IsValueType { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.equals?view=netcore-3.1">`bool Equals(object o)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.equals?view=netcore-3.1">`bool Equals(Type o)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.type.isassignablefrom?view=netcore-3.1">`bool IsAssignableFrom(Type c)`</a>

## ValueType class
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.valuetype.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

# System.Collections
## IEnumerable interface
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable.getenumerator?view=netcore-3.1">`IEnumerator GetEnumerator()`</a>

## IEnumerator interface
### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator.current?view=netcore-3.1">`object Current { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator.movenext?view=netcore-3.1">`bool MoveNext()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator.reset?view=netcore-3.1">`void Reset()`</a>

## DictionaryEntry struct
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.dictionaryentry.-ctor?view=netcore-3.1">`DictionaryEntry(object key, object value)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.dictionaryentry.key?view=netcore-3.1">`object Key { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.dictionaryentry.value?view=netcore-3.1">`object Value { get; set; }`</a>

# System.Collections.Generic
## ICollection&lt;T&gt; interface
### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection`1.count?view=netcore-3.1">`int Count { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection`1.isreadonly?view=netcore-3.1">`bool IsReadOnly { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection`1.add?view=netcore-3.1">`void Add(T item)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection`1.clear?view=netcore-3.1">`void Clear()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection`1.contains?view=netcore-3.1">`bool Contains(T item)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection`1.copyto?view=netcore-3.1">`void CopyTo(T[] array, int arrayIndex)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection`1.remove?view=netcore-3.1">`bool Remove(T item)`</a>

## IComparer&lt;T&gt; interface
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer`1.compare?view=netcore-3.1">`int Compare(T x, T y)`</a>

## IDictionary&lt;TKey, TValue&gt; interface
### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary`2.item?view=netcore-3.1">`TValue Item { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary`2.keys?view=netcore-3.1">`ICollection Keys { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary`2.values?view=netcore-3.1">`ICollection Values { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary`2.add?view=netcore-3.1">`void Add(TKey key, TValue value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary`2.containskey?view=netcore-3.1">`bool ContainsKey(TKey key)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary`2.remove?view=netcore-3.1">`bool Remove(TKey key)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary`2.trygetvalue?view=netcore-3.1">`bool TryGetValue(TKey key, out TValue value)`</a>

## IEnumerable&lt;T&gt; interface
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable`1.getenumerator?view=netcore-3.1">`IEnumerator GetEnumerator()`</a>

## IEnumerator&lt;T&gt; interface
### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerator`1.current?view=netcore-3.1">`T Current { get; }`</a>

## IEqualityComparer&lt;T&gt; interface
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer`1.equals?view=netcore-3.1">`bool Equals(T x, T y)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iequalitycomparer`1.gethashcode?view=netcore-3.1">`int GetHashCode(T obj)`</a>

## IList&lt;T&gt; interface
### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist`1.item?view=netcore-3.1">`T Item { get; set; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist`1.indexof?view=netcore-3.1">`int IndexOf(T item)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist`1.insert?view=netcore-3.1">`void Insert(int index, T item)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ilist`1.removeat?view=netcore-3.1">`void RemoveAt(int index)`</a>

## IReadOnlyCollection&lt;T&gt; interface
### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlycollection`1.count?view=netcore-3.1">`int Count { get; }`</a>

## IReadOnlyList&lt;T&gt; interface
### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlylist`1.item?view=netcore-3.1">`T Item { get; }`</a>

## ISet&lt;T&gt; interface
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iset`1.add?view=netcore-3.1">`bool Add(T item)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iset`1.exceptwith?view=netcore-3.1">`void ExceptWith(IEnumerable other)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iset`1.intersectwith?view=netcore-3.1">`void IntersectWith(IEnumerable other)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iset`1.ispropersubsetof?view=netcore-3.1">`bool IsProperSubsetOf(IEnumerable other)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iset`1.ispropersupersetof?view=netcore-3.1">`bool IsProperSupersetOf(IEnumerable other)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iset`1.issubsetof?view=netcore-3.1">`bool IsSubsetOf(IEnumerable other)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iset`1.issupersetof?view=netcore-3.1">`bool IsSupersetOf(IEnumerable other)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iset`1.overlaps?view=netcore-3.1">`bool Overlaps(IEnumerable other)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iset`1.setequals?view=netcore-3.1">`bool SetEquals(IEnumerable other)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iset`1.symmetricexceptwith?view=netcore-3.1">`void SymmetricExceptWith(IEnumerable other)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.iset`1.unionwith?view=netcore-3.1">`void UnionWith(IEnumerable other)`</a>

## KeyValuePair&lt;TKey, TValue&gt; struct
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.keyvaluepair`2.-ctor?view=netcore-3.1">`KeyValuePair<TKey, TValue>(TKey key, TValue value)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.keyvaluepair`2.key?view=netcore-3.1">`TKey Key { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.keyvaluepair`2.value?view=netcore-3.1">`TValue Value { get; }`</a>

## Dictionary&lt;TKey, TValue&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.-ctor?view=netcore-3.1">`Dictionary<TKey, TValue>()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.-ctor?view=netcore-3.1">`Dictionary<TKey, TValue>(IDictionary dictionary)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.-ctor?view=netcore-3.1">`Dictionary<TKey, TValue>(IDictionary dictionary, IEqualityComparer comparer)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.-ctor?view=netcore-3.1">`Dictionary<TKey, TValue>(IEqualityComparer comparer)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.-ctor?view=netcore-3.1">`Dictionary<TKey, TValue>(int capacity)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.-ctor?view=netcore-3.1">`Dictionary<TKey, TValue>(int capacity, IEqualityComparer comparer)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.comparer?view=netcore-3.1">`IEqualityComparer Comparer { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.count?view=netcore-3.1">`int Count { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.item?view=netcore-3.1">`TValue Item { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.keys?view=netcore-3.1">`System.Collections.Generic.Dictionary Keys { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.values?view=netcore-3.1">`System.Collections.Generic.Dictionary Values { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.add?view=netcore-3.1">`void Add(TKey key, TValue value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.clear?view=netcore-3.1">`void Clear()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.containskey?view=netcore-3.1">`bool ContainsKey(TKey key)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.containsvalue?view=netcore-3.1">`bool ContainsValue(TValue value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.getenumerator?view=netcore-3.1">`System.Collections.Generic.Dictionary GetEnumerator()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.remove?view=netcore-3.1">`bool Remove(TKey key)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary`2.trygetvalue?view=netcore-3.1">`bool TryGetValue(TKey key, out TValue value)`</a>

## EqualityComparer&lt;T&gt; class
### Static Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.equalitycomparer`1.default?view=netcore-3.1">`EqualityComparer Default { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.equalitycomparer`1.equals?view=netcore-3.1">`bool Equals(T x, T y)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.equalitycomparer`1.gethashcode?view=netcore-3.1">`int GetHashCode(T obj)`</a>

## KeyNotFoundException class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.keynotfoundexception.-ctor?view=netcore-3.1">`KeyNotFoundException()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.keynotfoundexception.-ctor?view=netcore-3.1">`KeyNotFoundException(string message)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.keynotfoundexception.-ctor?view=netcore-3.1">`KeyNotFoundException(string message, System.Exception innerException)`</a>

## List&lt;T&gt; class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.-ctor?view=netcore-3.1">`List<T>()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.-ctor?view=netcore-3.1">`List<T>(int capacity)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.capacity?view=netcore-3.1">`int Capacity { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.count?view=netcore-3.1">`int Count { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.item?view=netcore-3.1">`T Item { get; set; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.add?view=netcore-3.1">`void Add(T item)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.clear?view=netcore-3.1">`void Clear()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.contains?view=netcore-3.1">`bool Contains(T item)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.copyto?view=netcore-3.1">`void CopyTo(T[] array, int arrayIndex)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.findindex?view=netcore-3.1">`int FindIndex(int startIndex, int count, System.Predicate match)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.findindex?view=netcore-3.1">`int FindIndex(int startIndex, System.Predicate match)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.findindex?view=netcore-3.1">`int FindIndex(System.Predicate match)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.getenumerator?view=netcore-3.1">`System.Collections.Generic.List GetEnumerator()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.indexof?view=netcore-3.1">`int IndexOf(T item)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.insert?view=netcore-3.1">`void Insert(int index, T item)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.remove?view=netcore-3.1">`bool Remove(T item)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.removeat?view=netcore-3.1">`void RemoveAt(int index)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.reverse?view=netcore-3.1">`void Reverse()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.reverse?view=netcore-3.1">`void Reverse(int index, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list`1.toarray?view=netcore-3.1">`T[] ToArray()`</a>

# System.ComponentModel
## EditorBrowsableState enum
### Values
`Advanced`

`Always`

`Never`

## EditorBrowsableAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.editorbrowsableattribute.-ctor?view=netcore-3.1">`EditorBrowsableAttribute()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.editorbrowsableattribute.-ctor?view=netcore-3.1">`EditorBrowsableAttribute(EditorBrowsableState state)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.editorbrowsableattribute.state?view=netcore-3.1">`EditorBrowsableState State { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.editorbrowsableattribute.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

# System.Diagnostics
## ConditionalAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.conditionalattribute.-ctor?view=netcore-3.1">`ConditionalAttribute(string conditionString)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.conditionalattribute.conditionstring?view=netcore-3.1">`string ConditionString { get; }`</a>

## DebuggableAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggableattribute.-ctor?view=netcore-3.1">`DebuggableAttribute(bool isJITTrackingEnabled, bool isJITOptimizerDisabled)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggableattribute.-ctor?view=netcore-3.1">`DebuggableAttribute(System.Diagnostics.DebuggableAttribute/DebuggingModes modes)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggableattribute.debuggingflags?view=netcore-3.1">`System.Diagnostics.DebuggableAttribute/DebuggingModes DebuggingFlags { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggableattribute.isjitoptimizerdisabled?view=netcore-3.1">`bool IsJITOptimizerDisabled { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggableattribute.isjittrackingenabled?view=netcore-3.1">`bool IsJITTrackingEnabled { get; }`</a>

## Debugger class
### Static Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debugger.isattached?view=netcore-3.1">`bool IsAttached { get; }`</a>

## DebuggerDisplayAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggerdisplayattribute.-ctor?view=netcore-3.1">`DebuggerDisplayAttribute(string value)`</a>

## DebuggerStepThroughAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggerstepthroughattribute.-ctor?view=netcore-3.1">`DebuggerStepThroughAttribute()`</a>

## DebuggerTypeProxyAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debuggertypeproxyattribute.-ctor?view=netcore-3.1">`DebuggerTypeProxyAttribute(System.Type type)`</a>

## Stopwatch class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.-ctor?view=netcore-3.1">`Stopwatch()`</a>

### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.frequency?view=netcore-3.1">`readonly static long Frequency`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.ishighresolution?view=netcore-3.1">`readonly static bool IsHighResolution`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.startnew?view=netcore-3.1">`static Stopwatch StartNew()`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.elapsed?view=netcore-3.1">`System.TimeSpan Elapsed { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.elapsedmilliseconds?view=netcore-3.1">`long ElapsedMilliseconds { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.elapsedticks?view=netcore-3.1">`long ElapsedTicks { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.isrunning?view=netcore-3.1">`bool IsRunning { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.reset?view=netcore-3.1">`void Reset()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.restart?view=netcore-3.1">`void Restart()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.start?view=netcore-3.1">`void Start()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.stop?view=netcore-3.1">`void Stop()`</a>

# System.Globalization
## CultureInfo class
### Static Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture?view=netcore-3.1">`CultureInfo CurrentCulture { get; }`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.name?view=netcore-3.1">`string Name { get; }`</a>

## NumberFormatInfo class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.globalization.numberformatinfo.-ctor?view=netcore-3.1">`NumberFormatInfo()`</a>

### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.globalization.numberformatinfo.getinstance?view=netcore-3.1">`static NumberFormatInfo GetInstance(System.IFormatProvider formatProvider)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.globalization.numberformatinfo.clone?view=netcore-3.1">`object Clone()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.globalization.numberformatinfo.getformat?view=netcore-3.1">`object GetFormat(System.Type formatType)`</a>

# System.IO
## SeekOrigin enum
### Values
`Begin`

`Current`

`End`

## Stream class
### Static Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.null?view=netcore-3.1">`readonly static Stream Null`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.canread?view=netcore-3.1">`bool CanRead { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.canseek?view=netcore-3.1">`bool CanSeek { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.cantimeout?view=netcore-3.1">`bool CanTimeout { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.canwrite?view=netcore-3.1">`bool CanWrite { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.length?view=netcore-3.1">`long Length { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.position?view=netcore-3.1">`long Position { get; set; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.close?view=netcore-3.1">`void Close()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.copyto?view=netcore-3.1">`void CopyTo(Stream destination)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.copyto?view=netcore-3.1">`void CopyTo(Stream destination, int bufferSize)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.dispose?view=netcore-3.1">`void Dispose()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.flush?view=netcore-3.1">`void Flush()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.read?view=netcore-3.1">`int Read(System.Byte[] buffer, int offset, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.readbyte?view=netcore-3.1">`int ReadByte()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.seek?view=netcore-3.1">`long Seek(long offset, SeekOrigin origin)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.setlength?view=netcore-3.1">`void SetLength(long value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.write?view=netcore-3.1">`void Write(System.Byte[] buffer, int offset, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.writebyte?view=netcore-3.1">`void WriteByte(byte value)`</a>

# System.Reflection
## CustomAttributeExtensions class
### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.reflection.customattributeextensions.getcustomattribute?view=netcore-3.1">`static System.Attribute GetCustomAttribute(MemberInfo element, System.Type attributeType)`</a>

## DefaultMemberAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.reflection.defaultmemberattribute.-ctor?view=netcore-3.1">`DefaultMemberAttribute(string memberName)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.reflection.defaultmemberattribute.membername?view=netcore-3.1">`string MemberName { get; }`</a>

## MemberInfo class
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.reflection.memberinfo.equals?view=netcore-3.1">`bool Equals(object obj)`</a>

# System.Runtime.CompilerServices
## CompilationRelaxations enum
### Values
`NoStringInterning`

## MethodCodeType enum
### Values
`IL`

`Native`

`OPTIL`

`Runtime`

## MethodImplOptions enum
### Values
`AggressiveInlining`

`ForwardRef`

`InternalCall`

`NoInlining`

`NoOptimization`

`PreserveSig`

`Synchronized`

`Unmanaged`

## CompilationRelaxationsAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.compilationrelaxationsattribute.-ctor?view=netcore-3.1">`CompilationRelaxationsAttribute(int relaxations)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.compilationrelaxationsattribute.-ctor?view=netcore-3.1">`CompilationRelaxationsAttribute(CompilationRelaxations relaxations)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.compilationrelaxationsattribute.compilationrelaxations?view=netcore-3.1">`int CompilationRelaxations { get; }`</a>

## CompilerGeneratedAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.compilergeneratedattribute.-ctor?view=netcore-3.1">`CompilerGeneratedAttribute()`</a>

## ExtensionAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.extensionattribute.-ctor?view=netcore-3.1">`ExtensionAttribute()`</a>

## FixedAddressValueTypeAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.fixedaddressvaluetypeattribute.-ctor?view=netcore-3.1">`FixedAddressValueTypeAttribute()`</a>

## FixedBufferAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.fixedbufferattribute.-ctor?view=netcore-3.1">`FixedBufferAttribute(System.Type elementType, int length)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.fixedbufferattribute.elementtype?view=netcore-3.1">`System.Type ElementType { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.fixedbufferattribute.length?view=netcore-3.1">`int Length { get; }`</a>

## IndexerNameAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.indexernameattribute.-ctor?view=netcore-3.1">`IndexerNameAttribute(string indexerName)`</a>

## InternalsVisibleToAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.internalsvisibletoattribute.-ctor?view=netcore-3.1">`InternalsVisibleToAttribute(string assemblyName)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.internalsvisibletoattribute.allinternalsvisible?view=netcore-3.1">`bool AllInternalsVisible { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.internalsvisibletoattribute.assemblyname?view=netcore-3.1">`string AssemblyName { get; }`</a>

## IsVolatile class
## MethodImplAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.methodimplattribute.-ctor?view=netcore-3.1">`MethodImplAttribute(MethodImplOptions methodImplOptions)`</a>

### Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.methodimplattribute.methodcodetype?view=netcore-3.1">`MethodCodeType MethodCodeType`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.methodimplattribute.value?view=netcore-3.1">`MethodImplOptions Value { get; }`</a>

## RuntimeCompatibilityAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.runtimecompatibilityattribute.-ctor?view=netcore-3.1">`RuntimeCompatibilityAttribute()`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.runtimecompatibilityattribute.wrapnonexceptionthrows?view=netcore-3.1">`bool WrapNonExceptionThrows { get; set; }`</a>

## RuntimeHelpers class
### Static Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.runtimehelpers.offsettostringdata?view=netcore-3.1">`int OffsetToStringData { get; }`</a>

## TypeForwardedToAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.typeforwardedtoattribute.-ctor?view=netcore-3.1">`TypeForwardedToAttribute(System.Type destination)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.typeforwardedtoattribute.destination?view=netcore-3.1">`System.Type Destination { get; }`</a>

## UnsafeValueTypeAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.unsafevaluetypeattribute.-ctor?view=netcore-3.1">`UnsafeValueTypeAttribute()`</a>

# System.Runtime.ConstrainedExecution
## Cer enum
### Values
`MayFail`

`None`

`Success`

## Consistency enum
### Values
`MayCorruptAppDomain`

`MayCorruptInstance`

`MayCorruptProcess`

`WillNotCorruptState`

## CriticalFinalizerObject class
## ReliabilityContractAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.constrainedexecution.reliabilitycontractattribute.-ctor?view=netcore-3.1">`ReliabilityContractAttribute(Consistency consistencyGuarantee, Cer cer)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.constrainedexecution.reliabilitycontractattribute.cer?view=netcore-3.1">`Cer Cer { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.constrainedexecution.reliabilitycontractattribute.consistencyguarantee?view=netcore-3.1">`Consistency ConsistencyGuarantee { get; }`</a>

# System.Runtime.InteropServices
## CallingConvention enum
### Values
`Cdecl`

`FastCall`

`StdCall`

`ThisCall`

`Winapi`

## CharSet enum
### Values
`Ansi`

`Auto`

`None`

`Unicode`

## GCHandleType enum
### Values
`Normal`

`Pinned`

`Weak`

`WeakTrackResurrection`

## LayoutKind enum
### Values
`Auto`

`Explicit`

`Sequential`

## UnmanagedType enum
### Values
`AnsiBStr`

`AsAny`

`Bool`

`BStr`

`ByValArray`

`ByValTStr`

`Currency`

`CustomMarshaler`

`Error`

`FunctionPtr`

`HString`

`I1`

`I2`

`I4`

`I8`

`IDispatch`

`IInspectable`

`Interface`

`IUnknown`

`LPArray`

`LPStr`

`LPStruct`

`LPTStr`

`LPWStr`

`R4`

`R8`

`SafeArray`

`Struct`

`SysInt`

`SysUInt`

`TBStr`

`U1`

`U2`

`U4`

`U8`

`VariantBool`

`VBByRefStr`

## VarEnum enum
### Values
`VT_ARRAY`

`VT_BLOB`

`VT_BLOB_OBJECT`

`VT_BOOL`

`VT_BSTR`

`VT_BYREF`

`VT_CARRAY`

`VT_CF`

`VT_CLSID`

`VT_CY`

`VT_DATE`

`VT_DECIMAL`

`VT_DISPATCH`

`VT_EMPTY`

`VT_ERROR`

`VT_FILETIME`

`VT_HRESULT`

`VT_I1`

`VT_I2`

`VT_I4`

`VT_I8`

`VT_INT`

`VT_LPSTR`

`VT_LPWSTR`

`VT_NULL`

`VT_PTR`

`VT_R4`

`VT_R8`

`VT_RECORD`

`VT_SAFEARRAY`

`VT_STORAGE`

`VT_STORED_OBJECT`

`VT_STREAM`

`VT_STREAMED_OBJECT`

`VT_UI1`

`VT_UI2`

`VT_UI4`

`VT_UI8`

`VT_UINT`

`VT_UNKNOWN`

`VT_USERDEFINED`

`VT_VARIANT`

`VT_VECTOR`

`VT_VOID`

## GCHandle struct
### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.gchandle.alloc?view=netcore-3.1">`static GCHandle Alloc(object value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.gchandle.alloc?view=netcore-3.1">`static GCHandle Alloc(object value, GCHandleType type)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.gchandle.fromintptr?view=netcore-3.1">`static GCHandle FromIntPtr(System.IntPtr value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.gchandle.op_explicit?view=netcore-3.1">`static GCHandle op_Explicit(System.IntPtr value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.gchandle.op_explicit?view=netcore-3.1">`static System.IntPtr op_Explicit(GCHandle value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.gchandle.tointptr?view=netcore-3.1">`static System.IntPtr ToIntPtr(GCHandle value)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.gchandle.isallocated?view=netcore-3.1">`bool IsAllocated { get; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.gchandle.target?view=netcore-3.1">`object Target { get; set; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.gchandle.addrofpinnedobject?view=netcore-3.1">`System.IntPtr AddrOfPinnedObject()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.gchandle.equals?view=netcore-3.1">`bool Equals(object o)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.gchandle.free?view=netcore-3.1">`void Free()`</a>

## DllImportAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.dllimportattribute.-ctor?view=netcore-3.1">`DllImportAttribute(string dllName)`</a>

### Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.dllimportattribute.bestfitmapping?view=netcore-3.1">`bool BestFitMapping`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.dllimportattribute.callingconvention?view=netcore-3.1">`CallingConvention CallingConvention`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.dllimportattribute.charset?view=netcore-3.1">`CharSet CharSet`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.dllimportattribute.entrypoint?view=netcore-3.1">`string EntryPoint`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.dllimportattribute.exactspelling?view=netcore-3.1">`bool ExactSpelling`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.dllimportattribute.preservesig?view=netcore-3.1">`bool PreserveSig`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.dllimportattribute.setlasterror?view=netcore-3.1">`bool SetLastError`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.dllimportattribute.throwonunmappablechar?view=netcore-3.1">`bool ThrowOnUnmappableChar`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.dllimportattribute.value?view=netcore-3.1">`string Value { get; }`</a>

## FieldOffsetAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.fieldoffsetattribute.-ctor?view=netcore-3.1">`FieldOffsetAttribute(int offset)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.fieldoffsetattribute.value?view=netcore-3.1">`int Value { get; }`</a>

## InAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.inattribute.-ctor?view=netcore-3.1">`InAttribute()`</a>

## Marshal class
### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.freecotaskmem?view=netcore-3.1">`static void FreeCoTaskMem(System.IntPtr ptr)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.getfunctionpointerfordelegate?view=netcore-3.1">`static System.IntPtr GetFunctionPointerForDelegate(System.Delegate d)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.ptrtostringansi?view=netcore-3.1">`static string PtrToStringAnsi(System.IntPtr ptr)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.sizeof?view=netcore-3.1">`static int SizeOf<T>()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshal.stringtocotaskmemansi?view=netcore-3.1">`static System.IntPtr StringToCoTaskMemAnsi(string s)`</a>

## MarshalAsAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshalasattribute.-ctor?view=netcore-3.1">`MarshalAsAttribute(short unmanagedType)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshalasattribute.-ctor?view=netcore-3.1">`MarshalAsAttribute(UnmanagedType unmanagedType)`</a>

### Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshalasattribute.arraysubtype?view=netcore-3.1">`UnmanagedType ArraySubType`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshalasattribute.iidparameterindex?view=netcore-3.1">`int IidParameterIndex`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshalasattribute.marshalcookie?view=netcore-3.1">`string MarshalCookie`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshalasattribute.marshaltype?view=netcore-3.1">`string MarshalType`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshalasattribute.marshaltyperef?view=netcore-3.1">`System.Type MarshalTypeRef`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshalasattribute.safearraysubtype?view=netcore-3.1">`VarEnum SafeArraySubType`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshalasattribute.safearrayuserdefinedsubtype?view=netcore-3.1">`System.Type SafeArrayUserDefinedSubType`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshalasattribute.sizeconst?view=netcore-3.1">`int SizeConst`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshalasattribute.sizeparamindex?view=netcore-3.1">`short SizeParamIndex`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.marshalasattribute.value?view=netcore-3.1">`UnmanagedType Value { get; }`</a>

## OutAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.outattribute.-ctor?view=netcore-3.1">`OutAttribute()`</a>

## StructLayoutAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.structlayoutattribute.-ctor?view=netcore-3.1">`StructLayoutAttribute(short layoutKind)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.structlayoutattribute.-ctor?view=netcore-3.1">`StructLayoutAttribute(LayoutKind layoutKind)`</a>

### Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.structlayoutattribute.charset?view=netcore-3.1">`CharSet CharSet`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.structlayoutattribute.pack?view=netcore-3.1">`int Pack`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.structlayoutattribute.size?view=netcore-3.1">`int Size`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.structlayoutattribute.value?view=netcore-3.1">`LayoutKind Value { get; }`</a>

## UnmanagedFunctionPointerAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.unmanagedfunctionpointerattribute.-ctor?view=netcore-3.1">`UnmanagedFunctionPointerAttribute(CallingConvention callingConvention)`</a>

### Fields
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.unmanagedfunctionpointerattribute.bestfitmapping?view=netcore-3.1">`bool BestFitMapping`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.unmanagedfunctionpointerattribute.charset?view=netcore-3.1">`CharSet CharSet`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.unmanagedfunctionpointerattribute.setlasterror?view=netcore-3.1">`bool SetLastError`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.unmanagedfunctionpointerattribute.throwonunmappablechar?view=netcore-3.1">`bool ThrowOnUnmappableChar`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.unmanagedfunctionpointerattribute.callingconvention?view=netcore-3.1">`CallingConvention CallingConvention { get; }`</a>

# System.Security
## SecurityCriticalAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.securitycriticalattribute.-ctor?view=netcore-3.1">`SecurityCriticalAttribute()`</a>

## SecuritySafeCriticalAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.securitysafecriticalattribute.-ctor?view=netcore-3.1">`SecuritySafeCriticalAttribute()`</a>

## UnverifiableCodeAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.unverifiablecodeattribute.-ctor?view=netcore-3.1">`UnverifiableCodeAttribute()`</a>

# System.Security.Permissions
## SecurityAction enum
### Values
`Assert`

`Demand`

`Deny`

`InheritanceDemand`

`LinkDemand`

`PermitOnly`

`RequestMinimum`

`RequestOptional`

`RequestRefuse`

## SecurityPermissionFlag enum
### Values
`AllFlags`

`Assertion`

`BindingRedirects`

`ControlAppDomain`

`ControlDomainPolicy`

`ControlEvidence`

`ControlPolicy`

`ControlPrincipal`

`ControlThread`

`Execution`

`Infrastructure`

`NoFlags`

`RemotingConfiguration`

`SerializationFormatter`

`SkipVerification`

`UnmanagedCode`

## CodeAccessSecurityAttribute class
## SecurityAttribute class
## SecurityPermissionAttribute class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.-ctor?view=netcore-3.1">`SecurityPermissionAttribute(SecurityAction action)`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.assertion?view=netcore-3.1">`bool Assertion { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.bindingredirects?view=netcore-3.1">`bool BindingRedirects { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.controlappdomain?view=netcore-3.1">`bool ControlAppDomain { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.controldomainpolicy?view=netcore-3.1">`bool ControlDomainPolicy { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.controlevidence?view=netcore-3.1">`bool ControlEvidence { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.controlpolicy?view=netcore-3.1">`bool ControlPolicy { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.controlprincipal?view=netcore-3.1">`bool ControlPrincipal { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.controlthread?view=netcore-3.1">`bool ControlThread { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.execution?view=netcore-3.1">`bool Execution { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.flags?view=netcore-3.1">`SecurityPermissionFlag Flags { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.infrastructure?view=netcore-3.1">`bool Infrastructure { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.remotingconfiguration?view=netcore-3.1">`bool RemotingConfiguration { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.serializationformatter?view=netcore-3.1">`bool SerializationFormatter { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.skipverification?view=netcore-3.1">`bool SkipVerification { get; set; }`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.securitypermissionattribute.unmanagedcode?view=netcore-3.1">`bool UnmanagedCode { get; set; }`</a>

# System.Text
## Encoding class
### Static Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.utf8?view=netcore-3.1">`Encoding UTF8 { get; }`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.clone?view=netcore-3.1">`object Clone()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.equals?view=netcore-3.1">`bool Equals(object value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getbytecount?view=netcore-3.1">`int GetByteCount(System.Char* chars, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getbytecount?view=netcore-3.1">`int GetByteCount(System.Char[] chars)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getbytecount?view=netcore-3.1">`int GetByteCount(System.Char[] chars, int index, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getbytecount?view=netcore-3.1">`int GetByteCount(string s)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getbytes?view=netcore-3.1">`int GetBytes(System.Char* chars, int charCount, System.Byte* bytes, int byteCount)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getbytes?view=netcore-3.1">`System.Byte[] GetBytes(System.Char[] chars)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getbytes?view=netcore-3.1">`System.Byte[] GetBytes(System.Char[] chars, int index, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getbytes?view=netcore-3.1">`int GetBytes(System.Char[] chars, int charIndex, int charCount, System.Byte[] bytes, int byteIndex)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getbytes?view=netcore-3.1">`System.Byte[] GetBytes(string s)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getbytes?view=netcore-3.1">`int GetBytes(string s, int charIndex, int charCount, System.Byte[] bytes, int byteIndex)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getcharcount?view=netcore-3.1">`int GetCharCount(System.Byte* bytes, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getcharcount?view=netcore-3.1">`int GetCharCount(System.Byte[] bytes)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getcharcount?view=netcore-3.1">`int GetCharCount(System.Byte[] bytes, int index, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getchars?view=netcore-3.1">`int GetChars(System.Byte* bytes, int byteCount, System.Char* chars, int charCount)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getchars?view=netcore-3.1">`System.Char[] GetChars(System.Byte[] bytes)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getchars?view=netcore-3.1">`System.Char[] GetChars(System.Byte[] bytes, int index, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getchars?view=netcore-3.1">`int GetChars(System.Byte[] bytes, int byteIndex, int byteCount, System.Char[] chars, int charIndex)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getpreamble?view=netcore-3.1">`System.Byte[] GetPreamble()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring?view=netcore-3.1">`string GetString(System.Byte* bytes, int byteCount)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring?view=netcore-3.1">`string GetString(System.Byte[] bytes)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring?view=netcore-3.1">`string GetString(System.Byte[] bytes, int index, int count)`</a>

## UTF8Encoding class
### Constructors
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.-ctor?view=netcore-3.1">`UTF8Encoding()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.-ctor?view=netcore-3.1">`UTF8Encoding(bool encoderShouldEmitUTF8Identifier)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.-ctor?view=netcore-3.1">`UTF8Encoding(bool encoderShouldEmitUTF8Identifier, bool throwOnInvalidBytes)`</a>

### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.equals?view=netcore-3.1">`bool Equals(object value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.getbytecount?view=netcore-3.1">`int GetByteCount(System.Char* chars, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.getbytecount?view=netcore-3.1">`int GetByteCount(System.Char[] chars, int index, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.getbytecount?view=netcore-3.1">`int GetByteCount(string chars)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.getbytes?view=netcore-3.1">`int GetBytes(System.Char* chars, int charCount, System.Byte* bytes, int byteCount)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.getbytes?view=netcore-3.1">`int GetBytes(System.Char[] chars, int charIndex, int charCount, System.Byte[] bytes, int byteIndex)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.getbytes?view=netcore-3.1">`int GetBytes(string s, int charIndex, int charCount, System.Byte[] bytes, int byteIndex)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.getcharcount?view=netcore-3.1">`int GetCharCount(System.Byte* bytes, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.getcharcount?view=netcore-3.1">`int GetCharCount(System.Byte[] bytes, int index, int count)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.getchars?view=netcore-3.1">`int GetChars(System.Byte* bytes, int byteCount, System.Char* chars, int charCount)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.getchars?view=netcore-3.1">`int GetChars(System.Byte[] bytes, int byteIndex, int byteCount, System.Char[] chars, int charIndex)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.getpreamble?view=netcore-3.1">`System.Byte[] GetPreamble()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.text.utf8encoding.getstring?view=netcore-3.1">`string GetString(System.Byte[] bytes, int index, int count)`</a>

# System.Threading
## SpinLock struct
### Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.spinlock.enter?view=netcore-3.1">`void Enter(ref bool lockTaken)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.spinlock.exit?view=netcore-3.1">`void Exit(bool useMemoryBarrier)`</a>

## Interlocked class
### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.add?view=netcore-3.1">`static int Add(ref int location1, int value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.add?view=netcore-3.1">`static long Add(ref long location1, long value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.compareexchange?view=netcore-3.1">`static double CompareExchange(ref double location1, double value, double comparand)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.compareexchange?view=netcore-3.1">`static int CompareExchange(ref int location1, int value, int comparand)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.compareexchange?view=netcore-3.1">`static long CompareExchange(ref long location1, long value, long comparand)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.compareexchange?view=netcore-3.1">`static System.IntPtr CompareExchange(System.IntPtr location1, System.IntPtr value, System.IntPtr comparand)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.compareexchange?view=netcore-3.1">`static object CompareExchange(ref object location1, object value, object comparand)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.compareexchange?view=netcore-3.1">`static float CompareExchange(ref float location1, float value, float comparand)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.compareexchange?view=netcore-3.1">`static T CompareExchange<T>(T location1, T value, T comparand)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.decrement?view=netcore-3.1">`static int Decrement(ref int location)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.decrement?view=netcore-3.1">`static long Decrement(ref long location)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.exchange?view=netcore-3.1">`static double Exchange(ref double location1, double value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.exchange?view=netcore-3.1">`static int Exchange(ref int location1, int value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.exchange?view=netcore-3.1">`static long Exchange(ref long location1, long value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.exchange?view=netcore-3.1">`static System.IntPtr Exchange(System.IntPtr location1, System.IntPtr value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.exchange?view=netcore-3.1">`static object Exchange(ref object location1, object value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.exchange?view=netcore-3.1">`static float Exchange(ref float location1, float value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.exchange?view=netcore-3.1">`static T Exchange<T>(T location1, T value)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.increment?view=netcore-3.1">`static int Increment(ref int location)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.increment?view=netcore-3.1">`static long Increment(ref long location)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.memorybarrier?view=netcore-3.1">`static void MemoryBarrier()`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.interlocked.read?view=netcore-3.1">`static long Read(ref long location)`</a>

## Monitor class
### Static Methods
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.monitor.enter?view=netcore-3.1">`static void Enter(object obj)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.monitor.enter?view=netcore-3.1">`static void Enter(object obj, ref bool lockTaken)`</a>

<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.monitor.exit?view=netcore-3.1">`static void Exit(object obj)`</a>

## Thread class
### Static Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread.currentthread?view=netcore-3.1">`Thread CurrentThread { get; }`</a>

### Properties
<a href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread.currentculture?view=netcore-3.1">`System.Globalization.CultureInfo CurrentCulture { get; set; }`</a>


