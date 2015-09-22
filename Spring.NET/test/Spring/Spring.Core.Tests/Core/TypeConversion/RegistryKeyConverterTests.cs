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
using Microsoft.Win32;
using NUnit.Framework;

#endregion

namespace Spring.Core.TypeConversion
{
    /// <summary>
    /// Unit tests for the RegistryKeyConverter class.
    /// </summary>
    /// <author>Aleksandar Seovic</author>
    [TestFixture]
    public sealed class RegistryKeyConverterTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertFromNullReference()
        {
            RegistryKeyConverter rkc = new RegistryKeyConverter();
            rkc.ConvertFrom(null);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ConvertFromNonSupportedOptionBails()
        {
            RegistryKeyConverter rkc = new RegistryKeyConverter();
            rkc.ConvertFrom(12);
        }

        [Test]
        public void ConvertFrom()
        {
            RegistryKeyConverter rkc = new RegistryKeyConverter();
            Assert.AreEqual(Registry.CurrentUser, rkc.ConvertFrom("HKEY_CURRENT_USER"));
            Assert.AreEqual(Registry.CurrentUser.OpenSubKey("Software").Name,
                            ((RegistryKey) rkc.ConvertFrom(@"HKEY_CURRENT_USER\Software")).Name);
            Assert.AreEqual(Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Microsoft").Name,
                            ((RegistryKey) rkc.ConvertFrom(@"HKEY_CURRENT_USER\Software\Microsoft")).Name);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertFromEmptyString()
        {
            RegistryKeyConverter rkc = new RegistryKeyConverter();
            rkc.ConvertFrom(string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage = @"Registry key [HKEY_CURRENT_USER\sdgsdfgsdfgxadas] does not exist.")]
        public void ConvertFromBadKeyString()
        {
            RegistryKeyConverter rkc = new RegistryKeyConverter();
            rkc.ConvertFrom(@"HKEY_CURRENT_USER\sdgsdfgsdfgxadas\Xyz\Abc");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException), ExpectedMessage="Invalid root hive name [HKEY_ERROR].")]
        public void ConvertFromBadHiveString()
        {
            RegistryKeyConverter rkc = new RegistryKeyConverter();
            rkc.ConvertFrom(@"HKEY_ERROR\sdgsdfgsdfgxadas");
        }

    }
}