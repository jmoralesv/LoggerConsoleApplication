﻿using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace LoggerConsoleApplication.Tests.Attributes;

/// <summary>
/// Provides auto-generated data specimens generated by AutoFixture as an extension to xUnit.net's Theory attribute,
/// and uses Moq to create those auto-generated data specimens.
/// </summary>
public class AutoMoqDataAttribute : AutoDataAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AutoMoqDataAttribute"/> class.
    /// </summary>
    public AutoMoqDataAttribute()
        : base(() =>
        {
            var fixture = new Fixture()
                .Customize(new AutoMoqCustomization { ConfigureMembers = true });

            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        })
    {
    }
}
