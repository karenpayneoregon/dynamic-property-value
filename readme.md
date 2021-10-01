# About

Provides a language extension method to change a property value in a class instance by property name as a string.

# Why should we write unit tests?

Have you ever needed to change your code, but you were concerned about breaking something? I've been there too.

The main reason to write unit tests is to gain confidence. Unit tests allow us to make changes, with confidence that they will work. Unit tests allow change.

Unit tests work like a `safety net` to prevent us from breaking things when we add features or change our codebase.

In addition, unit tests work like a living documentation. The first end-user of our code is our unit tests. If we want to know what a library does, we should check its unit tests. Often, we will find not-documented features in the tests.

# What makes a good unit test?

Now, we know what is a unit test and why we should write them. The next question we need to answer is: 'What makes a test a good unit test?' Let's see what all good unit tests have in common.

- **Tests should run quickly**. The `longer` our tests take to run, the `less frequent` we run them. And, if we don't run our tests often, we have doors opened to bugs.
 
- **Tests should run in any order**. Tests shouldn't depend on the output of previous tests to run. A test should create its own state and not rely upon the state of other tests.
 
- **Tests should be deterministic**. No matter how many times we run our tests, they should either fail or pass every time. We don't want our test to use random input, for example.
 
- **Tests should validate themselves**. We shouldn't debug our tests to make sure they passed or failed. Each test should determine the success or failure of the tested behavior. Imagine we have hundreds of tests and to make sure they pass, we have to debug every one of them. What's the point, then?


# Dates/time

Date and time objects can be challenging when there is a need to work with past and future dates which reply on testing with the current date time. The current DateTime comes from DateTime.Now and cannot be altered.


Dates and times can be mocked to test with in test methods yet when there is a method which has DateTime.Now for computations mocking is not possible although there are services that can mock DateTime.Now such as JustMock. 

# Test data

Most developers will mock data rather than use a live development database. There are pros and cons such as test take longer with live data while in some cases Entity Framework Core will not act the same with mocked verses live data. Then there is clean-up with live data long with multiple users hitting the same records at the same time which can affect testing outcomes.

# Article

