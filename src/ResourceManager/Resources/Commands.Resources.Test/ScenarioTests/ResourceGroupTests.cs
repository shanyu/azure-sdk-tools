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

using Microsoft.Azure.Commands.Resources.Test.ScenarioTests;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.ResourceManagerTests
{
    public class ResourceGroupTests : ResourcesTestsBase
    {
        [Fact]
        public void TestCreatesNewSimpleResourceGroup()
        {
            RunPowerShellTest("Test-CreatesNewSimpleResourceGroup");
        }

        [Fact]
        public void TestUpdatesExistingResourceGroup()
        {
            RunPowerShellTest("Test-UpdatesExistingResourceGroup");
        }

        [Fact]
        public void TestCreatesAndRemoveResourceGroupViaPiping()
        {
            RunPowerShellTest("Test-CreatesAndRemoveResourceGroupViaPiping");
        }

        [Fact]
        public void TestGetNonExistingResourceGroup()
        {
            RunPowerShellTest("Test-GetNonExistingResourceGroup");
        }

        [Fact]
        public void TestNewResourceGroupInNonExistingLocation()
        {
            RunPowerShellTest("Test-NewResourceGroupInNonExistingLocation");
        }

        [Fact]
        public void TestRemoveNonExistingResourceGroup()
        {
            RunPowerShellTest("Test-RemoveNonExistingResourceGroup");
        }

        [Fact]
        public void TestAzureTagsEndToEnd()
        {
            RunPowerShellTest("Test-AzureTagsEndToEnd");
        }
    }
}
