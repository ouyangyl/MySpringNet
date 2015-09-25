#region License

/*
 * Copyright � 2002-2011 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

#region Imports

using System;
using NUnit.Framework;

#endregion

namespace Spring.Objects.Factory.Support
{
	/// <summary>
	/// Unit tests for the ReplacedMethodOverride class.
	/// </summary>
	/// <author>Rick Evans</author>
	[TestFixture]
	public sealed class ReplacedMethodOverrideTests
	{
		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void InstantiationWithNullMethodName()
		{
			new ReplacedMethodOverride(null, null);
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void InstantiationWithEmptyMethodName()
		{
			new ReplacedMethodOverride(string.Empty, null);
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void InstantiationWithWhitespacedMethodName()
		{
			new ReplacedMethodOverride("  ", null);
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void InstantiationWithNullMethodReplacerObjectName()
		{
			new ReplacedMethodOverride("foo", null);
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void InstantiationWithEmptyMethodReplacerObjectName()
		{
			new ReplacedMethodOverride("foo", string.Empty);
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void InstantiationWithWhitespacedMethodReplacerObjectName()
		{
			new ReplacedMethodOverride("foo", "  ");
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void AddNullTypeIdentifier()
		{
			new ReplacedMethodOverride("foo", "foo").AddTypeIdentifier(null);
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void AddEmptyTypeIdentifier()
		{
			new ReplacedMethodOverride("foo", "foo").AddTypeIdentifier(string.Empty);
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void AddWhitespacedTypeIdentifier()
		{
			new ReplacedMethodOverride("foo", "foo").AddTypeIdentifier("\n ");
		}

		[Test]
		public void Matches_TotallyDifferentMethodName()
		{
			ReplacedMethodOverride methodOverride = new ReplacedMethodOverride("Execute", "replacer");
			Assert.IsFalse(methodOverride.Matches(typeof (Executor).GetMethod("Administer")));
		}

		[Test]
		public void Matches_MatchingMethodNameNoOverload()
		{
			ReplacedMethodOverride methodOverride = new ReplacedMethodOverride("Administer", "replacer");
			methodOverride.IsOverloaded = false;
			Assert.IsTrue(methodOverride.Matches(typeof (Executor).GetMethod("Administer")));
		}

		[Test]
		public void Matches_MatchingMethodNameWithOverload()
		{
			ReplacedMethodOverride methodOverride = new ReplacedMethodOverride("Execute", "replacer");
			Assert.IsTrue(methodOverride.Matches(typeof (Executor).GetMethod("Execute", new Type[] {})));
		}

		[Test]
		public void Matches_MatchingMethodNameWithOverloadAndTypeIdentifiers()
		{
			ReplacedMethodOverride methodOverride = new ReplacedMethodOverride("Execute", "replacer");
			methodOverride.AddTypeIdentifier(typeof (object).FullName);
			Assert.IsTrue(methodOverride.Matches(typeof (Executor).GetMethod("Execute", new Type[] {typeof (object)})));
		}

		[Test]
		public void Matches_MatchingMethodNameWithOverloadAndBadTypeIdentifiers()
		{
			ReplacedMethodOverride methodOverride = new ReplacedMethodOverride("Execute", "replacer");
			methodOverride.AddTypeIdentifier(GetType().FullName);
			Assert.IsFalse(methodOverride.Matches(typeof (Executor).GetMethod("Execute", new Type[] {typeof (object)})));
		}

		[Test]
		public void Matches_RequiresAllTypeIdentifiers()
		{
			ReplacedMethodOverride methodOverride = new ReplacedMethodOverride("Execute", "replacer");
			methodOverride.AddTypeIdentifier(typeof (object).FullName);
			Assert.IsFalse(methodOverride.Matches(typeof (Executor).GetMethod("Execute",
			                                                                  new Type[] {typeof (object), typeof (object)})));
		}

		[Test]
		public void Matches_AllTypeIdentifiers()
		{
			ReplacedMethodOverride methodOverride = new ReplacedMethodOverride("Execute", "replacer");
			methodOverride.AddTypeIdentifier(typeof (object).FullName);
			methodOverride.AddTypeIdentifier(typeof (object).FullName);
			Assert.IsTrue(methodOverride.Matches(typeof (Executor).GetMethod("Execute",
			                                                                 new Type[] {typeof (object), typeof (object)})));
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void MatchesWithNullMethod()
		{
			ReplacedMethodOverride methodOverride = new ReplacedMethodOverride("Execute", "replacer");
			methodOverride.Matches(null);
		}

		[Test]
		public void ToStringWorks()
		{
			ReplacedMethodOverride methodOverride = new ReplacedMethodOverride("Execute", "replacer");
			Assert.AreEqual(typeof(ReplacedMethodOverride).Name + " for method 'Execute'; will call object 'replacer'.", methodOverride.ToString());
		}

		private sealed class Executor
		{
			public void Administer()
			{
			}

			public void Execute()
			{
			}

			public void Execute(object sender)
			{
			}

			public void Execute(object sender, object context)
			{
			}
		}
	}
}