:open_book: Microsoft TechNet: [Dynamically set property value in a class (C#)](https://social.technet.microsoft.com/wiki/contents/articles/54296.dynamically-set-property-value-in-a-class-c.aspx)

# Resources

- [QUint](https://qunitjs.com/) JavaScript testing framework.
- Pluralsight 
  - [Implementing C# Unit Testing Using Visual Studio 2019 and .NET 5](https://app.pluralsight.com/library/courses/basic-unit-testing-csharp-developers/table-of-contents)
  - [Creating Automated Browser Tests with Selenium in C#](https://app.pluralsight.com/library/courses/creating-automated-browser-tests-selenium-c-sharp/table-of-contents)
  - [Improving Unit Tests with Fluent Assertions](https://app.pluralsight.com/library/courses/fluent-assertions-improving-unit-tests/table-of-contents)


# Microsoft documentation
- [Unit test basics](https://docs.microsoft.com/en-us/visualstudio/test/unit-test-basics?view=vs-2019)
- [Live Unit Testing](https://docs.microsoft.com/en-us/visualstudio/test/live-unit-testing-intro?view=vs-2019)
- [web load testing](https://docs.microsoft.com/en-us/visualstudio/test/quickstart-create-a-load-test-project?view=vs-2019)

>  **Note** 
Live Unit Testing is only available in Visual Studio Enterprise edition and is supported only in .NET.

## Provides

|Class|Provides   |
| :---         |  :---  |
|TestBase | A place any `initialization code` and `mock-up code` here for unit test methods   |
|TestTraitsAttribute| The ability to setup meaningful [trait attributes](https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2019) for visual separation of unit test categories  |

# Use the MSTest framework in unit tests

The MSTest framework supports unit testing in Visual Studio. Use the classes and members in the Microsoft.VisualStudio.TestTools.UnitTesting namespace when you are coding unit tests. You can also use them when you are refining a unit test that was generated from code.

- [Microsoft documentation](https://docs.microsoft.com/en-us/visualstudio/test/using-microsoft-visualstudio-testtools-unittesting-members-in-unit-tests?view=vs-2019)

# Assertions – Constraint Model

|Assertion |What it does   |
| :---         |  :---  |
| Assert.AreEqual(28, _actualClaim);  | Tests whether the specified values are equal.   |
| Assert.AreNotEqual(28, _actualClaim);  | Tests whether the specified values are unequal. Same as AreEqual for numeric values.  |
| Assert.AreSame(_expectedInitialClaim, _actualInitialClaim); | Tests whether the specified objects both refer to the same object  |
| Assert.AreNotSame(_expectedInitialClaim, _actualInitialClaim); |  Tests whether the specified objects refer to different objects |
| Assert.IsTrue(_isThereEnoughFuel); | Tests whether the specified condition is true  |
| Assert.IsFalse(_isThereEnoughFuel); | Tests whether the specified condition is false  |
| Assert.IsNull(_actualInitialClaim); | Tests whether the specified object is null  |
| Assert.IsNotNull(_actualInitialClaim); | Tests whether the specified object is non-null  |
| Assert.IsInstanceOfType(_actualInitialClaim, typeof(dummyClaimInitialClaim)); | Tests whether the specified object is an instance of the expected type  |
| Assert.IsNotInstanceOfType(_actualInitialClaim, typeof(dummyClaim9InitialClaim)); | Tests whether the specified object is not an instance of type  |
| StringAssert.Contains(_expectedKarenTitle, "Karen"); | Tests whether the specified string contains the specified substring  |
| StringAssert.StartsWith(_expectedKarenTitle, "Karen"); | Tests whether the specified string begins with the specified substring  |
| StringAssert.Matches("(281)388-0388", @"(?d{3})?-? *d{3}-? *-?d{4}");  | Tests whether the specified string matches a regular expression  |
| StringAssert.DoesNotMatch("281)388-0388", @"(?d{3})?-? *d{3}-? *-?d{4}");  | Tests whether the specified string does not match a regular expression |
| CollectionAssert.AreEqual(_expectedInitialClaims, _actualInitialClaims);  | Tests whether the specified collections have the same elements in the same order and quantity.  |
| CollectionAssert.AreNotEqual(_expectedInitialClaims, _actualInitialClaims); | Tests whether the specified collections does not have the same elements or the elements are in a different order and quantity.  |
| CollectionAssert.AreEquivalent(_expectedInitialClaims, _actualInitialClaims); | Tests whether two collections contain the same elements.  |
| CollectionAssert.AreNotEquivalent(_expectedInitialClaims, _actualInitialClaims); | Tests whether two collections contain different elements.  |
| CollectionAssert.AllItemsAreInstancesOfType(_expectedInitialClaims, _actualInitialClaims); | Tests whether all elements in the specified collection are instances of the expected type  |
| CollectionAssert.AllItemsAreNotNull(_expectedInitialClaims); |  Tests whether all items in the specified collection are non-null |
| CollectionAssert.AllItemsAreUnique(_expectedInitialClaims); | Tests whether all items in the specified collection are unique  |
| CollectionAssert.Contains(_actualInitialClaims, dummyClaim9); | Tests whether the specified collection contains the specified element |
| CollectionAssert.DoesNotContain(_actualInitialClaims, dummyClaim9) | Tests whether the specified collection does not contain the specified element  |
| CollectionAssert.IsSubsetOf(_expectedInitialClaims, _actualInitialClaims); | Tests whether one collection is a subset of another collection  |
| CollectionAssert.IsNotSubsetOf(_expectedInitialClaims, _actualInitialClaims); | Tests whether one collection is not a subset of another collection  |
| Assert.ThrowsException<ArgumentNullException>(() => new Regex(null)); | ests whether the code specified by delegate throws exact given exception of type T  |

# Deep compares

For comparing complex objects use the following.

- **NuGet package** [CompareNETObjects](https://www.nuget.org/packages/CompareNETObjects) for deep compares on objects and list of objects.
  - [Project site](https://github.com/GregFinzer/Compare-Net-Objects)
  
- [Unit test basics](https://docs.microsoft.com/en-us/visualstudio/test/unit-test-basics?view=vs-2019)
- [Live Unit Testing](https://docs.microsoft.com/en-us/visualstudio/test/live-unit-testing-intro?view=vs-2019)
- [web load testing](https://docs.microsoft.com/en-us/visualstudio/test/quickstart-create-a-load-test-project?view=vs-2019)

>  **Note** 
Live Unit Testing is only available in Visual Studio Enterprise edition and is supported only in .NET.

## Provides

|Class|Provides   |
| :---         |  :---  |
|TestBase | A place any `initialization code` and `mock-up code` here for unit test methods   |
|TestTraitsAttribute| The ability to setup meaningful [trait attributes](https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2019) for visual separation of unit test categories  |

# Use the MSTest framework in unit tests

The MSTest framework supports unit testing in Visual Studio. Use the classes and members in the Microsoft.VisualStudio.TestTools.UnitTesting namespace when you are coding unit tests. You can also use them when you are refining a unit test that was generated from code.

- [Microsoft documentation](https://docs.microsoft.com/en-us/visualstudio/test/using-microsoft-visualstudio-testtools-unittesting-members-in-unit-tests?view=vs-2019)

# Assertions – Constraint Model

|Assertion |What it does   |
| :---         |  :---  |
| Assert.AreEqual(28, _actualClaim);  | Tests whether the specified values are equal.   |
| Assert.AreNotEqual(28, _actualClaim);  | Tests whether the specified values are unequal. Same as AreEqual for numeric values.  |
| Assert.AreSame(_expectedInitialClaim, _actualInitialClaim); | Tests whether the specified objects both refer to the same object  |
| Assert.AreNotSame(_expectedInitialClaim, _actualInitialClaim); |  Tests whether the specified objects refer to different objects |
| Assert.IsTrue(_isThereEnoughFuel); | Tests whether the specified condition is true  |
| Assert.IsFalse(_isThereEnoughFuel); | Tests whether the specified condition is false  |
| Assert.IsNull(_actualInitialClaim); | Tests whether the specified object is null  |
| Assert.IsNotNull(_actualInitialClaim); | Tests whether the specified object is non-null  |
| Assert.IsInstanceOfType(_actualInitialClaim, typeof(dummyClaimInitialClaim)); | Tests whether the specified object is an instance of the expected type  |
| Assert.IsNotInstanceOfType(_actualInitialClaim, typeof(dummyClaim9InitialClaim)); | Tests whether the specified object is not an instance of type  |
| StringAssert.Contains(_expectedKarenTitle, "Karen"); | Tests whether the specified string contains the specified substring  |
| StringAssert.StartsWith(_expectedKarenTitle, "Karen"); | Tests whether the specified string begins with the specified substring  |
| StringAssert.Matches("(281)388-0388", @"(?d{3})?-? *d{3}-? *-?d{4}");  | Tests whether the specified string matches a regular expression  |
| StringAssert.DoesNotMatch("281)388-0388", @"(?d{3})?-? *d{3}-? *-?d{4}");  | Tests whether the specified string does not match a regular expression |
| CollectionAssert.AreEqual(_expectedInitialClaims, _actualInitialClaims);  | Tests whether the specified collections have the same elements in the same order and quantity.  |
| CollectionAssert.AreNotEqual(_expectedInitialClaims, _actualInitialClaims); | Tests whether the specified collections does not have the same elements or the elements are in a different order and quantity.  |
| CollectionAssert.AreEquivalent(_expectedInitialClaims, _actualInitialClaims); | Tests whether two collections contain the same elements.  |
| CollectionAssert.AreNotEquivalent(_expectedInitialClaims, _actualInitialClaims); | Tests whether two collections contain different elements.  |
| CollectionAssert.AllItemsAreInstancesOfType(_expectedInitialClaims, _actualInitialClaims); | Tests whether all elements in the specified collection are instances of the expected type  |
| CollectionAssert.AllItemsAreNotNull(_expectedInitialClaims); |  Tests whether all items in the specified collection are non-null |
| CollectionAssert.AllItemsAreUnique(_expectedInitialClaims); | Tests whether all items in the specified collection are unique  |
| CollectionAssert.Contains(_actualInitialClaims, dummyClaim9); | Tests whether the specified collection contains the specified element |
| CollectionAssert.DoesNotContain(_actualInitialClaims, dummyClaim9) | Tests whether the specified collection does not contain the specified element  |
| CollectionAssert.IsSubsetOf(_expectedInitialClaims, _actualInitialClaims); | Tests whether one collection is a subset of another collection  |
| CollectionAssert.IsNotSubsetOf(_expectedInitialClaims, _actualInitialClaims); | Tests whether one collection is not a subset of another collection  |
| Assert.ThrowsException<ArgumentNullException>(() => new Regex(null)); | ests whether the code specified by delegate throws exact given exception of type T  |

# Deep compares

For comparing complex objects use the following.

**NuGet packages** 
- [DeepEquals](https://www.nuget.org/packages/DeepEqual/)
- [CompareNETObjects](https://www.nuget.org/packages/CompareNETObjects)

# Simple compares

[Enumerable.SequenceEqual Method](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sequenceequal?view=net-5.0)

