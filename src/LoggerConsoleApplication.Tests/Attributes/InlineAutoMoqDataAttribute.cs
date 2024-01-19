﻿using AutoFixture.Xunit2;

namespace LoggerConsoleApplication.Tests.Attributes;

/// <summary>
/// Provides a data source for a data theory, with the data coming from inline values combined with 
/// auto-generated data specimens generated by an <see cref="AutoMoqDataAttribute"/> instance.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="InlineAutoMoqDataAttribute"/> class.
/// </remarks>
/// <param name="values"></param>
public class InlineAutoMoqDataAttribute(params object[] values)
    : InlineAutoDataAttribute(new AutoMoqDataAttribute(), values)
{
}
