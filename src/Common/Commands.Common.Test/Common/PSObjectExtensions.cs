﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.Common
{
    using System.Management.Automation;

    public static class PSObjectExtensions
    {
        /// <summary>
        /// Gets the value of specific property for the given PSObject.
        /// </summary>
        /// <typeparam name="T">The return value type</typeparam>
        /// <param name="psobject">The powershell obbject</param>
        /// <param name="name">The property name</param>
        /// <returns>The property value</returns>
        public static T GetVariableValue<T>(this PSObject psobject, string name)
        {
            return (T)psobject.Members[name].Value;
        }
    }
}
