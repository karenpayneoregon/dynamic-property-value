using DeepEqual;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace ShouldlyUnitTestProject.Classes;

public static class DeepAssert
{
    public static void AreEqual(object actual, object expected, IComparison comparison = null)
    {
        actual.IsDeepEqual(expected, comparison).ShouldBe(true);
        actual.ShouldDeepEqual(expected, comparison);
    }

    public static void AreNotEqual(object actual, object expected, IComparison comparison = null)
    {
        actual.IsDeepEqual(expected, comparison).ShouldBe(false);
        Assert.ThrowsException<DeepEqualException>(() => actual.ShouldDeepEqual(expected, comparison));
    }
}